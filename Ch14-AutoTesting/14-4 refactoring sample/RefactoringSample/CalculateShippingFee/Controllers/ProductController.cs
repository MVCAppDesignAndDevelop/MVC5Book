using System.Collections.Generic;
using System.Web.Mvc;
using CalculateShippingFee.Models;
using CalculateShippingFee.Services;

namespace CalculateShippingFee.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            var companies = new List<SelectListItem>
            {
               new SelectListItem{ Text="黑貓", Value="1"},
               new SelectListItem{ Text="新竹貨運", Value="2"},
               new SelectListItem{ Text="郵局", Value="3"}
            };

            ViewBag.Company = companies;
            return View();
        }

        [HttpPost]
        public ActionResult Index(ProductModels product)
        {
            var companies = new List<SelectListItem>
            {
               new SelectListItem{ Text="黑貓", Value="1"},
               new SelectListItem{ Text="新竹貨運", Value="2"},
               new SelectListItem{ Text="郵局", Value="3"}
            };

            ViewBag.Company = companies;

            // Validation若不合法，則直接回傳
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            double fee = 0;
            IShipper shipper = Factory.GetShipper(product.Company);
            if (shipper != null)
            {
                fee = shipper.CalculateFee(product);

                // 將運費結果呈現在 View 上
                ViewBag.Fee = fee;
            }

            return View(product);
        }
    }
}