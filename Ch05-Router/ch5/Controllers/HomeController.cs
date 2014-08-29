using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ch4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            var newUrl = RouteTable.Routes.GetVirtualPathForArea(
             Request.RequestContext,        //傳入目前的 RequestContext 
             new RouteValueDictionary(new   //新增 RouteValueDictionary 
             {
                 page = 1                   //page=1 的 Route Value 
             })).VirtualPath;               //取得新的網址 
            ViewData["newUrl"] = newUrl;
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
    }
}