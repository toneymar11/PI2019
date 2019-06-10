using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ozoterija.Models;
using Rotativa;


namespace Ozoterija.Controllers
{
    public class dogadjajController : Controller
    {
        private Model1 db = new Model1();

        public ActionResult Svedog()
        {
            return View(db.dogadjaj.ToList());
        }

        // GET: dogadjaj
        public ActionResult Index()
        {
            var dogadjaj = db.dogadjaj.Include(d => d.grad);
            return View(dogadjaj.ToList());
        }

        public ActionResult GeneratePDF()
        {
            return new Rotativa.ActionAsPdf("Svedog");
        }

        // GET: dogadjaj/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dogadjaj dogadjaj = db.dogadjaj.Find(id);
            if (dogadjaj == null)
            {
                return HttpNotFound();
            }
            return View(dogadjaj);
        }

        // GET: dogadjaj/Create
        public ActionResult Create()
        {
            ViewBag.fk_grad = new SelectList(db.grad, "id_grad", "ime_grada");
            return View();
        }

        // POST: dogadjaj/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_dogadjaja,naziv_dogadjaja,cijena_dogadjaja,datum_dogadjaja,fk_grad")] dogadjaj dogadjaj)
        {
            if (ModelState.IsValid)
            {
                db.dogadjaj.Add(dogadjaj);
                db.SaveChanges();
                TempData["error"] = false;
                TempData["message"] = "Uspjesno ste dodali događaj";
                return RedirectToAction("Index");
            }

            TempData["error"] = true;
            TempData["message"] = "Popuni sva polja";
            ViewBag.fk_grad = new SelectList(db.grad, "id_grad", "ime_grada", dogadjaj.fk_grad);
            return View(dogadjaj);
        }

        // GET: dogadjaj/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dogadjaj dogadjaj = db.dogadjaj.Find(id);
            if (dogadjaj == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_grad = new SelectList(db.grad, "id_grad", "ime_grada", dogadjaj.fk_grad);
            return View(dogadjaj);
        }

        // POST: dogadjaj/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_dogadjaja,naziv_dogadjaja,cijena_dogadjaja,datum_dogadjaja,fk_grad")] dogadjaj dogadjaj)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dogadjaj).State = EntityState.Modified;
                db.SaveChanges();
                TempData["error"] = false;
                TempData["message"] = "Uspjesno ste ažurirali događaj";
                return RedirectToAction("Index");
            }
            ViewBag.fk_grad = new SelectList(db.grad, "id_grad", "ime_grada", dogadjaj.fk_grad);
            return View(dogadjaj);
        }

        // GET: dogadjaj/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dogadjaj dogadjaj = db.dogadjaj.Find(id);
            if (dogadjaj == null)
            {
                return HttpNotFound();
            }
            return View(dogadjaj);
        }

        // POST: dogadjaj/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            dogadjaj dogadjaj = db.dogadjaj.Find(id);
            db.dogadjaj.Remove(dogadjaj);
            db.SaveChanges();
            TempData["error"] = false;
            TempData["message"] = "Uspjesno ste izbrisali događaj";
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
