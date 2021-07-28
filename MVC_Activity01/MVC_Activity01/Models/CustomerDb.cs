//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Data.Entity;
//using MVC_Activity01.Models;

//namespace MVC_Activity01.Models
//{
//    public class CustomerDb : DbContext
//    {
//        public CustomerDb() : base("CustomerContext")
//        {
//            // Database.SetInitializer(new MigrateDatabaseToLatestVersion<CustomerContext, MVC_Activity01.Migrations.Configuration>());
//            //  Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CustomerContext>());
//            // Database.SetInitializer<CustomerContext>(new DropCreateDatabaseIfModelChanges<CustomerContext>());
//            //  Database.SetInitializer<CustomerContext>(new DropCreateDatabaseAlways<CustomerContext>());
//        }
//        public DbSet<Customers> Customers { get; set; }

//        protected override void OnModelCreating(DbModelBuilder modelBuilder)
//        {

//            //Remove Pluralization
//            //base.OnModelCreating(modelBuilder);
//        }
//    }
//}