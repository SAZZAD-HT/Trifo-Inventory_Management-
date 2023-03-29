namespace Trifo_Inventory_Management_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changed : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ImportLists",
                c => new
                    {
                        Import = c.Int(nullable: false, identity: true),
                        sProduct_name = c.String(),
                        country = c.String(),
                        sDescription = c.String(),
                        d_Quantity = c.String(),
                        cust_quantity = c.String(),
                        Customer_name = c.String(),
                        CustomerEmail = c.String(),
                        Customer_mobiler = c.String(),
                    })
                .PrimaryKey(t => t.Import);
            
            CreateTable(
                "dbo.Shops",
                c => new
                    {
                        Shop_prd_id = c.Int(nullable: false, identity: true),
                        sProduct_name = c.String(),
                        country = c.String(),
                        sDescription = c.String(),
                        Buy_Price = c.Double(nullable: false),
                        Sell_Price = c.Double(nullable: false),
                        sPicture = c.String(),
                        sell_date = c.DateTime(nullable: false),
                        Selled_Quantity = c.String(),
                        Customer_name = c.String(),
                        CustomerEmail = c.String(),
                        Customer_mobiler = c.String(),
                    })
                .PrimaryKey(t => t.Shop_prd_id);
            
            CreateTable(
                "dbo.Warehouses",
                c => new
                    {
                        Ware_prd_id = c.Int(nullable: false, identity: true),
                        Product_name = c.String(),
                        country = c.String(),
                        Description = c.String(),
                        Buy_Price = c.Double(nullable: false),
                        Sell_Price = c.Double(nullable: false),
                        Picture = c.String(),
                        sell_date = c.DateTime(nullable: false),
                        Selled_Quantity = c.String(),
                        Customer_name = c.String(),
                        CustomerEmail = c.String(),
                        Customer_mobiler = c.String(),
                    })
                .PrimaryKey(t => t.Ware_prd_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Warehouses");
            DropTable("dbo.Shops");
            DropTable("dbo.ImportLists");
        }
    }
}
