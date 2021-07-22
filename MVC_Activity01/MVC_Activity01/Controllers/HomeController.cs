using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Activity01.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Order Details";
            return View();
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
        public ActionResult OrderDetails(string orderNo, string orderDate, string customerName, string totalAmount)
        {
            ViewBag.Message = "View Details";
            ViewBag.OrderNumber = orderNo;
            ViewBag.OrderDate = orderDate;
            ViewBag.customerName = customerName;
            ViewBag.totalAmount = totalAmount;
            return View();
        }
    }
}