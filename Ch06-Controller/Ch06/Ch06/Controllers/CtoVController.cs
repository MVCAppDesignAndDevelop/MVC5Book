using Ch06.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Ch06.Models.ViewModels;


namespace Ch06.Controllers
{
    public class CtoVController : Controller
    {
        //
        // GET: /CtoV/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DemoViewData()
        {
            // key: Name
            // data: Bruce
            ViewData["Name"] = "Bruce";
            return View();
        }

        public ActionResult DemoViewBag()
        {
            // ViewData["Name"] = Bruce;
            ViewBag.Name = "Bruce";
            return View();
        }

        private NorthwindEntities db = new NorthwindEntities();
        
        public ActionResult DemoVDModel()
        {
            ViewData["products"] = db.Products.ToList();
            return View();
        }

        public ActionResult DemoVBModel()
        {
            ViewBag.products = db.Products.ToList();
            return View();
        }

        public ActionResult DemoViewDataModel()
        {
            var product = db.Products.ToList();
            ViewData.Model = product;
            return View();
        }

        public ActionResult DemoStronglytyped()
        {
            return View(db.Products.ToList());
        }

        public ActionResult DemoInput()
        {
            return View();
        }

        public ActionResult CheckInput(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                TempData["Error"] = "不得空白！";
                return RedirectToAction("DemoInput");
            }

            ViewBag.Name = name;
            return View();
        }

        public ActionResult DemoTempData()
        {
            ViewData["Msg1"] = "From ViewData Message.";
            ViewBag.Msg2 = "From ViewBag Message.";
            TempData["Msg3"] = "From TempData Message.";
            return RedirectToAction("Redirect1");
        }

        public ActionResult Redirect1()
        {
            // 取出處理
            TempData["Msg4"] = TempData["Msg3"];
            return RedirectToAction("GetRedirectData");
        }

        public ActionResult GetRedirectData()
        {
            return View();
        }

        public ActionResult DemoTempDataProduct()
        {
            TempData["products"] = db.Products.ToList();
            return Redirect("DemoTempDataKeep");
        }

        public ActionResult DemoTempDataKeep()
        {
            return View();
        }

        public ActionResult DemoInclude()
        {
            var products = db.Products
                             .Include(p => p.Category)
                             .Include(p => p.Supplier);
            return View(products.ToList());
        }

        public ActionResult DemoSelectList()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName"); 
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "CompanyName");
            return View();
        }

        public ActionResult DemoMultiModelObject()
        {
            ViewBag.Author = "Bruce";
            ViewBag.Book = "ASP.NET MVC 5網站開發美學";
            ViewBag.Product = (from p in db.Products
                               select p).Take(10).ToList();
            ViewBag.Category = (from c in db.Categories
                                select c).Take(10).ToList();
            return View();
        }

        public ActionResult DemoViewModel()
        {
            return View(new ProductCategoryViewModel() 
            { 
                //Author = "Bruce",
                //Book = "ASP.NET MVC 5網站開發美學",
                Product = (from p in db.Products select p).Take(10).ToList(),
                Category = (from c in db.Categories select c).Take(10).ToList()
            });
        }

        public ActionResult DemoTuple()
        {
            var products = db.Products.ToList();
            var categories = db.Categories.ToList();
            var suppliers = db.Suppliers.ToList();
            var tupleModel = new Tuple<List<Product>, List<Category>, List<Supplier>>
                                      (products, categories, suppliers);
            return View(tupleModel);
        }


        public ActionResult DemoScaffoldList()
        {
            return View(db.Products.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
	}
}