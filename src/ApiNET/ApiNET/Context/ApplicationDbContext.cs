using ApiNET.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNET.Context
{
    public class ApplicationDbContext
        : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Email> Emails { get; set; }


        public ApplicationDbContext(DbContextOptions options)
           : base(options)
        {

        }

        public ApplicationDbContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>()
                .ToTable("Customers")
                .HasData(SeedData.BuildCustomer());

            modelBuilder.Entity<Address>()
                .ToTable("Addresses")
                .HasData(SeedData.BuildAddress());

            modelBuilder.Entity<Email>()
                            .ToTable("Emails")
                            .HasData(SeedData.BuildEmail());

            modelBuilder.Entity<Phone>()
                            .ToTable("Phones")
                            .HasData(SeedData.BuildPhone());
        }
    }
}
