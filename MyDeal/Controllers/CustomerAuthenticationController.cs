using MyDeal.Models;
using MyDeal.Repository;
using MyDeal.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyDeal.Controllers
{
    public class CustomerAuthenticationController : Controller
    {
        private readonly ICustomerService service;
        private readonly IGenericRepository<Customer> repository;        
        public CustomerAuthenticationController()
        {
            service = new CustomerService();
            repository = new GenericRepository<Customer>();
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
                    Session["CustomerUserName"] = customer.UserName.ToString();
                    Session["Id"] = repository.GetFirstOrDefault(x => x.UserName == customer.UserName).Id;
                    var productId = Convert.ToInt32(Session["ProductId"].ToString());
                    return RedirectToAction("ProductDetails", "Shop", new { id = productId });
                }
                else
                {
                    Session["CustomerUserName"] = customer.UserName.ToString();
                    Session["Id"] = repository.GetFirstOrDefault(x => x.UserName == customer.UserName).Id;
                    return RedirectToAction("Index", "Shop");
                }
                

            }
            else
            {
                return View();
            }
        }

        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(Customer customer)
        {
            if (ModelState.IsValid)
            {
                if (Session["ProductId"] !=null)
                {
                    Session["CustomerUserName"] = customer.UserName.ToString();                    
                    var productId = Convert.ToInt32(Session["ProductId"].ToString());
                    service.Registration(customer);
                    Session["Id"] = repository.GetFirstOrDefault(x => x.UserName == customer.UserName).Id;
                    return RedirectToAction("ProductDetails", "Shop", new { id = productId });
                }
                else
                {
                    Session["CustomerUserName"] = customer.UserName.ToString();                    
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
            Session.Clear();
            return RedirectToAction("LogIn");
        }
    }
}