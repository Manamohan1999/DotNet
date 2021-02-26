using System;
using System.Collections.Generic;

namespace BookTurf.Data.Models
{
    public partial class SubscriptionMaster
    {
        public SubscriptionMaster()
        {
            CouponChild = new HashSet<CouponChild>();
            UserSubscriptionMapping = new HashSet<UserSubscriptionMapping>();
        }

        public int SubscriptionId { get; set; }
        public string PlanName { get; set; }
        public decimal? Amount { get; set; }
        public int? Duration { get; set; }
        public string Description { get; set; }
        public int? TotalBooks { get; set; }
        public bool? IsStatus { get; set; }
        public bool? IsDeleted { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual Login CreatedByNavigation { get; set; }
        public virtual Login ModifiedByNavigation { get; set; }
        public virtual ICollection<CouponChild> CouponChild { get; set; }
        public virtual ICollection<UserSubscriptionMapping> UserSubscriptionMapping { get; set; }
    }
}
