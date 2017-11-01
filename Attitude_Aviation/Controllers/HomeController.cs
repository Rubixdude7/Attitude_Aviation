using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Attitude_Aviation.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Here at attitude Aviation:";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Here is our contact information.";

            return View();
        }

        public ActionResult Rent()
        {
            ViewBag.Message = "Wish to rent aircraft at Attitude Aviation?";

            return View();
        }

        public ActionResult Maintain()
        {
            ViewBag.Message = "Wish to repair aircraft?";

            return View();
        }

        public ActionResult Learn()
        {
            ViewBag.Message = "Wish to learn how to fly aircraft?";

            return View();
        }
    }
}