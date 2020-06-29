using System;
using System.Net.Mime;
using DogHouseApi.Entities;
using DogHouseApi.Utilities;

namespace DogHouseApi.Extensions
{
    public static class Base64ImageExtension
    {
        public static string GetMimeType(this String base64Image)
        {
            return (base64Image.Split(",")[0]) switch
            {
                "data:image/gif;base64" => MediaTypeNames.Image.Gif,
                "data:image/tiff;base64" => MediaTypeNames.Image.Tiff,
                "data:image/png;base64" => "image/png",// No constant in MediaTypeNames for png
                _ => MediaTypeNames.Image.Jpeg,
            };
        }

        public static byte[] ConvertBase64ImageToBitMap(this String base64Image)
        {
            string[] strings = base64Image.Split(",");
            return Convert.FromBase64String(strings[Math.Max(0, strings.Length - 1)]);
        }

        public static ImageEntity ToImageEntity(this string base64Image)
        {

            ImageEntity imageEntity = new ImageEntity();

            imageEntity.Data = base64Image.ConvertBase64ImageToBitMap();

            imageEntity.MimeType = base64Image.GetMimeType();

            imageEntity.Extension =
                MimeTypeUtil.GetImageExtension(imageEntity.MimeType);

            imageEntity.Fingerprint = imageEntity.Data.GetFingerprint();

            return imageEntity;
        }

    }

}
