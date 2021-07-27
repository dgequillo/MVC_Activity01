using MVC_Activity01.Context;
using MVC_Activity01.Models;
using System;
using System.Linq;
using System.Web.Mvc;
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
            var model = list.Select(c => new CustomersDTO
            {
                Id = c.Id,
                Firstname = c.Firstname,
                Middlename = c.Middlename,
                Lastname = c.Lastname,
                Birthday = c.Birthday,
                Gender = c.Gender,
                Age = c.Age,
                Address = c.Address,
                EmailAdress = c.EmailAdress,
                Status = c.Status

            }).ToList();

            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            CustomersDTO model = new CustomersDTO();
            model.Birthday = DateTime.Today;
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CustomersDTO data)
        {
            var customer = new Customers
            {
                Id = data.Id,
                Firstname = data.Firstname,
                Middlename = data.Middlename,
                Lastname = data.Lastname,
                Birthday = data.Birthday,
                Gender = data.Gender,
                Age = data.Age,
                Address = data.Address,
                EmailAdress = data.EmailAdress,
                Status = data.Status
            };

            db.Customers.Add(customer);
            db.SaveChanges();
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
