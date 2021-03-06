# List Dogs

List all the dogs.

**URL** : `/api/v1/dogs`

**URL Parameters** :

- `page=[integer]` : Page number to get.
- `perPage=[integer]` : Number of dogs to return per page.  Defaults to 10.

**Method** : `GET`

## Examples

`$ curl "https://doghouse.thompsonbass.io/api/v1/dogs"`

`$ curl "https://doghouse.thompsonbass.io/api/v1/dogs?page=3&perPage=25"`

## Success Response

**Code** : `200 OK`

**Content examples**

```json
{
    "links": [
        {
            "href": "https://doghouse.thompsonbass.io/api/v1/dogs?page=1&perPage=10",
            "rel": "self",
            "method": "GET"
        },
        {
            "href": "https://doghouse.thompsonbass.io/api/v1/dogs?page=1&perPage=10",
            "rel": "first",
            "method": "GET"
        },
        {
            "href": "https://doghouse.thompsonbass.io/api/v1/dogs?page=1&perPage=10",
            "rel": "last",
            "method": "GET"
        }
    ],
    "page": {
        "number": 1,
        "size": 2,
        "totalPages": 1,
        "totalElements": 2
    },
    "data": [
        {
            "links": [
                {
                    "href": "https://doghouse.thompsonbass.io/api/v1/dogs/1",
                    "rel": "self",
                    "method": "GET"
                },
                {
                    "href": "https://doghouse.thompsonbass.io/api/v1/dogs/1",
                    "rel": "delete_dog",
                    "method": "DELETE"
                },
                {
                    "href": "https://doghouse.thompsonbass.io/api/v1/dogs/1",
                    "rel": "update_dog",
                    "method": "PUT"
                }
            ],
            "breed": "Poodle",
            "name": "Sparky",
            "imageUrl": "https://doghouse.thompsonbass.io/api/v1/images/1.gif"
        },
        {
            "links": [
                {
                    "href": "https://doghouse.thompsonbass.io/api/v1/dogs/2",
                    "rel": "self",
                    "method": "GET"
                },
                {
                    "href": "https://doghouse.thompsonbass.io/api/v1/dogs/2",
                    "rel": "delete_dog",
                    "method": "DELETE"
                },
                {
                    "href": "https://doghouse.thompsonbass.io/api/v1/dogs/2",
                    "rel": "update_dog",
                    "method": "PUT"
                }
            ],
            "breed": "German Shepherd",
            "name": "Major",
            "imageUrl": "https://images.dog.ceo/breeds/leonberg/n02111129_638.jpg"
        }
    ]
}
```

## Notes

* By default the first page of ten dogs will be returned.
