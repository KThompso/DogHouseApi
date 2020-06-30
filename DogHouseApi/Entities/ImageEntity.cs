using System.ComponentModel.DataAnnotations;

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

    }
}
