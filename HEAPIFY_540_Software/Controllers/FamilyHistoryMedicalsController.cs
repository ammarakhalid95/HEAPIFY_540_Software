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
    public class FamilyHistoryMedicalsController : Controller
    {
        private HEAPIFY_540_SoftwareContext db = new HEAPIFY_540_SoftwareContext();

        // GET: FamilyHistoryMedicals
        public ActionResult Index()
        {
            var familyHistoryMedicals = db.FamilyHistoryMedicals.Include(f => f.Patient).Include(f => f.Problem).Include(f => f.Relationship);
            return View(familyHistoryMedicals.ToList());
        }

        // GET: FamilyHistoryMedicals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FamilyHistoryMedical familyHistoryMedical = db.FamilyHistoryMedicals.Find(id);
            if (familyHistoryMedical == null)
            {
                return HttpNotFound();
            }
            return View(familyHistoryMedical);
        }

        // GET: FamilyHistoryMedicals/Create
        public ActionResult Create()
        {
            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "FirstName");
            ViewBag.ProblemID = new SelectList(db.Problems, "ProblemID", "ProblemsName");
            ViewBag.RelationshipID = new SelectList(db.Relationships, "RelationshipID", "RelationshipType");
            return View();
        }

        // POST: FamilyHistoryMedicals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PatientFamilyProblemID,ProblemID,RelationshipID,PatientID")] FamilyHistoryMedical familyHistoryMedical)
        {
            if (ModelState.IsValid)
            {
                db.FamilyHistoryMedicals.Add(familyHistoryMedical);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "FirstName", familyHistoryMedical.PatientID);
            ViewBag.ProblemID = new SelectList(db.Problems, "ProblemID", "ProblemsName", familyHistoryMedical.ProblemID);
            ViewBag.RelationshipID = new SelectList(db.Relationships, "RelationshipID", "RelationshipType", familyHistoryMedical.RelationshipID);
            return View(familyHistoryMedical);
        }

        // GET: FamilyHistoryMedicals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FamilyHistoryMedical familyHistoryMedical = db.FamilyHistoryMedicals.Find(id);
            if (familyHistoryMedical == null)
            {
                return HttpNotFound();
            }
            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "FirstName", familyHistoryMedical.PatientID);
            ViewBag.ProblemID = new SelectList(db.Problems, "ProblemID", "ProblemsName", familyHistoryMedical.ProblemID);
            ViewBag.RelationshipID = new SelectList(db.Relationships, "RelationshipID", "RelationshipType", familyHistoryMedical.RelationshipID);
            return View(familyHistoryMedical);
        }

        // POST: FamilyHistoryMedicals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PatientFamilyProblemID,ProblemID,RelationshipID,PatientID")] FamilyHistoryMedical familyHistoryMedical)
        {
            if (ModelState.IsValid)
            {
                db.Entry(familyHistoryMedical).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "FirstName", familyHistoryMedical.PatientID);
            ViewBag.ProblemID = new SelectList(db.Problems, "ProblemID", "ProblemsName", familyHistoryMedical.ProblemID);
            ViewBag.RelationshipID = new SelectList(db.Relationships, "RelationshipID", "RelationshipType", familyHistoryMedical.RelationshipID);
            return View(familyHistoryMedical);
        }

        // GET: FamilyHistoryMedicals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FamilyHistoryMedical familyHistoryMedical = db.FamilyHistoryMedicals.Find(id);
            if (familyHistoryMedical == null)
            {
                return HttpNotFound();
            }
            return View(familyHistoryMedical);
        }

        // POST: FamilyHistoryMedicals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FamilyHistoryMedical familyHistoryMedical = db.FamilyHistoryMedicals.Find(id);
            db.FamilyHistoryMedicals.Remove(familyHistoryMedical);
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
