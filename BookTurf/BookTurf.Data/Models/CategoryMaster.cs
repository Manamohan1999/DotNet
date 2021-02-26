using System;
using System.Collections.Generic;

namespace BookTurf.Data.Models
{
    public partial class CategoryMaster
    {
        public CategoryMaster()
        {
            BookMaster = new HashSet<BookMaster>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ColorCode { get; set; }
        public string ColorName { get; set; }
        public string Description { get; set; }
        public bool? IsStatus { get; set; }
        public bool? IsDeleted { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual Login CreatedByNavigation { get; set; }
        public virtual Login ModifiedByNavigation { get; set; }
        public virtual ICollection<BookMaster> BookMaster { get; set; }
    }
}
