using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ch06.Resouces;

namespace Ch06.Controllers
{
    public class OtherController : Controller
    {
        //
        // GET: /Other/
        public ActionResult Index()
        {
            ViewBag.AppMessage = Resources.ModelResource.ProductName;
            // 自訂目錄不需要使用 Resources來存取
            ViewBag.CusMessage = ProductResource.ProductName;
            return View();
        }
	}
}