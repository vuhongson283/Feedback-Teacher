﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MVC_FeedBackWed.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var path = context.HttpContext.Request.Path.ToString().ToLower();

            
            if (path.Contains("/login"))
            {
                base.OnActionExecuting(context);
                return;
            }

           
            var token = context.HttpContext.Session.GetString("Token");
            if (string.IsNullOrEmpty(token))
            {
                context.Result = new RedirectToRouteResult(new { controller = "Login", action = "Login" });
            }

            base.OnActionExecuting(context);
        }
    }
    
}
