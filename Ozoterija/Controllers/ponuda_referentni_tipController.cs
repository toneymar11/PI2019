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
    public class ponuda_referentni_tipController : Controller
    {
        private Model1 db = new Model1();

        // GET: ponuda_referentni_tip
        public ActionResult Index()
        {
            var ponuda_referentni_tip = db.ponuda_referentni_tip.Include(p => p.ponuda).Include(p => p.referetni_tip);
            return View(ponuda_referentni_tip.ToList());
        }

        // GET: ponuda_referentni_tip/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ponuda_referentni_tip ponuda_referentni_tip = db.ponuda_referentni_tip.Find(id);
            if (ponuda_referentni_tip == null)
            {
                return HttpNotFound();
            }
            return View(ponuda_referentni_tip);
        }

        // GET: ponuda_referentni_tip/Create
        public ActionResult Create()
        {
            ViewBag.fk_ponuda = new SelectList(db.ponuda, "id_ponuda", "cijena_ponude");
            ViewBag.fk_referentni_tip = new SelectList(db.referetni_tip, "id_referetni_tip", "ime_referetni_tip");
            return View();
        }

        // POST: ponuda_referentni_tip/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_ponuda_referetni_tip,fk_referentni_tip,fk_ponuda")] ponuda_referentni_tip ponuda_referentni_tip)
        {
            if (ModelState.IsValid)
            {
                db.ponuda_referentni_tip.Add(ponuda_referentni_tip);
                db.SaveChanges();
                TempData["error"] = false;
                TempData["message"] = "Uspjesno ste dodali Ponuda Referentni Tip";
                return RedirectToAction("Index");
            }

            ViewBag.fk_ponuda = new SelectList(db.ponuda, "id_ponuda", "cijena_ponude", ponuda_referentni_tip.fk_ponuda);
            ViewBag.fk_referentni_tip = new SelectList(db.referetni_tip, "id_referetni_tip", "ime_referetni_tip", ponuda_referentni_tip.fk_referentni_tip);
            return View(ponuda_referentni_tip);
        }

        // GET: ponuda_referentni_tip/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ponuda_referentni_tip ponuda_referentni_tip = db.ponuda_referentni_tip.Find(id);
            if (ponuda_referentni_tip == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_ponuda = new SelectList(db.ponuda, "id_ponuda", "cijena_ponude", ponuda_referentni_tip.fk_ponuda);
            ViewBag.fk_referentni_tip = new SelectList(db.referetni_tip, "id_referetni_tip", "ime_referetni_tip", ponuda_referentni_tip.fk_referentni_tip);
            return View(ponuda_referentni_tip);
        }

        // POST: ponuda_referentni_tip/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_ponuda_referetni_tip,fk_referentni_tip,fk_ponuda")] ponuda_referentni_tip ponuda_referentni_tip)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ponuda_referentni_tip).State = EntityState.Modified;
                db.SaveChanges();
                TempData["error"] = false;
                TempData["message"] = "Uspjesno ste ažurirali Ponuda Referenti tip";
                return RedirectToAction("Index");
            }
            ViewBag.fk_ponuda = new SelectList(db.ponuda, "id_ponuda", "cijena_ponude", ponuda_referentni_tip.fk_ponuda);
            ViewBag.fk_referentni_tip = new SelectList(db.referetni_tip, "id_referetni_tip", "ime_referetni_tip", ponuda_referentni_tip.fk_referentni_tip);
            return View(ponuda_referentni_tip);
        }

        // GET: ponuda_referentni_tip/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ponuda_referentni_tip ponuda_referentni_tip = db.ponuda_referentni_tip.Find(id);
            if (ponuda_referentni_tip == null)
            {
                return HttpNotFound();
            }
            return View(ponuda_referentni_tip);
        }

        // POST: ponuda_referentni_tip/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ponuda_referentni_tip ponuda_referentni_tip = db.ponuda_referentni_tip.Find(id);
            db.ponuda_referentni_tip.Remove(ponuda_referentni_tip);
            db.SaveChanges();
            TempData["error"] = false;
            TempData["message"] = "Uspjesno ste izbrisali Ponuda Referenti Tip";
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
