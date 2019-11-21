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
        public WelcomeSliderController()
        {
            service = new HomePageSliderService();
        }
        // GET: WelcomeSlider
        public ActionResult Index()
        {
            return PartialView(service.GetAll(x=>x.Id>0));
        }        
    }
}