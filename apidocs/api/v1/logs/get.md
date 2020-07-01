# List Logs

List log events between two date times.

**URL** : `/api/v1/logs`

**URL Parameters** :

- `start=[datetime]` : Get only logs on or after this time.
- `end=[datetime]` : Get only logs on or before this time.

**Method** : `GET`

## Examples

Get all logs.

`$ curl "https://doghouse.thompsonbass.io/api/v1/logs"`

Get logs between 6AM on June 30 and 3 PM on July 1, 2020.

`$ curl "https://doghouse.thompsonbass.io/api/v1/logs?start=2020-06-30T06:00:00&end=2020-07-01T15:00:00"`

## Success Response

**Code** : `200 OK`

**Content examples**

```json
{
  "links": [
    {
      "href": "https://doghouse.thompsonbass.io/api/v1/logs?start=01%2F01%2F0001%2000%3A00%3A00%20%2B00%3A00&end=01%2F01%2F0001%2000%3A00%3A00%20%2B00%3A00",
      "rel": "self",
      "method": "GET"
    }
  ],
  "logs": [
    {
      "message": "Starting up web server",
      "timestamp": "2020-07-01T17:27:03.050377-04:00",
      "level": "Information"
    },
    {
      "message": "Now listening on: \"https://doghouse.thompsonbass.io\"",
      "timestamp": "2020-07-01T17:27:04.710626-04:00",
      "level": "Information"
    },
    {
      "message": "Application started. Press Ctrl+C to shut down.",
      "timestamp": "2020-07-01T17:27:04.713257-04:00",
      "level": "Information"
    },
    {
      "message": "Hosting environment: \"Development\"",
      "timestamp": "2020-07-01T17:27:04.713314-04:00",
      "level": "Information"
    },
    {
      "message": "Request starting HTTP/1.1 GET https://doghouse.thompsonbass.io/swagger  ",
      "timestamp": "2020-07-01T17:27:04.861692-04:00",
      "level": "Information"
    },
    {
      "message": "Request finished in 54.3199ms 301 ",
      "timestamp": "2020-07-01T17:27:04.913591-04:00",
      "level": "Information"
    },
    {
      "message": "Request starting HTTP/1.1 GET https://doghouse.thompsonbass.io/swagger/index.html  ",
      "timestamp": "2020-07-01T17:27:04.935493-04:00",
      "level": "Information"
    },
    {
      "message": "Request finished in 30.5368ms 200 text/html;charset=utf-8",
      "timestamp": "2020-07-01T17:27:04.966055-04:00",
      "level": "Information"
    },
    {
      "message": "Request starting HTTP/1.1 GET https://doghouse.thompsonbass.io/swagger/index.html  ",
      "timestamp": "2020-07-01T17:27:06.082189-04:00",
      "level": "Information"
    },
    {
      "message": "Request finished in 2.5992ms 200 text/html;charset=utf-8",
      "timestamp": "2020-07-01T17:27:06.084657-04:00",
      "level": "Information"
    },
    {
      "message": "Request starting HTTP/1.1 GET https://doghouse.thompsonbass.io/swagger/swagger-ui.css  ",
      "timestamp": "2020-07-01T17:27:06.132031-04:00",
      "level": "Information"
    },
    {
      "message": "Sending file. Request path: '\"/swagger-ui.css\"'. Physical path: '\"N/A\"'",
      "timestamp": "2020-07-01T17:27:06.171638-04:00",
      "level": "Information"
    },
    {
      "message": "Request finished in 39.701ms 200 text/css",
      "timestamp": "2020-07-01T17:27:06.171721-04:00",
      "level": "Information"
    },
    {
      "message": "Request starting HTTP/1.1 GET https://doghouse.thompsonbass.io/swagger/swagger-ui-bundle.js  ",
      "timestamp": "2020-07-01T17:27:06.247649-04:00",
      "level": "Information"
    },
    {
      "message": "Request starting HTTP/1.1 GET https://doghouse.thompsonbass.io/swagger/swagger-ui-standalone-preset.js  ",
      "timestamp": "2020-07-01T17:27:06.433085-04:00",
      "level": "Information"
    },
    {
      "message": "Sending file. Request path: '\"/swagger-ui-standalone-preset.js\"'. Physical path: '\"N/A\"'",
      "timestamp": "2020-07-01T17:27:06.470865-04:00",
      "level": "Information"
    },
    {
      "message": "Request finished in 37.9524ms 200 application/javascript",
      "timestamp": "2020-07-01T17:27:06.470961-04:00",
      "level": "Information"
    },
    {
      "message": "Sending file. Request path: '\"/swagger-ui-bundle.js\"'. Physical path: '\"N/A\"'",
      "timestamp": "2020-07-01T17:27:06.522772-04:00",
      "level": "Information"
    },
    {
      "message": "Request finished in 275.2778ms 200 application/javascript",
      "timestamp": "2020-07-01T17:27:06.522908-04:00",
      "level": "Information"
    },
    {
      "message": "Request starting HTTP/1.1 GET https://doghouse.thompsonbass.io/swagger/v1/swagger.json  ",
      "timestamp": "2020-07-01T17:27:06.680341-04:00",
      "level": "Information"
    },
    {
      "message": "Request finished in 296.0141ms 200 application/json;charset=utf-8",
      "timestamp": "2020-07-01T17:27:06.976188-04:00",
      "level": "Information"
    },
    {
      "message": "Request starting HTTP/1.1 GET https://doghouse.thompsonbass.io/api/v1/logs  ",
      "timestamp": "2020-07-01T17:27:12.411545-04:00",
      "level": "Information"
    },
    {
      "message": "Executing endpoint '\"DogHouseApi.Controllers.LogsController.GetLogs (DogHouseApi)\"'",
      "timestamp": "2020-07-01T17:27:12.426149-04:00",
      "level": "Information"
    },
    {
      "message": "Route matched with \"{action = \\\"GetLogs\\\", controller = \\\"Logs\\\"}\". Executing controller action with signature \"Microsoft.AspNetCore.Mvc.ActionResult GetLogs(System.DateTimeOffset, System.DateTimeOffset, Microsoft.AspNetCore.Mvc.ApiVersion)\" on controller \"DogHouseApi.Controllers.LogsController\" (\"DogHouseApi\").",
      "timestamp": "2020-07-01T17:27:12.454258-04:00",
      "level": "Information"
    },
    {
      "message": "Executing ObjectResult, writing value of type '\"DogHouseApi.Models.LogListDto\"'.",
      "timestamp": "2020-07-01T17:27:12.513592-04:00",
      "level": "Information"
    }
  ]
}
```

## Notes

* By default all logs will be returned if `start` and `end` aren't specified.