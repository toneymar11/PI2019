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
    public class najamController : Controller
    {
        private Model1 db = new Model1();

        public ActionResult Svenajam()
        {
            return View(db.najam.ToList());
        }

        public ActionResult Index(string sortOrder, string CurrentSort, int? page)
        {
            int pageSize = 8;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;

            ViewBag.CurrentSort = sortOrder;

            sortOrder = String.IsNullOrEmpty(sortOrder) ? "ime_najma" : sortOrder;

            IPagedList<najam> najm = null;

            switch (sortOrder)
            {
                case "ime_najma":
                    if (sortOrder.Equals(CurrentSort))
                        najm = db.najam.OrderByDescending
                                (db => db.naziv_najma).ToPagedList(pageIndex, pageSize);
                    else
                        najm = db.najam.OrderBy
                                (db => db.naziv_najma).ToPagedList(pageIndex, pageSize);
                    break;

                case "vrsta_najma":
                    if (sortOrder.Equals(CurrentSort))
                        najm = db.najam.OrderByDescending
                                (db => db.tip_najma).ToPagedList(pageIndex, pageSize);
                    else
                        najm = db.najam.OrderBy
                                (db => db.tip_najma).ToPagedList(pageIndex, pageSize);
                    break;

                case "cijena_najma":
                    if (sortOrder.Equals(CurrentSort))
                        najm = db.najam.OrderByDescending
                                (db => db.cijena_najma).ToPagedList(pageIndex, pageSize);
                    else
                        najm = db.najam.OrderBy
                                (db => db.cijena_najma).ToPagedList(pageIndex, pageSize);
                    break;




                default:
                    najm = db.najam.OrderBy
                            (db => db.naziv_najma).ToPagedList(pageIndex, pageSize);
                    break;
            }
            return View(najm);
        }
        public ActionResult GeneratePDF()
        {
            return new Rotativa.ActionAsPdf("Svenajam");
        }
        // GET: najam/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            najam najam = db.najam.Find(id);
            if (najam == null)
            {
                return HttpNotFound();
            }
            return View(najam);
        }

        // GET: najam/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: najam/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_najam,naziv_najma,tip_najma,cijena_najma")] najam najam)
        {
            if (ModelState.IsValid)
            {
                db.najam.Add(najam);
                db.SaveChanges();
                TempData["error"] = false;
                TempData["message"] = "Uspjesno ste dodali najam ";
                return RedirectToAction("Index");
            }
            TempData["error"] = true;
            TempData["message"] = "Popuni sva polja";
            return View(najam);
        
        }

        // GET: najam/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            najam najam = db.najam.Find(id);
            if (najam == null)
            {
                return HttpNotFound();
            }
            return View(najam);
        }

        // POST: najam/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_najam,naziv_najma,tip_najma,cijena_najma")] najam najam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(najam).State = EntityState.Modified;
                db.SaveChanges();
                TempData["error"] = false;
                TempData["message"] = "Uspjesno ste ažurirali najam ";
                return RedirectToAction("Index");
            }
            return View(najam);
        }

        // GET: najam/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            najam najam = db.najam.Find(id);
            if (najam == null)
            {
                return HttpNotFound();
            }
            return View(najam);
        }

        // POST: najam/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            najam najam = db.najam.Find(id);
            db.najam.Remove(najam);
            db.SaveChanges();
            TempData["error"] = false;
            TempData["message"] = "Uspjesno ste izbrisali najam ";
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
