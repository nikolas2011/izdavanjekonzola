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
    public class IgricaController : Controller
    {
        private IzdavanjeKonzolaEntities db = new IzdavanjeKonzolaEntities();

        // GET: Igrica
        public ActionResult Index()
        {
            return View(db.Igricas.ToList());
        }

        // GET: Igrica/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Igrica igrica = db.Igricas.Find(id);
            if (igrica == null)
            {
                return HttpNotFound();
            }
            return View(igrica);
        }

        // GET: Igrica/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Igrica/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idIgrice,naziv,opis")] Igrica igrica)
        {
            if (ModelState.IsValid)
            {
                db.Igricas.Add(igrica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(igrica);
        }

        // GET: Igrica/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Igrica igrica = db.Igricas.Find(id);
            if (igrica == null)
            {
                return HttpNotFound();
            }
            return View(igrica);
        }

        // POST: Igrica/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idIgrice,naziv,opis")] Igrica igrica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(igrica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(igrica);
        }

        // GET: Igrica/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Igrica igrica = db.Igricas.Find(id);
            if (igrica == null)
            {
                return HttpNotFound();
            }
            return View(igrica);
        }

        // POST: Igrica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Igrica igrica = db.Igricas.Find(id);
            db.Igricas.Remove(igrica);
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
