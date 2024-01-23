using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Mangers.Models;
using Mangers.ViewModels;
using MangersDAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Mangers.Controllers
{
    public class AccountController : Controller
    {
        readonly UserManager<User> _userManager;
        readonly SignInManager<User> _signInManager;
        readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(RegistrationViewModel registrationViewModel)
        {
            if(ModelState.IsValid)
            {
                User user = new User
                {
                    UserName = registrationViewModel.UserName,
                    Email = registrationViewModel.Email
                };
                var result = await _userManager.CreateAsync(user, registrationViewModel.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Basic");
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        if (error.Code == "DuplicateUserName")
                            ModelState.AddModelError(string.Empty, "Данный ник уже занят, выбери другой");
                        if (error.Code == "DuplicateEmail")
                            ModelState.AddModelError(string.Empty, "Данный email уже занят, выбери другой");
                        if (error.Code == "PasswordTooShort")
                            ModelState.AddModelError(string.Empty, "Твой пароль слишком короткий");
                        if (error.Code == "PasswordRequiresNonAlphanumeric")
                            ModelState.AddModelError(string.Empty, "Пароль должен содержать какой-нибудь спец.символ");
                        if (error.Code == "PasswordRequiresLower")
                            ModelState.AddModelError(string.Empty, "Надо добавить в пароль маленькие буквы");
                        if (error.Code == "PasswordRequiresUpper")
                            ModelState.AddModelError(string.Empty, "Надо добавить в пароль большие буквы");
                        if (error.Code == "PasswordRequiresUpper")
                            ModelState.AddModelError(string.Empty, "Надо добавить в пароль циферки");
                        if (error.Code == "InvalidUserName")
                            ModelState.AddModelError(string.Empty, "Твой ник должен содержать только буквы и цифры (без пробелов)");
                    }
                }
            }

            if (ModelState["Email"].ValidationState == ModelValidationState.Invalid)
            {
                ModelState.AddModelError(string.Empty, "Некорректный email");
            }

            if(ModelState["ConfirmPassword"].ValidationState == ModelValidationState.Invalid)
            {
                ModelState.AddModelError(string.Empty, "Пароли не совпадают");
            }    

            return View(registrationViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> SignIn(string returnUrl)
        {
            SignInViewModel model = new SignInViewModel
            {
                ReturnUrl = returnUrl,
                ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel signInViewModel)
        {
            if(ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(signInViewModel.UserName, signInViewModel.Password, false, false);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Неправильный логин и (или) пароль");
                }
            }
            return View(signInViewModel);
        }

        [HttpPost]
        public IActionResult ExternalLogin(string provider, string returnUrl)
        {
            var redirectUrl = Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return new ChallengeResult(provider, properties);
        }

        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            SignInViewModel model = new SignInViewModel
            {
                ReturnUrl = returnUrl,
                ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };

            if(remoteError != null)
            {
                ModelState.AddModelError(string.Empty, $"Ошибка, исходящая от удаленного провайдера: {remoteError}");
                return View("SignIn", model);
            }

            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                ModelState.AddModelError(string.Empty, $"Ошибка загрузки информации удаленного провайдера");
                return View("SignIn", model);
            }
            var signInResult = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider,
                                        info.ProviderKey, isPersistent: false, bypassTwoFactor: false);

            if (signInResult.Succeeded)
            {
                LocalRedirect(returnUrl);
            }
            else
            {
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);

                if(email != null)
                {
                    var user = await _userManager.FindByEmailAsync(email);

                    if (user == null)
                    {
                        user = new User
                        {
                            UserName = info.Principal.FindFirstValue(ClaimTypes.Name),
                            Email = info.Principal.FindFirstValue(ClaimTypes.Email)
                        };

                        await _userManager.CreateAsync(user);
                    }    

                    await _userManager.AddLoginAsync(user, info);
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return LocalRedirect(returnUrl);
                }

                ViewBag.ErrorTitle = $"Мыло не пришло от {info.LoginProvider}";
                ViewBag.ErrorMessage = $"Обратитесь за помощью на мыло muradymov.bulat@mail.ru";

                return View("Error");
            }
            return View("Login", model);
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
