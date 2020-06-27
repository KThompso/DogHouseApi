using System.Collections.Generic;
using DogHouseApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DogHouseApi.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class DogsController : ControllerBase
    {

        private static int dogCount = 0;
        private static IDictionary<int, DogDto> dogs = new Dictionary<int, DogDto>();

        // POST /dogs
        [HttpPost]
        public ActionResult Post([FromBody] DogDto dogDto)
        {
            dogs.Add(++dogCount, dogDto);
            return CreatedAtRoute(new { id = dogCount }, dogDto);
        }

        // GET /dogs/1
        [HttpGet]
        public ActionResult Get() => Ok(dogs.Values);

        // GET /dogs
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            if (dogs.ContainsKey(id))
            {
                return Ok(dogs[id]);
            }

            return NotFound();
        }

    }
}
