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
    public class referetni_tipController : Controller
    {
        private Model1 db = new Model1();

        public ActionResult Index(string sortOrder, string CurrentSort, int? page)
        {
            int pageSize = 6;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;

            ViewBag.CurrentSort = sortOrder;

            sortOrder = String.IsNullOrEmpty(sortOrder) ? "ref_tip" : sortOrder;

            IPagedList<referetni_tip> grads = null;

            switch (sortOrder)
            {
                case "ref_tip":
                    if (sortOrder.Equals(CurrentSort))
                        grads = db.referetni_tip.OrderByDescending
                                (db => db.ime_referetni_tip).ToPagedList(pageIndex, pageSize);
                    else
                        grads = db.referetni_tip.OrderBy
                                (db => db.ime_referetni_tip).ToPagedList(pageIndex, pageSize);
                    break;

                case "cjena_ref":
                    if (sortOrder.Equals(CurrentSort))
                        grads = db.referetni_tip.OrderByDescending
                                (db => db.cijena_referetni_tip).ToPagedList(pageIndex, pageSize);
                    else
                        grads = db.referetni_tip.OrderBy
                                (db => db.cijena_referetni_tip).ToPagedList(pageIndex, pageSize);
                    break;

                default:
                    grads = db.referetni_tip.OrderBy
                            (db => db.ime_referetni_tip).ToPagedList(pageIndex, pageSize);
                    break;
            }
            return View(grads);
        }
    





    // GET: referetni_tip/Details/5
    public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            referetni_tip referetni_tip = db.referetni_tip.Find(id);
            if (referetni_tip == null)
            {
                return HttpNotFound();
            }
            return View(referetni_tip);
        }

        // GET: referetni_tip/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: referetni_tip/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_referetni_tip,ime_referetni_tip,cijena_referetni_tip")] referetni_tip referetni_tip)
        {
            if (ModelState.IsValid)
            {
                db.referetni_tip.Add(referetni_tip);
                db.SaveChanges();
                TempData["error"] = false;
                TempData["message"] = "Uspjesno ste dodali referentni tip";
                return RedirectToAction("Index");
            }

            return View(referetni_tip);
        }

        // GET: referetni_tip/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            referetni_tip referetni_tip = db.referetni_tip.Find(id);
            if (referetni_tip == null)
            {
                return HttpNotFound();
            }
            return View(referetni_tip);
        }

        // POST: referetni_tip/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_referetni_tip,ime_referetni_tip,cijena_referetni_tip")] referetni_tip referetni_tip)
        {
            if (ModelState.IsValid)
            {
                db.Entry(referetni_tip).State = EntityState.Modified;
                db.SaveChanges();
                TempData["error"] = false;
                TempData["message"] = "Uspjesno ste ažurirali referentni tip";
                return RedirectToAction("Index");
            }
            return View(referetni_tip);
        }

        // GET: referetni_tip/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            referetni_tip referetni_tip = db.referetni_tip.Find(id);
            if (referetni_tip == null)
            {
                return HttpNotFound();
            }
            return View(referetni_tip);
        }

        // POST: referetni_tip/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            referetni_tip referetni_tip = db.referetni_tip.Find(id);
            db.referetni_tip.Remove(referetni_tip);
            db.SaveChanges();
            TempData["error"] = false;
            TempData["message"] = "Uspjesno ste izbrisali referentni tip";
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
