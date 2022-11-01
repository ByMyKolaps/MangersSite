using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mangers.Helpers;
using Mangers.ViewModels;
using MangersBL;
using MangersDAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Mangers.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private IWebHostEnvironment _environment = null;

        public ProfileController(UserManager<User> userManager, SignInManager<User> signInManager, IWebHostEnvironment environment)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _environment = environment;
        }
        [Authorize]
        public IActionResult Profile(string name)
        {
            var user = _userManager.Users.FirstOrDefault(u => u.UserName == name);
            return View(user);
        }
        [HttpGet]
        [Authorize]
        public IActionResult Bookmarks(string name, string bookmarkType)
        {
            List<Manga> model = ProfileLogic.GetBookmarks(name, bookmarkType);
            return View(model);
        }

        [HttpGet]
        [Authorize]
        public IActionResult EditProfile()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> EditPhoto(IFormFile avatar)
        {
            string userName = User.Identity.Name;
            User user = _userManager.Users.FirstOrDefault(u => u.UserName == userName);
            string photoPath;
            if (avatar != null)
            {
                photoPath = await _environment.AddFile(avatar, "/img/");
                user.AvatarPicture = photoPath;
            }
            ProfileLogic.SaveUser(user);
            return RedirectToAction("Profile", new { name = userName });
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> EditPassword(string OldPassword, string NewPassword, string ConfirmPassword)
        {
            if (NewPassword != ConfirmPassword)
            {
                if(TempData["EditPasswordMessage"] != null)
                {
                    TempData["EditPasswordMessage"] = "Пароли не совпадают";
                    return RedirectToAction("EditProfile");
                }
                else
                {
                    TempData.Add("EditPasswordMessage", "Пароли не совпадают");
                    return RedirectToAction("EditProfile");
                }
            }
            string userName = User.Identity.Name;
            User user = _userManager.Users.FirstOrDefault(u => u.UserName == userName);
            IdentityResult result = await _userManager.ChangePasswordAsync(user, OldPassword, NewPassword);
            if(result.Succeeded)
            {
                return RedirectToAction("Profile", new { name = userName });
            }
            else
            {
                if (TempData["EditPasswordMessage"] != null)
                {
                    TempData["EditPasswordMessage"] = "Неправильный пароль";
                    return RedirectToAction("EditProfile");
                }
                else
                {
                    TempData.Add("EditPasswordMessage", "Пароли не совпадают");
                    return RedirectToAction("EditProfile");
                }

            }
        }

        [HttpGet]
        [Authorize]
        public IActionResult Premium()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public IActionResult PaymentInfo(PremiumConfirmViewModel model)
        {
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> GetPremium(string user)
        {
            User _user = await _userManager.FindByNameAsync(user);
            await _userManager.AddToRoleAsync(_user, "Premium");
            return RedirectToAction("Success");
        }

        [HttpGet]
        public IActionResult Success()
        {
            return View();
        }
    }
}
