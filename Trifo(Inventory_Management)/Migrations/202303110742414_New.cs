namespace Trifo_Inventory_Management_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Inventories",
                c => new
                    {
                        Pid = c.Int(nullable: false, identity: true),
                        Product_name = c.String(),
                        Product_Category = c.String(),
                        Description = c.String(),
                        Price = c.Double(nullable: false),
                        Picture = c.String(),
                    })
                .PrimaryKey(t => t.Pid);
            
            CreateTable(
                "dbo.selled_product",
                c => new
                    {
                        Sid = c.Int(nullable: false, identity: true),
                        sPid = c.Int(nullable: false),
                        sProduct_name = c.String(),
                        sProduct_Category = c.String(),
                        sDescription = c.String(),
                        Buy_Price = c.Double(nullable: false),
                        Sell_Price = c.Double(nullable: false),
                        sPicture = c.String(),
                    })
                .PrimaryKey(t => t.Sid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.selled_product");
            DropTable("dbo.Inventories");
        }
    }
}
