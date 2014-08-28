using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Ch06.Extensions;
using Ch06.Models;
using Microsoft.Ajax.Utilities;

namespace Ch06.Controllers
{
    public class MvcTypeController : Controller
    {
        //
        // GET: /MvcType/

        #region "Start"
        public ActionResult UseResult()
        {
            // 回傳繼承型別
            return new ViewResult();
        }

        // 指定為繼承型別
        public ViewResult UseResult2()
        {
            return new ViewResult();
        }

        // 一般用法
        public ActionResult UseMethod()
        {
            // 回傳Controller類別方法
            return View();
        }

        public ContentResult ContentAction()
        {
            return Content("Hello, ASP.NET MVC");
        }

        public JsonResult JsonAction()
        {
            return Json("Hello, ASP.NET MVC");
        }

        #endregion

        #region "ContentResult"

        public ActionResult DemoContent()
        {
            return Content("Hello, ASP.NET MVC");
        }

        public ActionResult DemoHtmlContent()
        {
            return Content("<h1>ASP.NET MVC 5</h1>", "text/html");
        }

        public ActionResult DemoEncodingContent()
        {
            return Content("<p>こんにちは</p>", "text/html", Encoding.UTF8);
        }

        public ActionResult DemoCSVContent()
        {
            return Content("Name,Age\r\nBruce,18\r\n", "text/csv");
        }

        public ActionResult DemoXMLContent()
        {
            string xmlContent = "<root><book>ASP.NET MVC 5</book></root>";
            return Content(xmlContent, "text/xml", Encoding.UTF8);
        }

        #endregion

        #region "JavaScript"

        public ActionResult OnlineGame()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult NextTime()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("var nextTime='{0}';\r\n", DateTime.UtcNow);
            return JavaScript(sb.ToString());
        }

        #endregion

        #region "Redirect"
        public ActionResult DemoRedirect(string param)
        {
            if (!String.IsNullOrEmpty(param))
            {
                string baseUrl = "http://mvcbook.net/";
                Uri url = new Uri(baseUrl + param);
                return Redirect(url.ToString());  // 302
                //return RedirectPermanent(url.ToString());   // 301
            }
            else
            {
                return Content("error");
            }
        }
        #endregion

        #region "File"

        public ActionResult DemoFilePath()
        {
            string path = Server.MapPath(@"~\Content\Site.css");
            return File(path, "text/css", "網站.css");
        }

        public ActionResult UploadToDisk()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadToDisk(HttpPostedFileBase file)
        {
            if (file != null)
            {
                if (file.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(file.FileName);
                    string path = Path.Combine(Server.MapPath("~/Files/"), fileName);
                    file.SaveAs(path);
                    string message = "Name:" + fileName + ",<br>" +
                                     "Content Type:" + file.ContentType + ",<br>" +
                                     "Size:" + file.ContentLength + ",<br>" +
                                     "上傳成功.";
                    TempData["Message"] = message;
                }
                else
                {
                    TempData["Message"] = "空白檔案？";
                }
            }
            else
            {
                TempData["Message"] = "有選到檔案？";
            }

            return RedirectToAction("UploadToDisk");
        }

        public ActionResult MultiFileUpload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MultiFileUpload(IEnumerable<HttpPostedFileBase> files)
        {
            string message = null;
            foreach (var file in files)
            {
                if (file != null && file.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(file.FileName);
                    string path = Path.Combine(Server.MapPath("~/Files/"), fileName);
                    file.SaveAs(path);
                    message += fileName + "上傳成功.<br>";
                }
            }

            TempData["Message"] = message;
            return View();
        }

