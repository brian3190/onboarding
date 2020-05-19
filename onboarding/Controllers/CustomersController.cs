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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCustomer([FromBody] Customer customer)
        {
            using (var db = new OnboardingContext())
            {
                if (ModelState.IsValid)
                {
                    db.Customer.Add(customer);
                    db.SaveChanges();
                    return StatusCode(StatusCodes.Status201Created);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }
            }
        }

        // PUT: Product/EditCustomer/#
        [HttpPut]
        public ActionResult EditCustomer(int id, [FromBody] Customer customer)
        {
            using (var db = new OnboardingContext())
            {
                if (ModelState.IsValid)
                {
                    var entity = db.Customer.Find(id);
                    entity.Name = customer.Name;
                    entity.Address = customer.Address;
                    db.SaveChanges();
                    return Ok("Record Updated Succesfully...");
                }
                else
                {
                    return NotFound("No record has been found against this id");
                }
            }
        }

        // DELETE: Customer/DeleteCustomer/#
        [HttpDelete]
        public ActionResult DeleteCustomer(int id)
        {
            using (var db = new OnboardingContext())
            {
                try
                {
                    var entity = db.Customer.Find(id);
                    db.Customer.Remove(entity);
                    db.SaveChanges();
                    return Ok("Customer deleted");
                }
                catch
                {
                    throw;
                }
            }
        }
    }
}