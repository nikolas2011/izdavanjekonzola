using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCAuthentitification.Models;

namespace MVCAuthentitification.Controllers
{
    public class KonzolaController : Controller
    {
        private IzdavanjeKonzolaEntities db = new IzdavanjeKonzolaEntities();

        // GET: Konzola
        public ActionResult Index()
        {
            return View(db.Konzolas.ToList());
        }

        // GET: Konzola/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Konzola konzola = db.Konzolas.Find(id);
            if (konzola == null)
            {
                return HttpNotFound();
            }
            return View(konzola);
        }

        // GET: Konzola/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Konzola/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idKonzole,model")] Konzola konzola)
        {
            if (ModelState.IsValid)
            {
                db.Konzolas.Add(konzola);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(konzola);
        }

        // GET: Konzola/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Konzola konzola = db.Konzolas.Find(id);
            if (konzola == null)
            {
                return HttpNotFound();
            }
            return View(konzola);
        }

        // POST: Konzola/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idKonzole,model")] Konzola konzola)
        {
            if (ModelState.IsValid)
            {
                db.Entry(konzola).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(konzola);
        }

        // GET: Konzola/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Konzola konzola = db.Konzolas.Find(id);
            if (konzola == null)
            {
                return HttpNotFound();
            }
            return View(konzola);
        }

        // POST: Konzola/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Konzola konzola = db.Konzolas.Find(id);
            db.Konzolas.Remove(konzola);
            db.SaveChanges();
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
