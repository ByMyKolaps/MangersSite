using Mangers.Helpers;
using Mangers.ViewModels;
using MangersBL;
using MangersDAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mangers.Controllers
{
    [Authorize(Roles="Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private IWebHostEnvironment _environment = null;

        public AdminController(UserManager<User> userManager, SignInManager<User> signInManager, IWebHostEnvironment environment)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _environment = environment;
        }
        [HttpGet]
        public IActionResult AddManga()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddManga(Manga manga, IFormFile photo)
        {
            string photoPath;
            if (photo != null)
            {
                photoPath = await _environment.AddFile(photo, "/img/");
                manga.PhotoPath = photoPath;
            }
            await AdminLogic.AddManga(manga);
            return View();
        }
        [HttpGet]
        public IActionResult AddChapter()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddChapter(Chapter chapter, List<IFormFile> pages)
        {
            await AdminLogic.AddChapter(chapter);
            int pageCounter = 1;
            foreach(var page in pages)
            {
                var status = AdminLogic.AddPages(page, chapter.ChapterNumber, pageCounter, chapter.MangaId);
                pageCounter++;
            }
            return View();
        }
    }
}
