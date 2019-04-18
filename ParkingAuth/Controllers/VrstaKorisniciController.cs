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
    public class VrstaKorisniciController : Controller
    {
        private ParkingServisPajaASPEntities db = new ParkingServisPajaASPEntities();

        // GET: VrstaKorisnici
        public ActionResult Index()
        {
            return View("~/Views/back-end/vrsta-korisnici/index.cshtml", db.vrsta_korisnici.ToList());
        }

        // GET: VrstaKorisnici/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vrsta_korisnici vrsta_korisnici = db.vrsta_korisnici.Find(id);
            if (vrsta_korisnici == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/back-end/vrsta-korisnici/details.cshtml", vrsta_korisnici);
        }

        // GET: VrstaKorisnici/Create
        public ActionResult Create()
        {
            return View("~/Views/back-end/vrsta-korisnici/create.cshtml");
        }

        // POST: VrstaKorisnici/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "vrsta_korisnici_id,naziv_vrsta_korisnici,created_at,updated_at")] vrsta_korisnici vrsta_korisnici)
        {
            if (ModelState.IsValid)
            {
                db.vrsta_korisnici.Add(vrsta_korisnici);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("~/Views/back-end/vrsta-korisnici/create.cshtml", vrsta_korisnici);
        }

        // GET: VrstaKorisnici/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vrsta_korisnici vrsta_korisnici = db.vrsta_korisnici.Find(id);
            if (vrsta_korisnici == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/back-end/vrsta-korisnici/edit.cshtml", vrsta_korisnici);
        }

        // POST: VrstaKorisnici/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "vrsta_korisnici_id,naziv_vrsta_korisnici,created_at,updated_at")] vrsta_korisnici vrsta_korisnici)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vrsta_korisnici).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("~/Views/back-end/vrsta-korisnici/edit.cshtml", vrsta_korisnici);
        }

        // GET: VrstaKorisnici/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vrsta_korisnici vrsta_korisnici = db.vrsta_korisnici.Find(id);
            if (vrsta_korisnici == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/back-end/vrsta-korisnici/delete.cshtml", vrsta_korisnici);
        }

        // POST: VrstaKorisnici/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            vrsta_korisnici vrsta_korisnici = db.vrsta_korisnici.Find(id);
            db.vrsta_korisnici.Remove(vrsta_korisnici);
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
