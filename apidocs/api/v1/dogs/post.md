# Create a Dog

Create a new dog.

**URL** : `/api/v1/dogs`

**Method** : `POST`

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

Create a dog using an image link.

```bash
$ curl https://doghouse.thompsonbass.io/api/v1/dogs \
      -H "Content-Type: application/json" \
      -d "{'name': 'Sparky',
           'breed': 'Poodle',
           'imageUrl': 'https://images.dog.ceo/breeds/poodle-toy/n02113624_429.jpg' }"
```

Create a dog with base64 encoded image data.

```bash
$ curl https://doghouse.thompsonbass.io/api/v1/dogs \
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

**Condition** : If request is invalid.

**Code** : `400 BAD REQUEST`