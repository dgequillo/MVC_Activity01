using MVC_Activity01.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MVC_Activity01.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Order Details";

            var list = new List<Order>();

            var order = new Order();
            order.No = "001";
            order.DocDate = DateTime.Now;
            order.CustomerName = "test";
            order.Amount = 1000;

            list.Add(order);

            var order2 = new Order();
            order2.No = "002";
            order2.DocDate = DateTime.Now;
            order2.CustomerName = "test2";
            order2.Amount = 2000;

            list.Add(order2);

            return View(list);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult OrderDetails(Order data)
        {
            ViewBag.Message = "View Details";

            return View(data);
        }
    }
}