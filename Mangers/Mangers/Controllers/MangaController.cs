using Mangers.ViewModels;
using MangersBL;
using MangersDAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mangers.Controllers
{
    public class MangaController : Controller
    {

        private readonly UserManager<User> _userManager;
        public MangaController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult MangaMainInfo(int mangaId)
        {
            Manga manga = MangaLogic.GetMangaById(mangaId).Result;
            return View(manga);
        }

        [HttpGet]
        public async Task<IActionResult> MangaChapterView(int mangaId, int curentChapterNumber, string user)
        {
            if(user == null || user == "")
            {
                return RedirectToAction("SignIn", "Account");
            }
            bool isMangaPremium = MangaLogic.IsPremium(mangaId);
            User _user = await _userManager.FindByNameAsync(user);
            bool isUserPremium = await _userManager.IsInRoleAsync(_user, "Premium");
            if(isMangaPremium && !isUserPremium)
            {
                return View("~/Views/Profile/PremiumOffer.cshtml");
            }
            MangaViewChapterViewModel model = new MangaViewChapterViewModel();
            model.MangaChapters = MangaLogic.GetMangaChapters(mangaId);
            model.ChapterPages = MangaLogic.GetChapterPages(curentChapterNumber, mangaId).Result;
            model.MangaId = mangaId;
            model.MangaTitle = MangaLogic.GetMangaName(mangaId);
            model.currentChapterNumber = curentChapterNumber;
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> MangaChapters(int mangaId)
        {
            Manga manga = await MangaLogic.GetMangaByIdWithChapters(mangaId);
            return View(manga);
        }

        [HttpPost]
        public IActionResult PostComment(int mangaId, string content, int estimation, string owner)
        {
            MangaLogic.PostComment(mangaId, content, estimation, owner);
            return RedirectToAction("MangaMainInfo", new { mangaId = mangaId });
        }

        [HttpPost]
        public void AddToBookmark(string bookmarkType, string user, int mangaId)
        {
            MangaLogic.AddBookmark(bookmarkType, user, mangaId);
        }

    }
}
