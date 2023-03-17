using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Trifo_Inventory_Management_.Models
{
    public class selled_product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Sid { get; set; }

        public int sPid { get; set; }

        public string sProduct_name { get; set; }

        public string sProduct_Category { get; set; }




        public String sDescription { get; set; }
        public Double Buy_Price { get; set; }
        public  Double Sell_Price { get; set;    }   

        public string sPicture { get; set; }
        public DateTime sell_date { get; set; }
        public string Selled_Quantity { get; set; }   

    }
}