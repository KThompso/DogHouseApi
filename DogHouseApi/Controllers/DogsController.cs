using System;
using System.Linq;
using DogHouseApi.Entities;
using DogHouseApi.Exceptions;
using DogHouseApi.Extensions;
using DogHouseApi.Mappers;
using DogHouseApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DogHouseApi.Controllers
{

    [Route("/api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    [Produces("application/json")]
    public class DogsController : ControllerBase
    {

        private readonly IDogEntityManager _entityManager;
        private readonly IDogMapper _dogMapper;

        public DogsController(
            IDogEntityManager entityManager,
            IDogMapper dogMapper)
        {
            _entityManager = entityManager;
            _dogMapper = dogMapper;
        }

        // POST /api/v1/dogs
        [HttpPost(Name = nameof(PostDog))]
        [ProducesResponseType(typeof(DogDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
        [SwaggerOperation(
            Summary = "Creates a new dog",
            OperationId = "CreateDog",
            Tags = new[] { "Dogs" }
        )]
        public ActionResult PostDog(
            [FromBody] DogDto dogDto,
            ApiVersion apiVersion)
        {
            if (dogDto == null)
            {
                throw new BadRequestException(ErrorMessage.INVALID_REQUEST);
            }

            if (dogDto.ImageData != null && dogDto.ImageUrl != null)
            {
                throw new BadRequestException(ErrorMessage.TOO_MANY_IMAGES);
            }

            DogEntity dogEntity;

            try
            {
                dogEntity = _dogMapper.ConvertToEntity(dogDto);
            }
            catch (System.FormatException)
            {
                throw new BadRequestException(ErrorMessage.INVALID_IMAGE);
            }

            dogEntity = _entityManager.AddDog(dogEntity);
            _entityManager.Save();

            return CreatedAtRoute(
                nameof(GetDog),
                new { id = dogEntity.Id, version = apiVersion.ToString() },
                _dogMapper.ConvertToDto(dogEntity, Url, apiVersion));
        }

        // GET /api/v1/dogs
        [HttpGet(Name = nameof(GetDogs))]
        [ProducesResponseType(typeof(PagedDto<DogDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Gets a list of dogs",
            OperationId = "GetDogs",
            Tags = new[] { "Dogs" }
        )]
        public ActionResult GetDogs(
            ApiVersion apiVersion,
            [FromQuery] int page = 1,
            [FromQuery] int perPage = 10)
        {
            perPage = Math.Max(perPage, 1);
            page = Math.Max(page, 1);

            var data =
                _entityManager.GetAllDogs()
                .Skip((page - 1) * perPage)
                .Take(perPage)
                .Select(dog => _dogMapper.ConvertToDto(dog, Url, apiVersion));

            var paginationData = new PageDataDto(
                page,
                data.Count(),
                perPage,
                _entityManager.GetDogCount());

            PagedDto<DogDto> result = new PagedDto<DogDto>(paginationData, data);

            return Ok(result.WithLinks<DogDto>(Url, apiVersion, nameof(GetDogs)));
        }

        // GET /api/v1/dogs/1
        [HttpGet("{id}", Name = nameof(GetDog))]
        [ProducesResponseType(typeof(DogDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
        [SwaggerOperation(
            Summary = "Gets a single dog",
            OperationId = "GetDog",
            Tags = new[] { "Dogs" }
        )]
        public ActionResult GetDog(int id, ApiVersion apiVersion)
        {
            DogEntity dogEntity = _entityManager.GetDog(id);

            if (dogEntity == null)
            {
                throw new NotFoundException();
            }

            return Ok(_dogMapper.ConvertToDto(dogEntity, Url, apiVersion));
        }

        // PUT /api/v1/dogs/1
        [HttpPut("{id}", Name = nameof(PutDog))]
        [ProducesResponseType(typeof(DogDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
        [SwaggerOperation(
            Summary = "Updates a dog",
            OperationId = "PutDog",
            Tags = new[] { "Dogs" }
        )]
        public IActionResult PutDog(
            int id,
            [FromBody] DogDto dogDto,
            ApiVersion apiVersion)
        {
            if (dogDto == null)
            {
                throw new BadRequestException(ErrorMessage.INVALID_REQUEST);
            }

            if (dogDto.ImageData != null && dogDto.ImageUrl != null)
            {
                throw new BadRequestException(ErrorMessage.TOO_MANY_IMAGES);
            }

            DogEntity existingDog = _entityManager.GetDog(id);

            if (existingDog == null)
            {
                throw new NotFoundException();
            }

            try
            {
                existingDog.UpdateFromDto(dogDto);
            }
            catch (System.FormatException)
            {
                throw new BadRequestException(ErrorMessage.INVALID_IMAGE);
            }

            _entityManager.UpdateDog(id, existingDog);
            _entityManager.Save();

            return CreatedAtRoute(
                nameof(GetDog),
                new { id, version = apiVersion.ToString() },
                _dogMapper.ConvertToDto(existingDog, Url, apiVersion));
        }

        // DELETE /api/v1/dogs
        [HttpDelete(Name = nameof(DeleteAllDogs))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [SwaggerOperation(
            Summary = "Deletes all dogs",
            OperationId = "DeleteAllDogs",
            Tags = new[] { "Dogs" }
        )]
        public ActionResult DeleteAllDogs(ApiVersion apiVersion)
        {
            _entityManager.DeleteAllDogs();
            _entityManager.Save();
            return NoContent();
        }

        // DELETE /api/v1/dogs/1
        [HttpDelete("{id}", Name = nameof(DeleteDog))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
        [SwaggerOperation(
            Summary = "Deletes a single dog",
            OperationId = "DeleteDog",
            Tags = new[] { "Dogs" }
        )]
        public ActionResult DeleteDog(int id, ApiVersion apiVersion)
        {
            DogEntity dogEntity = _entityManager.GetDog(id);

            if (dogEntity == null)
            {
                throw new NotFoundException();
            }

            _entityManager.DeleteDog(id);
            _entityManager.Save();

            return NoContent();
        }

    }
}
