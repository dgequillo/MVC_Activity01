using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MVC_Activity01.Models;
namespace MVC_Activity01.Context
{
    public class CustomerContext: DbContext
    {
        public CustomerContext() : base("CustomerContext")
        {

        }
        public DbSet<Customers> Customers { get; set; }

    }
}