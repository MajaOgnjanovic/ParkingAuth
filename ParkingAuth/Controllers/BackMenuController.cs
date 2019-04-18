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
    public class BackMenuController : Controller
    {
        private ParkingServisPajaASPEntities db = new ParkingServisPajaASPEntities();

        // GET: BackMenu
        public ActionResult Index()
        {
            var menu = db.menu.Include(m => m.vrsta_korisnici);
            return View("~/Views/back-end/back-menu/index.cshtml", menu.ToList());
        }

        // GET: BackMenu/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            menu menu = db.menu.Find(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/back-end/back-menu/details.cshtml", menu);
        }

        // GET: BackMenu/Create
        public ActionResult Create()
        {
            ViewBag.vrsta_korisnici_id = new SelectList(db.vrsta_korisnici, "vrsta_korisnici_id", "naziv_vrsta_korisnici");
            return View("~/Views/back-end/back-menu/create.cshtml");
        }

        // POST: BackMenu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "menu_id,slug,icon,naslov_menu,parent_id,controller,action,redosled,vrsta_korisnici_id,created_at,updated_at")] menu menu)
        {
            if (ModelState.IsValid)
            {
                db.menu.Add(menu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.vrsta_korisnici_id = new SelectList(db.vrsta_korisnici, "vrsta_korisnici_id", "naziv_vrsta_korisnici", menu.vrsta_korisnici_id);
            return View("~/Views/back-end/back-menu/create.cshtml", menu);
        }

        // GET: BackMenu/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            menu menu = db.menu.Find(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            ViewBag.vrsta_korisnici_id = new SelectList(db.vrsta_korisnici, "vrsta_korisnici_id", "naziv_vrsta_korisnici", menu.vrsta_korisnici_id);
            return View("~/Views/back-end/back-menu/edit.cshtml", menu);
        }

        // POST: BackMenu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "menu_id,slug,icon,naslov_menu,parent_id,controller,action,redosled,vrsta_korisnici_id,created_at,updated_at")] menu menu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(menu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.vrsta_korisnici_id = new SelectList(db.vrsta_korisnici, "vrsta_korisnici_id", "naziv_vrsta_korisnici", menu.vrsta_korisnici_id);
            return View("~/Views/back-end/back-menu/edit.cshtml", menu);
        }

        // GET: BackMenu/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            menu menu = db.menu.Find(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/back-end/back-menu/delete.cshtml", menu);
        }

        // POST: BackMenu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            menu menu = db.menu.Find(id);
            db.menu.Remove(menu);
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
