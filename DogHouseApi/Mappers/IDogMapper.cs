using DogHouseApi.Entities;
using DogHouseApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DogHouseApi.Mappers
{
    public interface IDogMapper
    {

        public abstract DogDto ConvertToDto(
            DogEntity dogEntity,
            IUrlHelper urlHelper,
            ApiVersion apiVersion);

        public abstract DogEntity ConvertToEntity(DogDto dogDto);

    }
}
