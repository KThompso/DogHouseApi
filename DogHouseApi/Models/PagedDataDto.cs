using System;
using Newtonsoft.Json;

namespace DogHouseApi.Models
{
    public class PageDataDto
    {

        public int Number { get; private set; }

        public int Size { get; private set; }

        [JsonIgnore]
        public int PerPage { get; private set; }

        public int TotalPages { get; private set; }

        public int TotalElements { get; private set; }

        public PageDataDto(int number, int size, int perPage, int totalElements)
        {
            Number = number;
            Size = size;
            PerPage = perPage;
            TotalElements = totalElements;
            TotalPages = Math.Max((totalElements + perPage - 1) / perPage, 1);
        }

    }
}
