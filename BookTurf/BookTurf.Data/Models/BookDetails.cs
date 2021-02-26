using System;
using System.Collections.Generic;

namespace BookTurf.Data.Models
{
    public partial class BookDetails
    {
        public int BookDetailsId { get; set; }
        public decimal? Price { get; set; }
        public int? BranchId { get; set; }
        public int? UserId { get; set; }
        public int? BookId { get; set; }
        public bool? IsLost { get; set; }
        public bool? IsDamaged { get; set; }
        public string Reason { get; set; }
        public string BarCode { get; set; }
        public int? StatusId { get; set; }
        public string BarCodeImageUrl { get; set; }
        public bool? IsStatus { get; set; }
        public bool IsDeleted { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual BookMaster Book { get; set; }
        public virtual BranchMaster Branch { get; set; }
        public virtual Login CreatedByNavigation { get; set; }
        public virtual Login ModifiedByNavigation { get; set; }
        public virtual ConstantCode Status { get; set; }
        public virtual UserMaster User { get; set; }
    }
}
