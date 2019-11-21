﻿using MyDeal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyDeal.Areas.Admin.Controllers
{
    public class AdminAuthenticationController : Controller
    {
        private readonly MyDealDbContext db;
        public AdminAuthenticationController()
        {
            db = new MyDealDbContext();
        }
        // GET: Admin/AdminAuthentication
        
        [HttpGet]
        public ActionResult LogIn()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult LogIn(AdminRegistration admin)
        {
            if (db.registrations.Any(x=>x.UserName==admin.UserName&& x.password==admin.password))
            {
                Session["UserName"] = admin.UserName.ToString();
                return RedirectToAction("index","DashBoard");
            }
            else
            {
                ModelState.AddModelError("", "UserName or Password invalid.");
                return PartialView();
            }
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(AdminRegistration admin)
        {
            if (ModelState.IsValid)
            {
                db.registrations.Add(admin);
                db.SaveChanges();
                return RedirectToAction("index","DashBoard");
            }
            else
            {
                ModelState.AddModelError("", "UserName or Password invalid.");
                return View();
            }
        }

        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("LogIn");
        }
    }
}