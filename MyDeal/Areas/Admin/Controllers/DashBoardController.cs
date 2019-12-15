using MyDeal.Areas.Admin.AdminAuthenticationFilter;
using MyDeal.AuthenticationFilter;
using MyDeal.Models;
using MyDeal.Models.BidsInformation;
using MyDeal.Service;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyDeal.Areas.Admin.Controllers
{
    //[AdminFiltering]    
    public class DashBoardController : Controller
    {
        private readonly ICustomerService service;
        private readonly IBidsService bidsService;
        private readonly MyDealDbContext dbContext;
        public DashBoardController()
        {
            service = new CustomerService();
            bidsService = new BidsService();
            dbContext = new MyDealDbContext();
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

        [HttpGet]
        public ActionResult AllWinner()
        {
            var model = dbContext.bids
                        .GroupBy(g => g.ProductId,
                        (key, group) => new WinnerVM
                        {
                            ProductId = key,                            
                            CustomerId = group.FirstOrDefault().CustomerId,
                            BidsPrice = group.Max(m => m.BidsPrice),
                            BidsTime = group.FirstOrDefault().BidsTime,
                            CustomerName=group.FirstOrDefault().Customer.FirstName,
                            ProductName=group.FirstOrDefault().Product.Title

                        }).ToList();
                        
            return View(model);
         }

    }
}