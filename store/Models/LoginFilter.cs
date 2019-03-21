using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace store.Models
{
    public class LoginFilter : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        { }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            String username = context.HttpContext.Session.GetString("username");
            

            if (username == null)
            {
                //重定向到登录页面
                context.HttpContext.Response.Redirect("../Home/Login");
                return;
            } 
        }

        //public override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    String username = filterContext.HttpContext.Session.GetString("username");

        //    if(username == null)
        //    {
        //        //重定向到登录页面
        //        filterContext.HttpContext.Response.Redirect("../Home/Login");
        //        return;
        //    }

        //    base.OnActionExecuting(filterContext);
        //}

    }
}
