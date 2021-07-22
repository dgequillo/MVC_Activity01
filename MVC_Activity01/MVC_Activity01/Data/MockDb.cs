using MVC_Activity01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Activity01.Data
{
    public static class MockDb
    {
        public static List<Order> Orders = new List<Order>
        {
            new Order
            {
                Id = 1,
                No = "0001",
                DocDate = DateTime.Today,
                CustomerName = "Juan",
                Amount = 1000
            },
            new Order
            {
                Id = 2,
                No = "0002",
                DocDate = DateTime.Today,
                CustomerName = "Pedro",
                Amount = 1500
            }
        };
    }
}