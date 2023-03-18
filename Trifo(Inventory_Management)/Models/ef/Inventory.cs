using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Trifo_Inventory_Management_.Models
{
    public class Inventory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Pid { get; set; }

        public string Product_name { get; set; }

        public string Product_Category { get; set; }




        public String Description { get; set; }
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Price must be a valid number with up to 2 decimal places.")]
        public Double Price { get; set; }
        public string Picture { get; set; }
        public DateTime Buy_DateTime { get; set; }
        public string stock { get; set; }
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Enter valid number")]
        public string Quantity { get; set; }    
       
    }
}