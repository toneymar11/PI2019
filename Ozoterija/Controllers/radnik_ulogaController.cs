using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ozoterija.Models;

namespace Ozoterija.Controllers
{
    public class radnik_ulogaController : Controller
    {
        private Model1 db = new Model1();

        // GET: radnik_uloga
        
        public ActionResult Index()
        {
            var radnik_uloga = db.radnik_uloga.Include(r => r.radnik).Include(r => r.uloga);
            return View(radnik_uloga.ToList());
        }

        // GET: radnik_uloga/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            radnik_uloga radnik_uloga = db.radnik_uloga.Find(id);
            if (radnik_uloga == null)
            {
                return HttpNotFound();
            }
            return View(radnik_uloga);
        }

        // GET: radnik_uloga/Create
        public ActionResult Create()
        {
            ViewBag.fk_radnik = new SelectList(db.radnik, "id_radnika", "ime_radnika");
            ViewBag.fk_uloga = new SelectList(db.uloga, "id_uloge", "ime_uloge");
            return View();
        }

        // POST: radnik_uloga/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_radnik_uloga,fk_radnik,fk_uloga")] radnik_uloga radnik_uloga)
        {
            if (ModelState.IsValid)
            {
                db.radnik_uloga.Add(radnik_uloga);
                db.SaveChanges();
                TempData["error"] = false;
                TempData["message"] = "Uspjesno ste dodali radnik uloga";
                return RedirectToAction("Index");
            }

            ViewBag.fk_radnik = new SelectList(db.radnik, "id_radnika", "ime_radnika", radnik_uloga.fk_radnik);
            ViewBag.fk_uloga = new SelectList(db.uloga, "id_uloge", "ime_uloge", radnik_uloga.fk_uloga);
            return View(radnik_uloga);
        }

        // GET: radnik_uloga/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            radnik_uloga radnik_uloga = db.radnik_uloga.Find(id);
            if (radnik_uloga == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_radnik = new SelectList(db.radnik, "id_radnika", "ime_radnika", radnik_uloga.fk_radnik);
            ViewBag.fk_uloga = new SelectList(db.uloga, "id_uloge", "ime_uloge", radnik_uloga.fk_uloga);
            return View(radnik_uloga);
        }

        // POST: radnik_uloga/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_radnik_uloga,fk_radnik,fk_uloga")] radnik_uloga radnik_uloga)
        {
            if (ModelState.IsValid)
            {
                db.Entry(radnik_uloga).State = EntityState.Modified;
                db.SaveChanges();
                TempData["error"] = false;
                TempData["message"] = "Uspjesno ste ažurirali radnik uloga";
                return RedirectToAction("Index");
            }
            ViewBag.fk_radnik = new SelectList(db.radnik, "id_radnika", "ime_radnika", radnik_uloga.fk_radnik);
            ViewBag.fk_uloga = new SelectList(db.uloga, "id_uloge", "ime_uloge", radnik_uloga.fk_uloga);
            return View(radnik_uloga);
        }

        // GET: radnik_uloga/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            radnik_uloga radnik_uloga = db.radnik_uloga.Find(id);
            if (radnik_uloga == null)
            {
                return HttpNotFound();
            }
            return View(radnik_uloga);
        }

        // POST: radnik_uloga/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            radnik_uloga radnik_uloga = db.radnik_uloga.Find(id);
            db.radnik_uloga.Remove(radnik_uloga);
            db.SaveChanges();
            TempData["error"] = false;
            TempData["message"] = "Uspjesno ste izbrisali radnik uloga";
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
