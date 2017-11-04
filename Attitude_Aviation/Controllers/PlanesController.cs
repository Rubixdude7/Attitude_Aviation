using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Attitude_Aviation.Controllers
{
    public class PlanesController : Controller
    {
        private Models.ApplicationDbContext _dbContext;

        public PlanesController()
        {
            _dbContext = new Models.ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var planes = _dbContext.Planes.ToList();
            return View(planes);
        }

        public ActionResult New()
        {
            return View();
        }

        public ActionResult Add(Models.Plane plane)
        {
            _dbContext.Planes.Add(plane);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var plane = _dbContext.Planes.SingleOrDefault(v => v.ID == id);

            if (plane == null)
                return HttpNotFound();

            return View(plane);
        }

        [HttpPost]
        public ActionResult Update(Models.Plane plane)
        {
            var planeInDb = _dbContext.Planes.SingleOrDefault(v => v.ID == plane.ID);

            if (planeInDb == null)
                return HttpNotFound();

            planeInDb.Name = plane.Name;
            planeInDb.Description = plane.Description;
            planeInDb.Stock = plane.Stock;
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var plane = _dbContext.Planes.SingleOrDefault(v => v.ID == id);

            if (plane == null)
                return HttpNotFound();

            return View(plane);
        }

        public ActionResult DoDelete(int id)
        {
            var plane = _dbContext.Planes.SingleOrDefault(v => v.ID == id);


            if(plane == null)
                return HttpNotFound();

            _dbContext.Planes.Remove(plane);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}