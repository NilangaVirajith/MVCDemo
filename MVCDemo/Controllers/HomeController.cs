using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Countries = new List<string> {
                "Sri Lanka",
                "India",
                "Pakistan"
            };
            return View();
        }

        public string Details()
        {
            return "Details method invoked";
        }
    }
}