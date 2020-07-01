# Delete a Dog

Delete a single dog.

**URL** : `/api/v1/dogs/{id:integer}`

**Path Parameters** :

- `{id:integer}` : Id of the dog to get.

**Method** : `DELETE`

## Examples

Delete the dog with id 102.

`$ curl -X DELETE "https://doghouse.thompsonbass.io/api/v1/dogs/102"`

## Success Response

**Condition** : If the Dog with `{id}` exists and was deleted.

**Code** : `204 NO CONTENT`

## Error Responses

**Condition** : If no dog exists with `{id}`.

**Code** : `404 NOT FOUND`

**Content** :

```json
{
    "type": "https://tools.ietf.org/html/rfc7231#section-6.5.4",
    "title": "Not Found",
    "status": 404,
    "traceId": "|c143817c-4db47a4d23727400."
}
```
