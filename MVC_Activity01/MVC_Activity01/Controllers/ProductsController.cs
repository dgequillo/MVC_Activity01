using MVC_Activity01.Context;
using MVC_Activity01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Activity01.Controllers
{
    public class ProductsController : Controller
    {
        CustomerContext db = new CustomerContext();
        // GET: Products
        public ActionResult Index()
        {
            ViewBag.Title = "List Of Product";

            var list = db.Products.ToList();
            var model = list.Select(p => new ProductDTO
            {
                Id = p.Id,
                Code = p.Code,
                Name = p.Name,
                StockOnHand = p.StockOnHand,
                Price = p.Price

            }).ToList();

            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductDTO data)
        {
            var product = new Product
            {
                Id = data.Id,
                Code = data.Code,
                Name = data.Name,
                StockOnHand = data.StockOnHand,
                Price = data.Price
            };

            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Product model = new Product();
            model = db.Products.FirstOrDefault(x => x.Id == id);
            return View(model);
        }

      [HttpPost]
      public ActionResult Edit(Product data)
        {
            using (var db = new CustomerContext())
            {
                var entity = db.Products.FirstOrDefault(x => x.Id == data.Id);
                db.Entry(entity).CurrentValues.SetValues(data);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
