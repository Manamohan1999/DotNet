using System;
using System.Collections.Generic;

namespace BookTurf.Data.Models
{
    public partial class UserSubscriptionMapping
    {
        public int MappingId { get; set; }
        public int? LoginId { get; set; }
        public int? SubscriptionId { get; set; }
        public decimal? Amount { get; set; }
        public int? CouponId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? ValidityDate { get; set; }
        public string TransanctionId { get; set; }
        public bool? IsExpired { get; set; }
        public bool? IsStatus { get; set; }
        public bool? IsDeleted { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual CouponChild Coupon { get; set; }
        public virtual Login CreatedByNavigation { get; set; }
        public virtual Login Login { get; set; }
        public virtual Login ModifiedByNavigation { get; set; }
        public virtual SubscriptionMaster Subscription { get; set; }
    }
}
