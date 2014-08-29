using System.Web.Mvc;

namespace SeleniumSample.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string id, string password)
        {
            if (id == "joey" && password == "1234")
            {
                //Redirect to index
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Message = "帳號或密碼有誤";
                return View();
            }
        }
    }
}