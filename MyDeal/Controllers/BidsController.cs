using Microsoft.AspNet.Identity;
using MyDeal.AuthenticationFilter;
using MyDeal.Models.BidsInformation;
using MyDeal.Service;
using System;
using System.Linq;
using System.Web.Mvc;


namespace MyDeal.Controllers
{
    [HandleError]
    public class BidsController : Controller
    {
        private readonly IBidsService service;
        private readonly ICommentService cmdservice;
        public BidsController()
        {
            service = new BidsService();
            cmdservice = new CommentService();
        }
        // GET: Bids
        public ActionResult Index()
        {
            return View();
        }

        [AuthenticationFiltering]
        [HttpPost]
        public ActionResult AddBids(int ProductId)
        {
            Bids bids = new Bids();
            bids.ProductId = ProductId;
            bids.CustomerId = Convert.ToInt32(Session["id"].ToString());
            bids.BidsPrice = Convert.ToDouble(Request.Form["Bids"]);
            bids.BidsTime = DateTime.Now;
            service.AddBids(bids);
            return RedirectToAction("ProductDetails", "Shop", new { id = ProductId });
        }

        [HttpGet]
        public ActionResult GetAllBiders(int ProductId)
        {
            return PartialView(service.GetFilterBider(x=>x.ProductId==ProductId).OrderByDescending(y=>y.BidsPrice));
        }

        [AuthenticationFiltering]
        [HttpPost]
        public ActionResult Comment(int ProductId)
        {
            Comment entity = new Comment();            
            try
            {
                entity.CustomerId= Convert.ToInt32(Session["id"].ToString());
                entity.ProductId = ProductId;
                entity.CommentText = Request.Form["CommentText"];
                entity.CommentTime = DateTime.Now;
                cmdservice.Add(entity);

                return RedirectToAction("ProductDetails", "Shop", new { id = ProductId });
            }
            catch (Exception ex)
            {

                return View("Error",ex.Message);
            }
        }

        [HttpGet]
        public ActionResult GetAllComment(int ProductId)
        {
            return PartialView(cmdservice.GetFilterComment(x => x.ProductId == ProductId).OrderBy(y => y.Id));
        }
    }
}