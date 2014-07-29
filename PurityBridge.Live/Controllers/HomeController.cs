using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PurityBridge
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TheRightChoice()
        {
            return RedirectToAction("Index", "TheRightChoice");
        }
    }
}
