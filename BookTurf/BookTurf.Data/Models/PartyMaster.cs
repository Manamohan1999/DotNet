using System;
using System.Collections.Generic;

namespace BookTurf.Data.Models
{
    public partial class PartyMaster
    {
        public PartyMaster()
        {
            BookMasterAuthor = new HashSet<BookMaster>();
            BookMasterPublisher = new HashSet<BookMaster>();
        }

        public int PartyMasterId { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int? UserTypeId { get; set; }
        public bool? IsStatus { get; set; }
        public bool? IsDeleted { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual Login CreatedByNavigation { get; set; }
        public virtual Login ModifiedByNavigation { get; set; }
        public virtual ConstantCode UserType { get; set; }
        public virtual ICollection<BookMaster> BookMasterAuthor { get; set; }
        public virtual ICollection<BookMaster> BookMasterPublisher { get; set; }
    }
}
