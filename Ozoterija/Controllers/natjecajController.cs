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
    public class natjecajController : Controller
    {
        private Model1 db = new Model1();

        public ActionResult Index(string sortOrder, string CurrentSort, int? page)
        {
            int pageSize = 8;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;

            ViewBag.CurrentSort = sortOrder;

            sortOrder = String.IsNullOrEmpty(sortOrder) ? "tip_nat" : sortOrder;

            IPagedList<natjecaj> nats = null;

            switch (sortOrder)
            {
                case "tip_nat":
                    if (sortOrder.Equals(CurrentSort))
                        nats = db.natjecaj.OrderByDescending
                                (db => db.tip_natjecaja).ToPagedList(pageIndex, pageSize);
                    else
                        nats = db.natjecaj.OrderBy
                                (db => db.tip_natjecaja).ToPagedList(pageIndex, pageSize);
                    break;

                case "ime_nat":
                    if (sortOrder.Equals(CurrentSort))
                        nats = db.natjecaj.OrderByDescending
                                (db => db.ime_natjecaja).ToPagedList(pageIndex, pageSize);
                    else
                        nats = db.natjecaj.OrderBy
                                (db => db.ime_natjecaja).ToPagedList(pageIndex, pageSize);
                    break;

               


                default:
                    nats = db.natjecaj.OrderBy
                            (db => db.tip_natjecaja).ToPagedList(pageIndex, pageSize);
                    break;
            }
            return View(nats);
        }
        // GET: natjecaj/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            natjecaj natjecaj = db.natjecaj.Find(id);
            if (natjecaj == null)
            {
                return HttpNotFound();
            }
            return View(natjecaj);
        }

        // GET: natjecaj/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: natjecaj/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_natjecaj,tip_natjecaja,ime_natjecaja,datum_otvaranja")] natjecaj natjecaj)
        {
            if (ModelState.IsValid)
            {
                db.natjecaj.Add(natjecaj);
                db.SaveChanges();
                TempData["error"] = false;
                TempData["message"] = "Uspjesno ste dodali natječaj";
                return RedirectToAction("Index");
            }

            return View(natjecaj);
        }

        // GET: natjecaj/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            natjecaj natjecaj = db.natjecaj.Find(id);
            if (natjecaj == null)
            {
                return HttpNotFound();
            }
            return View(natjecaj);
        }

        // POST: natjecaj/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_natjecaj,tip_natjecaja,ime_natjecaja,datum_otvaranja")] natjecaj natjecaj)
        {
            if (ModelState.IsValid)
            {
                db.Entry(natjecaj).State = EntityState.Modified;
                db.SaveChanges();
                TempData["error"] = false;
                TempData["message"] = "Uspjesno ste ažuriali natječaj";
                return RedirectToAction("Index");
            }
            return View(natjecaj);
        }

        // GET: natjecaj/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            natjecaj natjecaj = db.natjecaj.Find(id);
            if (natjecaj == null)
            {
                return HttpNotFound();
            }
            return View(natjecaj);
        }

        // POST: natjecaj/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            natjecaj natjecaj = db.natjecaj.Find(id);
            db.natjecaj.Remove(natjecaj);
            db.SaveChanges();
            TempData["error"] = false;
            TempData["message"] = "Uspjesno ste izbrisali natječaj";
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
