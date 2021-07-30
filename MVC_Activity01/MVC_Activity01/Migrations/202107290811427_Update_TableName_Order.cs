namespace MVC_Activity01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_TableName_Order : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Order", newName: "Orders");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Orders", newName: "Order");
        }
    }
}
