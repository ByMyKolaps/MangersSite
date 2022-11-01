using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MangersDAL.Models
{
    public class Page
    {
        [Key]
        public int PageId { get; set; }
        public int PageNumber { get; set; }
        [ForeignKey("Chapter")]
        public int ChapterId { get; set; }
        public int ChapterNumber { get; set; }
        public int MangaId { get; set; }
        public Chapter Chapter { get; set; }
        public string ImageUrl { get; set; }
    }
}
