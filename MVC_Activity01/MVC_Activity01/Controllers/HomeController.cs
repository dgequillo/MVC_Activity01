﻿using System.Web.Mvc;

namespace MVC_Activity01.Controllers
{
    public class HomeController : Controller
    {
      
        public ActionResult Index()
        {
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
        public ActionResult OrderDetails()
        {
            ViewBag.Message = "View Details";
            return View();
        }
    }
}