# Dog House API
![Build](https://github.com/KThompso/DogHouseApi/workflows/Build/badge.svg?branch=master)
![Deploy](https://github.com/KThompso/DogHouseApi/workflows/Deploy/badge.svg?branch=master)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

Dog House is an ASP.NET Core web API for storing information and images of dogs.  You can run Dog House locally as an ASP.NET application or docker image.  Alternatively you can access this version running on Microsoft Azure <https://the-dog-house.azurewebsites.net/swagger/index.html>.

## Docker

Run the latest docker image from docker hub.

```
$ docker run -p 80:80 kthompso/dog-house-api
```

## Documentation

The Dog House API allows users to create, read, update, and delete information about their dogs.  Images of your dogs can be uploaded as base64 encoded strings.

Swagger UI can be accessed [here][swagger-ui], and raw swagger documentation is available at <https://the-dog-house.azurewebsites.net/swagger/v1/swagger.json>.

## Development

```
$ git clone https://github.com/KThompso/DogHouseApi
$ cd DogHouseApi/DogHouseApi && dotnet run
```


[dog-house-base]: https://the-dog-house.azurewebsites.net/api/v1/dogs
[swagger-ui]: https://the-dog-house.azurewebsites.net/swagger/index.html
[swagger-raw]: https://the-dog-house.azurewebsites.net/swagger/v1/swagger.json
