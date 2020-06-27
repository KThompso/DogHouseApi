using System.ComponentModel.DataAnnotations;

namespace DogHouseApi.Models
{
    public class DogDto
    {

        public string Breed { get; set; }

        [Required]
        public string Name { get; set; }

        public string Picture { get; set; }

    }
}
