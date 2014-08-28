using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Ch06.Filters;

namespace Ch06.Controllers
{
    public class FiltersController : Controller
    {
        //
        // GET: /Filters/
        #region "Authorization filters"


        public ActionResult GetImageTag()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult ImageTag(string name)
        {
            string filePath = "/Images/" + name + ".jpg";
            string imgTag = "<img src=\"" + filePath + "\" />";
            return Content(imgTag);
        }

        [RequireHttps]
        public ActionResult Secure()
        {
            return View();
        }

        #endregion

        #region "Action filters"


        [AF1(Order = 3)]
        [AF2(Order = 2)]
        [AF3(Order = 1)]
        public ActionResult ActionOrder()
        {
            return View();
        }
        #endregion


        #region "Result Filters"

        //[OutputCache(Duration = 10)]
        [OutputCache(NoStore = true, 
                     Location = OutputCacheLocation.None)]
        public ActionResult GetCacheTime()
        {
            ViewBag.Time = DateTime.Now;
            Thread.Sleep(2000);
            return View();
        }

        [ChildActionOnly]
        [OutputCache(Duration = 10)]
        public ActionResult GetCacheTimeForChildAction()
        {
            ViewBag.Time = DateTime.Now;
            return PartialView();
        }

        [OutputCache(CacheProfile = "PagingCache")]
        public ActionResult Index(int page = 1)
        {
            // Paging Code
            return View();
        }

        #endregion
    }
}