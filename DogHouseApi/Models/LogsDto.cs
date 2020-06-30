using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Serilog.Events;

namespace DogHouseApi.Models
{
    public class LogsDto
    {

        [JsonIgnore]
        public DateTimeOffset start;

        [JsonIgnore]
        public DateTimeOffset end;

        public IEnumerable<LinkDto> Links { get; set; }

        public IOrderedEnumerable<LogEvent> Logs { get; set; }

    }
}
