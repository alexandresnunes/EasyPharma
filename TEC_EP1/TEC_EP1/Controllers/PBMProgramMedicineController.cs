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
    public class PBMProgramMedicineController : Controller
    {
        private EasyPharmaDbContext db = new EasyPharmaDbContext();

        // GET: PBMProgramMedicine
        public ActionResult Index()
        {
            var pBMProgramMedicines = db.PBMProgramMedicines.Include(p => p.Medicines).Include(p => p.PBMPrograms);
            return View(pBMProgramMedicines.ToList());
        }

        // GET: PBMProgramMedicine/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PBMProgramMedicine pBMProgramMedicine = db.PBMProgramMedicines.Find(id);
            if (pBMProgramMedicine == null)
            {
                return HttpNotFound();
            }
            return View(pBMProgramMedicine);
        }

        // GET: PBMProgramMedicine/Create
        public ActionResult Create()
        {
            ViewBag.IdMedicine = new SelectList(db.Medicines, "Id", "EAN");
            ViewBag.IdPBMProgram = new SelectList(db.PBMPrograms, "Id", "Name");
            return View();
        }

        // POST: PBMProgramMedicine/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PercDescPF,PercDescPMC,ExtraInfo,IdPBMProgram,IdMedicine")] PBMProgramMedicine pBMProgramMedicine)
        {
            if (ModelState.IsValid)
            {
                db.PBMProgramMedicines.Add(pBMProgramMedicine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdMedicine = new SelectList(db.Medicines, "Id", "EAN", pBMProgramMedicine.IdMedicine);
            ViewBag.IdPBMProgram = new SelectList(db.PBMPrograms, "Id", "Name", pBMProgramMedicine.IdPBMProgram);
            return View(pBMProgramMedicine);
        }

        // GET: PBMProgramMedicine/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PBMProgramMedicine pBMProgramMedicine = db.PBMProgramMedicines.Find(id);
            if (pBMProgramMedicine == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdMedicine = new SelectList(db.Medicines, "Id", "EAN", pBMProgramMedicine.IdMedicine);
            ViewBag.IdPBMProgram = new SelectList(db.PBMPrograms, "Id", "Name", pBMProgramMedicine.IdPBMProgram);
            return View(pBMProgramMedicine);
        }

        // POST: PBMProgramMedicine/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PercDescPF,PercDescPMC,ExtraInfo,IdPBMProgram,IdMedicine")] PBMProgramMedicine pBMProgramMedicine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pBMProgramMedicine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdMedicine = new SelectList(db.Medicines, "Id", "EAN", pBMProgramMedicine.IdMedicine);
            ViewBag.IdPBMProgram = new SelectList(db.PBMPrograms, "Id", "Name", pBMProgramMedicine.IdPBMProgram);
            return View(pBMProgramMedicine);
        }

        // GET: PBMProgramMedicine/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PBMProgramMedicine pBMProgramMedicine = db.PBMProgramMedicines.Find(id);
            if (pBMProgramMedicine == null)
            {
                return HttpNotFound();
            }
            return View(pBMProgramMedicine);
        }

        // POST: PBMProgramMedicine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PBMProgramMedicine pBMProgramMedicine = db.PBMProgramMedicines.Find(id);
            db.PBMProgramMedicines.Remove(pBMProgramMedicine);
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
