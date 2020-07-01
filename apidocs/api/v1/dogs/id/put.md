# Update a Dog

Update a dog's information.

**URL** : `/api/v1/dogs/{id}`

**Path Parameters** :

- `{id:integer}` : Id of the dog to get.

**Method** : `PUT`

**Data constraints**

Either `imageUrl` or `imageData` can be provided bot both.  `imageData` allows you to upload a base64 encoded string representing an image.  `imageUrl` takes a link to an image on the web.

```json
{
    "imageUrl": "[link to image]"
}
```

**OR**

```json
{
    "imageData": "[base64 encoded image data]"
}
```

**Data examples**

```json
{
    "name": "Sparky",
    "breed": "German Shepherd",
    "imageData": "[base64 encoded image]",
}
```

```json
{
    "name": "Fido",
    "breed": "Cockapoo",
    "imageUrl": "https://images.dog.ceo/breeds/leonberg/n02111129_638.jpg"
}
```

## Examples

Update the dog with id 101 using a link.

```bash
$ curl -X PUT "https://doghouse.thompsonbass.io/api/v1/dogs/101" \
      -H "Content-Type: application/json" \
      -d "{'name': 'Sparky',
           'breed': 'Poodle',
           'imageUrl': 'https://images.dog.ceo/breeds/poodle-toy/n02113624_429.jpg' }"
```

Update the dog with id 101 using base64 encoded image data.

```bash
$ curl -X PUT "https://doghouse.thompsonbass.io/api/v1/dogs/101" \
      -H "Content-Type: application/json" \
      -d "{'name': 'Sparky',
           'breed': 'Poodle',
           'imageData': '$(curl https://images.dog.ceo/breeds/poodle-toy/n02113624_429.jpg | base64)' }"
```

## Success Response

**Code** : `201 CREATED`

**Headers** : `Location: https://doghouse.thompsonbass.io/api/v1/dogs/3`

**Content examples**

```json
{
{
    "links": [
        {
            "href": "https://doghouse.thompsonbass.io/api/v1/dogs/3",
            "rel": "self",
            "method": "GET"
        },
        {
            "href": "https://doghouse.thompsonbass.io/api/v1/dogs/3",
            "rel": "delete_dog",
            "method": "DELETE"
        },
        {
            "href": "https://doghouse.thompsonbass.io/api/v1/dogs/3",
            "rel": "update_dog",
            "method": "PUT"
        }
    ],
    "breed": "German Shepherd",
    "name": "Sparky",
    "imageUrl": "https://doghouse.thompsonbass.io/api/v1/images/1.gif"
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