using System.Net.Mime;

namespace DogHouseApi.Utilities
{
    public static class MimeTypeUtil
    {
        public static string GetImageExtension(string mimeType)
        {
            switch (mimeType)
            {
                case MediaTypeNames.Image.Jpeg:
                    return "jpeg";
                case MediaTypeNames.Image.Gif:
                    return "gif";
                case MediaTypeNames.Image.Tiff:
                    return ".tiff";
                case "image/png":
                    return "png";
                default:
                    return null;
            }
        }
    }
}
