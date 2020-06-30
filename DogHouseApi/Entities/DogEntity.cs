using System.ComponentModel.DataAnnotations;
using DogHouseApi.Extensions;
using DogHouseApi.Models;

namespace DogHouseApi.Entities
{
    public class DogEntity
    {

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public DogBreed Breed { get; set; }

        public ImageEntity ImageData { get; set; }

        public string ImageUrl { get; set; }

        public void UpdateFromDto(DogDto dogDto)
        {
            Breed = dogDto.Breed;
            Name = dogDto.Name;
            ImageData = dogDto.ImageData?.ToImageEntity();
            ImageUrl = dogDto.ImageData == null ? dogDto.ImageUrl : null;
        }
    }
}
