using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mangers.ViewModels;
using MangersBL;
using MangersDAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mangers.Controllers
{
    public class CatalogController : Controller
    {
        public IActionResult Catalog(CatalogViewModel catalogViewModel)
        {
            if (catalogViewModel.currentPage == 0)
            {
                catalogViewModel.currentPage = 1;
            }
            CatalogViewModel model = new CatalogViewModel();
            List<Manga> mangas = CatalogLogic.GetMangas();
            if(!string.IsNullOrEmpty(catalogViewModel.searchString))
            {
                mangas = CatalogLogic.GetSearchedMangas(mangas, catalogViewModel.searchString);
            }
            mangas = CatalogLogic.Filter(mangas, catalogViewModel.mangaType, catalogViewModel.mangaGenre, catalogViewModel.mangaCategory);
            mangas = CatalogLogic.Sorting(mangas, catalogViewModel.sortingField, catalogViewModel.sortingType);
            model.maxPages = CatalogLogic.GetMaxPages(mangas.Count());
            mangas = CatalogLogic.GetPage(mangas, catalogViewModel.currentPage);
            model = catalogViewModel;
            model.Mangas = mangas;
            return View(model);
        }
    }
}
