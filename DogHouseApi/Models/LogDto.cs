using System;
namespace DogHouseApi.Models
{
    public class LogDto
    {

        public string Message { get; set; }

        public DateTimeOffset Timestamp { get; set; }

        public string Level { get; set; }

    }
}
