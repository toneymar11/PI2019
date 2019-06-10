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
    public class oprema_dogadjajController : Controller
    {
        private Model1 db = new Model1();

        // GET: oprema_dogadjaj
        public ActionResult Index()
        {
            var oprema_dogadjaj = db.oprema_dogadjaj.Include(o => o.dogadjaj).Include(o => o.oprema);
            return View(oprema_dogadjaj.ToList());
        }

        // GET: oprema_dogadjaj/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            oprema_dogadjaj oprema_dogadjaj = db.oprema_dogadjaj.Find(id);
            if (oprema_dogadjaj == null)
            {
                return HttpNotFound();
            }
            return View(oprema_dogadjaj);
        }

        // GET: oprema_dogadjaj/Create
        public ActionResult Create()
        {
            ViewBag.fk_dogadjaj = new SelectList(db.dogadjaj, "id_dogadjaja", "naziv_dogadjaja");
            ViewBag.fk_oprema = new SelectList(db.oprema, "id_opreme", "ime_opreme");
            return View();
        }

        // POST: oprema_dogadjaj/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_oprema_dogadjaj,fk_oprema,fk_dogadjaj")] oprema_dogadjaj oprema_dogadjaj)
        {
            if (ModelState.IsValid)
            {
                db.oprema_dogadjaj.Add(oprema_dogadjaj);
                db.SaveChanges();
                TempData["error"] = false;
                TempData["message"] = "Uspjesno ste dodali događaj opremu";
                return RedirectToAction("Index");
            }

            ViewBag.fk_dogadjaj = new SelectList(db.dogadjaj, "id_dogadjaja", "naziv_dogadjaja", oprema_dogadjaj.fk_dogadjaj);
            ViewBag.fk_oprema = new SelectList(db.oprema, "id_opreme", "ime_opreme", oprema_dogadjaj.fk_oprema);
            return View(oprema_dogadjaj);
        }

        // GET: oprema_dogadjaj/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            oprema_dogadjaj oprema_dogadjaj = db.oprema_dogadjaj.Find(id);
            if (oprema_dogadjaj == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_dogadjaj = new SelectList(db.dogadjaj, "id_dogadjaja", "naziv_dogadjaja", oprema_dogadjaj.fk_dogadjaj);
            ViewBag.fk_oprema = new SelectList(db.oprema, "id_opreme", "ime_opreme", oprema_dogadjaj.fk_oprema);
            return View(oprema_dogadjaj);
        }

        // POST: oprema_dogadjaj/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_oprema_dogadjaj,fk_oprema,fk_dogadjaj")] oprema_dogadjaj oprema_dogadjaj)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oprema_dogadjaj).State = EntityState.Modified;
                db.SaveChanges();
                TempData["error"] = false;
                TempData["message"] = "Uspjesno ste ažuriali događaj opremu";
                return RedirectToAction("Index");
            }
            ViewBag.fk_dogadjaj = new SelectList(db.dogadjaj, "id_dogadjaja", "naziv_dogadjaja", oprema_dogadjaj.fk_dogadjaj);
            ViewBag.fk_oprema = new SelectList(db.oprema, "id_opreme", "ime_opreme", oprema_dogadjaj.fk_oprema);
            return View(oprema_dogadjaj);
        }

        // GET: oprema_dogadjaj/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            oprema_dogadjaj oprema_dogadjaj = db.oprema_dogadjaj.Find(id);
            if (oprema_dogadjaj == null)
            {
                return HttpNotFound();
            }
            return View(oprema_dogadjaj);
        }

        // POST: oprema_dogadjaj/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            oprema_dogadjaj oprema_dogadjaj = db.oprema_dogadjaj.Find(id);
            db.oprema_dogadjaj.Remove(oprema_dogadjaj);
            db.SaveChanges();
            TempData["error"] = false;
            TempData["message"] = "Uspjesno ste izbrisali događaj opremu";
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
