# Dog House API
![Build](https://github.com/KThompso/DogHouseApi/workflows/Build/badge.svg?branch=master)
![Deploy](https://github.com/KThompso/DogHouseApi/workflows/Deploy/badge.svg?branch=master)

Dog House is an ASP.NET Core web API for storing information and images of dogs.  You can run Dog House locally using a docker image, or access a version running on Microsoft Azure at <https://the-dog-house.azurewebsites.net/swagger/index.html>.

## Docker

### Installation

Pull the latest docker image from docker hub.

`$ docker pull kthompso/dog-house-api:latest`

### Usage

Run the installed docker container locally and forward port 80.

`docker run -p 80:80 kthompso/dog-house-api`

## Development

`$ git clone k

## Documentation

The Dog House API allows users to create, read, update, and delete information about their dogs.  Images of your dogs can be uploaded as base64 encoded strings.

Swagger UI can be accessed [here][swagger-ui], and raw swagger documentation is available at <https://the-dog-house.azurewebsites.net/swagger/v1/swagger.json>.

## License

MIT

[dog-house-base]: https://the-dog-house.azurewebsites.net/api/v1/dogs
[swagger-ui]: https://the-dog-house.azurewebsites.net/swagger/index.html
[swagger-raw]: https://the-dog-house.azurewebsites.net/swagger/v1/swagger.json
