using System.Net;
using DogHouseApi.Exceptions;
using DogHouseApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DogHouseApi.Filters
{
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order { get; set; } = int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {

            switch (context.Exception)
            {
                case null:
                    return;
                case BadRequestException bre:
                    context.Result = new BadRequestObjectResult(
                    new ErrorDto
                    {
                        StatusCode = (int)HttpStatusCode.BadRequest,
                        Message = bre.Message
                    });
                    break;
                case NotFoundException _:
                    context.Result = new NotFoundObjectResult(
                    new ErrorDto
                    {
                        StatusCode = (int)HttpStatusCode.NotFound,
                        Message = ErrorMessage.NOT_FOUND
                    });
                    break;
                default:
                    context.Result = context.Result = new ObjectResult(
                    new ErrorDto
                    {
                        StatusCode = (int)HttpStatusCode.BadRequest,
                        Message = ErrorMessage.INTERNAL_SERVER_ERROR
                    })
                    {
                        StatusCode = (int)HttpStatusCode.InternalServerError,
                    };
                    break;
            }

            context.ExceptionHandled = true;

        }
    }
}
