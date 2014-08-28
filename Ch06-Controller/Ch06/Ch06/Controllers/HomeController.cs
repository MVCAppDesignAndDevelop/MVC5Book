using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ch06.Controllers
{
    //[Authorize]
    //[OutputCache(CacheProfile = "HomeCache")]
    public class HomeController : Controller
    {
        //[HandleError(View = "Error", ExceptionType = typeof(Exception))]
        public ActionResult Index()
        {
            //throw new Exception("測試Error頁面.");
            return View();
            //return Redirect("Account/Login");
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
    }
}