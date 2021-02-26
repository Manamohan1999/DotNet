using System;
using System.Collections.Generic;

namespace BookTurf.Data.Models
{
    public partial class ConstantCode
    {
        public ConstantCode()
        {
            BookDetails = new HashSet<BookDetails>();
            PartyMaster = new HashSet<PartyMaster>();
        }

        public int ConstantCodeId { get; set; }
        public int? ConstantId { get; set; }
        public string Code { get; set; }
        public bool? IsStatus { get; set; }
        public bool? IsDeleted { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual Login CreatedByNavigation { get; set; }
        public virtual Login ModifiedByNavigation { get; set; }
        public virtual ICollection<BookDetails> BookDetails { get; set; }
        public virtual ICollection<PartyMaster> PartyMaster { get; set; }
    }
}
