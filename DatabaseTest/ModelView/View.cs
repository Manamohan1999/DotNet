using DatabaseTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseTest.ModelView
{
    public class View
    {
        public IEnumerable<Student> students { get; set; }
        public IEnumerable<Address> addresses { get; set; }
        public List<StudentAddressViewModel> studentView { get; set; }
    }
}
