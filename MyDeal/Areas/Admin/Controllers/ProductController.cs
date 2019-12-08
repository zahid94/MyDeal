﻿using MyDeal.Areas.Admin.AdminAuthenticationFilter;
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
    [HandleError]
    public class ProductController : Controller
    {
        private readonly IProductService service;
        private readonly MyDealDbContext dbContext;
        public ProductController()
        {
            service = new ProductService();
            dbContext = new MyDealDbContext();
        }
        public ActionResult Index()
        {
            return View(service.GetAllProduct(x=>x.Id>0));
        }
        // GET: Admin/Product
        public ActionResult FilteredProduct(int id)
        {
            ViewBag.CategoryName = dbContext.categories.Where(x=>x.Id==id).FirstOrDefault().Name;
            return View(service.GetFilterProduct(x=>x.CategoryId==id));
        }

        [HttpGet]
        public ActionResult CategoryMenuPartials()
        {
            return PartialView(dbContext.categories.ToList());
        }

        // GET: Admin/AddProduct
        [HttpGet]       public ActionResult AddProduct()
        {
            ViewBag.CategoryId = new SelectList(dbContext.categories, "Id", "Name");
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddProduct(Product product , HttpPostedFileBase file)
        {
            ViewBag.CategoryId = new SelectList(dbContext.categories, "Id", "Name",product.Id);
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    
                    file.SaveAs(HttpContext.Server.MapPath("~/Image/") + file.FileName);
                    product.ImageName = file.FileName;
                }
                service.AddProduct(product);
                return RedirectToAction("AddProduct");
            }
            else
            {
                return View(product);
            }
        }

        // GET: Admin/EditProduct
        [HttpGet]
        public ActionResult EditProduct(int id)
        {
            ViewBag.CategoryId = new SelectList(dbContext.categories, "Id", "Name");
            return View(service.ProductDetails(x=>x.Id==id));
        }

        [HttpPost]
        public ActionResult EditProduct(Product product,HttpPostedFileBase file)
        {
            ViewBag.CategoryId = new SelectList(dbContext.categories, "Id", "Name",product.Id);
            if (ModelState.IsValid)
            {
                if (file != null)
                {

                    file.SaveAs(HttpContext.Server.MapPath("~/Image/") + file.FileName);
                    product.ImageName = file.FileName;
                }
                service.UpdateProduct(product);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
           
        }

        // GET: Admin/ProductDetails
        [HttpGet]
        public ActionResult ProductDetails(int id)
        {
            return View(service.ProductDetails(x => x.Id == id));
        }

        // GET: Admin/ProductDetails
        [HttpGet]
        public ActionResult RemoveProduct(int id)
        {
            return View(service.ProductDetails(x => x.Id == id));
        }
        [HttpPost]
        public ActionResult RemoveProduct(Product product)
        {
            service.RemoveProduct(product);
            return RedirectToAction("Index");
        }
    }
}