using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ch06.Models;
using Ch06.Models.ViewModels;

namespace Ch06.Controllers
{
    public class VtoCController : Controller
    {
        //
        // GET: /VtoC/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DemoQueryString()
        {
            ViewBag.id = Request.QueryString["id"];
            return View();
        }

        public ActionResult DemoRouteData(int id)
        {
            ViewBag.id = id;
            return View();
        }


        public ActionResult BasicModelBinding(string name)
        {
            ViewBag.Name = name;
            return View();
        }

        public ActionResult BasicModelBindingByModel(string name)
        {
            ViewData.Model = name;
            return View();
        }

        public ActionResult DemoFormCollection(FormCollection form)
        {
            ViewBag.Name = form["name"]; 
            ViewBag.Age = form["age"]; 
            return View();
        }

        public ActionResult PersonModelBinding(Person person)
        {
            //ViewData.Model = person;
            //return View();

            return View(person);

            // 使用Create範本
            // return View("CreatePersonModelBinding", person);
        }

        public ActionResult MultiPersonModelBinding(Person man, Person woman)
        {
            ViewBag.ManName = man.Name;
            ViewBag.ManAge = man.Age;

            ViewBag.WomanName = woman.Name;
            ViewBag.WomanAge = woman.Age;

            return View();
        }

        public ActionResult ViewModelModelBinding()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ViewModelModelBinding(PersonViewModel person)
        {
            return View("ShowViewModelModelBinding",person);
        }
    }
}