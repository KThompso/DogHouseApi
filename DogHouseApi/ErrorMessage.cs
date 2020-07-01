namespace DogHouseApi
{
    public static class ErrorMessage
    {

        public static readonly string INTERNAL_SERVER_ERROR = "Internal Server Error";
        public static readonly string INVALID_IMAGE = "Invalid base64 encoded image";
        public static readonly string INVALID_REQUEST = "Invalid request";
        public static readonly string NOT_FOUND = "Not found";
        public static readonly string TOO_MANY_IMAGES = "Specify imageUrl or imageData, but not both";

    }
}
