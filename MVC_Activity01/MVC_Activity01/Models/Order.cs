using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Activity01.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Order No.")]
        public string No { get; set; }
        [Display(Name ="Order Date")]
        public string OrderName { get; set; }
        public DateTime DocDate { get; set; }
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
        public Customer Customer { get; set; }

        public List<Orders_Items> Items { get; set; }

    }
}