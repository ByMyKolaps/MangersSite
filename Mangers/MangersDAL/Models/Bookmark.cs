using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MangersDAL.Models
{
    public class Bookmark
    {
        [Key]
        public int BookmarkId { get; set; }
        public string UserName { get; set; }
        public User User { get; set; }
        public BookmarkType BookmarkType { get; set; }
        [ForeignKey("Manga")]
        public int MangaId { get; set; }
        public Manga Manga { get; set; }
    }
}
