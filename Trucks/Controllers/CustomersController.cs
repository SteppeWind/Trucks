using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Web.Mvc;
using Trucks.Common.Extensions;
using Trucks.Data.Repositories;
using Trucks.Domain;
using Trucks.Services;
using Trucks.Web.Common.App.Extensions;
using Trucks.Web.Models.Customers;

namespace Trucks.Web.Controllers
{
    public class CustomersController : Controller
    {
        public ICustomerRepository CustomerRepository { get; set; }
        public ICustomerService CustomerService { get; set; }

        [HttpGet]
        public ActionResult List()
        {
            var customers = CustomerRepository.GetAll(customer => new ListModel.Customer
            {
                Id = customer.Id,
                Name = customer.Name,
                Surname = customer.Surname,
                PhoneNumber = customer.PhoneNumber,
                CompleteOrderCount = customer.Orders.Count(o => o.Status == Status.Complete),
                IncompleteOrderCount = customer.Orders.Count(o => o.Status == Status.Incomplete),
                TotalOrderCount = customer.Orders.Count
            }).ToArray();

            return View(new ListModel
            {
                Customers = customers
            });
        }

        [ChildActionOnly]
        public ActionResult Create()
        {
            return PartialView("~/Views/Customers/Create.cshtml");
        }

        [HttpPost]
        public ActionResult Create(CreateModel model)
        {
            var customer = new Customer
            {
                Name = model.Name,
                Surname = model.Surname,
                PhoneNumber = model.PhoneNumber
            };

            CustomerService.Save(customer);

            return new JsonResult
            {
                Data = new { customer.Id }
            };
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = CustomerRepository.GetById(id, c => new DetailsModel
            {
                Name = c.Name,
                Surname = c.Surname,
                PhoneNumber = c.PhoneNumber
            });

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            CustomerService.Delete(id);

            return this.Ok();
        }
    }
}