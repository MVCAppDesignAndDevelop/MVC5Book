using CookieSample.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CookieSample.Controllers
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

public ActionResult Login(string account, string password)
{
    var cookieName = "mvcAuth";
    if (account == "mvc" && password == "123456")
    {
        if (Response.Cookies.AllKeys.Contains(cookieName))
        {
            var cookieVal = Response.Cookies[cookieName].Value;
            HttpContext.Application.Remove(cookieVal);

            Response.Cookies.Remove(cookieName);
        }
        //登入成功產生一組token
        var token = Guid.NewGuid().ToString();

        //將 token 存放到 Application 內(實務上應該存進資料庫)
        HttpContext.Application[token] = DateTime.UtcNow.AddHours(1);

        var hc = new HttpCookie(cookieName, token)
        {
            Expires = DateTime.Now.AddHours(1),
            HttpOnly = true
        };
        Response.Cookies.Add(hc);
    }
    return RedirectToAction("Index");
}

        [AuthorizePlus]
        public ActionResult Test()
        {
            return Content("登入成功");
        }
    }
}