using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Trifo_Inventory_Management_.Models.ef;

namespace Trifo_Inventory_Management_.Models
{
    public class dbContext:DbContext
    {
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<selled_product> Products { get; set; }
        public DbSet<Warehouse> Warehouse { get; set; } 
        public DbSet<Shop> Shop { get; set; }
        public DbSet <ImportList> Imports { get; set; }
    }
}