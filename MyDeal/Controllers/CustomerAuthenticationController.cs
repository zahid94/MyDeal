using MyDeal.Models;
using MyDeal.Repository;
using MyDeal.Service;
using MyDeal.Service.RandomNumer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyDeal.Controllers
{
    [HandleError]
    public class CustomerAuthenticationController : Controller
    {
        private readonly ICustomerService service;
        private readonly IGenericRepository<Customer> repository;
        private readonly RandomNumberCreate random;
        public CustomerAuthenticationController()
        {
            service = new CustomerService();
            repository = new GenericRepository<Customer>();
            random = new RandomNumberCreate();
        }
        // GET: CustomerAuthenticaiton
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(Customer customer)
        {
            if (repository.IsExist(x=>x.UserName==customer.UserName && x.PassWord==customer.PassWord))
            {
                if (Session["ProductId"] != null)
                {
                    //Session["CustomerUserName"] = customer.UserName.ToString();
                    FormsAuthentication.SetAuthCookie(customer.UserName,false);
                    Session["Id"] = repository.GetFirstOrDefault(x => x.UserName == customer.UserName).Id;
                    var productId = Convert.ToInt32(Session["ProductId"]);
                    return RedirectToAction("ProductDetails", "Shop", new { id = productId });
                }
                else
                {
                    //Session["CustomerUserName"] = customer.UserName.ToString();
                    FormsAuthentication.SetAuthCookie(customer.UserName,false);
                    Session["Id"] = repository.GetFirstOrDefault(x => x.UserName == customer.UserName).Id;
                    return RedirectToAction("Index", "Shop");
                }   
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(Customer customer, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (Session["ProductId"] !=null)
                {
                    Session["CustomerUserName"] = customer.UserName.ToString();                    
                    var productId = Convert.ToInt32(Session["ProductId"].ToString());
                    if (file !=null)
                    {
                        file.SaveAs(HttpContext.Server.MapPath("~/Image/Customer/") + file.FileName);
                        customer.ImageName = file.FileName;
                    }
                    service.Registration(customer);
                    Session["Id"] = repository.GetFirstOrDefault(x => x.UserName == customer.UserName).Id;
                    return RedirectToAction("ProductDetails", "Shop", new { id = productId });
                }
                else
                {
                    Session["CustomerUserName"] = customer.UserName.ToString();
                    if (file != null)
                    {
                        file.SaveAs(HttpContext.Server.MapPath("~/Image/Customer/") + file.FileName);
                        customer.ImageName = file.FileName;
                    }
                    service.Registration(customer);
                    Session["Id"] = repository.GetFirstOrDefault(x => x.UserName == customer.UserName).Id;
                    return RedirectToAction("Index", "Shop");
                }     
            }
            else
            {
                return View();
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("LogIn");
        }        
        
    }
}