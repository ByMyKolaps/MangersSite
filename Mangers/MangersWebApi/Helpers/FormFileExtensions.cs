using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace MangersWebApi.Helpers
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
