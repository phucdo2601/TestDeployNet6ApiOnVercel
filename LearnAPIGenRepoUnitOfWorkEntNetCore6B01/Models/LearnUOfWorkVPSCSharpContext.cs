using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LearnAPIGenRepoUnitOfWorkEntNetCore6B01.Models
{
    public partial class LearnUOfWorkVPSCSharpContext : DbContext
    {
        public LearnUOfWorkVPSCSharpContext()
        {
        }

        public LearnUOfWorkVPSCSharpContext(DbContextOptions<LearnUOfWorkVPSCSharpContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BookingInfo> BookingInfos { get; set; } = null!;
        public virtual DbSet<Bucountry> Bucountries { get; set; } = null!;
        public virtual DbSet<Car> Cars { get; set; } = null!;
        public virtual DbSet<CostCenter> CostCenters { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<Driver> Drivers { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserType> UserTypes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-7CKON28R\\SQLEXPRESS;Initial Catalog=LearnUOfWorkVPSCSharp;User ID=sa;Password=12345678");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookingInfo>(entity =>
            {
                entity.HasKey(e => e.CbId);

                entity.ToTable("BookingInfo");

                entity.Property(e => e.CbCreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CbCustomer).HasMaxLength(250);

                entity.Property(e => e.CbDeparrturePlace).HasMaxLength(250);

                entity.Property(e => e.CbDestinationPlace).HasMaxLength(250);

                entity.Property(e => e.CbEndDate).HasColumnType("datetime");

                entity.Property(e => e.CbLastUpdate).HasColumnType("datetime");

                entity.Property(e => e.CbOrg).HasMaxLength(250);

                entity.Property(e => e.CbRemarks).HasMaxLength(250);

                entity.Property(e => e.CbStaff).HasMaxLength(250);

                entity.Property(e => e.CbStaffNo).HasMaxLength(250);

                entity.Property(e => e.CbStartDate).HasColumnType("datetime");

                entity.Property(e => e.CbStatus).HasMaxLength(250);
            });

            modelBuilder.Entity<Bucountry>(entity =>
            {
                entity.ToTable("Bucountry");

                entity.Property(e => e.Bu).HasMaxLength(250);

                entity.Property(e => e.Bucode).HasMaxLength(250);

                entity.Property(e => e.Country).HasMaxLength(250);
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.ToTable("Car");

                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.PlateNo).HasMaxLength(250);
            });

            modelBuilder.Entity<CostCenter>(entity =>
            {
                entity.ToTable("CostCenter");

                entity.Property(e => e.CcName).HasMaxLength(250);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Ccode)
                    .HasMaxLength(250)
                    .HasColumnName("CCode");

                entity.Property(e => e.Cflag).HasColumnName("CFlag");

                entity.Property(e => e.Cname)
                    .HasMaxLength(250)
                    .HasColumnName("CName");

                entity.Property(e => e.Ctype)
                    .HasMaxLength(250)
                    .HasColumnName("CType");
            });

            modelBuilder.Entity<Driver>(entity =>
            {
                entity.ToTable("Driver");

                entity.Property(e => e.EmailAdd).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.PhoneNo).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Uid);

                entity.ToTable("User");

                entity.Property(e => e.Uid).HasColumnName("UId");

                entity.Property(e => e.BcId).HasMaxLength(50);

                entity.Property(e => e.EmailAddress).HasMaxLength(50);

                entity.Property(e => e.MobileNo).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(250);
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.ToTable("UserType");

                entity.Property(e => e.UserTypeName).HasMaxLength(250);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
