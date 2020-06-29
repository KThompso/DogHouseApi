using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace DogHouseApi.Models
{

    public class DogDto
    {

        public IEnumerable<LinkDto> Links { get; set; }

        [JsonIgnore]
        public int? Id { get; set; }

        public DogBreed Breed { get; set; }

        [Required]
        public string Name { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Image { get; set; }

    }
}
