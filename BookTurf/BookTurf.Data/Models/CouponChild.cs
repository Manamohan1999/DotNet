using System;
using System.Collections.Generic;

namespace BookTurf.Data.Models
{
    public partial class CouponChild
    {
        public CouponChild()
        {
            UserSubscriptionMapping = new HashSet<UserSubscriptionMapping>();
        }

        public int CouponId { get; set; }
        public int? CouponMasterId { get; set; }
        public string CouponCode { get; set; }
        public int? SubscriptionId { get; set; }
        public DateTime? StartDate { get; set; }
        public bool? IsUsed { get; set; }
        public bool? IsStatus { get; set; }
        public bool? IsDeleted { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual CouponMaster CouponMaster { get; set; }
        public virtual Login CreatedByNavigation { get; set; }
        public virtual Login ModifiedByNavigation { get; set; }
        public virtual SubscriptionMaster Subscription { get; set; }
        public virtual ICollection<UserSubscriptionMapping> UserSubscriptionMapping { get; set; }
    }
}
