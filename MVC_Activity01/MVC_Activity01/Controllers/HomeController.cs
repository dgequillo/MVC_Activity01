using MVC_Activity01.Data;
using MVC_Activity01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MVC_Activity01.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Order Details";
            var list = MockDb.Orders;
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
        public ActionResult OrderDetails(int id)
        {
            ViewBag.Message = "View Details";

            var list = MockDb.Orders;
            var model = list.FirstOrDefault(m => m.Id == id);

            return View(model);
        }
    }
}