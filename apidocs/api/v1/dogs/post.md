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

## Success Response

**Code** : `201 CREATED`

**Headers** : `Location: https://localhost:5001/api/v1/dogs/3`

**Content examples**

```json
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
    "imageUrl": "https://localhost:5001/api/v1/images/1.gif"
}
```
