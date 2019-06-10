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
    public class ulogaController : Controller
    {
        private Model1 db = new Model1();

        public ActionResult Index(string sortOrder, string CurrentSort, int? page)
        {
            int pageSize = 5;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;

            ViewBag.CurrentSort = sortOrder;

            sortOrder = String.IsNullOrEmpty(sortOrder) ? "imeuloge" : sortOrder;

            IPagedList<uloga> ulogaa = null;

            switch (sortOrder)
            {
                case "ime_uloge":
                    if (sortOrder.Equals(CurrentSort))
                        ulogaa = db.uloga.OrderByDescending
                                (db => db.ime_uloge).ToPagedList(pageIndex, pageSize);
                    else
                        ulogaa = db.uloga.OrderBy
                                (db => db.ime_uloge).ToPagedList(pageIndex, pageSize);
                    break;

                case "cijena_satnice":
                    if (sortOrder.Equals(CurrentSort))
                        ulogaa = db.uloga.OrderByDescending
                                (db => db.cijena_satnice).ToPagedList(pageIndex, pageSize);
                    else
                        ulogaa = db.uloga.OrderBy
                                (db => db.cijena_satnice).ToPagedList(pageIndex, pageSize);
                    break;






                default:
                    ulogaa = db.uloga.OrderBy
                            (db => db.ime_uloge).ToPagedList(pageIndex, pageSize);
                    break;
            }
            return View(ulogaa);
        }





        // GET: uloga/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            uloga uloga = db.uloga.Find(id);
            if (uloga == null)
            {
                return HttpNotFound();
            }
            return View(uloga);
        }

        // GET: uloga/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: uloga/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_uloge,ime_uloge,cijena_satnice")] uloga uloga)
        {
            if (ModelState.IsValid)
            {
                db.uloga.Add(uloga);
                db.SaveChanges();
                TempData["error"] = false;
                TempData["message"] = "Uspjesno ste dodali ulogu";
                return RedirectToAction("Index");
            }

            return View(uloga);
        }

        // GET: uloga/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            uloga uloga = db.uloga.Find(id);
            if (uloga == null)
            {
                return HttpNotFound();
            }
            return View(uloga);
        }

        // POST: uloga/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_uloge,ime_uloge,cijena_satnice")] uloga uloga)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uloga).State = EntityState.Modified;
                db.SaveChanges();
                TempData["error"] = false;
                TempData["message"] = "Uspjesno ste ažurirali ulogu";
                return RedirectToAction("Index");
            }
            return View(uloga);
        }

        // GET: uloga/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            uloga uloga = db.uloga.Find(id);
            if (uloga == null)
            {
                return HttpNotFound();
            }
            return View(uloga);
        }

        // POST: uloga/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            uloga uloga = db.uloga.Find(id);
            db.uloga.Remove(uloga);
            db.SaveChanges();
            TempData["error"] = false;
            TempData["message"] = "Uspjesno ste izbrisali ulogu";
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
