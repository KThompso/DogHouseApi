using System.Linq;
using DogHouseApi.Entities;
using DogHouseApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DogHouseApi.Controllers
{

    [Route("/api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    [Produces("application/json")]
    public class DogsController : ControllerBase
    {

        public IDogEntityManager entityManager;

        public DogsController(IDogEntityManager entityManager)
        {
            this.entityManager = entityManager;
        }

        // POST /api/v1/dogs
        [HttpPost]
        [ProducesResponseType(typeof(DogDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Post([FromBody] DogDto dogDto, ApiVersion apiVersion)
        {
            if (dogDto == null)
            {
                return BadRequest();
            }

            DogEntity dogEntity;

            try
            {
                dogEntity = DogEntity.FromDto(dogDto);
            }
            catch (System.FormatException)
            {
                return BadRequest(ErrorMessages.INVALID_IMAGE);
            }

            dogEntity = entityManager.Add(dogEntity);
            entityManager.Save();

            return CreatedAtRoute(
                nameof(GetDog),
                new { id = dogEntity.Id, version = apiVersion.ToString() },
                dogEntity.ToDto(Url, apiVersion));
        }

        // GET /api/v1/dogs
        [HttpGet]
        [ProducesResponseType(typeof(IQueryable<DogDto>), StatusCodes.Status200OK)]
        public ActionResult Get(ApiVersion apiVersion)
            => Ok(entityManager
            .GetAllDogs()
            .Select(x => x.ToDto(Url, apiVersion)));

        // GET /api/v1/dogs/1
        [HttpGet("{id}", Name = nameof(GetDog))]
        [ProducesResponseType(typeof(DogDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetDog(int id, ApiVersion apiVersion)
        {
            DogEntity dogEntity = entityManager.GetDog(id);

            if (dogEntity != null)
            {
                return Ok(dogEntity.ToDto(Url, apiVersion));
            }

            return NotFound();
        }

        // PUT /api/v1/dogs/1
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(DogDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put(int id, [FromBody] DogDto dogDto, ApiVersion apiVersion)
        {
            if (dogDto == null)
            {
                return BadRequest();
            }

            var existingDog = entityManager.GetDog(id);

            if (existingDog == null)
            {
                return NotFound();
            }

            // TODO move to mapping class
            existingDog.Breed = dogDto.Breed;
            existingDog.Name = dogDto.Name;

            try
            {
                existingDog.Image = dogDto.Picture == null ? null : ImageEntity.FromBase64String(dogDto.Picture);
            }
            catch (System.FormatException) {
                return BadRequest(ErrorMessages.INVALID_IMAGE);
            }

            entityManager.Update(id, existingDog);
            entityManager.Save();

            return CreatedAtRoute(nameof(GetDog),
                new
                {
                    id,
                    version = apiVersion.ToString()
                }, existingDog.ToDto(Url, apiVersion));
        }

        // DELETE /api/v1/dogs
        [HttpDelete()]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult Delete(ApiVersion apiVersion)
        {
            entityManager.DeleteAllDogs();
            entityManager.Save();
            return NoContent();
        }

        // DELETE /api/v1/dogs/1
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(int id, ApiVersion apiVersion)
        {
            DogEntity dogEntity = entityManager.GetDog(id);

            if (dogEntity == null)
            {
                return NotFound();
            }

            entityManager.DeleteDog(id);
            entityManager.Save();

            return NoContent();
        }

    }
}
