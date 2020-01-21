using MyDeal.Models;
using MyDeal.Models.BidsInformation;
using MyDeal.Repository;
using MyDeal.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;

namespace MyDeal.Controllers
{
    [HandleError]
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
        public ActionResult Index(int? page)
        {
            return View(service.GetAllProduct(x=>x.Id>0).ToPagedList(page ?? 1,4));
        }

        public ActionResult GetFilterProduct(int id)
        {
            ViewBag.CategoryName = db.categories.Where(x => x.Id == id).FirstOrDefault().Name;
            return View(service.GetFilterProduct(x => x.CategoryId == id));
        }

        [HttpGet]
        public ActionResult SearchCategory( Search search)
        {
            
            if (!String.IsNullOrEmpty(search.Searching.Trim()))
            {
                var catlist = db.categories.Where(x => x.Name.Contains(search.Searching.Trim())).FirstOrDefault();
                ViewBag.CategoryName = catlist.Name;                               
                return View(service.GetFilterProduct(x => x.CategoryId == catlist.Id));
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult CategoryMenu()
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

            //ViewBag.gallery = db.gallaryImages.Where(s=>s.ProductId==id).ToList();
            return View(product);
        }

        [HttpGet]
        public ActionResult ProductDecription(int id)
        {
            return PartialView(service.ProductDetails(x => x.Id == id));
        }
    }
}