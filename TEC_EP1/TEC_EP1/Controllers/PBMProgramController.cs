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
    public class PBMProgramController : Controller
    {
        private EasyPharmaDbContext db = new EasyPharmaDbContext();

        // GET: PBMProgram
        public ActionResult Index()
        {
            var pBMPrograms = db.PBMPrograms.Include(p => p.PBMs);
            return View(pBMPrograms.ToList());
        }

        // GET: PBMProgram/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PBMProgram pBMProgram = db.PBMPrograms.Find(id);
            if (pBMProgram == null)
            {
                return HttpNotFound();
            }
            return View(pBMProgram);
        }

        // GET: PBMProgram/Create
        public ActionResult Create()
        {
            ViewBag.IdPBM = new SelectList(db.PBMs, "Id", "Name");
            return View();
        }

        // POST: PBMProgram/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,IdPBM")] PBMProgram pBMProgram)
        {
            if (ModelState.IsValid)
            {
                db.PBMPrograms.Add(pBMProgram);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdPBM = new SelectList(db.PBMs, "Id", "Name", pBMProgram.IdPBM);
            return View(pBMProgram);
        }

        // GET: PBMProgram/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PBMProgram pBMProgram = db.PBMPrograms.Find(id);
            if (pBMProgram == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPBM = new SelectList(db.PBMs, "Id", "Name", pBMProgram.IdPBM);
            return View(pBMProgram);
        }

        // POST: PBMProgram/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,IdPBM")] PBMProgram pBMProgram)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pBMProgram).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdPBM = new SelectList(db.PBMs, "Id", "Name", pBMProgram.IdPBM);
            return View(pBMProgram);
        }

        // GET: PBMProgram/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PBMProgram pBMProgram = db.PBMPrograms.Find(id);
            if (pBMProgram == null)
            {
                return HttpNotFound();
            }
            return View(pBMProgram);
        }

        // POST: PBMProgram/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PBMProgram pBMProgram = db.PBMPrograms.Find(id);
            db.PBMPrograms.Remove(pBMProgram);
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
