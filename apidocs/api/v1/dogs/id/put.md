# Update a Dog

Update a dog's information.

**URL** : `/api/v1/dogs/{id}`

**Path Parameters** :

- `{id:integer}` : Id of the dog to get.

**Method** : `PUT`

## Success Response

**Code** : `201 CREATED`

**Headers** : `Location: https://localhost:5001/api/v1/dogs/3`

**Content examples**

```json
{
{
    "links": [
        {
            "href": "https://localhost:5001/api/v1/dogs/3",
            "rel": "self",
            "method": "GET"
        },
        {
            "href": "https://localhost:5001/api/v1/dogs/3",
            "rel": "delete_dog",
            "method": "DELETE"
        },
        {
            "href": "https://localhost:5001/api/v1/dogs/3",
            "rel": "update_dog",
            "method": "PUT"
        }
    ],
    "breed": "German Shepherd",
    "name": "Sparky",
    "image": "https://localhost:5001/api/v1/images/1.gif"
}
```

## Error Responses

**Condition** : If dog does not exist with `{id}`.

**Code** : `404 NOT FOUND`

**Content** :

```json
{
    "type": "https://tools.ietf.org/html/rfc7231#section-6.5.4",
    "title": "Not Found",
    "status": 404,
    "traceId": "|c1438178-4db47a4d23727400."
}
```