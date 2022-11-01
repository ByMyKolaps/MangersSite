using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mangers.ViewModels
{
    public class RegistrationViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Email")]
        [RegularExpression(@"[a-zA-Z0-9]+@[a-zA-Z0-9]+\.[a-zA-Z0-9]+", ErrorMessage = "Некорректный email")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public string ReturnUrl { get; set; }
        public IList<AuthenticationScheme> ExternalLogins { get; set; }
    }
}
