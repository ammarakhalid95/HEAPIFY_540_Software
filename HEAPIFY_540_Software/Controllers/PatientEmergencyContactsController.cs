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
    public class PatientEmergencyContactsController : Controller
    {
        private HEAPIFY_540_SoftwareContext db = new HEAPIFY_540_SoftwareContext();

        // GET: PatientEmergencyContacts
        public ActionResult Index()
        {
            var patientEmergencyContacts = db.PatientEmergencyContacts.Include(p => p.EmergencyContact).Include(p => p.Patient);
            return View(patientEmergencyContacts.ToList());
        }

        // GET: PatientEmergencyContacts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientEmergencyContact patientEmergencyContact = db.PatientEmergencyContacts.Find(id);
            if (patientEmergencyContact == null)
            {
                return HttpNotFound();
            }
            return View(patientEmergencyContact);
        }

        // GET: PatientEmergencyContacts/Create
        public ActionResult Create()
        {
            ViewBag.EmergencyContactID = new SelectList(db.EmergencyContacts, "EmergencyContactID", "FirstName");
            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "FirstName");
            return View();
        }

        // POST: PatientEmergencyContacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PatientEmergencyContactID,PatientID,EmergencyContactID")] PatientEmergencyContact patientEmergencyContact)
        {
            if (ModelState.IsValid)
            {
                db.PatientEmergencyContacts.Add(patientEmergencyContact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmergencyContactID = new SelectList(db.EmergencyContacts, "EmergencyContactID", "FirstName", patientEmergencyContact.EmergencyContactID);
            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "FirstName", patientEmergencyContact.PatientID);
            return View(patientEmergencyContact);
        }

        // GET: PatientEmergencyContacts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientEmergencyContact patientEmergencyContact = db.PatientEmergencyContacts.Find(id);
            if (patientEmergencyContact == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmergencyContactID = new SelectList(db.EmergencyContacts, "EmergencyContactID", "FirstName", patientEmergencyContact.EmergencyContactID);
            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "FirstName", patientEmergencyContact.PatientID);
            return View(patientEmergencyContact);
        }

        // POST: PatientEmergencyContacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PatientEmergencyContactID,PatientID,EmergencyContactID")] PatientEmergencyContact patientEmergencyContact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patientEmergencyContact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmergencyContactID = new SelectList(db.EmergencyContacts, "EmergencyContactID", "FirstName", patientEmergencyContact.EmergencyContactID);
            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "FirstName", patientEmergencyContact.PatientID);
            return View(patientEmergencyContact);
        }

        // GET: PatientEmergencyContacts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientEmergencyContact patientEmergencyContact = db.PatientEmergencyContacts.Find(id);
            if (patientEmergencyContact == null)
            {
                return HttpNotFound();
            }
            return View(patientEmergencyContact);
        }

        // POST: PatientEmergencyContacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PatientEmergencyContact patientEmergencyContact = db.PatientEmergencyContacts.Find(id);
            db.PatientEmergencyContacts.Remove(patientEmergencyContact);
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
