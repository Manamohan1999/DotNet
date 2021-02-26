using System;
using System.Collections.Generic;

namespace BookTurf.Data.Models
{
    public partial class Form
    {
        public Form()
        {
            RoleFormMapping = new HashSet<RoleFormMapping>();
        }

        public int FormId { get; set; }
        public string FormName { get; set; }
        public bool? IsStatus { get; set; }
        public bool? IsDeleted { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual Login CreatedByNavigation { get; set; }
        public virtual Login ModifiedByNavigation { get; set; }
        public virtual ICollection<RoleFormMapping> RoleFormMapping { get; set; }
    }
}
