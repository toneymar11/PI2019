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
    public class ponudaController : Controller
    {
        private Model1 db = new Model1();

        public ActionResult Svepod()
        {
            return View(db.ponuda.ToList());
        }
        public ActionResult GeneratePDF()
        {
            return new Rotativa.ActionAsPdf("Svepod");
        }

        // GET: ponuda
        public ActionResult Index()
        {
            return View(db.ponuda.ToList());
        }


        // GET: ponuda/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ponuda ponuda = db.ponuda.Find(id);
            if (ponuda == null)
            {
                return HttpNotFound();
            }
            return View(ponuda);
        }

        // GET: ponuda/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ponuda/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_ponuda,cijena_ponude")] ponuda ponuda)
        {
            if (ModelState.IsValid)
            {
                db.ponuda.Add(ponuda);
                db.SaveChanges();
                TempData["error"] = false;
                TempData["message"] = "Uspjesno ste dodali ponudu";
                return RedirectToAction("Index");
            }

            return View(ponuda);
        }

        // GET: ponuda/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ponuda ponuda = db.ponuda.Find(id);
            if (ponuda == null)
            {
                return HttpNotFound();
            }
            return View(ponuda);
        }

        // POST: ponuda/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_ponuda,cijena_ponude")] ponuda ponuda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ponuda).State = EntityState.Modified;
                db.SaveChanges();
                TempData["error"] = false;
                TempData["message"] = "Uspjesno ste ažurirali ponudu";
                return RedirectToAction("Index");
            }
            return View(ponuda);
        }

        // GET: ponuda/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ponuda ponuda = db.ponuda.Find(id);
            if (ponuda == null)
            {
                return HttpNotFound();
            }
            return View(ponuda);
        }

        // POST: ponuda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ponuda ponuda = db.ponuda.Find(id);
            db.ponuda.Remove(ponuda);
            db.SaveChanges();
            TempData["error"] = false;
            TempData["message"] = "Uspjesno ste izbrisali ponudu";
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
