using System.ComponentModel.DataAnnotations;

namespace DogHouseApi.Models
{

    public class DogDto
    {

        public DogBreed Breed { get; set; }

        [Required]
        public string Name { get; set; }

        public string Picture { get; set; }

    }
}
