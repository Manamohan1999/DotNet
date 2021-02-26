using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookTurf.Web.Models
{
    public class Login
    {
        [Required(ErrorMessage =" Enter User Id")]
        [EmailAddress(ErrorMessage =" Enter a valid User ID")]
        public string UserId { get; set; }

        [Required(ErrorMessage =" Enter Password")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}