using MyDeal.Models;
using MyDeal.Models.BidsInformation;
using MyDeal.Repository;
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
        private readonly MyDealDbContext db;

        public ShopController()
        {
            service = new ShopService();
            db= new MyDealDbContext();
        }

        [HttpGet]
        // GET: Shop
        public ActionResult Index(int id)
        {
            return View(db.products.Where(x=>x.CategoryId==id).ToList());
        }

        [HttpGet]
        public ActionResult ProductMenuPartial()
        {
            return PartialView(db.categories.ToList());
        }

        [HttpGet]
        public ActionResult ProductDetails(int id)
        {
            Session["ProductId"] = id.ToString();
            var product = service.ProductDetails(x => x.Id == id);
           
            var price = (service.GetFilterBider(x=>x.ProductId==id).OrderByDescending(p => p.BidsPrice).Select(p => new { p.BidsPrice })
             ).Take(1).FirstOrDefault();


            if (price != null && price.BidsPrice>product.CurrentPrice && price.BidsPrice>product.ActualPrice)
            {
                product.CurrentPrice=price.BidsPrice;
            }            
            else
            {
                ModelState.AddModelError("","Please added Highest Bids.");
                product.CurrentPrice = product.ActualPrice;
            }
            
            return View(product);
        }

        [HttpGet]
        public ActionResult ProductDecription( int id)
        {
            return PartialView(service.ProductDetails(x=>x.Id==id));
        }
    }
}