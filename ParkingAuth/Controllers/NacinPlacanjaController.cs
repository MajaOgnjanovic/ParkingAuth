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
    public class NacinPlacanjaController : Controller
    {
        private ParkingServisPajaASPEntities db = new ParkingServisPajaASPEntities();

        // GET: NacinPlacanja
        public ActionResult Index()
        {
            return View("~/Views/back-end/nacin-placanja/index.cshtml", db.nacin_placanja.ToList());
        }

        // GET: NacinPlacanja/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            nacin_placanja nacin_placanja = db.nacin_placanja.Find(id);
            if (nacin_placanja == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/back-end/nacin-placanja/details.cshtml", nacin_placanja);
        }

        // GET: NacinPlacanja/Create
        public ActionResult Create()
        {
            return View("~/Views/back-end/nacin-placanja/create.cshtml");
        }

        // POST: NacinPlacanja/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nacin_placanja_id,naziv_nacin_placanja")] nacin_placanja nacin_placanja)
        {
            if (ModelState.IsValid)
            {
                db.nacin_placanja.Add(nacin_placanja);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("~/Views/back-end/nacin-placanja/create.cshtml", nacin_placanja);
        }

        // GET: NacinPlacanja/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            nacin_placanja nacin_placanja = db.nacin_placanja.Find(id);
            if (nacin_placanja == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/back-end/nacin-placanja/edit.cshtml", nacin_placanja);
        }

        // POST: NacinPlacanja/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "nacin_placanja_id,naziv_nacin_placanja")] nacin_placanja nacin_placanja)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nacin_placanja).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("~/Views/back-end/nacin-placanja/edit.cshtml", nacin_placanja);
        }

        // GET: NacinPlacanja/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            nacin_placanja nacin_placanja = db.nacin_placanja.Find(id);
            if (nacin_placanja == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/back-end/nacin-placanja/delete.cshtml", nacin_placanja);
        }

        // POST: NacinPlacanja/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            nacin_placanja nacin_placanja = db.nacin_placanja.Find(id);
            db.nacin_placanja.Remove(nacin_placanja);
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
