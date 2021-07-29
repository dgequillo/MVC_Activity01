using MVC_Activity01.Context;
using MVC_Activity01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Activity01.Controllers
{
    public class OrderController : Controller
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

    }
}
