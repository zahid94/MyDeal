using MyDeal.Areas.Admin.AdminAuthenticationFilter;
using MyDeal.AuthenticationFilter;
using MyDeal.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyDeal.Areas.Admin.Controllers
{
    [AdminFiltering]
    public class DashBoardController : Controller
    {
        private readonly ICustomerService service;
        private readonly IBidsService bidsService;
        public DashBoardController()
        {
            service = new CustomerService();
            bidsService = new BidsService();
        }
        // GET: Admin/DashBoard
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return View(service.GetAll(x=>x.Id>0));
        }
        [HttpGet]
        public ActionResult GetAllBiders()
        {
            return View(bidsService.GetAllBider(x => x.Id > 0));
        }
    }
}