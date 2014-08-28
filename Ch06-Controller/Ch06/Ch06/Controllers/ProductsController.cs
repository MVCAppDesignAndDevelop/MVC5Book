using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ch06.Models;

namespace Ch06.Controllers
{
    public class ProductsController : BaseController
    {
        //private NorthwindEntities db = new NorthwindEntities();

        // GET: /Products/
        //[OutputCache(Duration = 10, SqlDependency = "NorthwindCache:Products")]
        public ActionResult Index()
        {
            Title = "產品首頁";
            return View(db.Products.ToList());
        }

        // GET: /Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: /Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Products/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ProductID,ProductName,SupplierID,CategoryID,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued")] Product product)
        {
            //if (ModelState["UnitPrice"].Errors.Count > 0)
            //{
            //    ModelError error = ModelState["UnitPrice"].Errors[0];
            //    string errorMessage = error.ErrorMessage;
            //    Exception errorException = error.Exception;
            //    // 寫入日誌
            //}

            if (ModelState.IsValid)
            {

                // 自訂驗證
                //if (product.UnitPrice <= 0)
                //{
                //    ModelState.AddModelError("UnitPrice", "請確認產品單價是否有問題");
                //    return View(product);
                //}

                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ModelState.Clear();
            return View(product);
        }

        // GET: /Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

         //POST: /Products/Edit/5
         //若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
         //詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        //[ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ProductID,ProductName,SupplierID,CategoryID,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // POST: /Products/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit()
        //{
        //    Product product = new Product();
        //    try
        //    {
        //        UpdateModel(product);
        //        db.Entry(product).State = EntityState.Modified;
        //        db.SaveChanges();
        //    }
        //    catch (Exception)
        //    {
        //        return View(product);
        //    }
        //    return RedirectToAction("Index");
        //}

        //// POST: /Products/Edit/5
        //// 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        //// 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(FormCollection form)
        //{
        //    Product product = new Product();
        //    TryUpdateModel(product, "", form.AllKeys,
        //        new[] { "SupplierID,CategoryID,,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel" });
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(product).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        // 錯誤處理
        //        return View(product);
        //    }

        //    //if (TryUpdateModel(product))
        //    //{
        //    //    db.Entry(product).State = EntityState.Modified;
        //    //    db.SaveChanges();
        //    //    return RedirectToAction("Index");
        //    //}
        //    //else
        //    //{
        //    //    // 錯誤處理
        //    //    return View(product);
        //    //}
        //    //
        //    //return View(product);
        //}

        // GET: /Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: /Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
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
