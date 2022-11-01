using MangersDAL.Models;
using MangersDAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MangersDAL.ReposRealization
{
    public class CatalogRepo : Repo, ICatalogRepo
    {
        public List<Manga> GetFilteredMangas(string mangaTypes, string mangaGenre, string mangaCategory)
        {
            List<Manga> mangas = GetMangas();
            if(mangaTypes != null && mangaTypes != "")
            {
                mangas = mangas.Where(m => m.MangaType.ToString().ToUpper() == mangaTypes).ToList();
            }
            var i = mangas.FirstOrDefault(m => m.Rating == 0).MangaGenre.ToString().ToUpper();
            if (mangaGenre != null && mangaGenre != "")
            {
                mangas = mangas.Where(m => m.MangaGenre.ToString().ToUpper() == mangaGenre).ToList();
            }
            if (mangaCategory != null && mangaCategory != "")
            {
                mangas = mangas.Where(m => m.MangaCategory.ToString().ToUpper() == mangaCategory).ToList();
            }
            return mangas;
        }

        public int GetMangasCount()
        {
            return _context.Mangas.Count();
        }

        public List<Manga> GetMangas()
        {
            /*return _context.Mangas.Skip((page - 1) * 6).Take(6).ToList();*/
            return _context.Mangas.ToList();
        }
        public List<Manga> GetSearchedMangas(string searchString)
        {
            return _context.Mangas.Where(m => m.Name.Contains(searchString)).ToList();
        }


    }
}
