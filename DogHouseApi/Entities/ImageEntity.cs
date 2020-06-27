using System.ComponentModel.DataAnnotations;
using DogHouseApi.Extensions;
using DogHouseApi.Utilities;

namespace DogHouseApi.Entities
{
    public class ImageEntity
    {

        [Key]
        public int Id { get; set; }

        public string Fingerprint { get; set; }

        public string MimeType { get; set; }

        public string Extension { get; set; }

        public byte[] Data { get; set; }

        // TODO move to mapper class
        public static ImageEntity FromBase64String(string base64data)
        {

            var data = base64data.ConvertBase64ImageToBitMap();
            var mimeType = base64data.GetMimeType();

            ImageEntity image = new ImageEntity
            {
                MimeType = mimeType,
                Data = data,
                Fingerprint = data.GetFingerprint(),
                Extension = MimeTypeUtil.GetImageExtension(mimeType),
            };

            return image;
        }

    }
}
