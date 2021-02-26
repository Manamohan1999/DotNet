using System;
using System.Collections.Generic;

namespace BookTurf.Data.Models
{
    public partial class UserRole
    {
        public UserRole()
        {
            Login = new HashSet<Login>();
            RoleFormMapping = new HashSet<RoleFormMapping>();
            UserMaster = new HashSet<UserMaster>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool? IsEdit { get; set; }
        public bool? IsStatus { get; set; }
        public bool? IsDeleted { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual Login CreatedByNavigation { get; set; }
        public virtual Login ModifiedByNavigation { get; set; }
        public virtual ICollection<Login> Login { get; set; }
        public virtual ICollection<RoleFormMapping> RoleFormMapping { get; set; }
        public virtual ICollection<UserMaster> UserMaster { get; set; }
    }
}
