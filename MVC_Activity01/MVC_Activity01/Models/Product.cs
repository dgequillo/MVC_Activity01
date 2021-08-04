using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Activity01.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Product Code")]
        public string Code { get; set; }

        [Display(Name = "Product Name")]
        public string Name { get; set; }
        public decimal  StockOnHand { get; set; }
        public decimal Price { get; set; }
    }
}