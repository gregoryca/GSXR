using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GSXRWorkshop.Models;

namespace GSXRWorkshop.Controllers
{
    public class CarRepairsController : Controller
    {
        private GarageDbContext db = new GarageDbContext();

        // GET: CarRepairs
        [Authorize]
        public ActionResult Index()
        {
            var carRepairs = db.CarRepairs.Include(c => c.Car).Include(c => c.Employee);
            return View(carRepairs.ToList());
        }

        // GET: CarRepairs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarRepair carRepair = db.CarRepairs.Find(id);
            if (carRepair == null)
            {
                return HttpNotFound();
            }
            return View(carRepair);
        }

        // GET: CarRepairs/Create
        public ActionResult Create()
        {
            ViewBag.CarId = new SelectList(db.Cars, "CarId", "Manufacturer");
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "Name");
            return View();
        }

        // POST: CarRepairs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RepairId,RepairName,Notes,CarId,EmployeeId")] CarRepair carRepair)
        {
            if (ModelState.IsValid)
            {
                db.CarRepairs.Add(carRepair);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CarId = new SelectList(db.Cars, "CarId", "Manufacturer", carRepair.CarId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "Name", carRepair.EmployeeId);
            return View(carRepair);
        }

        // GET: CarRepairs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarRepair carRepair = db.CarRepairs.Find(id);
            if (carRepair == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarId = new SelectList(db.Cars, "CarId", "Manufacturer", carRepair.CarId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "Name", carRepair.EmployeeId);
            return View(carRepair);
        }

        // POST: CarRepairs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RepairId,RepairName,Notes,CarId,EmployeeId")] CarRepair carRepair)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carRepair).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarId = new SelectList(db.Cars, "CarId", "Manufacturer", carRepair.CarId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "Name", carRepair.EmployeeId);
            return View(carRepair);
        }

        // GET: CarRepairs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarRepair carRepair = db.CarRepairs.Find(id);
            if (carRepair == null)
            {
                return HttpNotFound();
            }
            return View(carRepair);
        }

        // POST: CarRepairs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarRepair carRepair = db.CarRepairs.Find(id);
            db.CarRepairs.Remove(carRepair);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

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
