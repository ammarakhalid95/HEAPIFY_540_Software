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
    [Authorize(Roles = "Medical Staff")]
    public class PatientImmunizationsController : Controller
    {
        private HEAPIFY_540_SoftwareContext db = new HEAPIFY_540_SoftwareContext();

        // GET: PatientImmunizations
        public ActionResult Index()
        {
            var patientImmunizations = db.PatientImmunizations.Include(p => p.Immunization).Include(p => p.Patient);
            return View(patientImmunizations.ToList());
        }

        // GET: PatientImmunizations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientImmunization patientImmunization = db.PatientImmunizations.Find(id);
            if (patientImmunization == null)
            {
                return HttpNotFound();
            }
            return View(patientImmunization);
        }

        // GET: PatientImmunizations/Create
        public ActionResult Create()
        {
            ViewBag.ImmunizationID = new SelectList(db.Immunizations, "ImmunizationID", "Vaccine");
            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "FirstName");
            return View();
        }

        // POST: PatientImmunizations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PatientImmunizationID,PatientID,ImmunizationID,DateGiven")] PatientImmunization patientImmunization)
        {
            if (ModelState.IsValid)
            {
                db.PatientImmunizations.Add(patientImmunization);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ImmunizationID = new SelectList(db.Immunizations, "ImmunizationID", "Vaccine", patientImmunization.ImmunizationID);
            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "FirstName", patientImmunization.PatientID);
            return View(patientImmunization);
        }

        // GET: PatientImmunizations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientImmunization patientImmunization = db.PatientImmunizations.Find(id);
            if (patientImmunization == null)
            {
                return HttpNotFound();
            }
            ViewBag.ImmunizationID = new SelectList(db.Immunizations, "ImmunizationID", "Vaccine", patientImmunization.ImmunizationID);
            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "FirstName", patientImmunization.PatientID);
            return View(patientImmunization);
        }

        // POST: PatientImmunizations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PatientImmunizationID,PatientID,ImmunizationID,DateGiven")] PatientImmunization patientImmunization)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patientImmunization).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ImmunizationID = new SelectList(db.Immunizations, "ImmunizationID", "Vaccine", patientImmunization.ImmunizationID);
            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "FirstName", patientImmunization.PatientID);
            return View(patientImmunization);
        }

        // GET: PatientImmunizations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientImmunization patientImmunization = db.PatientImmunizations.Find(id);
            if (patientImmunization == null)
            {
                return HttpNotFound();
            }
            return View(patientImmunization);
        }

        // POST: PatientImmunizations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PatientImmunization patientImmunization = db.PatientImmunizations.Find(id);
            db.PatientImmunizations.Remove(patientImmunization);
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
