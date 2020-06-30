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

            if (dogEntity.ImageData != null)
            {
                dogDto.ImageUrl = urlHelper?.Link(
                    nameof(ImagesController.GetImage),
                    new
                    {
                        id = dogEntity.ImageData.Id,
                        extension = dogEntity.ImageData.Extension,
                        version = apiVersion.ToString()
                    });
            } else
            {
                dogDto.ImageUrl = dogEntity.ImageUrl;
            }

            return dogDto.WithLinks(urlHelper, apiVersion);
        }

        public DogEntity ConvertToEntity(DogDto dogDto) =>
            new DogEntity
            {
                Name = dogDto.Name,
                Breed = dogDto.Breed,
                ImageData = dogDto.ImageData?.ToImageEntity(),
                ImageUrl = dogDto.ImageUrl,
            };
    }
}
