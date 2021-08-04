namespace MVC_Activity01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_OrderItem_and_Product : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders_Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        ProductCode = c.String(maxLength: 10),
                        ProductName = c.String(maxLength: 100),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(maxLength: 10),
                        Name = c.String(maxLength: 100),
                        StockOnHand = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders_Items", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Orders_Items", "OrderId", "dbo.Orders");
            DropIndex("dbo.Orders_Items", new[] { "ProductId" });
            DropIndex("dbo.Orders_Items", new[] { "OrderId" });
            DropTable("dbo.Products");
            DropTable("dbo.Orders_Items");
        }
    }
}
