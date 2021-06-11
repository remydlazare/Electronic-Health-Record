using Rehabilitation.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Rehabilitation.Filters
{
    public class LoginFilter : ActionFilterAttribute
    {
        public string Role { get; set; } = null;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["Username"] == null)
            {
                //var controller = (LoginController)filterContext.Controller;
                filterContext.Result = new RedirectResult("~/Authorize/Index");
            }
        }
    }
    public class RoleFilter : ActionFilterAttribute
    {
        public string Role { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string CurrentRole = HttpContext.Current.Session["Role"] == null ? null : HttpContext.Current.Session["Role"].ToString();
            int CurrentRoleLv = -1, RoleLv = 0;
            switch(CurrentRole)
            {
                case "Patient":
                    CurrentRoleLv = 1;
                    break;
                case "Doctor":
                    CurrentRoleLv = 2;
                    break;
                case "Admin":
                    CurrentRoleLv = 3;
                    break;
            }
            switch (Role)
            {
                case "Patient":
                    RoleLv = 1;
                    break;
                case "Doctor":
                    RoleLv = 2;
                    break;
                case "Admin":
                    RoleLv = 3;
                    break;
            }
            if (CurrentRoleLv < RoleLv)
            {
                filterContext.Controller.ViewBag.ErrorMessage = "The search results has been sent.";
                filterContext.Result = new HttpStatusCodeResult(401);
            }
        }
    }
}