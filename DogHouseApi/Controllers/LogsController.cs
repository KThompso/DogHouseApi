using System;
using System.Collections.Generic;
using System.Net.Mime;
using DogHouseApi.Extensions;
using DogHouseApi.Logging;
using DogHouseApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog.Events;
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
        [ProducesResponseType(typeof(IEnumerable<LogEvent>), StatusCodes.Status200OK)]
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

            LogsDto logsDto = new LogsDto
            {
                start = start,
                end = end,
                Logs = MemorySink.GetInstance().GetLogs(start, end)
            };

            return Ok(logsDto.WithLinks(Url, apiVersion));
        }

    }
}
