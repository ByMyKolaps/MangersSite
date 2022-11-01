using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mangers.ViewModels
{
    public class PremiumConfirmViewModel
    {
        public int CardMonth { get; set; }
        public int CardYear { get; set; }
        [Required]
        [DataType(DataType.CreditCard, ErrorMessage = "Wrong card number!")]
        public string CardNumber { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string CCV { get; set; }
    }
}
