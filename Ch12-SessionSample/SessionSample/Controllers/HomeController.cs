using SessionSample.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SessionSample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            Session["auth"] = true;
            return RedirectToAction("Index");
        }

        public ActionResult Logout()
        {
            Session["auth"] = false;
            return RedirectToAction("Index");
        }

        [AuthorizePlus]
        public ActionResult Backend()
        {
            return Content("您已進入後台");
        }
    }
}