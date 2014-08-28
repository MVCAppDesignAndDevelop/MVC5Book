using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ch06.Models;

namespace Ch06.Controllers
{
    public class BaseController : Controller
    {
        protected NorthwindEntities db = new NorthwindEntities();

        protected string Title {
            set
            {
                ViewBag.Title = value;
            } 
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            log("OnActionExecuting", filterContext.RouteData);
        }

        private void log(string method, RouteData routeData)
        {
            var controller = routeData.Values["controller"];
            var action = routeData.Values["action"];
            string message = String.Format("{0} - controller:{1} action:{2}",
                                           method, controller, action);
            Console.WriteLine(message);
            Debug.WriteLine(message, "Action Filter Log");
        }
    }
}