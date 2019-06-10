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
    public class dogadjaj_ponudaController : Controller
    {
        private Model1 db = new Model1();


        public ActionResult Index(string sortOrder, string CurrentSort, int? page)
        {
            int pageSize = 6;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;

            ViewBag.CurrentSort = sortOrder;

            sortOrder = String.IsNullOrEmpty(sortOrder) ? "nazdog" : sortOrder;

            IPagedList<dogadjaj_ponuda> dogadjajs = null;

            switch (sortOrder)
            {
                case "nazdog":
                    if (sortOrder.Equals(CurrentSort))
                        dogadjajs = db.dogadjaj_ponuda.OrderByDescending
                                (db => db.dogadjaj.naziv_dogadjaja).ToPagedList(pageIndex, pageSize);
                    else
                        dogadjajs = db.dogadjaj_ponuda.OrderBy
                                (db => db.dogadjaj.naziv_dogadjaja).ToPagedList(pageIndex, pageSize);
                    break;

                case "cipo":
                    if (sortOrder.Equals(CurrentSort))
                        dogadjajs = db.dogadjaj_ponuda.OrderByDescending
                                (db => db.ponuda.cijena_ponude).ToPagedList(pageIndex, pageSize);
                    else
                        dogadjajs = db.dogadjaj_ponuda.OrderBy
                                (db => db.ponuda.cijena_ponude).ToPagedList(pageIndex, pageSize);
                    break;

                default:
                    dogadjajs = db.dogadjaj_ponuda.OrderBy
                            (db => db.dogadjaj.naziv_dogadjaja).ToPagedList(pageIndex, pageSize);
                    break;
            }
            return View(dogadjajs);
        }

        /* // GET: dogadjaj_ponuda
         public ActionResult Index()
         {
             var dogadjaj_ponuda = db.dogadjaj_ponuda.Include(d => d.dogadjaj).Include(d => d.ponuda);
             return View(dogadjaj_ponuda.ToList());
         }
 */
        // GET: dogadjaj_ponuda/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dogadjaj_ponuda dogadjaj_ponuda = db.dogadjaj_ponuda.Find(id);
            if (dogadjaj_ponuda == null)
            {
                return HttpNotFound();
            }
            return View(dogadjaj_ponuda);
        }

        // GET: dogadjaj_ponuda/Create
        public ActionResult Create()
        {
            ViewBag.fk_dogadjaj = new SelectList(db.dogadjaj, "id_dogadjaja", "naziv_dogadjaja");
            ViewBag.fk_ponuda = new SelectList(db.ponuda, "id_ponuda", "cijena_ponude");
            return View();
        }

        // POST: dogadjaj_ponuda/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_dogadjaj_ponuda,fk_dogadjaj,fk_ponuda")] dogadjaj_ponuda dogadjaj_ponuda)
        {
            if (ModelState.IsValid)
            {
                db.dogadjaj_ponuda.Add(dogadjaj_ponuda);
                db.SaveChanges();
                TempData["error"] = false;
                TempData["message"] = "Uspjesno ste dodali događaj ponudu";
                return RedirectToAction("Index");
            }

            ViewBag.fk_dogadjaj = new SelectList(db.dogadjaj, "id_dogadjaja", "naziv_dogadjaja", dogadjaj_ponuda.fk_dogadjaj);
            ViewBag.fk_ponuda = new SelectList(db.ponuda, "id_ponuda", "cijena_ponude", dogadjaj_ponuda.fk_ponuda);
            return View(dogadjaj_ponuda);
        }

        // GET: dogadjaj_ponuda/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dogadjaj_ponuda dogadjaj_ponuda = db.dogadjaj_ponuda.Find(id);
            if (dogadjaj_ponuda == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_dogadjaj = new SelectList(db.dogadjaj, "id_dogadjaja", "naziv_dogadjaja", dogadjaj_ponuda.fk_dogadjaj);
            ViewBag.fk_ponuda = new SelectList(db.ponuda, "id_ponuda", "cijena_ponude", dogadjaj_ponuda.fk_ponuda);
            return View(dogadjaj_ponuda);
        }

        // POST: dogadjaj_ponuda/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_dogadjaj_ponuda,fk_dogadjaj,fk_ponuda")] dogadjaj_ponuda dogadjaj_ponuda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dogadjaj_ponuda).State = EntityState.Modified;
                db.SaveChanges();
                TempData["error"] = false;
                TempData["message"] = "Uspjesno ste ažurirali događaj ponudu";
                return RedirectToAction("Index");
            }
            ViewBag.fk_dogadjaj = new SelectList(db.dogadjaj, "id_dogadjaja", "naziv_dogadjaja", dogadjaj_ponuda.fk_dogadjaj);
            ViewBag.fk_ponuda = new SelectList(db.ponuda, "id_ponuda", "cijena_ponude", dogadjaj_ponuda.fk_ponuda);
            return View(dogadjaj_ponuda);
        }

        // GET: dogadjaj_ponuda/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dogadjaj_ponuda dogadjaj_ponuda = db.dogadjaj_ponuda.Find(id);
            if (dogadjaj_ponuda == null)
            {
                return HttpNotFound();
            }
            return View(dogadjaj_ponuda);
        }

        // POST: dogadjaj_ponuda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            dogadjaj_ponuda dogadjaj_ponuda = db.dogadjaj_ponuda.Find(id);
            db.dogadjaj_ponuda.Remove(dogadjaj_ponuda);
            db.SaveChanges();
            TempData["error"] = false;
            TempData["message"] = "Uspjesno ste izbrisali događaj ponudu";
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
