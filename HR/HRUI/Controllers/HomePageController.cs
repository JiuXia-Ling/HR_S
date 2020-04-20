using HRUI.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRUI.Controllers
{
    [Login]
    public class HomePageController : Controller
    {
        // GET: HomePage
        public ActionResult Mian()
        {
            return View();
        }

        public ActionResult left()
        {
            return View();
        }

        public ActionResult main()
        {
            ViewBag.Name = Session["Name"];
            return View();
        }

        public ActionResult top()
        {
            ViewBag.Name = Session["Name"];
            return View();
        }
    }
}