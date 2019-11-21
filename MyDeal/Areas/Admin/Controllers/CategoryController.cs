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
    [AuthenticationFiltering]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _service;
        public CategoryController()
        {
            _service = new CategoryService();
        }
        // GET: Admin/Category
        public ActionResult Index()
        {
            return View(_service.GetAllCategory(x=>x.Id>0));
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                _service.AddCategory(category);
                return RedirectToAction("AddCategory");
            }
            return View(category);

        }
        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            return View(_service.CategoryDetails(x => x.Id == id));
        }
        [HttpPost]
        public ActionResult EditCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                _service.UpdateCategory(category);
                return RedirectToAction("index");
            }
            else
            {
                return View(category);
            }            
        }
        [HttpGet]
        public ActionResult RemoveCategory(int id)
        {
            return View(_service.CategoryDetails(x => x.Id == id));
        }
        [HttpPost]
        [ActionName("RemoveCategory")]
        public ActionResult RemoveCategoryConfirm(Category category)
        {
            _service.RemoveCategory(category);
            return RedirectToAction("index");
        }

    }
}