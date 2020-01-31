using MyDeal.Areas.Admin.AdminAuthenticationFilter;
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
    [HandleError]
    public class HomePageSliderController : Controller
    {
        private readonly IHomePageSliderService service;
        public HomePageSliderController()
        {
            service = new HomePageSliderService();
        }

        // GET: Admin/HomePageSlider
        public ActionResult Index()
        {
            return View(service.GetAll(x=>x.Id>0));
        }

        // GET: Admin/Add
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(HomePageSlider slider,HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    file.SaveAs(HttpContext.Server.MapPath("~/Image/") + file.FileName);
                    slider.ImageName = file.FileName;
                }
                service.AddSlider(slider);
                return RedirectToAction("Add");
            }
            else
            {
                return View(slider);
            }
        }

        [HttpGet]
        public ActionResult Remove(int id)
        {
            return View(service.SliderDetails(x=>x.Id==id));
        }

        [HttpPost]
        public ActionResult Remove(HomePageSlider slider)
        {
            service.RemoveSlider(slider);
            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(service.SliderDetails(x => x.Id == id));
        }

        [HttpPost]
        public ActionResult Edit(HomePageSlider slider, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    file.SaveAs(HttpContext.Server.MapPath("~/Image/") + file.FileName);
                    slider.ImageName = file.FileName;
                }
                service.UpdateSlider(slider);
                return RedirectToAction("Add");
            }
            else
            {
                return View(slider);
            }
        }
    }
}