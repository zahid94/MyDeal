using MyDeal.Models;
using MyDeal.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyDeal.Areas.Admin.Controllers
{
    public class FirstSliderImageController : Controller
    {
        private readonly IFirstSliderService service;
        public FirstSliderImageController()
        {
            service = new FirstSliderService();
        }
        // GET: Admin/FirstSliderImage
        public ActionResult Index()
        {
            return PartialView(service.GetAll(x => x.Id > 0));
        }
        // GET: Admin/Add
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(FirstSlider slider, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    file.SaveAs(HttpContext.Server.MapPath("~/Image/") + file.FileName);
                    slider.ImageName = file.FileName;
                }
                service.AddSlider(slider);
                return RedirectToAction("index", "HomePageSlider");
            }
            else
            {
                return View(slider);
            }
        }

        [HttpGet]
        public ActionResult Remove(int id)
        {
            return View(service.SliderDetails(x => x.Id == id));
        }

        [HttpPost]
        public ActionResult Remove(FirstSlider slider)
        {
            service.RemoveSlider(slider);
            return RedirectToAction("index", "HomePageSlider");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(service.SliderDetails(x => x.Id == id));
        }

        [HttpPost]
        public ActionResult Edit(FirstSlider slider, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    file.SaveAs(HttpContext.Server.MapPath("~/Image/") + file.FileName);
                    slider.ImageName = file.FileName;
                }
                service.UpdateSlider(slider);
                return RedirectToAction("index", "HomePageSlider");
            }
            else
            {
                return View(slider);
            }
        }
    }
}