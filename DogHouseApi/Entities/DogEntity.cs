using System.ComponentModel.DataAnnotations;
using DogHouseApi.Controllers;
using DogHouseApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DogHouseApi.Entities
{
    public class DogEntity
    {

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Breed { get; set; }

        public ImageEntity Image { get; set; }

        // TODO move to mapping class
        internal static DogEntity FromDto(DogDto dogDto)
        {
            var dogEntity = new DogEntity
            {
                Name = dogDto.Name,
                Breed = dogDto.Breed,
            };

            if (!string.IsNullOrEmpty(dogDto.Picture))
            {
                dogEntity.Image = ImageEntity.FromBase64String(dogDto.Picture);
            }

            return dogEntity;
        }

        // TODO move to mapping class
        internal DogDto ToDto(IUrlHelper urlHelper, ApiVersion apiVersion)
        {
            var dogDto = new DogDto
            {
                Name = this.Name,
                Breed = this.Breed,
            };

            if (Image != null)
            {
                dogDto.Picture = urlHelper.Link(nameof(ImagesController.GetImage),
                    new
                    {
                        id = Image.Id,
                        extension = Image.Extension,
                        version = apiVersion.ToString()
                    });
            }

            return dogDto;
        }
    }
}
