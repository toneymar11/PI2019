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
    public class natjecaj_ponudaController : Controller
    {
        private Model1 db = new Model1();

        // GET: natjecaj_ponuda
        public ActionResult Index()
        {
            var natjecaj_ponuda = db.natjecaj_ponuda.Include(n => n.natjecaj).Include(n => n.ponuda);
            return View(natjecaj_ponuda.ToList());
        }

        // GET: natjecaj_ponuda/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            natjecaj_ponuda natjecaj_ponuda = db.natjecaj_ponuda.Find(id);
            if (natjecaj_ponuda == null)
            {
                return HttpNotFound();
            }
            return View(natjecaj_ponuda);
        }

        // GET: natjecaj_ponuda/Create
        public ActionResult Create()
        {
            ViewBag.fk_natjecaj = new SelectList(db.natjecaj, "id_natjecaj", "tip_natjecaja");
            ViewBag.fk_ponuda = new SelectList(db.ponuda, "id_ponuda", "cijena_ponude");
            return View();
        }

        // POST: natjecaj_ponuda/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_natjecaj_ponuda,fk_ponuda,fk_natjecaj")] natjecaj_ponuda natjecaj_ponuda)
        {
            if (ModelState.IsValid)
            {
                db.natjecaj_ponuda.Add(natjecaj_ponuda);
                db.SaveChanges();
                TempData["error"] = false;
                TempData["message"] = "Uspjesno ste dodali natječaj ponuda";
                return RedirectToAction("Index");
            }

            ViewBag.fk_natjecaj = new SelectList(db.natjecaj, "id_natjecaj", "tip_natjecaja", natjecaj_ponuda.fk_natjecaj);
            ViewBag.fk_ponuda = new SelectList(db.ponuda, "id_ponuda", "cijena_ponude", natjecaj_ponuda.fk_ponuda);
            return View(natjecaj_ponuda);
        }

        // GET: natjecaj_ponuda/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            natjecaj_ponuda natjecaj_ponuda = db.natjecaj_ponuda.Find(id);
            if (natjecaj_ponuda == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_natjecaj = new SelectList(db.natjecaj, "id_natjecaj", "tip_natjecaja", natjecaj_ponuda.fk_natjecaj);
            ViewBag.fk_ponuda = new SelectList(db.ponuda, "id_ponuda", "cijena_ponude", natjecaj_ponuda.fk_ponuda);
            return View(natjecaj_ponuda);
        }

        // POST: natjecaj_ponuda/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_natjecaj_ponuda,fk_ponuda,fk_natjecaj")] natjecaj_ponuda natjecaj_ponuda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(natjecaj_ponuda).State = EntityState.Modified;
                db.SaveChanges();
                TempData["error"] = false;
                TempData["message"] = "Uspjesno ste ažurirali natjecaj ponuda";
                return RedirectToAction("Index");
            }
            ViewBag.fk_natjecaj = new SelectList(db.natjecaj, "id_natjecaj", "tip_natjecaja", natjecaj_ponuda.fk_natjecaj);
            ViewBag.fk_ponuda = new SelectList(db.ponuda, "id_ponuda", "cijena_ponude", natjecaj_ponuda.fk_ponuda);
            return View(natjecaj_ponuda);
        }

        // GET: natjecaj_ponuda/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            natjecaj_ponuda natjecaj_ponuda = db.natjecaj_ponuda.Find(id);
            if (natjecaj_ponuda == null)
            {
                return HttpNotFound();
            }
            return View(natjecaj_ponuda);
        }

        // POST: natjecaj_ponuda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            natjecaj_ponuda natjecaj_ponuda = db.natjecaj_ponuda.Find(id);
            db.natjecaj_ponuda.Remove(natjecaj_ponuda);
            db.SaveChanges();
            TempData["error"] = false;
            TempData["message"] = "Uspjesno ste izbrisali natječaj ponuda";
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
