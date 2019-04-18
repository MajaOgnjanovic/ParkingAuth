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
    public class KorisniciController : Controller
    {
        private ParkingServisPajaASPEntities db = new ParkingServisPajaASPEntities();

        // GET: Korisnici
        public ActionResult Index()
        {
            var korisnici = db.korisnici.Include(k => k.vrsta_korisnici);
            return View("~/Views/back-end/korisnici/index.cshtml", korisnici.ToList());
        }

        // GET: Korisnici/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            korisnici korisnici = db.korisnici.Find(id);
            if (korisnici == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/back-end/korisnici/details.cshtml", korisnici);
        }

        // GET: Korisnici/Create
        public ActionResult Create()
        {
            ViewBag.vrsta_korisnika_id = new SelectList(db.vrsta_korisnici, "vrsta_korisnici_id", "naziv_vrsta_korisnici");
            return View("~/Views/back-end/korisnici/create.cshtml");
        }

        // POST: Korisnici/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "korisnici_id,ime,prezime,username,email,password,telefon,vrsta_korisnika_id,created_at,updated_at")] korisnici korisnici)
        {
            if (ModelState.IsValid)
            {
                db.korisnici.Add(korisnici);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.vrsta_korisnika_id = new SelectList(db.vrsta_korisnici, "vrsta_korisnici_id", "naziv_vrsta_korisnici", korisnici.vrsta_korisnika_id);
            return View("~/Views/back-end/korisnici/create.cshtml", korisnici);
        }

        // GET: Korisnici/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            korisnici korisnici = db.korisnici.Find(id);
            if (korisnici == null)
            {
                return HttpNotFound();
            }
            ViewBag.vrsta_korisnika_id = new SelectList(db.vrsta_korisnici, "vrsta_korisnici_id", "naziv_vrsta_korisnici", korisnici.vrsta_korisnika_id);
            return View("~/Views/back-end/korisnici/edit.cshtml", korisnici);
        }

        // POST: Korisnici/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "korisnici_id,ime,prezime,username,email,password,telefon,vrsta_korisnika_id,created_at,updated_at")] korisnici korisnici)
        {
            if (ModelState.IsValid)
            {
                db.Entry(korisnici).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.vrsta_korisnika_id = new SelectList(db.vrsta_korisnici, "vrsta_korisnici_id", "naziv_vrsta_korisnici", korisnici.vrsta_korisnika_id);
            return View("~/Views/back-end/korisnici/edit.cshtml", korisnici);
        }

        // GET: Korisnici/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            korisnici korisnici = db.korisnici.Find(id);
            if (korisnici == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/back-end/korisnici/delete.cshtml", korisnici);
        }

        // POST: Korisnici/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            korisnici korisnici = db.korisnici.Find(id);
            db.korisnici.Remove(korisnici);
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

