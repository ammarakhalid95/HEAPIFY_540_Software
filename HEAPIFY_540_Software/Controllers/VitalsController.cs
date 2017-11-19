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
    public class VitalsController : Controller
    {
        private HEAPIFY_540_SoftwareContext db = new HEAPIFY_540_SoftwareContext();

        // GET: Vitals
        public ActionResult Index()
        {
            var vitals = db.Vitals.Include(v => v.Patient);
            return View(vitals.ToList());
        }

        // GET: Vitals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vital vital = db.Vitals.Find(id);
            if (vital == null)
            {
                return HttpNotFound();
            }
            return View(vital);
        }

        // GET: Vitals/Create
        public ActionResult Create()
        {
            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "FullName");
            return View();
        }

        // POST: Vitals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VitalID,DateAndTime,BloodPressure,Heart_Rate,Respiratory_Rate,Height_Length,Weight,Temperature,Comments,PatientID")] Vital vital)
        {
            if (ModelState.IsValid)
            {
                db.Vitals.Add(vital);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "FirstName", vital.PatientID);
            return View(vital);
        }

        // GET: Vitals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vital vital = db.Vitals.Find(id);
            if (vital == null)
            {
                return HttpNotFound();
            }
            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "FirstName", vital.PatientID);
            return View(vital);
        }

        // POST: Vitals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VitalID,DateAndTime,BloodPressure,Heart_Rate,Respiratory_Rate,Height_Length,Weight,Temperature,Comments,PatientID")] Vital vital)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vital).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "FirstName", vital.PatientID);
            return View(vital);
        }

        // GET: Vitals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vital vital = db.Vitals.Find(id);
            if (vital == null)
            {
                return HttpNotFound();
            }
            return View(vital);
        }

        // POST: Vitals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vital vital = db.Vitals.Find(id);
            db.Vitals.Remove(vital);
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
