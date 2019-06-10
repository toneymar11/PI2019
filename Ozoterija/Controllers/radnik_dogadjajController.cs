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
    public class radnik_dogadjajController : Controller
    {
        private Model1 db = new Model1();

        // GET: radnik_dogadjaj
        public ActionResult Index()
        {
            var radnik_dogadjaj = db.radnik_dogadjaj.Include(r => r.dogadjaj).Include(r => r.radnik);
            return View(radnik_dogadjaj.ToList());
        }

        // GET: radnik_dogadjaj/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            radnik_dogadjaj radnik_dogadjaj = db.radnik_dogadjaj.Find(id);
            if (radnik_dogadjaj == null)
            {
                return HttpNotFound();
            }
            return View(radnik_dogadjaj);
        }

        // GET: radnik_dogadjaj/Create
        public ActionResult Create()
        {
            ViewBag.fk_dogadjaj = new SelectList(db.dogadjaj, "id_dogadjaja", "naziv_dogadjaja");
            ViewBag.fk_radnik = new SelectList(db.radnik, "id_radnika", "ime_radnika");
            return View();
        }

        // POST: radnik_dogadjaj/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_radnik_dogadjaj,pocetak_dogadjaja,kraj_dogadjaja,plata,uloga,fk_radnik,fk_dogadjaj")] radnik_dogadjaj radnik_dogadjaj)
        {
            if (ModelState.IsValid)
            {
                db.radnik_dogadjaj.Add(radnik_dogadjaj);
                db.SaveChanges();
                TempData["error"] = false;
                TempData["message"] = "Uspjesno ste dodali radnik događaj";
                return RedirectToAction("Index");
            }

            ViewBag.fk_dogadjaj = new SelectList(db.dogadjaj, "id_dogadjaja", "naziv_dogadjaja", radnik_dogadjaj.fk_dogadjaj);
            ViewBag.fk_radnik = new SelectList(db.radnik, "id_radnika", "ime_radnika", radnik_dogadjaj.fk_radnik);
            return View(radnik_dogadjaj);
        }

        // GET: radnik_dogadjaj/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            radnik_dogadjaj radnik_dogadjaj = db.radnik_dogadjaj.Find(id);
            if (radnik_dogadjaj == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_dogadjaj = new SelectList(db.dogadjaj, "id_dogadjaja", "naziv_dogadjaja", radnik_dogadjaj.fk_dogadjaj);
            ViewBag.fk_radnik = new SelectList(db.radnik, "id_radnika", "ime_radnika", radnik_dogadjaj.fk_radnik);
            return View(radnik_dogadjaj);
        }

        // POST: radnik_dogadjaj/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_radnik_dogadjaj,pocetak_dogadjaja,kraj_dogadjaja,plata,uloga,fk_radnik,fk_dogadjaj")] radnik_dogadjaj radnik_dogadjaj)
        {
            if (ModelState.IsValid)
            {
                db.Entry(radnik_dogadjaj).State = EntityState.Modified;
                db.SaveChanges();
                TempData["error"] = false;
                TempData["message"] = "Uspjesno ste ažurirali radnik događaj";
                return RedirectToAction("Index");
            }
            ViewBag.fk_dogadjaj = new SelectList(db.dogadjaj, "id_dogadjaja", "naziv_dogadjaja", radnik_dogadjaj.fk_dogadjaj);
            ViewBag.fk_radnik = new SelectList(db.radnik, "id_radnika", "ime_radnika", radnik_dogadjaj.fk_radnik);
            return View(radnik_dogadjaj);
        }

        // GET: radnik_dogadjaj/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            radnik_dogadjaj radnik_dogadjaj = db.radnik_dogadjaj.Find(id);
            if (radnik_dogadjaj == null)
            {
                return HttpNotFound();
            }
            return View(radnik_dogadjaj);
        }

        // POST: radnik_dogadjaj/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            radnik_dogadjaj radnik_dogadjaj = db.radnik_dogadjaj.Find(id);
            db.radnik_dogadjaj.Remove(radnik_dogadjaj);
            db.SaveChanges();
            TempData["error"] = false;
            TempData["message"] = "Uspjesno ste izbrisali radnik događaj";
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
