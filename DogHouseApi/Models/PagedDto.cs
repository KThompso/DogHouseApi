using System.Collections.Generic;

namespace DogHouseApi.Models
{
    public class PagedDto<T>
    {

        public IEnumerable<LinkDto> Links { get; set; }

        public PageDataDto Page { get; private set; }

        public IEnumerable<T> Data { get; private set; }

        public PagedDto(PageDataDto pagingData, IEnumerable<T> data)
        {
            Data = data;
            Page = pagingData;
        }

    }
}
