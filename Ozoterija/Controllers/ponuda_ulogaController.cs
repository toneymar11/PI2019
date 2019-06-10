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
    public class ponuda_ulogaController : Controller
    {
        private Model1 db = new Model1();

        // GET: ponuda_uloga
        public ActionResult Index()
        {
            var ponuda_uloga = db.ponuda_uloga.Include(p => p.ponuda).Include(p => p.uloga);
            return View(ponuda_uloga.ToList());
        }

        // GET: ponuda_uloga/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ponuda_uloga ponuda_uloga = db.ponuda_uloga.Find(id);
            if (ponuda_uloga == null)
            {
                return HttpNotFound();
            }
            return View(ponuda_uloga);
        }

        // GET: ponuda_uloga/Create
        public ActionResult Create()
        {
            ViewBag.fk_ponuda = new SelectList(db.ponuda, "id_ponuda", "cijena_ponude");
            ViewBag.fk_uloga = new SelectList(db.uloga, "id_uloge", "ime_uloge");
            return View();
        }

        // POST: ponuda_uloga/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_ponuda_uloga,fk_uloga,fk_ponuda")] ponuda_uloga ponuda_uloga)
        {
            if (ModelState.IsValid)
            {
                db.ponuda_uloga.Add(ponuda_uloga);
                db.SaveChanges();
                TempData["error"] = false;
                TempData["message"] = "Uspjesno ste dodali ponuda uloga";
                return RedirectToAction("Index");
            }

            ViewBag.fk_ponuda = new SelectList(db.ponuda, "id_ponuda", "cijena_ponude", ponuda_uloga.fk_ponuda);
            ViewBag.fk_uloga = new SelectList(db.uloga, "id_uloge", "ime_uloge", ponuda_uloga.fk_uloga);
            return View(ponuda_uloga);
        }

        // GET: ponuda_uloga/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ponuda_uloga ponuda_uloga = db.ponuda_uloga.Find(id);
            if (ponuda_uloga == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_ponuda = new SelectList(db.ponuda, "id_ponuda", "cijena_ponude", ponuda_uloga.fk_ponuda);
            ViewBag.fk_uloga = new SelectList(db.uloga, "id_uloge", "ime_uloge", ponuda_uloga.fk_uloga);
            return View(ponuda_uloga);
        }

        // POST: ponuda_uloga/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_ponuda_uloga,fk_uloga,fk_ponuda")] ponuda_uloga ponuda_uloga)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ponuda_uloga).State = EntityState.Modified;
                db.SaveChanges();
                TempData["error"] = false;
                TempData["message"] = "Uspjesno ste ažurirali ponuda uloga";
                return RedirectToAction("Index");
            }
            ViewBag.fk_ponuda = new SelectList(db.ponuda, "id_ponuda", "cijena_ponude", ponuda_uloga.fk_ponuda);
            ViewBag.fk_uloga = new SelectList(db.uloga, "id_uloge", "ime_uloge", ponuda_uloga.fk_uloga);
            return View(ponuda_uloga);
        }

        // GET: ponuda_uloga/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ponuda_uloga ponuda_uloga = db.ponuda_uloga.Find(id);
            if (ponuda_uloga == null)
            {
                return HttpNotFound();
            }
            return View(ponuda_uloga);
        }

        // POST: ponuda_uloga/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ponuda_uloga ponuda_uloga = db.ponuda_uloga.Find(id);
            db.ponuda_uloga.Remove(ponuda_uloga);
            db.SaveChanges();
            TempData["error"] = false;
            TempData["message"] = "Uspjesno ste izbrisali ponuda uloga";
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
