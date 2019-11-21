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
            if (string.IsNullOrEmpty(Convert.ToString(filterContext.HttpContext.Session["UserName"])))
            {
                //filterContext.Result = new HttpUnauthorizedResult();
                filterContext.Result = new RedirectResult("/admin/AdminAuthentication/LogIn");
            }
        }
        //public void OnAuthorizationChallenge(AuthenticationChallengeContext filterContext)
        //{
        //    //if (filterContext.Result==null||filterContext.Result is HttpUnauthorizedResult)
        //    //{
        //    //    //filterContext.Result = new ViewResult { ViewName = "Error" };
        //    //    filterContext.Result = new RedirectResult("/admin/dashboard");
        //    //}
        //}
    }
}