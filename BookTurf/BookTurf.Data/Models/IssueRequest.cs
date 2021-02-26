using System;
using System.Collections.Generic;

namespace BookTurf.Data.Models
{
    public partial class IssueRequest
    {
        public int RequestId { get; set; }
        public int? LoginId { get; set; }
        public DateTime? RequestDate { get; set; }
        public int? BookId { get; set; }
        public bool? Status { get; set; }
        public DateTime? AvailableTime { get; set; }
        public bool? IsStatus { get; set; }
        public bool IsDeleted { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual BookMaster Book { get; set; }
        public virtual Login CreatedByNavigation { get; set; }
        public virtual Login Login { get; set; }
        public virtual Login ModifiedByNavigation { get; set; }
    }
}
