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
        public string No { get; set; }
        public string OrderName { get; set; }
        public DateTime DocDate { get; set; }
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }

        public Customer Customer { get; set; }
    }
}