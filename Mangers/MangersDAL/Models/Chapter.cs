using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MangersDAL.Models
{
    public class Chapter
    {
        [Key]
        public int ChapterId { get; set; }
        public int ChapterNumber { get; set; }
        [ForeignKey("Manga")]
        public int MangaId { get; set; }
        public Manga Manga { get; set; }
        public DateTime DateOfCreation { get; set; }
        public int CountOfPages { get; set; }
        public List<Page> Pages { get; set; }

    }
}
