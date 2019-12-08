using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyDeal.Areas.Admin.AdminAuthenticationFilter
{
    public class AdminFiltering : ActionFilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (string.IsNullOrEmpty(Convert.ToString(filterContext.HttpContext.Session["UserName"])))            {
                
                filterContext.Result = new RedirectResult("/admin/AdminAuthentication/LogIn");
            }
        }
    }
}