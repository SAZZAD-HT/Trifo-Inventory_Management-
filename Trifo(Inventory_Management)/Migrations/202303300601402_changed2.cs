namespace Trifo_Inventory_Management_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changed2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shops", "Quantity", c => c.String());
            AddColumn("dbo.Shops", "stock", c => c.String());
            AddColumn("dbo.Warehouses", "Quantity", c => c.String());
            AddColumn("dbo.Warehouses", "stock", c => c.String());
            DropColumn("dbo.Shops", "Selled_Quantity");
            DropColumn("dbo.Warehouses", "Selled_Quantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Warehouses", "Selled_Quantity", c => c.String());
            AddColumn("dbo.Shops", "Selled_Quantity", c => c.String());
            DropColumn("dbo.Warehouses", "stock");
            DropColumn("dbo.Warehouses", "Quantity");
            DropColumn("dbo.Shops", "stock");
            DropColumn("dbo.Shops", "Quantity");
        }
    }
}
