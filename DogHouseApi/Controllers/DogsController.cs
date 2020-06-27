using System.Collections.Generic;
using DogHouseApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DogHouseApi.Controllers
{

    [Route("/api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class DogsController : ControllerBase
    {

        private static int dogCount = 0;
        private static IDictionary<int, DogDto> dogs = new Dictionary<int, DogDto>();

        // POST /api/v1/dogs
        [HttpPost]
        public ActionResult Post([FromBody] DogDto dogDto, ApiVersion apiVersion)
        {
            dogs.Add(++dogCount, dogDto);
            return CreatedAtRoute(new { id = dogCount, version = apiVersion.ToString() }, dogDto);
        }

        // GET /api/v1/dogs
        [HttpGet]
        public ActionResult Get(ApiVersion apiVersion) => Ok(dogs.Values);

        // GET /api/v1/dogs/1
        [HttpGet("{id}")]
        public ActionResult Get(int id, ApiVersion apiVersion)
        {
            if (dogs.ContainsKey(id))
            {
                return Ok(dogs[id]);
            }

            return NotFound();
        }

        // DELETE /api/v1/dogs
        [HttpDelete()]
        public ActionResult Delete(ApiVersion apiVersion)
        {
            dogs.Clear();
            return NoContent();
        }

        // DELETE /api/v1/dogs/1
        [HttpDelete("{id}")]
        public ActionResult Delete(int id, ApiVersion apiVersion)
        {
            if (!dogs.ContainsKey(id))
            {
                return NotFound();
            }

            dogs.Remove(id);
            return NoContent();
        }

    }
}
