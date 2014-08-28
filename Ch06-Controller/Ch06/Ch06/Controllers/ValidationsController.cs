using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Ch06.Models;

namespace Ch06.Controllers
{
    public class ValidationsController : Controller
    {
        // GET: /Validations/Price
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public ActionResult Price([Bind(Include = "UnitPrice")] Product product)
        {
            string message = null;
            if (product.UnitPrice.HasValue)
            {
                // min：應該由資料庫或組態檔取得
                const decimal min = 10;

                if (product.UnitPrice < min)
                {
                    message = "價格低於系統限制。";
                    return Json(message, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                message = "錯誤。";
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
    }
}