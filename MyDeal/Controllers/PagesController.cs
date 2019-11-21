using MyDeal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyDeal.Controllers
{
    public class PagesController : Controller
    {
        private readonly MyDealDbContext db;
        public PagesController()
        {
            db = new MyDealDbContext();
        }
        // GET: Pages
        public ActionResult Index(string pages)
        {
            Page model;            
            model = db.pages.FirstOrDefault(x=>x.Name==pages);
            ViewBag.PageName = model.Name;
            return View(model);
        }

        public ActionResult pageMenuPartial()
        {
            List<Page> model;
            model = db.pages.ToArray().ToList();
            return PartialView(model);
        }
    }
}