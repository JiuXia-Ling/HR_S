using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRUI.Filters
{
    public class LoginAttribute : ActionFilterAttribute
    {
        //提个问题：我在哪个方法干预合适
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //需求：我怎么判断用户登录了呢？
            if (filterContext.HttpContext.Session["user"] == null)
            {
                //让用户强行调到登录页面
                filterContext.HttpContext.Response.Redirect("/Longin/Index");
            }
        }
    }
}