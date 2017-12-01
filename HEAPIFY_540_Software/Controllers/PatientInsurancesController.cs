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
    [Authorize]
    //[Authorize(Roles = "Medical Receptionist, Patient Billing Representative")]
    public class PatientInsurancesController : Controller
    {
        private HEAPIFY_540_SoftwareContext db = new HEAPIFY_540_SoftwareContext();

        // GET: PatientInsurances
        public ActionResult Index()
        {
            var patientInsurances = db.PatientInsurances.Include(p => p.Insurance).Include(p => p.Patient);
            return View(patientInsurances.ToList());
        }

        // GET: PatientInsurances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientInsurance patientInsurance = db.PatientInsurances.Find(id);
            if (patientInsurance == null)
            {
                return HttpNotFound();
            }
            return View(patientInsurance);
        }

        // GET: PatientInsurances/Create
        public ActionResult Create()
        {
            ViewBag.InsuranceID = new SelectList(db.Insurances, "InsuranceID", "InsuranceName");
            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "FullName");
            return View();
        }

        // POST: PatientInsurances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PatientInsuranceID,PatientID,InsuranceID")] PatientInsurance patientInsurance)
        {
            if (ModelState.IsValid)
            {
                db.PatientInsurances.Add(patientInsurance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InsuranceID = new SelectList(db.Insurances, "InsuranceID", "InsuranceName", patientInsurance.InsuranceID);
            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "FullName", patientInsurance.PatientID);
            return View(patientInsurance);
        }

        // GET: PatientInsurances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientInsurance patientInsurance = db.PatientInsurances.Find(id);
            if (patientInsurance == null)
            {
                return HttpNotFound();
            }
            ViewBag.InsuranceID = new SelectList(db.Insurances, "InsuranceID", "InsuranceName", patientInsurance.InsuranceID);
            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "FulltName", patientInsurance.PatientID);
            return View(patientInsurance);
        }

        // POST: PatientInsurances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PatientInsuranceID,PatientID,InsuranceID")] PatientInsurance patientInsurance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patientInsurance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InsuranceID = new SelectList(db.Insurances, "InsuranceID", "InsuranceName", patientInsurance.InsuranceID);
            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "FullName", patientInsurance.PatientID);
            return View(patientInsurance);
        }

        // GET: PatientInsurances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientInsurance patientInsurance = db.PatientInsurances.Find(id);
            if (patientInsurance == null)
            {
                return HttpNotFound();
            }
            return View(patientInsurance);
        }

        // POST: PatientInsurances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PatientInsurance patientInsurance = db.PatientInsurances.Find(id);
            db.PatientInsurances.Remove(patientInsurance);
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
