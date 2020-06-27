using System;
using System.Security.Cryptography;

namespace DogHouseApi.Extensions
{
    public static class ByteExtension
    {

        public static string GetFingerprint(this byte[] data)
        {
            using (var md5 = MD5.Create())
            {
                return BitConverter.ToString(md5.ComputeHash(data));
            }
        }

    }
}
