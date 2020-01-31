using MyDeal.Areas.Admin.AdminAuthenticationFilter;
using MyDeal.Models;
using MyDeal.Models.BidsInformation;
using MyDeal.Service;
using MyDeal.Service.Messaging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        private readonly MyDealDbContext dbContext;
        private readonly EmailSending _email;
        public DashBoardController()
        {
            service = new CustomerService();
            bidsService = new BidsService();
            dbContext = new MyDealDbContext();
            _email = new EmailSending();
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
        public ActionResult CustomerDetails(int id)
        {
            return View(dbContext.customers.FirstOrDefault(x=>x.Id==id));
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

        [HttpPost]
        public ActionResult SendingMail(Email email)
        {
            try
            {
                var customerInfo = dbContext.customers.FirstOrDefault(x => x.Id == email.CustomerId);
                string Email = customerInfo.Email;
                string UserName = customerInfo.UserName;
                string MailSubject = "welcome Sir";
                string MailBody = " your bidded this product. ProductId: " + email.ProductId + " ProductName:" + email.ProductName + " .you are highest bidder .so you are selected for this product. welcome to you for win. Please collect your product.";
                _email.Email(Email, UserName, MailSubject, MailBody);
                TempData["sm"] = "succesful";
                return RedirectToAction("AllWinner");
            }
            catch (Exception)
            {
                TempData["sm"] = "failed";
                return RedirectToAction("AllWinner");
            }
        }
    }
}