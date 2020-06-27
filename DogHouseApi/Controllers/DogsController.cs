﻿using System.Linq;
using DogHouseApi.Entities;
using DogHouseApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DogHouseApi.Controllers
{

    [Route("/api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class DogsController : ControllerBase
    {

        public IDogEntityManager entityManager;

        public DogsController(IDogEntityManager entityManager)
        {
            this.entityManager = entityManager;
        }

        // POST /api/v1/dogs
        [HttpPost]
        public ActionResult Post([FromBody] DogDto dogDto, ApiVersion apiVersion)
        {
            if (dogDto == null)
            {
                return BadRequest();
            }

            DogEntity dogEntity = entityManager.Add(DogEntity.FromDto(dogDto));
            entityManager.Save();

            return CreatedAtRoute(
                nameof(GetDog),
                new { id = dogEntity.Id, version = apiVersion.ToString() },
                dogEntity.ToDto());
        }

        // GET /api/v1/dogs
        [HttpGet]
        public ActionResult Get(ApiVersion apiVersion)
            => Ok(entityManager.GetAllDogs().Select(x => x.ToDto()));

        // GET /api/v1/dogs/1
        [HttpGet("{id}", Name = nameof(GetDog))]
        public ActionResult GetDog(int id, ApiVersion apiVersion)
        {
            DogEntity dogEntity = entityManager.GetDog(id);

            if (dogEntity != null)
            {
                return Ok(dogEntity.ToDto());
            }

            return NotFound();
        }

        // PUT /api/v1/dogs/1
        [HttpPut("{id}")]
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
            existingDog.Picture = dogDto.Picture;

            entityManager.Update(id, existingDog);
            entityManager.Save();

            return CreatedAtRoute(nameof(GetDog),
                new
                {
                    id,
                    version = apiVersion.ToString()
                }, existingDog.ToDto());
        }

        // DELETE /api/v1/dogs
        [HttpDelete()]
        public ActionResult Delete(ApiVersion apiVersion)
        {
            entityManager.DeleteAllDogs();
            entityManager.Save();
            return NoContent();
        }

        // DELETE /api/v1/dogs/1
        [HttpDelete("{id}")]
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