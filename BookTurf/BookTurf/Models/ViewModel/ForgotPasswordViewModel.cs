using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookTurf.Web.Models.ViewModel
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage ="Please Enter a Email-Id")]
        [EmailAddress(ErrorMessage ="Not a valid Email")]
        public string Email { get; set; }
    }
}
