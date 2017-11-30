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
    [Authorize(Roles = "Patient Billing Representative")]
    public class BillingsController : Controller
    {
        private HEAPIFY_540_SoftwareContext db = new HEAPIFY_540_SoftwareContext();

        // GET: Billings
        public ActionResult Index()
        {
            var billings = db.Billings.Include(b => b.AdjustmentCode).Include(b => b.CurrentProceduralTerminology).Include(b => b.Insurance).Include(b => b.Patient).Include(b => b.PaymentMode);
            return View(billings.ToList());
        }

        // GET: Billings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Billing billing = db.Billings.Find(id);
            if (billing == null)
            {
                return HttpNotFound();
            }
            return View(billing);
        }

        // GET: Billings/Create
        public ActionResult Create()
        {
            ViewBag.AdjustmentCodeID = new SelectList(db.AdjustmentCodes, "AdjustmentCodeID", "AdjustmentDescription");
            ViewBag.CurrentProceduralTerminologyID = new SelectList(db.CurrentProceduralTerminologies, "CurrentProceduralTerminologyID", "CPTActualNumber");
            ViewBag.InsuranceID = new SelectList(db.Insurances, "InsuranceID", "InsuranceName");
            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "FullName");
            ViewBag.PaymentModeID = new SelectList(db.PaymentModes, "PaymentModeID", "PaymentModeType");
            return View();
        }

        // POST: Billings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BillingID,CurrentProceduralTerminologyID,Quantity,Payment,AdjustmentCodeID,PaymentModeID,DatePaid,PaidBy,Notes,PatientID,InsuranceID")] Billing billing)
        {
            if (ModelState.IsValid)
            {
                db.Billings.Add(billing);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AdjustmentCodeID = new SelectList(db.AdjustmentCodes, "AdjustmentCodeID", "AdjustmentDescription", billing.AdjustmentCodeID);
            ViewBag.CurrentProceduralTerminologyID = new SelectList(db.CurrentProceduralTerminologies, "CurrentProceduralTerminologyID", "CPTActualNumber", billing.CurrentProceduralTerminologyID);
            ViewBag.InsuranceID = new SelectList(db.Insurances, "InsuranceID", "InsuranceName", billing.InsuranceID);
            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "FullName", billing.PatientID);
            ViewBag.PaymentModeID = new SelectList(db.PaymentModes, "PaymentModeID", "PaymentModeType", billing.PaymentModeID);
            return View(billing);
        }

        // GET: Billings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Billing billing = db.Billings.Find(id);
            if (billing == null)
            {
                return HttpNotFound();
            }
            ViewBag.AdjustmentCodeID = new SelectList(db.AdjustmentCodes, "AdjustmentCodeID", "AdjustmentDescription", billing.AdjustmentCodeID);
            ViewBag.CurrentProceduralTerminologyID = new SelectList(db.CurrentProceduralTerminologies, "CurrentProceduralTerminologyID", "CPTActualNumber", billing.CurrentProceduralTerminologyID);
            ViewBag.InsuranceID = new SelectList(db.Insurances, "InsuranceID", "InsuranceName", billing.InsuranceID);
            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "FullName", billing.PatientID);
            ViewBag.PaymentModeID = new SelectList(db.PaymentModes, "PaymentModeID", "PaymentModeType", billing.PaymentModeID);
            return View(billing);
        }

        // POST: Billings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BillingID,CurrentProceduralTerminologyID,Quantity,Payment,AdjustmentCodeID,PaymentModeID,DatePaid,PaidBy,Notes,PatientID,InsuranceID")] Billing billing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(billing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AdjustmentCodeID = new SelectList(db.AdjustmentCodes, "AdjustmentCodeID", "AdjustmentDescription", billing.AdjustmentCodeID);
            ViewBag.CurrentProceduralTerminologyID = new SelectList(db.CurrentProceduralTerminologies, "CurrentProceduralTerminologyID", "CPTActualNumber", billing.CurrentProceduralTerminologyID);
            ViewBag.InsuranceID = new SelectList(db.Insurances, "InsuranceID", "InsuranceName", billing.InsuranceID);
            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "FullName", billing.PatientID);
            ViewBag.PaymentModeID = new SelectList(db.PaymentModes, "PaymentModeID", "PaymentModeType", billing.PaymentModeID);
            return View(billing);
        }

        // GET: Billings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Billing billing = db.Billings.Find(id);
            if (billing == null)
            {
                return HttpNotFound();
            }
            return View(billing);
        }

        // POST: Billings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Billing billing = db.Billings.Find(id);
            db.Billings.Remove(billing);
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
