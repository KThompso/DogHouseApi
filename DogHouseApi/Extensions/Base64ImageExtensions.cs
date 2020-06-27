using System;
using System.Net.Mime;

namespace DogHouseApi.Extensions
{
    public static class Base64ImageExtension
    {
        public static string GetMimeType(this String base64Image)
        {
            switch (base64Image.Split(",")[0])
            {
                case "data:image/gif;base64":
                    return MediaTypeNames.Image.Gif;
                case "data:image/tiff;base64":
                    return MediaTypeNames.Image.Tiff;
                case "data:image/png;base64":
                    return "image/png"; // No constant in MediaTypeNames for png
                default:
                    return MediaTypeNames.Image.Jpeg;
            }
        }

        public static byte[] ConvertBase64ImageToBitMap(this String base64Image)
        {
            string[] strings = base64Image.Split(",");
            return Convert.FromBase64String(strings[Math.Max(0, strings.Length - 1)]);
        }

    }

}