        public ActionResult UploadToDB()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadToDB(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                string fileName = Path.GetFileName(file.FileName);
                int length = file.ContentLength;
                byte[] buffer = new byte[length];
                // 讀取Stream，寫入buffer
                file.InputStream.Read(buffer, 0, length);

                DbFile dbfile = new DbFile()
                {
                    Name = fileName,
                    MimeType = file.ContentType,
                    Size = file.ContentLength,
                    Content = buffer
                };
                try
                {
                    db.DbFiles.Add(dbfile);
                    db.SaveChanges();
                    string message = "Name:" + fileName + ",<br>" +
                                     "Content Type:" + file.ContentType + ",<br>" +
                                     "Size:" + file.ContentLength + ",<br>" +
                                     "上傳成功.";
                    TempData["Message"] = message;
                }
                catch (Exception ex)
                {
                    TempData["Message"] = "儲存錯誤：" + ex.Message;
                }
            }
            else
            {
                TempData["Message"] = "未選擇或空白檔案。";
            }
            return View();
        }

        public ActionResult MultiFileUploadDB()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MultiFileUploadDB(IEnumerable<HttpPostedFileBase> files )
        {
            string message = null;
            foreach (var file in files)
            {
                if (file != null && file.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(file.FileName);
                    int length = file.ContentLength;
                    byte[] buffer = new byte[length];
                    // 讀取Stream，寫入buffer
                    file.InputStream.Read(buffer, 0, length);

                    DbFile dbfile = new DbFile()
                    {
                        Name = fileName,
                        MimeType = file.ContentType,
                        Size = file.ContentLength,
                        Content = buffer
                    };
                    try
                    {
                        db.DbFiles.Add(dbfile);
                        db.SaveChanges();
                        message += fileName + "上傳成功.<br>";
                        TempData["Message"] += message;
                    }
                    catch (Exception ex)
                    {
                        TempData["Message"] = "儲存錯誤：" + ex.Message;
                    }
                }
                else
                {
                    TempData["Message"] = "未選擇或空白檔案。";
                }
            }
            
            return View();
        }

        public ActionResult DemoFileContent(int id)
        {
            var file = db.DbFiles
                         .Where(f => f.Id  == id)
                         .SingleOrDefault();
            if (file != null)
            {
                byte[] buffer = file.Content;
                return File(buffer, file.MimeType , file.Name);
            }
            
            return Content("找不到檔案！");
        }

        public ActionResult GetImages()
        {
            string path = Server.MapPath(@"~\Images\View01.jpg");
            byte[] by;
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                BinaryReader br = new BinaryReader(fs);
                by = br.ReadBytes((int)fs.Length);
            }
            return File(by, "image/jpeg");
        }

        public ActionResult GetImages(string image)
        {
            string path = Server.MapPath(@"~\Images\" + image + ".jpg");
            byte[] by;
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                BinaryReader br = new BinaryReader(fs);
                by = br.ReadBytes((int)fs.Length);
            }
            return File(by, "image/jpeg");
        }

        public ActionResult ShowImages()
        {
            return View();
        }

        public ActionResult DemoFileStream()
        {
            string path = Server.MapPath(@"~\Images\View01.jpg");
            FileStream fs = System.IO.File.OpenRead(path);
            return File(fs, "image/jpge");
        }

        public ActionResult DemoVideo()
        {
            // 應該由資料庫取得相關資訊
            return new VideoResult("sky.mp4", "video/mp4");
        }

        public ActionResult ShowVideo()
        {
            return View();
        }

        #endregion


        #region "View"

        public ActionResult DemoActionName()
        {
            ViewBag.Book = "ASP.NET MVC 5";
            //return View("DemoActionName2");
            return View("DemoActionName3");
        }

        public ActionResult DemoMaster()
        {
            //return View(null, "_Layout2");
            return View();
        }

        public ActionResult DemoPartialView()
        {
            return View();
        }

        public ActionResult GetTime()
        {
            Thread.Sleep(2000);
            return PartialView("_GetTimePartial");
        }


        #endregion

 

        private NorthwindEntities db = new NorthwindEntities();

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

            if (!Request.IsAjaxRequest())
            {
                return View(product);
            }
            else
            {
                // AllowGet有資安風險，請參考Json()的說明
                return Json(product, JsonRequestBehavior.AllowGet);
            }
        }

        public int ProductsCount()
        {
            return db.Products.Count();
        }

        #region "Json"
        public ActionResult DemoJson1()
        {
            Person person = new Person
            {
                Name = "Bruce",
                Age = 18
            };

            return Json(person, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DemoJson2()
        {
            var person = new
            {
                Name = "Bruce",
                Age = 18,
                Birthday = new DateTime(2099, 9, 9)
            };
            return Json(person, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DemoJsonModel(int? id)
        {
            // LazyLoadingEnabled 處理循環參考
            db.Configuration.LazyLoadingEnabled = false;
            Product product = db.Products.Find(id);
            return Json(product);
        }
        #endregion

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