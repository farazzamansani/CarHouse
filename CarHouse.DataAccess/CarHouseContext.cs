using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CarHouse.DataAccess
{
    public partial class CarHouseContext : DbContext
    {
        public CarHouseContext()
        {
        }

        public CarHouseContext(DbContextOptions<CarHouseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Car> Cars { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Sale> Sales { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=CarHouse;User ID=sa;Password=Password99;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity.Property(e => e.AdvertisedPrice).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Make).HasMaxLength(50);

                entity.Property(e => e.Model).HasMaxLength(100);

                entity.Property(e => e.Notes).HasMaxLength(2000);

                entity.Property(e => e.OdometerKm).HasColumnName("OdometerKM");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.ContactNumber)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.DriversLicenseNo).HasMaxLength(11);

                entity.Property(e => e.Email).HasMaxLength(150);

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.LastName).HasMaxLength(100);

                entity.Property(e => e.ResidentialPostCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ResidentialSuburb).HasMaxLength(100);
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.Property(e => e.SaleId).ValueGeneratedNever();

                entity.Property(e => e.AdvertisedPrice).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.SaleAmount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.SalesmanName).HasMaxLength(200);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
