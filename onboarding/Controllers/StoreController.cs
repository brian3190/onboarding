﻿using System;
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
    public class StoreController : Controller
    {
        // GET: Store/StoreListSales ***This is for the sales Dropdown options
        [HttpGet]
        public JsonResult StoreListSales()
        {
            using (var db = new OnboardingContext())
            {
                var stores = db.Stores.Select(x => new Store()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Address = x.Address
                }).ToList();

                return Json(stores);
            }
        }

        // GET: Store/StoreList
        [HttpGet]
        public JsonResult StoreList(string sortColumnName, string sortOrder, int pageSize, int currentPage)
        {

            List<Store> list = new List<Store>();
            int totalPage = 0;
            int totalRecord = 0;

            using (var db = new OnboardingContext())
            {
                var stores = db.Stores;
                totalRecord = stores.Count();

                if (pageSize > 0)
                {
                    totalPage = totalRecord / pageSize + ((totalRecord % pageSize) > 0 ? 1 : 0);
                    list = stores.Select(x => new Store()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Address = x.Address
                    }).OrderBy(sortColumnName + " " + sortOrder).Skip(pageSize * (currentPage - 1)).Take(pageSize).ToList();
                }
                else
                {
                    list = stores.ToList();
                }


                var result = new { list = list, totalRecord = totalRecord, totalPage = totalPage };

                return Json(result);
            }
        }

        // POST: Store/CreateStore
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateStore([FromBody] Store store)
        {
            using (var db = new OnboardingContext())
            {
                if (ModelState.IsValid)
                {
                    db.Stores.Add(store);
                    db.SaveChanges();
                    return StatusCode(StatusCodes.Status201Created);
                }

                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }

            }
        }

        // PUT: Store/EditStore/#
        [HttpPut]
        public ActionResult EditStore(int id, [FromBody] Store store)
        {
            using (var db = new OnboardingContext())
            {
                if (ModelState.IsValid)
                {
                    var entity = db.Stores.Find(id);
                    entity.Name = store.Name;
                    entity.Address = store.Address;
                    db.SaveChanges();
                    return Ok("Record Updated Succesfully...");
                }
                else
                {
                    return NotFound("No record has been found against this id");
                }
            }
        }

        // DELETE: Store/DeleteStore/#
        [HttpDelete]
        public ActionResult DeleteStore(int id)
        {
            using (var db = new OnboardingContext())
            {
                try
                {
                    var entity = db.Stores.Find(id);
                    db.Stores.Remove(entity);
                    db.SaveChanges();
                    return Ok("Store deleted");
                }
                catch
                {
                    throw;
                }
            }
        }
    }
}