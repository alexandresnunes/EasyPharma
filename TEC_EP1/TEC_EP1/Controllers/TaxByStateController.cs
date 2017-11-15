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
    public class TaxByStateController : Controller
    {
        private EasyPharmaDbContext db = new EasyPharmaDbContext();

        // GET: TaxByState
        public ActionResult Index()
        {
            var taxByStates = db.TaxByStates.Include(t => t.States);
            return View(taxByStates.ToList());
        }

        // GET: TaxByState/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaxByState taxByState = db.TaxByStates.Find(id);
            if (taxByState == null)
            {
                return HttpNotFound();
            }
            return View(taxByState);
        }

        // GET: TaxByState/Create
        public ActionResult Create()
        {
            ViewBag.IdState = new SelectList(db.States, "Id", "Name");
            return View();
        }

        // POST: TaxByState/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PF,PMC,IdState")] TaxByState taxByState)
        {
            if (ModelState.IsValid)
            {
                db.TaxByStates.Add(taxByState);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdState = new SelectList(db.States, "Id", "Name", taxByState.IdState);
            return View(taxByState);
        }

        // GET: TaxByState/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaxByState taxByState = db.TaxByStates.Find(id);
            if (taxByState == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdState = new SelectList(db.States, "Id", "Name", taxByState.IdState);
            return View(taxByState);
        }

        // POST: TaxByState/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PF,PMC,IdState")] TaxByState taxByState)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taxByState).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdState = new SelectList(db.States, "Id", "Name", taxByState.IdState);
            return View(taxByState);
        }

        // GET: TaxByState/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaxByState taxByState = db.TaxByStates.Find(id);
            if (taxByState == null)
            {
                return HttpNotFound();
            }
            return View(taxByState);
        }

        // POST: TaxByState/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TaxByState taxByState = db.TaxByStates.Find(id);
            db.TaxByStates.Remove(taxByState);
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
