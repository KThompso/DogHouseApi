# Dog House API
![Build](https://github.com/KThompso/DogHouseApi/workflows/Build/badge.svg?branch=master)
![Deploy](https://github.com/KThompso/DogHouseApi/workflows/Deploy/badge.svg?branch=master)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

Easily manage information and pictures of dogs.

## Overview

Dog House is an API that allows users to upload, retrieve, update, and delete information about their dogs.  Pictures of your dogs can be uploaded as links or as images encoded as base64 strings.  If uploading the image as base64 data, the image will be saved to the Dog House servers and a link to the image will be returned.

**Swagger** : The swagger UI can be accessed [here][swagger-ui], and the raw swagger spec is available at <https://doghouse.thompsonbass.io/swagger/v1/swagger.json>.

**Postman** : A postman collection is available for download at <https://github.com/KThompso/DogHouseApi/blob/master/postman/DogHouseAPI.postman_collection.json?raw=true>.

## Endpoints

### Dogs

Endpoints to display or manipulate data related to dogs.

- [List Dogs](apidocs/api/v1/dogs/get.md) : `GET /api/v1/dogs`
- [Create Dog](apidocs/api/v1/dogs/post.md) : `POST /api/v1/dogs`
- [Display Dog](apidocs/api/v1/dogs/id/get.md) : `GET /api/v1/dogs/{id}`
- [Update Dog](apidocs/api/v1/dogs/id/put.md) : `PUT /api/v1/dogs/{id}`
- [Delete Dog](apidocs/api/v1/dogs/id/delete.md) : `DELETE /api/v1/dogs/{id}`
- [Delete All Dogs](apidocs/api/v1/dogs/delete.md) : `DELETE /api/v1/dogs`

### Logs

Endpoints for retrieving web logs.

- [List Logs](apidocs/api/v1/logs/get.md) : `GET /api/v1/logs`

### Documentation

- Swagger : `GET /swagger`

## Docker

Run the latest docker image from [docker hub][docker-hub].

```
$ docker run -p 80:80 kthompso/dog-house-api
```

## Development

To start developing on Dog House just clone this repository and run.

```
$ git clone https://github.com/KThompso/DogHouseApi
$ cd DogHouseApi/DogHouseApi && dotnet run
```

[docker-hub]: https://hub.docker.com/repository/docker/kthompso/dog-house-api
[dog-house-base]: https://doghouse.thompsonbass.io/api/v1/dogs
[postman-docs]: https://github.com/KThompso/DogHouseApi/blob/master/postman/DogHouseAPI.postman_collection.json?raw=true
[swagger-ui]: https://doghouse.thompsonbass.io/swagger/index.html
[swagger-raw]: https://doghouse.thompsonbass.io/swagger/v1/swagger.json
