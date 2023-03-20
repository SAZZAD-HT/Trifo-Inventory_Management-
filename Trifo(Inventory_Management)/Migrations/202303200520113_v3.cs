namespace Trifo_Inventory_Management_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.selled_product", "Customer_name", c => c.String());
            AddColumn("dbo.selled_product", "CustomerEmail", c => c.String());
            AddColumn("dbo.selled_product", "Customer_mobiler", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.selled_product", "Customer_mobiler");
            DropColumn("dbo.selled_product", "CustomerEmail");
            DropColumn("dbo.selled_product", "Customer_name");
        }
    }
}
