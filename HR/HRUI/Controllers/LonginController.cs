using HRIBLL;
using HRModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRUI.Controllers
{
    public class LonginController : Controller
    {
        public IusersBLL ius { get; set; }
        // GET: Longin
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(usersModel us)
        {
            if (ModelState.IsValid)
            {
                List<usersModel> list = ius.us().Where(a => a.u_name == us.u_name && a.u_password == us.u_password).ToList();
                if (list.Count > 0)
                {
                    Session["User"] = us.u_name;
                    Session["Name"] = list[0].u_true_name;
                    return Content("<script>alert('登录成功');window.location.href='/HomePage/Mian'</script>");
                }
                else
                {
                    return Content("<script>alert('登录失败');window.location.href='/Longin/Index'</script>");
                }
            }
            else
            {
                return View();
            }
        }
    }
}