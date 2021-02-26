using System;
using System.Collections.Generic;

namespace BookTurf.Data.Models
{
    public partial class ConstantMaster
    {
        public int ConstantId { get; set; }
        public string ConstantName { get; set; }
        public bool? IsStatus { get; set; }
        public bool? IsDeleted { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual Login CreatedByNavigation { get; set; }
        public virtual Login ModifiedByNavigation { get; set; }
    }
}
