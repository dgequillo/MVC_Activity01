using MVC_Activity01.Context;
using System.Linq;
using System.Web.Mvc;
using MVC_Activity01.Models;
using System;

namespace MVC_Activity01.Controllers
{
    public class CustomerController : Controller
    {
        CustomerContext db = new CustomerContext();
        // GET: Customer
        public ActionResult Index()
        {
            ViewBag.Title = "Customer List";
            var list = db.Customers.ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            Customers model = new Customers();
            model.Birthday = DateTime.Today;
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Customers data)
        {
            using (var db = new CustomerContext())
            {
                db.Customers.Add(data);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Customers model = new Customers();
            model = db.Customers.FirstOrDefault(x => x.Id == id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Customers data)
        {
            using (var db = new CustomerContext())
            {
                var entity = db.Customers.FirstOrDefault(x => x.Id == data.Id);
                db.Entry(entity).CurrentValues.SetValues(data);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
