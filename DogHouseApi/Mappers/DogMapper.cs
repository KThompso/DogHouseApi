using DogHouseApi.Controllers;
using DogHouseApi.Entities;
using DogHouseApi.Extensions;
using DogHouseApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DogHouseApi.Mappers
{
    public class DogMapper : IDogMapper
    {
        public DogDto ConvertToDto(
            DogEntity dogEntity,
            IUrlHelper urlHelper,
            ApiVersion apiVersion)
        {
            var dogDto = new DogDto
            {
                Id = dogEntity.Id,
                Name = dogEntity.Name,
                Breed = dogEntity.Breed,
            };

            if (dogEntity.Image != null)
            {
                dogDto.Image = urlHelper?.Link(
                    nameof(ImagesController.GetImage),
                    new
                    {
                        id = dogEntity.Image.Id,
                        extension = dogEntity.Image.Extension,
                        version = apiVersion.ToString()
                    });
            }

            return dogDto.WithLinks(urlHelper, apiVersion);
        }

        public DogEntity ConvertToEntity(DogDto dogDto) =>
            new DogEntity
            {
                Name = dogDto.Name,
                Breed = dogDto.Breed,
                Image = dogDto?.Image.ToImageEntity()
            };
    }
}
