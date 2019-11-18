using MyDeal.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyDeal.Controllers
{
    public class WelcomeSliderController : Controller
    {
        private readonly IHomePageSliderService service;
        private readonly IFirstSliderService _service;
        public WelcomeSliderController()
        {
            service = new HomePageSliderService();
            _service = new FirstSliderService();
        }
        // GET: WelcomeSlider
        public ActionResult Index()
        {
            return PartialView(service.GetAll(x=>x.Id>0));
        }

        public ActionResult FirstSlider()
        {
            return PartialView(_service.GetAll(x => x.Id > 0));
        }
    }
}