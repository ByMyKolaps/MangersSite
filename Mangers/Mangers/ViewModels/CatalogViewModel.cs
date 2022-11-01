using MangersDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mangers.ViewModels
{
    public class CatalogViewModel
    {
        public List<Manga> Mangas { get; set; }
        public int currentPage { get; set; }
        public int maxPages { get; set; }
        public string searchString { get; set; }
        public string mangaType { get; set; }
        public string mangaGenre { get; set; }
        public string mangaCategory { get; set; }
        public string sortingField { get; set; }
        public string sortingType { get; set; }
    }
}
