# Create a Dog

Create a new dog.

**URL** : `/api/v1/dogs`

**Method** : `POST`

**Data example**

```json
{
    "name": "Sparky",
    "breed": "German Shepherd",
    "image": "base64 encoded image"
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
    "image": "https://localhost:5001/api/v1/images/1.gif"
}
```
