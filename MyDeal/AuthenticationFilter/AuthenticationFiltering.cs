using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace MyDeal.AuthenticationFilter
{    
    public class AuthenticationFiltering : ActionFilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (string.IsNullOrEmpty(Convert.ToString(filterContext.HttpContext.Session["CustomerUserName"])))
            {
                filterContext.Result = new RedirectResult("/CustomerAuthentication/LogIn");                
            }
        }
    }
}