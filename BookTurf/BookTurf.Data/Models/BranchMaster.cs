using System;
using System.Collections.Generic;

namespace BookTurf.Data.Models
{
    public partial class BranchMaster
    {
        public BranchMaster()
        {
            BookDetails = new HashSet<BookDetails>();
            Login = new HashSet<Login>();
        }

        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public string BranchCode { get; set; }
        public string Model { get; set; }
        public bool? IsStatus { get; set; }
        public bool? IsDeleted { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual Login CreatedByNavigation { get; set; }
        public virtual Login ModifiedByNavigation { get; set; }
        public virtual ICollection<BookDetails> BookDetails { get; set; }
        public virtual ICollection<Login> Login { get; set; }
    }
}
