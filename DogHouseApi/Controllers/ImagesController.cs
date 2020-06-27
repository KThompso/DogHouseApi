using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;

namespace DogHouseApi.Controllers
{

    [Route("/api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ImagesController : ControllerBase
    {

        public IDogEntityManager entityManager;

        public ImagesController(IDogEntityManager entityManager)
        {
            this.entityManager = entityManager;
        }

        // GET /api/v{version}/images/1.jpeg
        [HttpGet("{id:int}.{extension}", Name = nameof(GetImage))]
        [Produces(MediaTypeNames.Image.Jpeg, MediaTypeNames.Image.Gif, MediaTypeNames.Image.Tiff, "image/png")]
        public ActionResult GetImage(int id)
        {
            var image = entityManager.GetImage(id);

            if (image == null)
            {
                return NotFound();
            }

            return File(image.Data, image.MimeType);
        }

    }
}
