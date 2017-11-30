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
    //[Authorize(Roles = "Medical Staff")]
    [Authorize]
    public class PatientDrugsController : Controller
    {
        private HEAPIFY_540_SoftwareContext db = new HEAPIFY_540_SoftwareContext();

        // GET: PatientDrugs
        public ActionResult Index()
        {
            var patientDrugs = db.PatientDrugs.Include(p => p.Drug).Include(p => p.Patient);
            return View(patientDrugs.ToList());
        }

        // GET: PatientDrugs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientDrug patientDrug = db.PatientDrugs.Find(id);
            if (patientDrug == null)
            {
                return HttpNotFound();
            }
            return View(patientDrug);
        }

        // GET: PatientDrugs/Create
        public ActionResult Create()
        {
            ViewBag.DrugID = new SelectList(db.Drugs, "DrugID", "DrugName");
            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "FirstName");
            return View();
        }

        // POST: PatientDrugs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PatientDrugID,PatientID,DrugID")] PatientDrug patientDrug)
        {
            if (ModelState.IsValid)
            {
                db.PatientDrugs.Add(patientDrug);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DrugID = new SelectList(db.Drugs, "DrugID", "DrugName", patientDrug.DrugID);
            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "FirstName", patientDrug.PatientID);
            return View(patientDrug);
        }

        // GET: PatientDrugs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientDrug patientDrug = db.PatientDrugs.Find(id);
            if (patientDrug == null)
            {
                return HttpNotFound();
            }
            ViewBag.DrugID = new SelectList(db.Drugs, "DrugID", "DrugName", patientDrug.DrugID);
            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "FirstName", patientDrug.PatientID);
            return View(patientDrug);
        }

        // POST: PatientDrugs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PatientDrugID,PatientID,DrugID")] PatientDrug patientDrug)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patientDrug).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DrugID = new SelectList(db.Drugs, "DrugID", "DrugName", patientDrug.DrugID);
            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "FirstName", patientDrug.PatientID);
            return View(patientDrug);
        }

        // GET: PatientDrugs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientDrug patientDrug = db.PatientDrugs.Find(id);
            if (patientDrug == null)
            {
                return HttpNotFound();
            }
            return View(patientDrug);
        }

        // POST: PatientDrugs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PatientDrug patientDrug = db.PatientDrugs.Find(id);
            db.PatientDrugs.Remove(patientDrug);
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
