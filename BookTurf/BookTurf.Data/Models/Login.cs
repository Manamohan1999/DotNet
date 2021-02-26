using System;
using System.Collections.Generic;

namespace BookTurf.Data.Models
{
    public partial class Login
    {
        public Login()
        {
            BookDetailsCreatedByNavigation = new HashSet<BookDetails>();
            BookDetailsModifiedByNavigation = new HashSet<BookDetails>();
            BookMasterCreatedByNavigation = new HashSet<BookMaster>();
            BookMasterModifiedByNavigation = new HashSet<BookMaster>();
            BranchMasterCreatedByNavigation = new HashSet<BranchMaster>();
            BranchMasterModifiedByNavigation = new HashSet<BranchMaster>();
            CategoryMasterCreatedByNavigation = new HashSet<CategoryMaster>();
            CategoryMasterModifiedByNavigation = new HashSet<CategoryMaster>();
            ConstantCodeCreatedByNavigation = new HashSet<ConstantCode>();
            ConstantCodeModifiedByNavigation = new HashSet<ConstantCode>();
            ConstantMasterCreatedByNavigation = new HashSet<ConstantMaster>();
            ConstantMasterModifiedByNavigation = new HashSet<ConstantMaster>();
            CouponChildCreatedByNavigation = new HashSet<CouponChild>();
            CouponChildModifiedByNavigation = new HashSet<CouponChild>();
            CouponMasterCreatedByNavigation = new HashSet<CouponMaster>();
            CouponMasterLogin = new HashSet<CouponMaster>();
            CouponMasterModifiedByNavigation = new HashSet<CouponMaster>();
            FormCreatedByNavigation = new HashSet<Form>();
            FormModifiedByNavigation = new HashSet<Form>();
            GenreMasterCreatedByNavigation = new HashSet<GenreMaster>();
            GenreMasterModifiedByNavigation = new HashSet<GenreMaster>();
            IssueRequestCreatedByNavigation = new HashSet<IssueRequest>();
            IssueRequestLogin = new HashSet<IssueRequest>();
            IssueRequestModifiedByNavigation = new HashSet<IssueRequest>();
            PartyMasterCreatedByNavigation = new HashSet<PartyMaster>();
            PartyMasterModifiedByNavigation = new HashSet<PartyMaster>();
            RoleFormMappingCreatedByNavigation = new HashSet<RoleFormMapping>();
            RoleFormMappingModifiedByNavigation = new HashSet<RoleFormMapping>();
            SubscriptionMasterCreatedByNavigation = new HashSet<SubscriptionMaster>();
            SubscriptionMasterModifiedByNavigation = new HashSet<SubscriptionMaster>();
            UserMasterCreatedByNavigation = new HashSet<UserMaster>();
            UserMasterModifiedByNavigation = new HashSet<UserMaster>();
            UserRoleCreatedByNavigation = new HashSet<UserRole>();
            UserRoleModifiedByNavigation = new HashSet<UserRole>();
            UserSubscriptionMappingCreatedByNavigation = new HashSet<UserSubscriptionMapping>();
            UserSubscriptionMappingLogin = new HashSet<UserSubscriptionMapping>();
            UserSubscriptionMappingModifiedByNavigation = new HashSet<UserSubscriptionMapping>();
            VolumeMasterCreatedByNavigation = new HashSet<VolumeMaster>();
            VolumeMasterModifiedByNavigation = new HashSet<VolumeMaster>();
        }

        public int LoginId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int? BranchId { get; set; }
        public int? RoleId { get; set; }
        public int? UserId { get; set; }
        public string EmpCode { get; set; }
        public string Token { get; set; }
        public bool? IsStatus { get; set; }
        public bool IsDeleted { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual BranchMaster Branch { get; set; }
        public virtual UserRole Role { get; set; }
        public virtual UserMaster User { get; set; }
        public virtual ICollection<BookDetails> BookDetailsCreatedByNavigation { get; set; }
        public virtual ICollection<BookDetails> BookDetailsModifiedByNavigation { get; set; }
        public virtual ICollection<BookMaster> BookMasterCreatedByNavigation { get; set; }
        public virtual ICollection<BookMaster> BookMasterModifiedByNavigation { get; set; }
        public virtual ICollection<BranchMaster> BranchMasterCreatedByNavigation { get; set; }
        public virtual ICollection<BranchMaster> BranchMasterModifiedByNavigation { get; set; }
        public virtual ICollection<CategoryMaster> CategoryMasterCreatedByNavigation { get; set; }
        public virtual ICollection<CategoryMaster> CategoryMasterModifiedByNavigation { get; set; }
        public virtual ICollection<ConstantCode> ConstantCodeCreatedByNavigation { get; set; }
        public virtual ICollection<ConstantCode> ConstantCodeModifiedByNavigation { get; set; }
        public virtual ICollection<ConstantMaster> ConstantMasterCreatedByNavigation { get; set; }
        public virtual ICollection<ConstantMaster> ConstantMasterModifiedByNavigation { get; set; }
        public virtual ICollection<CouponChild> CouponChildCreatedByNavigation { get; set; }
        public virtual ICollection<CouponChild> CouponChildModifiedByNavigation { get; set; }
        public virtual ICollection<CouponMaster> CouponMasterCreatedByNavigation { get; set; }
        public virtual ICollection<CouponMaster> CouponMasterLogin { get; set; }
        public virtual ICollection<CouponMaster> CouponMasterModifiedByNavigation { get; set; }
        public virtual ICollection<Form> FormCreatedByNavigation { get; set; }
        public virtual ICollection<Form> FormModifiedByNavigation { get; set; }
        public virtual ICollection<GenreMaster> GenreMasterCreatedByNavigation { get; set; }
        public virtual ICollection<GenreMaster> GenreMasterModifiedByNavigation { get; set; }
        public virtual ICollection<IssueRequest> IssueRequestCreatedByNavigation { get; set; }
        public virtual ICollection<IssueRequest> IssueRequestLogin { get; set; }
        public virtual ICollection<IssueRequest> IssueRequestModifiedByNavigation { get; set; }
        public virtual ICollection<PartyMaster> PartyMasterCreatedByNavigation { get; set; }
        public virtual ICollection<PartyMaster> PartyMasterModifiedByNavigation { get; set; }
        public virtual ICollection<RoleFormMapping> RoleFormMappingCreatedByNavigation { get; set; }
        public virtual ICollection<RoleFormMapping> RoleFormMappingModifiedByNavigation { get; set; }
        public virtual ICollection<SubscriptionMaster> SubscriptionMasterCreatedByNavigation { get; set; }
        public virtual ICollection<SubscriptionMaster> SubscriptionMasterModifiedByNavigation { get; set; }
        public virtual ICollection<UserMaster> UserMasterCreatedByNavigation { get; set; }
        public virtual ICollection<UserMaster> UserMasterModifiedByNavigation { get; set; }
        public virtual ICollection<UserRole> UserRoleCreatedByNavigation { get; set; }
        public virtual ICollection<UserRole> UserRoleModifiedByNavigation { get; set; }
        public virtual ICollection<UserSubscriptionMapping> UserSubscriptionMappingCreatedByNavigation { get; set; }
        public virtual ICollection<UserSubscriptionMapping> UserSubscriptionMappingLogin { get; set; }
        public virtual ICollection<UserSubscriptionMapping> UserSubscriptionMappingModifiedByNavigation { get; set; }
        public virtual ICollection<VolumeMaster> VolumeMasterCreatedByNavigation { get; set; }
        public virtual ICollection<VolumeMaster> VolumeMasterModifiedByNavigation { get; set; }
    }
}
