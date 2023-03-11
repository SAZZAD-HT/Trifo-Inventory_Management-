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
        public Double Price { get; set; }
        public string Picture { get; set; }
       
    }
}