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
    public class opremaController : Controller
    {
        private Model1 db = new Model1();

        public ActionResult Sveop()
        {
            return View(db.oprema.ToList());
        }

        public ActionResult GeneratePDF()
        {
            return new Rotativa.ActionAsPdf("Sveop");
        }


        // GET: oprema
        public ActionResult Index()
        {
            var oprema = db.oprema.Include(o => o.referetni_tip).Include(o => o.skladiste);
            return View(oprema.ToList());
        }

        // GET: oprema/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            oprema oprema = db.oprema.Find(id);
            if (oprema == null)
            {
                return HttpNotFound();
            }
            return View(oprema);
        }

        // GET: oprema/Create
        public ActionResult Create()
        {
            ViewBag.fk_referetni_tip = new SelectList(db.referetni_tip, "id_referetni_tip", "ime_referetni_tip");
            ViewBag.fk_skladiste = new SelectList(db.skladiste, "id_skladista", "ime_sklaldista");
            return View();
        }

        // POST: oprema/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_opreme,ime_opreme,kupovna_vrijednost,knjigovodstvena_vrijednost,trenutno_stanje,fk_referetni_tip,fk_skladiste")] oprema oprema)
        {
            if (ModelState.IsValid)
            {
                db.oprema.Add(oprema);
                db.SaveChanges();
                TempData["error"] = false;
                TempData["message"] = "Uspjesno ste dodali opremu";
                return RedirectToAction("Index");
            }

               TempData["error"] = true;
               TempData["message"] = "Popuni sva polja";
               ViewBag.fk_referetni_tip = new SelectList(db.referetni_tip, "id_referetni_tip", "ime_referetni_tip", oprema.fk_referetni_tip);
                ViewBag.fk_skladiste = new SelectList(db.skladiste, "id_skladista", "ime_sklaldista", oprema.fk_skladiste);
                return View(oprema); 
        }

        // GET: oprema/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            oprema oprema = db.oprema.Find(id);
            if (oprema == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_referetni_tip = new SelectList(db.referetni_tip, "id_referetni_tip", "ime_referetni_tip", oprema.fk_referetni_tip);
            ViewBag.fk_skladiste = new SelectList(db.skladiste, "id_skladista", "ime_sklaldista", oprema.fk_skladiste);
            return View(oprema);
        }

        // POST: oprema/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_opreme,ime_opreme,kupovna_vrijednost,knjigovodstvena_vrijednost,trenutno_stanje,fk_referetni_tip,fk_skladiste")] oprema oprema)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oprema).State = EntityState.Modified;
                db.SaveChanges();
                TempData["error"] = false;
                TempData["message"] = "Uspjesno ste ažurirali opremu";
                return RedirectToAction("Index");
            }
            ViewBag.fk_referetni_tip = new SelectList(db.referetni_tip, "id_referetni_tip", "ime_referetni_tip", oprema.fk_referetni_tip);
            ViewBag.fk_skladiste = new SelectList(db.skladiste, "id_skladista", "ime_sklaldista", oprema.fk_skladiste);
            return View(oprema);
        }

        // GET: oprema/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            oprema oprema = db.oprema.Find(id);
            if (oprema == null)
            {
                return HttpNotFound();
            }
            return View(oprema);
        }

        // POST: oprema/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            oprema oprema = db.oprema.Find(id);
            db.oprema.Remove(oprema);
            db.SaveChanges();
            TempData["error"] = false;
            TempData["message"] = "Uspjesno ste izbrisali opremu";
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
