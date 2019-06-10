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
    public class servisController : Controller
    {
        private Model1 db = new Model1();

        // GET: servis
        public ActionResult Index()
        {
            var servis = db.servis.Include(s => s.oprema);
            return View(servis.ToList());
        }

        // GET: servis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            servis servis = db.servis.Find(id);
            if (servis == null)
            {
                return HttpNotFound();
            }
            return View(servis);
        }

        // GET: servis/Create
        public ActionResult Create()
        {
            ViewBag.fk_oprema = new SelectList(db.oprema, "id_opreme", "ime_opreme");
            return View();
        }

        // POST: servis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_servisa,cijena_servisa,dijelovi,datum_servisa,fk_oprema")] servis servis)
        {
            if (ModelState.IsValid)
            {
                db.servis.Add(servis);
                db.SaveChanges();
                TempData["error"] = false;
                TempData["message"] = "Uspjesno ste dodali servis";
                return RedirectToAction("Index");
            }

            ViewBag.fk_oprema = new SelectList(db.oprema, "id_opreme", "ime_opreme", servis.fk_oprema);
            return View(servis);
        }

        // GET: servis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            servis servis = db.servis.Find(id);
            if (servis == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_oprema = new SelectList(db.oprema, "id_opreme", "ime_opreme", servis.fk_oprema);
            return View(servis);
        }

        // POST: servis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_servisa,cijena_servisa,dijelovi,datum_servisa,fk_oprema")] servis servis)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servis).State = EntityState.Modified;
                db.SaveChanges();
                TempData["error"] = false;
                TempData["message"] = "Uspjesno ste ažurirali servis";
                return RedirectToAction("Index");
            }
            ViewBag.fk_oprema = new SelectList(db.oprema, "id_opreme", "ime_opreme", servis.fk_oprema);
            return View(servis);
        }

        // GET: servis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            servis servis = db.servis.Find(id);
            if (servis == null)
            {
                return HttpNotFound();
            }
            return View(servis);
        }

        // POST: servis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            servis servis = db.servis.Find(id);
            db.servis.Remove(servis);
            db.SaveChanges();
            TempData["error"] = false;
            TempData["message"] = "Uspjesno ste izbrisali servis";
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
