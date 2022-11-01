using MangersDAL.Models;
using System.Collections.Generic;

namespace MangersDAL.Repos
{
    public interface ICatalogRepo
    {
        public List<Manga> GetMangas();
        public List<Manga> GetSearchedMangas(string searchString);
        public List<Manga> GetFilteredMangas(string mangaTypes, string mangaGenre, string mangaCategory);
        public int GetMangasCount();
    }
}
