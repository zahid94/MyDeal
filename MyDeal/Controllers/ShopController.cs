using MyDeal.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyDeal.Controllers
{
    public class ShopController : Controller
    {
        private readonly IShopService service;
        public ShopController()
        {
            service = new ShopService();
        }
        // GET: Shop
        public ActionResult Index()
        {
            return View(service.GetAllProduct(x=>x.Id>0));
        }
        public ActionResult ProductDetails(int id)
        {
            return View(service.ProductDetails(x => x.Id > 0));
        }
    }
}