using System.ComponentModel.DataAnnotations;
using DogHouseApi.Models;

namespace DogHouseApi.Entities
{
    public class DogEntity
    {

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Breed { get; set; }

        public string Picture { get; set; }

        // TODO move to mapping class
        internal static DogEntity FromDto(DogDto dogDto)
        {
            return new DogEntity
            {
                Name = dogDto.Name,
                Breed = dogDto.Breed,
                Picture = dogDto.Picture
            };
        }

        // TODO move to mapping class
        internal DogDto ToDto()
        {
            return new DogDto
            {
                Name = this.Name,
                Breed = this.Breed,
                Picture = this.Picture
            };
        }
    }
}
