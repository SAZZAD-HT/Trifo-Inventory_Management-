namespace Trifo_Inventory_Management_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inventories", "Quantity", c => c.String());
            AddColumn("dbo.selled_product", "Selled_Quantity", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.selled_product", "Selled_Quantity");
            DropColumn("dbo.Inventories", "Quantity");
        }
    }
}
