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
    public class gradController : Controller
    {
        private Model1 db = new Model1();

        public ActionResult Index(string sortOrder, string CurrentSort, int? page)
        {
            int pageSize = 8;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;

            ViewBag.CurrentSort = sortOrder;

            sortOrder = String.IsNullOrEmpty(sortOrder) ? "imegrada" : sortOrder;

            IPagedList<grad> grads = null;

            switch (sortOrder)
            {
                case "imegrada":
                    if (sortOrder.Equals(CurrentSort))
                        grads = db.grad.OrderByDescending
                                (db => db.ime_grada).ToPagedList(pageIndex, pageSize);
                    else
                        grads = db.grad.OrderBy
                                (db => db.ime_grada).ToPagedList(pageIndex, pageSize);
                    break;

                default:
                    grads = db.grad.OrderBy
                            (db => db.ime_grada).ToPagedList(pageIndex, pageSize);
                    break;
            }
            return View(grads);
        }

        /* // GET: grad
         public ActionResult Index()
         {
             return View(db.grad.ToList());
         }
         */
        // GET: grad/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            grad grad = db.grad.Find(id);
            if (grad == null)
            {
                return HttpNotFound();
            }
            return View(grad);
        }

        // GET: grad/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: grad/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_grad,ime_grada")] grad grad)
        {
            if (ModelState.IsValid)
            {
                db.grad.Add(grad);
                db.SaveChanges();
                TempData["error"] = false;
                TempData["message"] = "Uspjesno ste dodali grad";
                return RedirectToAction("Index");
            }
            TempData["error"] = true;
            TempData["message"] = "Popuni sva polja";
            return View(grad);
        }

        // GET: grad/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            grad grad = db.grad.Find(id);
            if (grad == null)
            {
                return HttpNotFound();
            }
            return View(grad);
        }

        // POST: grad/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_grad,ime_grada")] grad grad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grad).State = EntityState.Modified;
                db.SaveChanges();
                TempData["error"] = false;
                TempData["message"] = "Uspjesno ste ažurirali grad";
                return RedirectToAction("Index");
            }
            return View(grad);
        }

        // GET: grad/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            grad grad = db.grad.Find(id);
            if (grad == null)
            {
                return HttpNotFound();
            }
            return View(grad);
        }

        // POST: grad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            grad grad = db.grad.Find(id);
            db.grad.Remove(grad);
            db.SaveChanges();
            TempData["error"] = false;
            TempData["message"] = "Uspjesno ste ažurirali grad";
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
