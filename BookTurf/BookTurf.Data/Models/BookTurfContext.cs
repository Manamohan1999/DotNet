
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BookTurf.Data.Models
{
    public partial class BookTurfContext : DbContext
    {
        public BookTurfContext()
        {
        }

        public BookTurfContext(DbContextOptions<BookTurf> options)
            : base(options)
        {
        }

        public virtual DbSet<BookDetails> BookDetails { get; set; }
        public virtual DbSet<BookMaster> BookMaster { get; set; }
        public virtual DbSet<BranchMaster> BranchMaster { get; set; }
        public virtual DbSet<CategoryMaster> CategoryMaster { get; set; }
        public virtual DbSet<ConstantCode> ConstantCode { get; set; }
        public virtual DbSet<ConstantMaster> ConstantMaster { get; set; }
        public virtual DbSet<CouponChild> CouponChild { get; set; }
        public virtual DbSet<CouponMaster> CouponMaster { get; set; }
        public virtual DbSet<Form> Form { get; set; }
        public virtual DbSet<GenreMaster> GenreMaster { get; set; }
        public virtual DbSet<IssueRequest> IssueRequest { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<PartyMaster> PartyMaster { get; set; }
        public virtual DbSet<RoleFormMapping> RoleFormMapping { get; set; }
        public virtual DbSet<SubscriptionMaster> SubscriptionMaster { get; set; }
        public virtual DbSet<UserMaster> UserMaster { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<UserSubscriptionMapping> UserSubscriptionMapping { get; set; }
        public virtual DbSet<VolumeMaster> VolumeMaster { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=159.65.151.134;Database=BookTurf;Trusted_Connection=True;User Id=sa;Password=Mkr5htg!;Integrated Security=false;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookDetails>(entity =>
            {
                entity.Property(e => e.BarCode)
                    .HasMaxLength(48)
                    .IsUnicode(false);

                entity.Property(e => e.BarCodeImageUrl)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsStatus)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Reason)
                    .HasMaxLength(48)
                    .IsUnicode(false);

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.BookDetails)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK_BookDetails_BookMaster");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.BookDetails)
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("FK_BookDetails_BranchMaster");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.BookDetailsCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_BookDetails_Login");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.BookDetailsModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_BookDetails_Login1");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.BookDetails)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_BookDetails_ConstantCode");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BookDetails)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_BookDetails_UserMaster");
            });

            modelBuilder.Entity<BookMaster>(entity =>
            {
                entity.HasKey(e => e.BookId);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Details)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.EntryDate).HasColumnType("date");

                entity.Property(e => e.IsStatus)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Isbnno)
                    .HasColumnName("ISBNNo")
                    .HasMaxLength(48)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PublishDate).HasColumnType("date");

                entity.Property(e => e.Title)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.BookMasterAuthor)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK_BookMaster_PartyMaster1");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.BookMaster)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_BookMaster_CategoryMaster");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.BookMasterCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_BookMaster_Login");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.BookMasterModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_BookMaster_Login1");

                entity.HasOne(d => d.Publisher)
                    .WithMany(p => p.BookMasterPublisher)
                    .HasForeignKey(d => d.PublisherId)
                    .HasConstraintName("FK_BookMaster_PartyMaster");

                entity.HasOne(d => d.Volume)
                    .WithMany(p => p.BookMaster)
                    .HasForeignKey(d => d.VolumeId)
                    .HasConstraintName("FK_BookMaster_VolumeMaster");
            });

            modelBuilder.Entity<BranchMaster>(entity =>
            {
                entity.HasKey(e => e.BranchId);

                entity.Property(e => e.BranchCode)
                    .HasMaxLength(48)
                    .IsUnicode(false);

                entity.Property(e => e.BranchName)
                    .HasMaxLength(48)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsStatus).HasDefaultValueSql("((1))");

                entity.Property(e => e.Model)
                    .HasMaxLength(48)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.BranchMasterCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_BranchMaster_Login");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.BranchMasterModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_BranchMaster_Login1");
            });

            modelBuilder.Entity<CategoryMaster>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(48)
                    .IsUnicode(false);

                entity.Property(e => e.ColorCode)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.ColorName)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsStatus).HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.CategoryMasterCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_CategoryMaster_Login");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.CategoryMasterModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_CategoryMaster_Login1");
            });

            modelBuilder.Entity<ConstantCode>(entity =>
            {
                entity.Property(e => e.Code)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsStatus).HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.ConstantCodeCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_ConstantCode_Login");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.ConstantCodeModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_ConstantCode_Login1");
            });

            modelBuilder.Entity<ConstantMaster>(entity =>
            {
                entity.HasKey(e => e.ConstantId);

                entity.Property(e => e.ConstantName)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsStatus).HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.ConstantMasterCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_ConstantMaster_Login");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.ConstantMasterModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_ConstantMaster_Login1");
            });

            modelBuilder.Entity<CouponChild>(entity =>
            {
                entity.HasKey(e => e.CouponId);

                entity.Property(e => e.CouponCode)
                    .HasMaxLength(24)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsStatus).HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.CouponMaster)
                    .WithMany(p => p.CouponChild)
                    .HasForeignKey(d => d.CouponMasterId)
                    .HasConstraintName("FK_CouponChild_CouponMaster");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.CouponChildCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_CouponChild_Login");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.CouponChildModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_CouponChild_Login1");

                entity.HasOne(d => d.Subscription)
                    .WithMany(p => p.CouponChild)
                    .HasForeignKey(d => d.SubscriptionId)
                    .HasConstraintName("FK_CouponChild_SubscriptionMaster");
            });

            modelBuilder.Entity<CouponMaster>(entity =>
            {
                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasMaxLength(48)
                    .IsUnicode(false);

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsStatus).HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .HasMaxLength(48)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNo)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.CouponMasterCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_CouponMaster_Login");

                entity.HasOne(d => d.Login)
                    .WithMany(p => p.CouponMasterLogin)
                    .HasForeignKey(d => d.LoginId)
                    .HasConstraintName("FK_CouponMaster_Login2");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.CouponMasterModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_CouponMaster_Login1");
            });

            modelBuilder.Entity<Form>(entity =>
            {
                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FormName)
                    .HasMaxLength(48)
                    .IsUnicode(false);

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsStatus).HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.FormCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_Form_Login");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.FormModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_Form_Login1");
            });

            modelBuilder.Entity<GenreMaster>(entity =>
            {
                entity.HasKey(e => e.GenreId);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsStatus).HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .HasMaxLength(48)
                    .IsUnicode(false);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.GenreMasterCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_GenreMaster_Login");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.GenreMasterModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_GenreMaster_Login1");
            });

            modelBuilder.Entity<IssueRequest>(entity =>
            {
                entity.HasKey(e => e.RequestId);

                entity.Property(e => e.AvailableTime).HasColumnType("datetime");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsStatus)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RequestDate).HasColumnType("datetime");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.IssueRequest)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK_IssueRequest_BookMaster");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.IssueRequestCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_IssueRequest_Login1");

                entity.HasOne(d => d.Login)
                    .WithMany(p => p.IssueRequestLogin)
                    .HasForeignKey(d => d.LoginId)
                    .HasConstraintName("FK_IssueRequest_Login");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.IssueRequestModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_IssueRequest_Login2");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EmpCode)
                    .HasMaxLength(56)
                    .IsUnicode(false);

                entity.Property(e => e.IsStatus)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Password)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Token).IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.Login)
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("FK_Login_BranchMaster");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Login)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_Login_UserRole");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Login)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Login_UserMaster");
            });

            modelBuilder.Entity<PartyMaster>(entity =>
            {
                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(48)
                    .IsUnicode(false);

                entity.Property(e => e.Image)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsStatus).HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .HasMaxLength(48)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNo)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.PartyMasterCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_PartyMaster_Login");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.PartyMasterModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_PartyMaster_Login1");

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.PartyMaster)
                    .HasForeignKey(d => d.UserTypeId)
                    .HasConstraintName("FK_PartyMaster_ConstantCode");
            });

            modelBuilder.Entity<RoleFormMapping>(entity =>
            {
                entity.HasKey(e => e.FormMappingId);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsStatus).HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.RoleFormMappingCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_RoleFormMapping_Login");

                entity.HasOne(d => d.Form)
                    .WithMany(p => p.RoleFormMapping)
                    .HasForeignKey(d => d.FormId)
                    .HasConstraintName("FK_RoleFormMapping_Form");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.RoleFormMappingModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_RoleFormMapping_Login1");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleFormMapping)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_RoleFormMapping_UserRole");
            });

            modelBuilder.Entity<SubscriptionMaster>(entity =>
            {
                entity.HasKey(e => e.SubscriptionId);

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsStatus).HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PlanName)
                    .HasMaxLength(48)
                    .IsUnicode(false);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.SubscriptionMasterCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_SubscriptionMaster_Login");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.SubscriptionMasterModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_SubscriptionMaster_Login1");
            });

            modelBuilder.Entity<UserMaster>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.Address)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.AnniversaryDate).HasColumnType("date");

                entity.Property(e => e.City)
                    .HasMaxLength(48)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(48)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(48)
                    .IsUnicode(false);

                entity.Property(e => e.Grade)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Image).IsUnicode(false);

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsStatus).HasDefaultValueSql("((1))");

                entity.Property(e => e.LastName)
                    .HasMaxLength(48)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PhoneNo)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(48)
                    .IsUnicode(false);

                entity.Property(e => e.UniversityName)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Zip)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.UserMasterCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_UserMaster_Login");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.UserMasterModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_UserMaster_Login1");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserMaster)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_UserMaster_UserRole");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsStatus).HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.UserRoleCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_UserRole_Login");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.UserRoleModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_UserRole_Login1");
            });

            modelBuilder.Entity<UserSubscriptionMapping>(entity =>
            {
                entity.HasKey(e => e.MappingId);

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsStatus).HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.TransanctionId)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.ValidityDate).HasColumnType("date");

                entity.HasOne(d => d.Coupon)
                    .WithMany(p => p.UserSubscriptionMapping)
                    .HasForeignKey(d => d.CouponId)
                    .HasConstraintName("FK_UserSubscriptionMapping_CouponChild");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.UserSubscriptionMappingCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_UserSubscriptionMapping_Login1");

                entity.HasOne(d => d.Login)
                    .WithMany(p => p.UserSubscriptionMappingLogin)
                    .HasForeignKey(d => d.LoginId)
                    .HasConstraintName("FK_UserSubscriptionMapping_Login");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.UserSubscriptionMappingModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_UserSubscriptionMapping_Login2");

                entity.HasOne(d => d.Subscription)
                    .WithMany(p => p.UserSubscriptionMapping)
                    .HasForeignKey(d => d.SubscriptionId)
                    .HasConstraintName("FK_UserSubscriptionMapping_SubscriptionMaster");
            });

            modelBuilder.Entity<VolumeMaster>(entity =>
            {
                entity.HasKey(e => e.VolumeId);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsStatus).HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .HasMaxLength(48)
                    .IsUnicode(false);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.VolumeMasterCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_VolumeMaster_Login");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.VolumeMasterModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_VolumeMaster_Login1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
