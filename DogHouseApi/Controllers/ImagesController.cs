using System.Net.Mime;
using DogHouseApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DogHouseApi.Controllers
{

    [Route("/api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ImagesController : ControllerBase
    {

        private readonly IDogEntityManager _entityManager;

        public ImagesController(IDogEntityManager entityManager)
        {
            _entityManager = entityManager;
        }

        // GET /api/v{version}/images/1.jpeg
        [HttpGet("{id:int}.{extension}", Name = nameof(GetImage))]
        [Produces(MediaTypeNames.Image.Jpeg,
                  MediaTypeNames.Image.Gif,
                  MediaTypeNames.Image.Tiff,
                  "image/png")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public ActionResult GetImage(int id)
        {
            ImageEntity image = _entityManager.GetImage(id);

            if (image == null)
            {
                return NotFound();
            }

            string link = Url.Link(
                nameof(GetImage),
                new { id = image.Id, extension = image.Extension });

            Response.Headers.Add("Link", $"<{link}>; rel=\"self\"");

            return File(image.Data, image.MimeType);
        }

    }
}
