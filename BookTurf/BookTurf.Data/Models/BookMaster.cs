using System;
using System.Collections.Generic;

namespace BookTurf.Data.Models
{
    public partial class BookMaster
    {
        public BookMaster()
        {
            BookDetails = new HashSet<BookDetails>();
            IssueRequest = new HashSet<IssueRequest>();
        }

        public int BookId { get; set; }
        public string Title { get; set; }
        public string Isbnno { get; set; }
        public int? AuthorId { get; set; }
        public int? PublisherId { get; set; }
        public int? CategoryId { get; set; }
        public int? VolumeId { get; set; }
        public DateTime? EntryDate { get; set; }
        public DateTime? PublishDate { get; set; }
        public bool? IsIssuable { get; set; }
        public int? AvailableQuantity { get; set; }
        public string Details { get; set; }
        public bool? IsStatus { get; set; }
        public bool IsDeleted { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual PartyMaster Author { get; set; }
        public virtual CategoryMaster Category { get; set; }
        public virtual Login CreatedByNavigation { get; set; }
        public virtual Login ModifiedByNavigation { get; set; }
        public virtual PartyMaster Publisher { get; set; }
        public virtual VolumeMaster Volume { get; set; }
        public virtual ICollection<BookDetails> BookDetails { get; set; }
        public virtual ICollection<IssueRequest> IssueRequest { get; set; }
    }
}
