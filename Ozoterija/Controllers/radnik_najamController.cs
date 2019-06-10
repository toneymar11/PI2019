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
    public class radnik_najamController : Controller
    {
        private Model1 db = new Model1();

        // GET: radnik_najam
        public ActionResult Index()
        {
            var radnik_najam = db.radnik_najam.Include(r => r.najam).Include(r => r.radnik);
            return View(radnik_najam.ToList());
        }

        // GET: radnik_najam/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            radnik_najam radnik_najam = db.radnik_najam.Find(id);
            if (radnik_najam == null)
            {
                return HttpNotFound();
            }
            return View(radnik_najam);
        }

        // GET: radnik_najam/Create
        public ActionResult Create()
        {
            ViewBag.fk_najam = new SelectList(db.najam, "id_najam", "naziv_najma");
            ViewBag.fk_radnik = new SelectList(db.radnik, "id_radnika", "ime_radnika");
            return View();
        }

        // POST: radnik_najam/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_radnik_najam,otkada,dokada,plata,uloga,fk_radnik,fk_najam")] radnik_najam radnik_najam)
        {
            if (ModelState.IsValid)
            {
                db.radnik_najam.Add(radnik_najam);
                db.SaveChanges();
                TempData["error"] = false;
                TempData["message"] = "Uspjesno ste dodali radnik najam";
                return RedirectToAction("Index");
            }

            ViewBag.fk_najam = new SelectList(db.najam, "id_najam", "naziv_najma", radnik_najam.fk_najam);
            ViewBag.fk_radnik = new SelectList(db.radnik, "id_radnika", "ime_radnika", radnik_najam.fk_radnik);
            return View(radnik_najam);
        }

        // GET: radnik_najam/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            radnik_najam radnik_najam = db.radnik_najam.Find(id);
            if (radnik_najam == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_najam = new SelectList(db.najam, "id_najam", "naziv_najma", radnik_najam.fk_najam);
            ViewBag.fk_radnik = new SelectList(db.radnik, "id_radnika", "ime_radnika", radnik_najam.fk_radnik);
            return View(radnik_najam);
        }

        // POST: radnik_najam/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_radnik_najam,otkada,dokada,plata,uloga,fk_radnik,fk_najam")] radnik_najam radnik_najam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(radnik_najam).State = EntityState.Modified;
                db.SaveChanges();
                TempData["error"] = false;
                TempData["message"] = "Uspjesno ste ažurirali radnik najam";
                return RedirectToAction("Index");
            }
            ViewBag.fk_najam = new SelectList(db.najam, "id_najam", "naziv_najma", radnik_najam.fk_najam);
            ViewBag.fk_radnik = new SelectList(db.radnik, "id_radnika", "ime_radnika", radnik_najam.fk_radnik);
            return View(radnik_najam);
        }

        // GET: radnik_najam/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            radnik_najam radnik_najam = db.radnik_najam.Find(id);
            if (radnik_najam == null)
            {
                return HttpNotFound();
            }
            return View(radnik_najam);
        }

        // POST: radnik_najam/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            radnik_najam radnik_najam = db.radnik_najam.Find(id);
            db.radnik_najam.Remove(radnik_najam);
            db.SaveChanges();
            TempData["error"] = false;
            TempData["message"] = "Uspjesno ste izbrisali radnik najam";
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
