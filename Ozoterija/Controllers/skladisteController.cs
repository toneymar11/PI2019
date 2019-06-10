using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ozoterija.Models;
using PagedList;
namespace Ozoterija.Controllers
{
    public class skladisteController : Controller
    {
        private Model1 db = new Model1();

        public ActionResult Index(string sortOrder, string CurrentSort, int? page)
        {
            int pageSize = 6;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;

            ViewBag.CurrentSort = sortOrder;

            sortOrder = String.IsNullOrEmpty(sortOrder) ? "imegrada" : sortOrder;

            IPagedList<skladiste> grads = null;

            switch (sortOrder)
            {
                case "imegrada":
                    if (sortOrder.Equals(CurrentSort))
                        grads = db.skladiste.OrderByDescending
                                (db => db.grad.ime_grada).ToPagedList(pageIndex, pageSize);
                    else
                        grads = db.skladiste.OrderBy
                                (db => db.grad.ime_grada).ToPagedList(pageIndex, pageSize);
                    break;

                case "imeskl":
                    if (sortOrder.Equals(CurrentSort))
                        grads = db.skladiste.OrderByDescending
                                (db => db.ime_sklaldista).ToPagedList(pageIndex, pageSize);
                    else
                        grads = db.skladiste.OrderBy
                                (db => db.ime_sklaldista).ToPagedList(pageIndex, pageSize);
                    break;

                default:
                    grads = db.skladiste.OrderBy
                            (db => db.grad.ime_grada).ToPagedList(pageIndex, pageSize);
                    break;
            }
            return View(grads);
        }

        // GET: skladiste/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            skladiste skladiste = db.skladiste.Find(id);
            if (skladiste == null)
            {
                return HttpNotFound();
            }
            return View(skladiste);
        }

        // GET: skladiste/Create
        public ActionResult Create()
        {
            ViewBag.fk_grad = new SelectList(db.grad, "id_grad", "ime_grada");
            return View();
        }

        // POST: skladiste/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_skladista,ime_sklaldista,fk_grad")] skladiste skladiste)
        {
            if (ModelState.IsValid)
            {
                db.skladiste.Add(skladiste);
                db.SaveChanges();
                TempData["error"] = false;
                TempData["message"] = "Uspjesno ste dodali skladište";
                return RedirectToAction("Index");
            }
            TempData["error"] = true;
            TempData["message"] = "Popuni sva polja";

            ViewBag.fk_grad = new SelectList(db.grad, "id_grad", "ime_grada", skladiste.fk_grad);
            return View(skladiste);
        }

        // GET: skladiste/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            skladiste skladiste = db.skladiste.Find(id);
            if (skladiste == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_grad = new SelectList(db.grad, "id_grad", "ime_grada", skladiste.fk_grad);
            return View(skladiste);
        }

        // POST: skladiste/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_skladista,ime_sklaldista,fk_grad")] skladiste skladiste)
        {
            if (ModelState.IsValid)
            {
                db.Entry(skladiste).State = EntityState.Modified;
                db.SaveChanges();
                TempData["error"] = false;
                TempData["message"] = "Uspjesno ste ažurirali skladište";
                return RedirectToAction("Index");
            }
            ViewBag.fk_grad = new SelectList(db.grad, "id_grad", "ime_grada", skladiste.fk_grad);
            return View(skladiste);
        }

        // GET: skladiste/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            skladiste skladiste = db.skladiste.Find(id);
            if (skladiste == null)
            {
                return HttpNotFound();
            }
            return View(skladiste);
        }

        // POST: skladiste/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            skladiste skladiste = db.skladiste.Find(id);
            db.skladiste.Remove(skladiste);
            db.SaveChanges();
            TempData["error"] = false;
            TempData["message"] = "Uspjesno ste izbrisali skladište";
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
