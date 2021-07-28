namespace MVC_Activity01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Customer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Firstname = c.String(),
                        Middlename = c.String(),
                        Lastname = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        Gender = c.String(),
                        Age = c.Int(nullable: false),
                        Address = c.String(),
                        EmailAdress = c.String(),
                        status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Customers");
        }
    }
}
