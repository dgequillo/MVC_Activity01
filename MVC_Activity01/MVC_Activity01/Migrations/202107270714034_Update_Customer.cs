namespace MVC_Activity01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Customer : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Customers", newName: "Customer");
            AlterColumn("dbo.Customer", "Firstname", c => c.String(maxLength: 64));
            AlterColumn("dbo.Customer", "Middlename", c => c.String(maxLength: 64));
            AlterColumn("dbo.Customer", "Lastname", c => c.String(maxLength: 64));
            AlterColumn("dbo.Customer", "Gender", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customer", "Gender", c => c.String());
            AlterColumn("dbo.Customer", "Lastname", c => c.String());
            AlterColumn("dbo.Customer", "Middlename", c => c.String());
            AlterColumn("dbo.Customer", "Firstname", c => c.String());
            RenameTable(name: "dbo.Customer", newName: "Customers");
        }
    }
}
