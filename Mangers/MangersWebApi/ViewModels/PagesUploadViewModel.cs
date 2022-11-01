using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MangersWebApi.ViewModels
{
    public class PagesUploadViewModel
    {
        public string ChapterNumber { get; set; }
        public IFormFile Page { get; set; }
        public string PageNumber { get; set; }
        public string MangaId { get; set; }
    }
}
