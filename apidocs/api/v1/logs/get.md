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
            "timestamp": "2020-06-29T09:01:25.227042-04:00",
            "level": 2,
            "messageTemplate": {
                "text": "Route matched with {RouteData}. Executing controller action with signature {MethodInfo} on controller {Controller} ({AssemblyName}).",
                "tokens": [
                    {
                        "length": 19,
                        "text": "Route matched with ",
                        "startIndex": 0
                    },
                    {
                        "length": 11,
                        "propertyName": "RouteData",
                        "destructuring": 0,
                        "format": null,
                        "alignment": null,
                        "isPositional": false,
                        "startIndex": 19
                    },
                    {
                        "length": 45,
                        "text": ". Executing controller action with signature ",
                        "startIndex": 30
                    },
                    {
                        "length": 12,
                        "propertyName": "MethodInfo",
                        "destructuring": 0,
                        "format": null,
                        "alignment": null,
                        "isPositional": false,
                        "startIndex": 75
                    },
                    {
                        "length": 15,
                        "text": " on controller ",
                        "startIndex": 87
                    },
                    {
                        "length": 12,
                        "propertyName": "Controller",
                        "destructuring": 0,
                        "format": null,
                        "alignment": null,
                        "isPositional": false,
                        "startIndex": 102
                    },
                    {
                        "length": 2,
                        "text": " (",
                        "startIndex": 114
                    },
                    {
                        "length": 14,
                        "propertyName": "AssemblyName",
                        "destructuring": 0,
                        "format": null,
                        "alignment": null,
                        "isPositional": false,
                        "startIndex": 116
                    },
                    {
                        "length": 2,
                        "text": ").",
                        "startIndex": 130
                    }
                ]
            },
            "properties": {
                "RouteData": {
                    "value": "{action = \"GetLogs\", controller = \"Logs\"}"
                },
                "MethodInfo": {
                    "value": "Microsoft.AspNetCore.Mvc.ActionResult GetLogs(System.DateTimeOffset, System.DateTimeOffset, Microsoft.AspNetCore.Mvc.ApiVersion)"
                },
                "Controller": {
                    "value": "DogHouseApi.Controllers.LogsController"
                },
                "AssemblyName": {
                    "value": "DogHouseApi"
                },
                "EventId": {
                    "typeTag": null,
                    "properties": [
                        {
                            "name": "Id",
                            "value": {
                                "value": 3
                            }
                        },
                        {
                            "name": "Name",
                            "value": {
                                "value": "ControllerActionExecuting"
                            }
                        }
                    ]
                },
                "SourceContext": {
                    "value": "Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker"
                },
                "ActionId": {
                    "value": "4ec05d1a-5a7c-4d36-ba6a-7fa52b37d72c"
                },
                "ActionName": {
                    "value": "DogHouseApi.Controllers.LogsController.GetLogs (DogHouseApi)"
                },
                "RequestId": {
                    "value": "0HM0SNC1LPRT5:00000001"
                },
                "RequestPath": {
                    "value": "/api/v1/logs"
                },
                "SpanId": {
                    "value": "|ec75d34f-48b95d3e0f58ffb0."
                },
                "TraceId": {
                    "value": "ec75d34f-48b95d3e0f58ffb0"
                },
                "ParentId": {
                    "value": ""
                },
                "ConnectionId": {
                    "value": "0HM0SNC1LPRT5"
                }
            },
            "exception": null
        },
        {
            "timestamp": "2020-06-29T09:01:25.297368-04:00",
            "level": 2,
            "messageTemplate": {
                "text": "Executing ObjectResult, writing value of type '{Type}'.",
                "tokens": [
                    {
                        "length": 47,
                        "text": "Executing ObjectResult, writing value of type '",
                        "startIndex": 0
                    },
                    {
                        "length": 6,
                        "propertyName": "Type",
                        "destructuring": 0,
                        "format": null,
                        "alignment": null,
                        "isPositional": false,
                        "startIndex": 47
                    },
                    {
                        "length": 2,
                        "text": "'.",
                        "startIndex": 53
                    }
                ]
            },
            "properties": {
                "Type": {
                    "value": "DogHouseApi.Models.LogsDto"
                },
                "EventId": {
                    "typeTag": null,
                    "properties": [
                        {
                            "name": "Id",
                            "value": {
                                "value": 1
                            }
                        },
                        {
                            "name": "Name",
                            "value": {
                                "value": "ObjectResultExecuting"
                            }
                        }
                    ]
                },
                "SourceContext": {
                    "value": "Microsoft.AspNetCore.Mvc.Infrastructure.ObjectResultExecutor"
                },
                "ActionId": {
                    "value": "4ec05d1a-5a7c-4d36-ba6a-7fa52b37d72c"
                },
                "ActionName": {
                    "value": "DogHouseApi.Controllers.LogsController.GetLogs (DogHouseApi)"
                },
                "RequestId": {
                    "value": "0HM0SNC1LPRT5:00000001"
                },
                "RequestPath": {
                    "value": "/api/v1/logs"
                },
                "SpanId": {
                    "value": "|ec75d34f-48b95d3e0f58ffb0."
                },
                "TraceId": {
                    "value": "ec75d34f-48b95d3e0f58ffb0"
                },
                "ParentId": {
                    "value": ""
                },
                "ConnectionId": {
                    "value": "0HM0SNC1LPRT5"
                }
            },
            "exception": null
        }
    ]
}
```

## Notes

* By default all logs will be returned if `start` and `end` aren't specified.