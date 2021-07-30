namespace MVC_Activity01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Order : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        No = c.String(maxLength: 10),
                        OrderName = c.String(maxLength: 64),
                        DocDate = c.DateTime(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Order", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Order", new[] { "CustomerId" });
            DropTable("dbo.Order");
        }
    }
}
