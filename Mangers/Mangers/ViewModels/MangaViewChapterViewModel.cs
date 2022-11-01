using MangersDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mangers.ViewModels
{
    public class MangaViewChapterViewModel
    {
        public List<Chapter> MangaChapters { get; set; }
        public List<Page> ChapterPages { get; set; }
        public int MangaId { get; set; }
        public string MangaTitle { get; set; }
        public int currentChapterNumber { get; set; }


    }
}
