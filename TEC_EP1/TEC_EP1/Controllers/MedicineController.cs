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
    public class MedicineController : Controller
    {
        private EasyPharmaDbContext db = new EasyPharmaDbContext();

        // GET: Medicine
        public ActionResult Index()
        {
            var medicines = db.Medicines.Include(m => m.Laboratories).Include(m => m.TaxByStates).Include(m => m.TherapeuticClasses);
            return View(medicines.ToList());
        }

        // GET: Medicine/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicine medicine = db.Medicines.Find(id);
            if (medicine == null)
            {
                return HttpNotFound();
            }
            return View(medicine);
        }

        // GET: Medicine/Create
        public ActionResult Create()
        {
            ViewBag.IdLab = new SelectList(db.Laboratories, "Id", "Name");
            ViewBag.IdTaxByState = new SelectList(db.TaxByStates, "Id", "Id");
            ViewBag.IdTherapeuticClass = new SelectList(db.TherapeuticClasses, "Id", "Name");
            return View();
        }

        // POST: Medicine/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EAN,Registration,Description,Composition,IdLab,IdTherapeuticClass,IdTaxByState")] Medicine medicine)
        {
            if (ModelState.IsValid)
            {
                db.Medicines.Add(medicine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdLab = new SelectList(db.Laboratories, "Id", "Name", medicine.IdLab);
            ViewBag.IdTaxByState = new SelectList(db.TaxByStates, "Id", "Id", medicine.IdTaxByState);
            ViewBag.IdTherapeuticClass = new SelectList(db.TherapeuticClasses, "Id", "Name", medicine.IdTherapeuticClass);
            return View(medicine);
        }

        // GET: Medicine/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicine medicine = db.Medicines.Find(id);
            if (medicine == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdLab = new SelectList(db.Laboratories, "Id", "Name", medicine.IdLab);
            ViewBag.IdTaxByState = new SelectList(db.TaxByStates, "Id", "Id", medicine.IdTaxByState);
            ViewBag.IdTherapeuticClass = new SelectList(db.TherapeuticClasses, "Id", "Name", medicine.IdTherapeuticClass);
            return View(medicine);
        }

        // POST: Medicine/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EAN,Registration,Description,Composition,IdLab,IdTherapeuticClass,IdTaxByState")] Medicine medicine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdLab = new SelectList(db.Laboratories, "Id", "Name", medicine.IdLab);
            ViewBag.IdTaxByState = new SelectList(db.TaxByStates, "Id", "Id", medicine.IdTaxByState);
            ViewBag.IdTherapeuticClass = new SelectList(db.TherapeuticClasses, "Id", "Name", medicine.IdTherapeuticClass);
            return View(medicine);
        }

        // GET: Medicine/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicine medicine = db.Medicines.Find(id);
            if (medicine == null)
            {
                return HttpNotFound();
            }
            return View(medicine);
        }

        // POST: Medicine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Medicine medicine = db.Medicines.Find(id);
            db.Medicines.Remove(medicine);
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
