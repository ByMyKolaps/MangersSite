using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MangersWebApi.Models
{
    public class Page
    {
        [Key]
        public int PageId { get; set; }
        public int PageNumber { get; set; }
        public int ChapterNumber { get; set; }
        public int MangaId { get; set; }
        public string ImageUrl { get; set; }
    }
}
