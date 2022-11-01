using Microsoft.AspNetCore.Http;
using System;
using System.Security.Cryptography;


namespace Mangers.Helpers
{
    public static class FormFileExtensions
    {
        public static string GetMd5Hash(this IFormFile file)
        {
            var stream = file.OpenReadStream();
            var md5 = MD5.Create();
            var bytes = md5.ComputeHash(stream);
            return BitConverter.ToString(bytes).Replace("-", "").ToLowerInvariant();
        }
    }
}
