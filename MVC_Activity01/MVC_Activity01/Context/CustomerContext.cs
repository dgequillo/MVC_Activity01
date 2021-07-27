using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MVC_Activity01.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MVC_Activity01.Context
{
    public class CustomerContext: DbContext
    {
        public CustomerContext() : base("CustomerContext")
        {
            
        }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<CustomersDTO> CustomersDTO { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.Entity<Customers>()
                .ToTable("Customer");

            modelBuilder.Entity<Customers>().HasKey(c => c.Id);
            modelBuilder.Entity<Customers>().Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Customers>().Property(c => c.Firstname).HasMaxLength(64);
            modelBuilder.Entity<Customers>().Property(c => c.Middlename).HasMaxLength(64);
            modelBuilder.Entity<Customers>().Property(c => c.Lastname).HasMaxLength(64);
            modelBuilder.Entity<Customers>().Property(c => c.Gender).HasMaxLength(10);
        }
    }
}