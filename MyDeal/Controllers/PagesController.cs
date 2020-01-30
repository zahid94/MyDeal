using MyDeal.Models;
using MyDeal.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyDeal.Controllers
{
    [HandleError]
    public class PagesController : Controller
    {
        private readonly IPageMenuService service; 
        public PagesController()
        {
            service = new PageMenuService();
        }
        
        // GET: Pages
        public ActionResult Index(string pages)
        {
            ViewBag.Title = pages;
            return View(service.PageDetails(x=>x.Name==pages));
        }

        public ActionResult pageMenuPartial()
        {
            return PartialView(service.GetAllPage(x=>x.Id>0).ToList());
        }
    }
}