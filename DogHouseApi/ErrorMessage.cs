using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DogHouseApi
{
    public static class ErrorMessage
    {

        public static readonly string INVALID_IMAGE = "Invalid base64 encoded image.";
        public static readonly string TOO_MANY_IMAGE_TYPES = "Specify imageUrl or imageData, but not both.";
    }
}
