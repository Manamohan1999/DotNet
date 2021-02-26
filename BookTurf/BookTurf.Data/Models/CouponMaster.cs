using System;
using System.Collections.Generic;

namespace BookTurf.Data.Models
{
    public partial class CouponMaster
    {
        public CouponMaster()
        {
            CouponChild = new HashSet<CouponChild>();
        }

        public int CouponMasterId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public int? Count { get; set; }
        public int? LoginId { get; set; }
        public bool? IsStatus { get; set; }
        public bool? IsDeleted { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual Login CreatedByNavigation { get; set; }
        public virtual Login Login { get; set; }
        public virtual Login ModifiedByNavigation { get; set; }
        public virtual ICollection<CouponChild> CouponChild { get; set; }
    }
}
