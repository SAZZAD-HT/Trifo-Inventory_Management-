using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Trifo_Inventory_Management_.Models.ef
{
    public class ImportList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]


        public int Import { get; set; }

        public string sProduct_name { get; set; }

        public string country { get; set; }




        public String sDescription { get; set; }


        
       
        public string d_Quantity { get; set; }
        public string cust_quantity { get; set; }
        public String Customer_name { get; set; }
        public string CustomerEmail { get; set; }
        public string Customer_mobiler { get; set; }
    }
}