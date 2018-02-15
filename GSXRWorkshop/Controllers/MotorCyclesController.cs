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
    public class MotorCyclesController : Controller
    {
        private GarageDbContext db = new GarageDbContext();

        // GET: MotorCycles
        public ActionResult Index()
        {
            return View(db.Motorcycles.ToList());
        }

        // GET: MotorCycles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MotorCycle motorCycle = db.Motorcycles.Find(id);
            if (motorCycle == null)
            {
                return HttpNotFound();
            }
            return View(motorCycle);
        }

        // GET: MotorCycles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MotorCycles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MotorCycleId,MotorCycleName,Manufacturer,Year,Model,Displacement,Wheelbase")] MotorCycle motorCycle)
        {
            if (ModelState.IsValid)
            {
                db.Motorcycles.Add(motorCycle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(motorCycle);
        }

        // GET: MotorCycles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MotorCycle motorCycle = db.Motorcycles.Find(id);
            if (motorCycle == null)
            {
                return HttpNotFound();
            }
            return View(motorCycle);
        }

        // POST: MotorCycles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MotorCycleId,MotorCycleName,Manufacturer,Year,Model,Displacement,Wheelbase")] MotorCycle motorCycle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(motorCycle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(motorCycle);
        }

        // GET: MotorCycles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MotorCycle motorCycle = db.Motorcycles.Find(id);
            if (motorCycle == null)
            {
                return HttpNotFound();
            }
            return View(motorCycle);
        }

        // POST: MotorCycles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MotorCycle motorCycle = db.Motorcycles.Find(id);
            db.Motorcycles.Remove(motorCycle);
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
