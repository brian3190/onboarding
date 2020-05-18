using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using onboarding.Models;

namespace onboarding.Controllers
{
    public class CustomersController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //GET: Customer
        [HttpGet]
        public JsonResult GetCustomerData()
        {
            using (var db = new OnboardingContext())
            {
                var customers = db.Customer.Select(x => new Customer()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Address = x.Address
                }).ToList();

                return Json(customers);
            }
        }

        //Create customer
        public JsonResult CreateCustomer(Customer customer)
        {
            try
            {
                db.Customers.Add(customer);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.Write("Exception Occured /n {0}", e.Data);
                return new JsonResult { Data = "Create Customer Failed", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            return new JsonResult { Data = "Customer created", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}