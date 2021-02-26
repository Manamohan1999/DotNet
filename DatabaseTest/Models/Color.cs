using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseTest.Models
{
    public class Color
    {
        public int ID { get; set; }

        [Display(Name ="Color")]
        public string ColorHex { get; set; }
    }
}
