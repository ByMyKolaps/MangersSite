using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MangersDAL.Models
{
    public class Manga
    {
        [Key]
        public int MangaId { get; set; }
        public MangaCategory MangaCategory { get; set; }
        public MangaGenre MangaGenre { get; set; }
        public string Name { get; set; }
        public MangaTypes MangaType { get; set; }
        public double Rating { get; set; }
        public string PhotoPath { get; set; }
        public int YearOfCreation { get; set; }
        public string Description { get; set; }
        public List<Chapter> Chapters { get; set; }
        public List<Comments> Comments { get; set; }
        public bool IsPremium { get; set; }

    }
}
