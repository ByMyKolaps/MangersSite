using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MangersDAL.Models
{
    public class Comments
    {
        [Key]
        public int CommentId { get; set; }
        [ForeignKey("Owner")]
        public string OwnerId { get; set; }
        public User Owner { get; set; }
        [ForeignKey("Manga")]
        public int MangaId { get; set; } 
        public Manga Manga { get; set; }
        public string Content { get; set; }
        public int Estimation { get; set; }

    }
}
