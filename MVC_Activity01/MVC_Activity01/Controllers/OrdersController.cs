using MVC_Activity01.Context;
using MVC_Activity01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace MVC_Activity01.Controllers
{
    public class OrdersController : Controller
    {
        private CustomerContext db = new CustomerContext();
        // GET: Order
        public ActionResult Index()
        {
            ViewBag.Title = "Order Details";
            var customers = db.Customers.ToList();
            var customerModel = customers.Select(c => new CustomerDTO
            {
                Id = c.Id,
                Name = $"{c.Lastname}, {c.Firstname} {c.Middlename}"
            }).ToList();

            SelectList CustomerList = new SelectList(customerModel, "Id", "Name");
            ViewData["CustomerList"] = CustomerList;
            return View();
        }
        public ActionResult OrderDetails(int id = 0)
        {
            var customers = db.Customers.ToList();
            var customerModel = customers.Select(c => new CustomerDTO
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
                Status = c.Status,
                Name = $"{c.Lastname}, {c.Firstname} {c.Middlename}"
            }).ToList();

            var orderList = db.Orders.Where(x => x.CustomerId == id || id == 0).ToList();
            var modelOrder = orderList.Select(c => new OrderDTO
            {
                Id = c.Id,
                No = c.No,
                OrderName = c.OrderName,
                DocDate = c.DocDate,
                CustomerId = c.CustomerId,
                Amount = c.Amount,
                Customer = customerModel.FirstOrDefault(x => x.Id == c.CustomerId)
            }).ToList();



            return PartialView("_OrderDetails", modelOrder);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var customers = db.Customers.ToList();
            var customerModel = customers.Select(c => new CustomerDTO
            {
                Id = c.Id,
                Name = $"{c.Lastname}, {c.Firstname} {c.Middlename}"
            }).ToList();

            SelectList CustomerList = new SelectList(customerModel, "Id", "Name");
            ViewData["CustomerId"] = CustomerList;
            return View();
        }
        [HttpPost]
        public ActionResult Create(OrderDTO data)
        {
            using (var db = new CustomerContext())
            {
                var order_item = data.Items.Select(s => new Orders_Items
                {
                    Id = s.Id,
                    OrderId = s.OrderId,
                    ProductId = s.ProductId,
                    ProductCode = s.ProductCode,
                    ProductName = s.ProductName,
                    Quantity = s.Quantity,
                    Price = s.Price,
                    Amount = s.Amount,

                }).ToList();
                var order = new Order
                {
                    Id = data.Id,
                    No = data.No,
                    OrderName = data.OrderName,
                    DocDate = data.DocDate,
                    CustomerId = data.CustomerId,
                    Amount = order_item.Sum(x => x.Amount),
                    Items = order_item
                };

                db.Orders.Add(order);
                db.SaveChanges();
            }
            return Json("", JsonRequestBehavior.AllowGet);
        }

        public ActionResult ProductModal()
        {
            var model = new Orders_ItemsDTO();
            var products = db.Products.ToList();
            var productModel = products.Select(c => new ProductDTO
            {
                Id = c.Id,
                Name = c.Name,
                Code = c.Code,
                Price = c.Price
            });
            SelectList ProductList = new SelectList(productModel, "Id", "Name");
            ViewData["ProductId"] = ProductList;
            return PartialView("_ProductModal", model);

        }
        public ActionResult GetValueOnchangeProduct(int id)
        {
            var product = db.Products.FirstOrDefault(p => p.Id == id);
            var productModel = new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Code = product.Code,
                Price = product.Price

            };
            return Json(productModel, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var order = db.Orders.FirstOrDefault(c => c.Id == id);
            order.Items = db.OrdersItems.Where(x => x.OrderId == id).ToList();

            var order_item = order.Items.Select(s => new Orders_ItemsDTO
            {
                Id = s.Id,
                OrderId = s.OrderId,
                ProductId = s.ProductId,
                ProductCode = s.ProductCode,
                ProductName = s.ProductName,
                Quantity = s.Quantity,
                Price = s.Price,
                Amount = s.Amount,
            }).ToList();

            var model = new OrderDTO
            {
                Id = order.Id,
                No = order.No,
                OrderName = order.OrderName,
                DocDate = order.DocDate,
                CustomerId = order.CustomerId,
                Items = order_item
            };

            var customers = db.Customers.ToList();
            var customerModel = customers.Select(c => new CustomerDTO
            {
                Id = c.Id,
                Name = $"{c.Lastname}, {c.Firstname} {c.Middlename}"
            }).ToList();
            SelectList CustomerList = new SelectList(customerModel, "Id", "Name", model.CustomerId);
            ViewData["CustomerId"] = CustomerList;

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(OrderDTO data)
        {
            using (var db = new CustomerContext())
            {
                var order_item = data.Items.Select(s => new Orders_Items
                {
                    Id = s.Id,
                    OrderId = data.Id,
                    ProductId = s.ProductId,
                    ProductCode = s.ProductCode,
                    ProductName = s.ProductName,
                    Quantity = s.Quantity,
                    Price = s.Price,
                    Amount = s.Amount,

                }).ToList();
                var order = new Order
                {
                    Id = data.Id,
                    No = data.No,
                    OrderName = data.OrderName,
                    DocDate = data.DocDate,
                    CustomerId = data.CustomerId,
                    Amount = order_item.Sum(x => x.Amount)
                };
                var toDelete = db.OrdersItems.Where(x => x.OrderId == order.Id).ToList();
                db.OrdersItems.RemoveRange(toDelete);

                db.OrdersItems.AddRange(order_item);

                var entity = db.Orders.FirstOrDefault(x => x.Id == data.Id);
                db.Entry(entity).CurrentValues.SetValues(order);
                db.SaveChanges();
            }
             return Json("", JsonRequestBehavior.AllowGet);
          
        }
    }
}
