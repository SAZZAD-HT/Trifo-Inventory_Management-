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
            
        }
    }
}
