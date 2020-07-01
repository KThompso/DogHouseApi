using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DogHouseApi.Models
{
    public class LogListDto
    {

        [JsonIgnore]
        public DateTimeOffset start;

        [JsonIgnore]
        public DateTimeOffset end;

        public IEnumerable<LinkDto> Links { get; set; }

        public IEnumerable<LogDto> Logs { get; set; }

    }
}
