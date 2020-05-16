using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BankApplication.Models.Entities;

namespace BankApplication.Models
{
    public partial class DataDbContext : DbContext
    {
        public DataDbContext()
        {
        }

        public DataDbContext(DbContextOptions<DataDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Bank> Banks { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<InterestRate> InterestRates { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Salary> Salaries { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.From)
                .WithMany(a => a.Transactions)
                .HasForeignKey(t => t.FromId);

            modelBuilder.Entity<Person>()
                .HasOne(p => p.Client)
                .WithOne(c => c.Person)
                .HasForeignKey<Client>(c => c.PersonId);

            //modelBuilder.Entity<Client>()
            //    .HasOne(c => c.Person)
            //    .WithOne(p => p.Client)
            //    .HasForeignKey<Person>(p => p.ClientId);

            modelBuilder.Entity<Person>()
                .HasOne(p => p.Employee)
                .WithOne(e => e.Person)
                .HasForeignKey<Employee>(e => e.PersonId);
        }
    }
}
