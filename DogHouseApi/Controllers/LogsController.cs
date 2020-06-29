using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using DogHouseApi.Serilog;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog.Events;

namespace DogHouseApi.Controllers
{
    [Route("/api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class LogsController : ControllerBase
    {

        ILogger<LogsController> logger;

        public LogsController(ILogger<LogsController> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(IEnumerable<LogEvent>), StatusCodes.Status200OK)]
        public ActionResult Get(
            [FromQuery(Name = "start")] DateTimeOffset start,
            [FromQuery(Name = "end")] DateTimeOffset end) =>
            Ok(MemorySink
                .GetInstance()
                .GetLogs(start, end));

    }
}
