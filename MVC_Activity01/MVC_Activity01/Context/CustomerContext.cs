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
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.Entity<Customer>()
                .ToTable("Customers");

            modelBuilder.Entity<Customer>().HasKey(c => c.Id);
            modelBuilder.Entity<Customer>().Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Customer>().Property(c => c.Firstname).HasMaxLength(64);
            modelBuilder.Entity<Customer>().Property(c => c.Middlename).HasMaxLength(64);
            modelBuilder.Entity<Customer>().Property(c => c.Lastname).HasMaxLength(64);
            modelBuilder.Entity<Customer>().Property(c => c.Gender).HasMaxLength(10);

            modelBuilder.Entity<Order>()
               .ToTable("Orders");

            modelBuilder.Entity<Order>().HasKey(c => c.Id);
            modelBuilder.Entity<Order>().Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Order>().Property(c => c.No).HasMaxLength(10);
            modelBuilder.Entity<Order>().Property(c => c.OrderName).HasMaxLength(64);
            modelBuilder.Entity<Order>().Property(c => c.Amount).HasPrecision(18,2);

            modelBuilder.Entity<Order>()
                 .HasRequired(c => c.Customer)
                 .WithMany()
                 .HasForeignKey(d => d.CustomerId);
        }
    }
}