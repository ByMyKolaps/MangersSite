using MangersDAL.Models;
using MangersDAL.Repos;
using MangersDAL.ReposRealization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangersBL
{
    public class CatalogLogic
    {
        public static ICatalogRepo CatalogRepo = new CatalogRepo();
        public static List<Manga> GetMangas()
        {
            return CatalogRepo.GetMangas();
        }

        public static List<Manga> GetSearchedMangas(List<Manga> mangas, string searchString)
        {
            return mangas.Where(m => m.Name.Contains(searchString)).ToList();
        }

        public static int GetMaxPages(double count)
        {
            double pages = count / 6;
            return Convert.ToInt32(Math.Ceiling(pages));
            
        }

        public static List<Manga> Filter(List<Manga> mangas,string mangaType, string mangaGenre, string mangaCategory)
        {
            if (mangaType != null && mangaType != "")
            {
                mangas = mangas.Where(m => m.MangaType.ToString().ToUpper() == mangaType).ToList();
            }
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

        public static List<Manga> Sorting(List<Manga> mangas, string sortingField, string sortingType)
        {
            if(sortingField == "СОРТИРОВАТЬ ПО" || sortingField == null)
            {
                return mangas;
            }
            if (sortingType == "СОРТИРОВАТЬ ПО" || sortingType == null)
            {
                return mangas;
            }
            if (sortingField == "ПО РЕЙТИНГУ")
            {
                if (sortingType == "СОРТИРОВАТЬ ПО" || sortingType == "ПО ВОЗРАСТАНИЮ")
                    return mangas.OrderByDescending(m => m.Rating).ToList();
                else
                    return mangas.OrderBy(m => m.Rating).ToList();
            }    
            else
            {
                if (sortingType == "СОРТИРОВАТЬ ПО" || sortingType == "По ВОЗРАСТАНИЮ")
                    return mangas.OrderByDescending(m => m.YearOfCreation).ToList();
                else
                    return mangas.OrderBy(m => m.YearOfCreation).ToList();
            }
        }

        public static List<Manga> GetPage(List<Manga> mangas, int currentPage)
        {
            return mangas.Skip((currentPage - 1) * 6).Take(6).ToList();
        }
    }
}
