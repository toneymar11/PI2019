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
    public class radnikController : Controller
    {
        private Model1 db = new Model1();

        public ActionResult Sverad()
        {
            return View(db.radnik.ToList());
        }

        public ActionResult GeneratePDF()
        {
            return new Rotativa.ActionAsPdf("Sverad");
        }

        // GET: radnik
        public ActionResult Index()
        {
            var radnik = db.radnik.Include(r => r.grad);
            return View(radnik.ToList());
        }

        // GET: radnik/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            radnik radnik = db.radnik.Find(id);
            if (radnik == null)
            {
                return HttpNotFound();
            }
            return View(radnik);
        }

        // GET: radnik/Create
        public ActionResult Create()
        {
            ViewBag.fk_grad = new SelectList(db.grad, "id_grad", "ime_grada");
            return View();
        }

        // POST: radnik/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_radnika,ime_radnika,prezime_radnika,plata_radnika,fk_grad,certifikat_radnika")] radnik radnik)
        {
            if (ModelState.IsValid)
            {
                db.radnik.Add(radnik);
                db.SaveChanges();
                TempData["error"] = false;
                TempData["message"] = "Uspjesno ste dodali radnik";
                return RedirectToAction("Index");
            }
            TempData["error"] = true;
            TempData["message"] = "Popuni sva polja";
            ViewBag.fk_grad = new SelectList(db.grad, "id_grad", "ime_grada", radnik.fk_grad);
            return View(radnik);
        }

        // GET: radnik/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            radnik radnik = db.radnik.Find(id);
            if (radnik == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_grad = new SelectList(db.grad, "id_grad", "ime_grada", radnik.fk_grad);
            return View(radnik);
        }

        // POST: radnik/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_radnika,ime_radnika,prezime_radnika,plata_radnika,fk_grad,certifikat_radnika")] radnik radnik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(radnik).State = EntityState.Modified;
                db.SaveChanges();
                TempData["error"] = false;
                TempData["message"] = "Uspjesno ste ažurirali radnik";
                return RedirectToAction("Index");
            }
            ViewBag.fk_grad = new SelectList(db.grad, "id_grad", "ime_grada", radnik.fk_grad);
            return View(radnik);
        }

        // GET: radnik/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            radnik radnik = db.radnik.Find(id);
            if (radnik == null)
            {
                return HttpNotFound();
            }
            return View(radnik);
        }

        // POST: radnik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            radnik radnik = db.radnik.Find(id);
            db.radnik.Remove(radnik);
            db.SaveChanges();
            TempData["error"] = false;
            TempData["message"] = "Uspjesno ste izbrisali radnik";
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
