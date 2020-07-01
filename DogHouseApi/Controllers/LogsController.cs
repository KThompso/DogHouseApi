using System;
using System.Linq;
using System.Net.Mime;
using DogHouseApi.Extensions;
using DogHouseApi.Logging;
using DogHouseApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;

namespace DogHouseApi.Controllers
{
    [Route("/api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        readonly ILogger<LogsController> logger;

        public LogsController(ILogger<LogsController> logger)
        {
            this.logger = logger;
        }

        [HttpGet(Name = nameof(GetLogs))]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(LogListDto), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Gets some logs",
            OperationId = "GetLogs",
            Tags = new[] { "Logs" }
        )]
        public ActionResult GetLogs(
            [FromQuery(Name = "start")] DateTimeOffset start,
            [FromQuery(Name = "end")] DateTimeOffset end,
            ApiVersion apiVersion)
        {

            LogListDto logsDto = new LogListDto
            {
                start = start,
                end = end,
                Logs = MemorySink
                           .GetInstance()
                           .GetLogs(start, end)
                           .Select(logEvent =>
                               new LogDto
                               {
                                   Timestamp = logEvent.Timestamp,
                                   Message = logEvent.RenderMessage(),
                                   Level = logEvent.Level.ToString()
                               })
                           .OrderBy(logDto => logDto.Timestamp),
            };

            return Ok(logsDto.WithLinks(Url, apiVersion));
        }

    }
}
