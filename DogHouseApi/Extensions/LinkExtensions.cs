using System.Collections.Generic;
using DogHouseApi.Controllers;
using DogHouseApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DogHouseApi.Extensions
{
    public static class DogLinkExtensions
    {
        public static DogDto WithLinks(
            this DogDto dogDto,
            IUrlHelper urlHelper,
            ApiVersion apiVersion)
        {
            dogDto.Links = new List<LinkDto>
            {
                new LinkDto(
                    urlHelper?.Link(
                        nameof(DogsController.GetDog),
                        new { id = dogDto.Id, version = apiVersion.ToString() }),
                    "self",
                    System.Net.Http.HttpMethod.Get.Method),
                new LinkDto(
                    urlHelper?.Link(
                        nameof(DogsController.DeleteDog),
                        new { id = dogDto.Id, version = apiVersion.ToString() }),
                    "delete_dog",
                    System.Net.Http.HttpMethod.Delete.Method),
                new LinkDto(
                    urlHelper?.Link(
                        nameof(DogsController.PutDog),
                        new { id = dogDto.Id, version = apiVersion.ToString() }),
                    "update_dog",
                    System.Net.Http.HttpMethod.Put.Method)
            };

            return dogDto;
        }
    }

    public static class PagedLinkExtensions
    {
        public static PagedDto<T> WithLinks<T>(
            this PagedDto<T> dto,
            IUrlHelper urlHelper,
            ApiVersion apiVersion,
            string routeName)
        {
            IList<LinkDto> links = new List<LinkDto>
            {
                new LinkDto(
                    urlHelper?.Link(
                        routeName,
                        new {
                            page = dto.Page.Number,
                            perPage = dto.Page.PerPage,
                            version = apiVersion.ToString() }),
                    "self",
                    System.Net.Http.HttpMethod.Get.Method),
                new LinkDto(
                    urlHelper?.Link(
                        routeName,
                        new {
                            page = 1,
                            perPage = dto.Page.PerPage,
                            version = apiVersion.ToString() }),
                    "first",
                    System.Net.Http.HttpMethod.Get.Method)
            };

            if (dto.Page.Number > 1)
            {
                links.Add(new LinkDto(
                    urlHelper?.Link(
                        routeName,
                        new
                        {
                            page = dto.Page.Number - 1,
                            perPage = dto.Page.PerPage,
                            version = apiVersion.ToString()
                        }),
                    "prev",
                    System.Net.Http.HttpMethod.Get.Method));
            }

            if (dto.Page.Number < dto.Page.TotalPages)
            {
                links.Add(new LinkDto(
                    urlHelper?.Link(
                        routeName,
                        new
                        {
                            page = dto.Page.Number + 1,
                            perPage = dto.Page.PerPage,
                            version = apiVersion.ToString()
                        }),
                    "next",
                    System.Net.Http.HttpMethod.Get.Method));
            }

            links.Add(new LinkDto(
                urlHelper?.Link(
                    routeName,
                    new
                    {
                        page = dto.Page.TotalPages,
                        perPage = dto.Page.PerPage,
                        version = apiVersion.ToString()
                    }),
                "last",
                System.Net.Http.HttpMethod.Get.Method));

            dto.Links = links;

            return dto;
        }
    }

    public static class LogsLinkExtensions
    {
        public static LogListDto WithLinks(
            this LogListDto dto,
            IUrlHelper urlHelper,
            ApiVersion apiVersion)
        {

            dto.Links = new List<LinkDto>
            {
                new LinkDto(
                    urlHelper.Link(nameof(LogsController.GetLogs),
                    new
                    {
                        dto.start,
                        dto.end,
                        version = apiVersion.ToString()
                    }),
                    "self",
                    System.Net.Http.HttpMethod.Get.Method)
            };

            return dto;
        }
    }
}
