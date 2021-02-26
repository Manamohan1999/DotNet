using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookTurf.Web.Models.ViewModel
{
    public class ResetPasswordViewModel
    {
        [Required]
        public string  Password { get; set; }

        [Required]
        [Display(Name ="Confirm Password")]
        [Compare("Password", ErrorMessage="Password and ConfirmPassword does not match.")]
        public string  ConfirmPassword { get; set; }
    }
}
