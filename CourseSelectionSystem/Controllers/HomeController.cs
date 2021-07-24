using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourseSelectionSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CourseQuery()
        {
            return View();
        }
        public ActionResult StudentQuery()
        {
            return View();
        }

        public ActionResult SelectionQuery()
        {
            return View();
        }
    }
}