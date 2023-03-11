using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Trifo_Inventory_Management_.Models
{
    public class dbContext:DbContext
    {
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<selled_product> Products { get; set; }
    }
}