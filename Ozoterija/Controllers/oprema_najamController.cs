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
    public class oprema_najamController : Controller
    {
        private Model1 db = new Model1();

        // GET: oprema_najam
        public ActionResult Index()
        {
            var oprema_najam = db.oprema_najam.Include(o => o.najam).Include(o => o.oprema);
            return View(oprema_najam.ToList());
        }

        // GET: oprema_najam/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            oprema_najam oprema_najam = db.oprema_najam.Find(id);
            if (oprema_najam == null)
            {
                return HttpNotFound();
            }
            return View(oprema_najam);
        }

        // GET: oprema_najam/Create
        public ActionResult Create()
        {
            ViewBag.fk_najam = new SelectList(db.najam, "id_najam", "naziv_najma");
            ViewBag.fk_oprema = new SelectList(db.oprema, "id_opreme", "ime_opreme");
            return View();
        }

        // POST: oprema_najam/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_oprema_najam,otkada,dokada,fk_najam,fk_oprema")] oprema_najam oprema_najam)
        {
            if (ModelState.IsValid)
            {
                db.oprema_najam.Add(oprema_najam);
                db.SaveChanges();
                TempData["error"] = false;
                TempData["message"] = "Uspjesno ste dodali opremu najam";
                return RedirectToAction("Index");
            }

            ViewBag.fk_najam = new SelectList(db.najam, "id_najam", "naziv_najma", oprema_najam.fk_najam);
            ViewBag.fk_oprema = new SelectList(db.oprema, "id_opreme", "ime_opreme", oprema_najam.fk_oprema);
            return View(oprema_najam);
        }

        // GET: oprema_najam/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            oprema_najam oprema_najam = db.oprema_najam.Find(id);
            if (oprema_najam == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_najam = new SelectList(db.najam, "id_najam", "naziv_najma", oprema_najam.fk_najam);
            ViewBag.fk_oprema = new SelectList(db.oprema, "id_opreme", "ime_opreme", oprema_najam.fk_oprema);
            return View(oprema_najam);
        }

        // POST: oprema_najam/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_oprema_najam,otkada,dokada,fk_najam,fk_oprema")] oprema_najam oprema_najam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oprema_najam).State = EntityState.Modified;
                db.SaveChanges();
                TempData["error"] = false;
                TempData["message"] = "Uspjesno ste ažurirali opremu najam";
                return RedirectToAction("Index");
            }
            ViewBag.fk_najam = new SelectList(db.najam, "id_najam", "naziv_najma", oprema_najam.fk_najam);
            ViewBag.fk_oprema = new SelectList(db.oprema, "id_opreme", "ime_opreme", oprema_najam.fk_oprema);
            return View(oprema_najam);
        }

        // GET: oprema_najam/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            oprema_najam oprema_najam = db.oprema_najam.Find(id);
            if (oprema_najam == null)
            {
                return HttpNotFound();
            }
            return View(oprema_najam);
        }

        // POST: oprema_najam/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            oprema_najam oprema_najam = db.oprema_najam.Find(id);
            db.oprema_najam.Remove(oprema_najam);
            db.SaveChanges();
            TempData["error"] = false;
            TempData["message"] = "Uspjesno ste izbrisali opremu najam";
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
