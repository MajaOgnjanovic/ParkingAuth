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
    public class ParkingKarteController : Controller
    {
        private ParkingServisPajaASPEntities db = new ParkingServisPajaASPEntities();

        // GET: ParkingKarte
        public ActionResult Index()
        {
            var parking_karte = db.parking_karte.Include(p => p.korisnici).Include(p => p.nacin_placanja).Include(p => p.parking_zone);
            return View("~/Views/back-end/parking-karte/index.cshtml", parking_karte.ToList());
        }

        // GET: ParkingKarte/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            parking_karte parking_karte = db.parking_karte.Find(id);
            if (parking_karte == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/back-end/parking-karte/details.cshtml", parking_karte);
        }

        // GET: ParkingKarte/Create
        public ActionResult Create()
        {
            ViewBag.korisnici_id = new SelectList(db.korisnici, "korisnici_id", "ime");
            ViewBag.nacin_placanja_id = new SelectList(db.nacin_placanja, "nacin_placanja_id", "naziv_nacin_placanja");
            ViewBag.parking_zona_id = new SelectList(db.parking_zone, "parking_zone_id", "naziv_parking_zone");
            return View("~/Views/back-end/parking-karte/create.cshtml");
        }

        // POST: ParkingKarte/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "parking_karte_id,parking_zona_id,registarske_tablice,parking_karata_datum_isteka,nacin_placanja_id,parking_karta_datum_kupovine,parking_kazna,korisnici_id,created_at,updated_at")] parking_karte parking_karte)
        {
            if (ModelState.IsValid)
            {
                db.parking_karte.Add(parking_karte);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.korisnici_id = new SelectList(db.korisnici, "korisnici_id", "ime", parking_karte.korisnici_id);
            ViewBag.nacin_placanja_id = new SelectList(db.nacin_placanja, "nacin_placanja_id", "naziv_nacin_placanja", parking_karte.nacin_placanja_id);
            ViewBag.parking_zona_id = new SelectList(db.parking_zone, "parking_zone_id", "naziv_parking_zone", parking_karte.parking_zona_id);
            return View("~/Views/back-end/parking-karte/create.cshtml", parking_karte);
        }

        // GET: ParkingKarte/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            parking_karte parking_karte = db.parking_karte.Find(id);
            if (parking_karte == null)
            {
                return HttpNotFound();
            }
            ViewBag.korisnici_id = new SelectList(db.korisnici, "korisnici_id", "ime", parking_karte.korisnici_id);
            ViewBag.nacin_placanja_id = new SelectList(db.nacin_placanja, "nacin_placanja_id", "naziv_nacin_placanja", parking_karte.nacin_placanja_id);
            ViewBag.parking_zona_id = new SelectList(db.parking_zone, "parking_zone_id", "naziv_parking_zone", parking_karte.parking_zona_id);
            return View("~/Views/back-end/parking-karte/edit.cshtml", parking_karte);
        }

        // POST: ParkingKarte/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "parking_karte_id,parking_zona_id,registarske_tablice,parking_karata_datum_isteka,nacin_placanja_id,parking_karta_datum_kupovine,parking_kazna,korisnici_id,created_at,updated_at")] parking_karte parking_karte)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parking_karte).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.korisnici_id = new SelectList(db.korisnici, "korisnici_id", "ime", parking_karte.korisnici_id);
            ViewBag.nacin_placanja_id = new SelectList(db.nacin_placanja, "nacin_placanja_id", "naziv_nacin_placanja", parking_karte.nacin_placanja_id);
            ViewBag.parking_zona_id = new SelectList(db.parking_zone, "parking_zone_id", "naziv_parking_zone", parking_karte.parking_zona_id);
            return View("~/Views/back-end/parking-karte/edit.cshtml", parking_karte);
        }

        // GET: ParkingKarte/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            parking_karte parking_karte = db.parking_karte.Find(id);
            if (parking_karte == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/back-end/parking-karte/delete.cshtml", parking_karte);
        }

        // POST: ParkingKarte/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            parking_karte parking_karte = db.parking_karte.Find(id);
            db.parking_karte.Remove(parking_karte);
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

