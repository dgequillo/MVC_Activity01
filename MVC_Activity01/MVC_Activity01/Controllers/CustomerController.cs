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

            // simple mapping
            var model = list.Select(c => new CustomersDTO
            {
                Id = c.Id,
                Firstname = c.Firstname,
                Lastname = c.Lastname
            }).ToList();

            //var config = new MapperConfiguration(cfg => cfg.CreateMap<Customers, CustomersDTO>());
            //var mapper = new Mapper(config);
            //var custDTO = mapper.Map<List<CustomersDTO>>(list);

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
            // simple mapping
            var customer = new Customers
            {
                Id = data.Id,
                Firstname = data.Firstname,
                Lastname = data.Lastname
            };

            using (var db = new CustomerContext())
            {

                db.Customers.Add(customer);
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
