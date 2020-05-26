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
        //GET: Customer/Get
        [HttpGet]
        public JsonResult Get()
        {
            using (var db = new OnboardingContext())
            {
                var customers = db.Customers.Select(x => new Customer()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Address = x.Address
                }).ToList();

                return Json(customers);
            }
        }

        //POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromBody] Customer customer)
        {
            //Does not implement catching exception
            using (var db = new OnboardingContext())
            {
                if (ModelState.IsValid)
                {
                    db.Customers.Add(customer);
                    db.SaveChanges();
                    return StatusCode(StatusCodes.Status201Created);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }
            }            
        }

        // PUT: Customers/Edit
        [HttpPut]
        public ActionResult Edit(int id, [FromBody] Customer customer)
        {
            using (var db = new OnboardingContext())
            {
                if (ModelState.IsValid)
                {
                    var entity = db.Customers.Find(id);
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

        // DELETE: Customer/Delete
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            using (var db = new OnboardingContext())
            {
                try
                {
                    var entity = db.Customers.Find(id);
                    db.Customers.Remove(entity);
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