using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ch06.Models;

namespace Ch06.Controllers
{
    public class ModelBinderController : Controller
    {
        //
        // GET: /ModelBinder/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Test(decimal amount)
        {
            return View(amount);
        }

        public ActionResult GetScoreRecord()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetScoreRecord(List<ScoreRecord> scores)
        {
            ViewBag.Result = string.Join("\n",
                                scores.Select(
                                    o =>
                                        string.Format("<li>{0} : {1}</li>",
                                        o.UserId, o.Score)).ToArray()
                             );
            return View();
        }
	}
}