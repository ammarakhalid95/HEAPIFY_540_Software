using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HEAPIFY_540_Software.Models;

namespace HEAPIFY_540_Software.Controllers
{
    public class CurrentProceduralTerminologiesController : Controller
    {
        private HEAPIFY_540_SoftwareContext db = new HEAPIFY_540_SoftwareContext();

        // GET: CurrentProceduralTerminologies
        public ActionResult Index()
        {
            return View(db.CurrentProceduralTerminologies.ToList());
        }

        // GET: CurrentProceduralTerminologies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CurrentProceduralTerminology currentProceduralTerminology = db.CurrentProceduralTerminologies.Find(id);
            if (currentProceduralTerminology == null)
            {
                return HttpNotFound();
            }
            return View(currentProceduralTerminology);
        }

        // GET: CurrentProceduralTerminologies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CurrentProceduralTerminologies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CurrentProceduralTerminologyID,CPTActualNumber,Description")] CurrentProceduralTerminology currentProceduralTerminology)
        {
            if (ModelState.IsValid)
            {
                db.CurrentProceduralTerminologies.Add(currentProceduralTerminology);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(currentProceduralTerminology);
        }

        // GET: CurrentProceduralTerminologies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CurrentProceduralTerminology currentProceduralTerminology = db.CurrentProceduralTerminologies.Find(id);
            if (currentProceduralTerminology == null)
            {
                return HttpNotFound();
            }
            return View(currentProceduralTerminology);
        }

        // POST: CurrentProceduralTerminologies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CurrentProceduralTerminologyID,CPTActualNumber,Description")] CurrentProceduralTerminology currentProceduralTerminology)
        {
            if (ModelState.IsValid)
            {
                db.Entry(currentProceduralTerminology).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(currentProceduralTerminology);
        }

        // GET: CurrentProceduralTerminologies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CurrentProceduralTerminology currentProceduralTerminology = db.CurrentProceduralTerminologies.Find(id);
            if (currentProceduralTerminology == null)
            {
                return HttpNotFound();
            }
            return View(currentProceduralTerminology);
        }

        // POST: CurrentProceduralTerminologies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CurrentProceduralTerminology currentProceduralTerminology = db.CurrentProceduralTerminologies.Find(id);
            db.CurrentProceduralTerminologies.Remove(currentProceduralTerminology);
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
