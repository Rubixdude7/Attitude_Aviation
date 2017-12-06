using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Attitude_Aviation.Controllers
{
    public class HomeController : Controller
    {
        private Models.ApplicationDbContext _dbContext;

        public HomeController()
        {
            _dbContext = new Models.ApplicationDbContext();
        }

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
            
            bool val = (System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
            if(val)
            {
                ViewBag.Message = "Wish to rent aircraft at Attitude Aviation?";
                var planes = _dbContext.Planes.ToList();
                return View(planes);
            }
            else
            {
                ViewBag.Message = "You're not logged in. Please Create an account";
                return View();
            }
        }

        public ActionResult Select(int id)
        {
            ViewBag.Message = "You have succesfully chosen a plane";

            return View();
        }

        public ActionResult Maintain()
        {
            bool val = (System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
            if(val)
            {
                ViewBag.Message = "Wish to repair aircraft?";
                var requests = _dbContext.Requests.ToList();
                return View(requests);
            }
            else
            {
                ViewBag.Message = "You're not logged in. Please Create an account";
                return View();
            }
        }

        public ActionResult Learn()
        {
            ViewBag.Message = "Wish to learn how to fly aircraft?";

            return View();
        }

        public ActionResult Add_Request(Models.MaintenanceRequest request)
        {
            _dbContext.Requests.Add(request);
            _dbContext.SaveChanges();
            return RedirectToAction("Maintain");
        }

        public ActionResult NewRequest()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            var request = _dbContext.Requests.SingleOrDefault(v => v.ID == id);

            if (request == null)
                return HttpNotFound();

            return View(request);
        }

        [HttpPost]
        public ActionResult Update(Models.MaintenanceRequest request)
        {
            var requestInDb = _dbContext.Requests.SingleOrDefault(v => v.ID == request.ID);

            if (requestInDb == null)
                return HttpNotFound();

            requestInDb.Plane_name = request.Plane_name;
            requestInDb.Problem = request.Problem;
            requestInDb.Description = request.Description;
            _dbContext.SaveChanges();

            return RedirectToAction("Maintain");
        }

        public ActionResult Delete(int id)
        {
            var request = _dbContext.Requests.SingleOrDefault(v => v.ID == id);

            if (request == null)
                return HttpNotFound();

            return View(request);
        }

        public ActionResult DoDelete(int id)
        {
            var request = _dbContext.Requests.SingleOrDefault(v => v.ID == id);


            if (request == null)
                return HttpNotFound();

            _dbContext.Requests.Remove(request);
            _dbContext.SaveChanges();
            return RedirectToAction("Maintain");
        }
    }
}