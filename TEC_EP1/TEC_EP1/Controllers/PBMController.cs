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
    public class PBMController : Controller
    {
        private EasyPharmaDbContext db = new EasyPharmaDbContext();

        // GET: PBM
        public ActionResult Index()
        {
            return View(db.PBMs.ToList());
        }

        // GET: PBM/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PBM pBM = db.PBMs.Find(id);
            if (pBM == null)
            {
                return HttpNotFound();
            }
            return View(pBM);
        }

        // GET: PBM/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PBM/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] PBM pBM)
        {
            if (ModelState.IsValid)
            {
                db.PBMs.Add(pBM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pBM);
        }

        // GET: PBM/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PBM pBM = db.PBMs.Find(id);
            if (pBM == null)
            {
                return HttpNotFound();
            }
            return View(pBM);
        }

        // POST: PBM/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] PBM pBM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pBM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pBM);
        }

        // GET: PBM/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PBM pBM = db.PBMs.Find(id);
            if (pBM == null)
            {
                return HttpNotFound();
            }
            return View(pBM);
        }

        // POST: PBM/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PBM pBM = db.PBMs.Find(id);
            db.PBMs.Remove(pBM);
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
