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
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
        }
    }
}