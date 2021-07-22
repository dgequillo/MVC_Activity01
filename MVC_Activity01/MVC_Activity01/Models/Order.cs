using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Activity01.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string No { get; set; }
        public DateTime DocDate { get; set; }
        public string CustomerName { get; set; }
        public decimal Amount { get; set; }
    }
}