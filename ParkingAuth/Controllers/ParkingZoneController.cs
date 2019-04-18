using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ParkingAuth.Models;

namespace ParkingAuth.Controllers
{
    public class ParkingZoneController : Controller
    {
        private ParkingServisPajaASPEntities db = new ParkingServisPajaASPEntities();

        // GET: ParkingZone
        public ActionResult Index()
        {
            return View("~/Views/back-end/parking-zone/index.cshtml", db.parking_zone.ToList());
        }

        // GET: ParkingZone/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            parking_zone parking_zone = db.parking_zone.Find(id);
            if (parking_zone == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/back-end/parking-zone/details.cshtml", parking_zone);
        }

        // GET: ParkingZone/Create
        public ActionResult Create()
        {
            return View("~/Views/back-end/parking-zone/create.cshtml");
        }

        // POST: ParkingZone/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "parking_zone_id,naziv_parking_zone")] parking_zone parking_zone)
        {
            if (ModelState.IsValid)
            {
                db.parking_zone.Add(parking_zone);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("~/Views/back-end/parking-zone/create.cshtml", parking_zone);
        }

        // GET: ParkingZone/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            parking_zone parking_zone = db.parking_zone.Find(id);
            if (parking_zone == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/back-end/parking-zone/edit.cshtml", parking_zone);
        }

        // POST: ParkingZone/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "parking_zone_id,naziv_parking_zone")] parking_zone parking_zone)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parking_zone).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("~/Views/back-end/parking-zone/edit.cshtml", parking_zone);
        }

        // GET: ParkingZone/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            parking_zone parking_zone = db.parking_zone.Find(id);
            if (parking_zone == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/back-end/parking-zone/delete.cshtml", parking_zone);
        }

        // POST: ParkingZone/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            parking_zone parking_zone = db.parking_zone.Find(id);
            db.parking_zone.Remove(parking_zone);
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
