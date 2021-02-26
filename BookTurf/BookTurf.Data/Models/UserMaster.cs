using System;
using System.Collections.Generic;

namespace BookTurf.Data.Models
{
    public partial class UserMaster
    {
        public UserMaster()
        {
            BookDetails = new HashSet<BookDetails>();
            Login = new HashSet<Login>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public int? RoleId { get; set; }
        public DateTime? Dob { get; set; }
        public string Image { get; set; }
        public string UniversityName { get; set; }
        public DateTime? AnniversaryDate { get; set; }
        public string Grade { get; set; }
        public int? Gender { get; set; }
        public int? Age { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Zip { get; set; }
        public string Address { get; set; }
        public bool? IsStatus { get; set; }
        public bool? IsDeleted { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual Login CreatedByNavigation { get; set; }
        public virtual Login ModifiedByNavigation { get; set; }
        public virtual UserRole Role { get; set; }
        public virtual ICollection<BookDetails> BookDetails { get; set; }
        public virtual ICollection<Login> Login { get; set; }
    }
}
