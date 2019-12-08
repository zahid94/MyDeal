using MyDeal.Areas.Admin.AdminAuthenticationFilter;
using MyDeal.AuthenticationFilter;
using MyDeal.Models;
using MyDeal.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyDeal.Areas.Admin.Controllers
{
    [AdminFiltering]
    public class PageController : Controller
    {
        private readonly IPageService service;
        public PageController()
        {
            service = new PageService();
        }
        // GET: Admin/Page
        public ActionResult Index()
        {           
            return View(service.GetAllPage(x=>x.Id>0));
        }
        [HttpGet]
        public ActionResult CreatePage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreatePage(Page page)
        {
            if (ModelState.IsValid)
            {
                service.AddPage(page);
                return RedirectToAction("index");

            }
            return View(page);
        }
        [HttpGet]
        public ActionResult EditPage(int id)
        {
            return View(service.PageDetails(x=>x.Id==id));
        }
        public ActionResult EditPage(Page page)
        {
            if (ModelState.IsValid)
            {
                service.UpdatePage(page);
                return RedirectToAction("Index");
            }
            return View(page);
        }
        [HttpGet]
        public ActionResult Remove(int id)
        {
            return View(service.PageDetails(x => x.Id == id));
        }
        [HttpPost]
        [ActionName("Remove")]
        public ActionResult RemoveConfirm(Page page)
        {
            service.RemovePage(page);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(service.PageDetails(x => x.Id == id));
        }
    }
}