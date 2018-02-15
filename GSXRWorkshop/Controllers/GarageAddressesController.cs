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
    public class GarageAddressesController : Controller
    {
        private GarageDbContext db = new GarageDbContext();

        // GET: GarageAddresses
        public ActionResult Index()
        {
            var garageAddress = db.GarageAddress.Include(g => g.Garage);
            return View(garageAddress.ToList());
        }

        // GET: GarageAddresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GarageAddress garageAddress = db.GarageAddress.Find(id);
            if (garageAddress == null)
            {
                return HttpNotFound();
            }
            return View(garageAddress);
        }

        // GET: GarageAddresses/Create
        public ActionResult Create()
        {
            ViewBag.GarageId = new SelectList(db.Garages, "GarageId", "Name");
            return View();
        }

        // POST: GarageAddresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AddressId,GarageId,StreetName,ZipCode,Housenumber,City")] GarageAddress garageAddress)
        {
            if (ModelState.IsValid)
            {
                db.GarageAddress.Add(garageAddress);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GarageId = new SelectList(db.Garages, "GarageId", "Name", garageAddress.GarageId);
            return View(garageAddress);
        }

        // GET: GarageAddresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GarageAddress garageAddress = db.GarageAddress.Find(id);
            if (garageAddress == null)
            {
                return HttpNotFound();
            }
            ViewBag.GarageId = new SelectList(db.Garages, "GarageId", "Name", garageAddress.GarageId);
            return View(garageAddress);
        }

        // POST: GarageAddresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AddressId,GarageId,StreetName,ZipCode,Housenumber,City")] GarageAddress garageAddress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(garageAddress).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GarageId = new SelectList(db.Garages, "GarageId", "Name", garageAddress.GarageId);
            return View(garageAddress);
        }

        // GET: GarageAddresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GarageAddress garageAddress = db.GarageAddress.Find(id);
            if (garageAddress == null)
            {
                return HttpNotFound();
            }
            return View(garageAddress);
        }

        // POST: GarageAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GarageAddress garageAddress = db.GarageAddress.Find(id);
            db.GarageAddress.Remove(garageAddress);
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
