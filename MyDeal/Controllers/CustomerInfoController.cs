using MyDeal.Models;
using MyDeal.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyDeal.Controllers
{
    public class CustomerInfoController : Controller
    {
        private readonly ICustomerService service;
        private readonly IBidsService bidsService;
        public CustomerInfoController()
        {
            service = new CustomerService();
            bidsService = new BidsService();
        }
        // GET: CustomerInfo
        public ActionResult MyBids( int id)
        {
            return View(bidsService.GetFilterBider(x=>x.CustomerId==id));
        }

        // GET: CustomerInfo/Details/5
        public ActionResult Details(int id)
        {
            return View(service.CustomerDetails(x=>x.Id==id));
        }

        // GET: CustomerInfo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerInfo/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerInfo/Edit/5
        public ActionResult Edit(int id)
        {
            return View(service.CustomerDetails(x => x.Id == id));
        }

        // POST: CustomerInfo/Edit/5
        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                service.UpdateCustomer(customer);                
                return RedirectToAction("Details");
            }
            else
            {
                ModelState.AddModelError("","Something is wrong. please try again.");
                return View(customer);
            }
        }

        // GET: CustomerInfo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerInfo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
