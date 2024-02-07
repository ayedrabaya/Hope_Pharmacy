using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HopePharmacy.Entities
{
    public partial class HopeDecemberPharmacyContext : DbContext
    {
        public HopeDecemberPharmacyContext()
        {
        }

        public HopeDecemberPharmacyContext(DbContextOptions<HopeDecemberPharmacyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Manufacture> Manufactures { get; set; }
        public virtual DbSet<Medicine> Medicines { get; set; }
        public virtual DbSet<MedicineSupplier> MedicineSuppliers { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server= AYED-PC\\AYED;Database= HopeDecemberPharmacy;Trusted_Connection=True; User Id=sa;password=0592941591;Integrated Security=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.JoinDate).HasColumnType("date");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Mobile)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Position).HasMaxLength(50);

                entity.Property(e => e.Qualifications)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Salary).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.Property(e => e.ProfitPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SellingPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TransactionDate).HasColumnType("datetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Invoices_Employees");

                entity.HasOne(d => d.Medicine)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.MedicineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Invoices_Medicines");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Invoices_Patients");
            });

            modelBuilder.Entity<Manufacture>(entity =>
            {
                entity.ToTable("Manufacture");

                entity.Property(e => e.ManufactureName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Medicine>(entity =>
            {
                entity.Property(e => e.MedicineName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<MedicineSupplier>(entity =>
            {
                entity.Property(e => e.CostPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.DiscountValue).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ExpiaryDate).HasColumnType("date");

                entity.Property(e => e.SellingPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TaxValue).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Medicine)
                    .WithMany(p => p.MedicineSuppliers)
                    .HasForeignKey(d => d.MedicineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MedicineSuppliers_Medicines");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.MedicineSuppliers)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MedicineSuppliers_Suppliers");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.Property(e => e.Mobile)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.PatientName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasKey(e => e.SuppliersId);

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Mobile)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.SupplierName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Manufacture)
                    .WithMany(p => p.Suppliers)
                    .HasForeignKey(d => d.ManufactureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Suppliers_Manufacture");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
