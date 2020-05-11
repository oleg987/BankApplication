using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BankApplication.Models
{
    public partial class AplicationDataContext : DbContext
    {
        public AplicationDataContext()
        {
        }

        public AplicationDataContext(DbContextOptions<AplicationDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bank> Bank { get; set; }
        public virtual DbSet<Branch> Branch { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bank>(entity =>
            {
                entity.ToTable("bank");

                entity.HasIndex(e => e.Id)
                    .HasName("banks_id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('banks_id_seq'::regclass)");

                entity.Property(e => e.Address).HasColumnName("address");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title");
            });

            modelBuilder.Entity<Branch>(entity =>
            {
                entity.ToTable("branch");

                entity.HasIndex(e => e.Id)
                    .HasName("branches_id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('branches_id_seq'::regclass)");

                entity.Property(e => e.Address).HasColumnName("address");

                entity.Property(e => e.BankId).HasColumnName("bank_id");

                entity.Property(e => e.Title).IsRequired();

                entity.HasOne(d => d.Bank)
                    .WithMany(p => p.Branch)
                    .HasForeignKey(d => d.BankId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("branches_banks_id_fk");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employee");

                entity.HasIndex(e => e.Id)
                    .HasName("employee_id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BranchId).HasColumnName("branch_id");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.BranchId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("employee_branch_id_fk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
