using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Trifo_Inventory_Management_.Models.ef
{
    public class Warehouse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]


        public int Ware_prd_id { get; set; }

        public string Product_name { get; set; }

        public string country { get; set; }




        public String Description { get; set; }
        public Double Buy_Price { get; set; }
        public Double Sell_Price { get; set; }

        public string Picture { get; set; }
        public DateTime sell_date { get; set; }
        public string Quantity { get; set; }
        public String Customer_name { get; set; }
        public string CustomerEmail { get; set; }
        public string Customer_mobiler { get; set; }
        public string stock { get; set; }   
    }
}