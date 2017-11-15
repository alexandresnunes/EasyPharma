using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TEC_EP1.DAL;
using TEC_EP1.Models;

namespace TEC_EP1.Controllers
{
    public class TherapeuticClassController : Controller
    {
        private EasyPharmaDbContext db = new EasyPharmaDbContext();

        // GET: TherapeuticClass
        public ActionResult Index()
        {
            return View(db.TherapeuticClasses.ToList());
        }

        // GET: TherapeuticClass/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TherapeuticClass therapeuticClass = db.TherapeuticClasses.Find(id);
            if (therapeuticClass == null)
            {
                return HttpNotFound();
            }
            return View(therapeuticClass);
        }

        // GET: TherapeuticClass/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TherapeuticClass/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] TherapeuticClass therapeuticClass)
        {
            if (ModelState.IsValid)
            {
                db.TherapeuticClasses.Add(therapeuticClass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(therapeuticClass);
        }

        // GET: TherapeuticClass/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TherapeuticClass therapeuticClass = db.TherapeuticClasses.Find(id);
            if (therapeuticClass == null)
            {
                return HttpNotFound();
            }
            return View(therapeuticClass);
        }

        // POST: TherapeuticClass/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] TherapeuticClass therapeuticClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(therapeuticClass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(therapeuticClass);
        }

        // GET: TherapeuticClass/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TherapeuticClass therapeuticClass = db.TherapeuticClasses.Find(id);
            if (therapeuticClass == null)
            {
                return HttpNotFound();
            }
            return View(therapeuticClass);
        }

        // POST: TherapeuticClass/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TherapeuticClass therapeuticClass = db.TherapeuticClasses.Find(id);
            db.TherapeuticClasses.Remove(therapeuticClass);
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
