using ApiNET.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNET.Repository
{
    public class ApplicationDbContext
        : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<AddressMap> AddressMaps { get; set; }

        public DbSet<Phone> Phones { get; set; }
        public DbSet<PhoneMap> PhoneMaps  { get; set; }

        public DbSet<Email> Emails { get; set; }
        public DbSet<EmailMap> EmailMaps { get; set; } 


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

            modelBuilder.Entity<AddressMap>()
                .ToTable("AddressMaps")
                .HasData(SeedData.BuildAddressMap());

            modelBuilder.Entity<Email>()
                        .ToTable("Emails")
                        .HasData(SeedData.BuildEmail());

            modelBuilder.Entity<EmailMap>()
                        .ToTable("EmailMaps")
                        .HasData(SeedData.BuildEmailMap());

            modelBuilder.Entity<Phone>()
                        .ToTable("Phones")
                        .HasData(SeedData.BuildPhone());

            modelBuilder.Entity<PhoneMap>()
                        .ToTable("PhoneMaps")
                        .HasData(SeedData.BuildPhoneMap());
        }
    }
}
