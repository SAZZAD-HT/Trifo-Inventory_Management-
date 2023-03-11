namespace Trifo_Inventory_Management_.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Trifo_Inventory_Management_.Models;
    

    internal sealed class Configuration : DbMigrationsConfiguration<Trifo_Inventory_Management_.Models.dbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Trifo_Inventory_Management_.Models.dbContext context)
        {
            var inventory = new List<Inventory>
    {
                new Inventory { Product_name = "Product1", Product_Category = "Category1", Description = "Description1", Price = 10, Picture = "Picture1.jpg" },
             new Inventory { Product_name = "Product2", Product_Category = "Category2", Description = "Description2", Price = 20, Picture = "Picture2.jpg" },
              new Inventory { Product_name = "Product3", Product_Category = "Category3", Description = "Description3", Price = 30, Picture = "Picture3.jpg" },
    };
            inventory.ForEach(i => context.Inventory.AddOrUpdate(p => p.Product_name, i));
            context.SaveChanges();
            var selled_products = new List<selled_product>
            {
               new selled_product { sPid = 1, sProduct_name = "Product1", sProduct_Category = "Category1", sDescription = "Description1", Buy_Price = 5, Sell_Price = 10, sPicture = "Picture1.jpg" },
               new selled_product { sPid = 2, sProduct_name = "Product2", sProduct_Category = "Category2", sDescription = "Description2", Buy_Price = 10, Sell_Price = 20, sPicture = "Picture2.jpg" },
              new selled_product { sPid = 3, sProduct_name = "Product3", sProduct_Category = "Category3", sDescription = "Description3", Buy_Price = 15, Sell_Price = 30, sPicture = "Picture3.jpg" },
    };
            selled_products.ForEach(s => context.Products.AddOrUpdate(p => p.sPid, s));
            context.SaveChanges();
        }
    }
}
