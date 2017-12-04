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
    //[Authorize(Roles = "Medical Staff, Medical Receptionist")]
    public class PatientsController : Controller
    {
        private HEAPIFY_540_SoftwareContext db = new HEAPIFY_540_SoftwareContext();

        // GET: Patients
        public ActionResult Index()
        {
            var patients = db.Patients.Include(p => p.Address).Include(p => p.Insurance).Include(p => p.MaritalStanding).Include(p => p.PhoneNumber);
            return View(patients.ToList());
        }

        public ActionResult AdministrativeRecord()
        {
            var patients = db.Patients.Include(p => p.Address).Include(p => p.Insurance).Include(p => p.MaritalStanding).Include(p => p.PhoneNumber);
            return View(patients.ToList());
        }

        public ActionResult SecondaryMenu()
        {
            return View("SideMenu");
        }

        public ActionResult FaceSheet(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);

        }
        // GET: Patients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // GET: Patients/Create
        public ActionResult Create()
        {
            ViewBag.AddressID = new SelectList(db.Addresses, "AddressID", "FullAddress");
            ViewBag.InsuranceID = new SelectList(db.Insurances, "InsuranceID", "InsuranceFull");
            ViewBag.MaritalStatusID = new SelectList(db.MaritalStandings, "MaritalStatusID", "MaritalStatusType");
            ViewBag.PhoneNumberID = new SelectList(db.PhoneNumbers, "PhoneNumberID", "PhoneNumber1");
            return View();
        }

        // POST: Patients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PatientID,FirstName,MiddleName,LastName,AddressID,PhoneNumberID,MaritalStatusID,InsuranceID,PatientSSN,Email,DateOfBirth")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Patients.Add(patient);
                db.SaveChanges();
                //return RedirectToAction("Index");
                return RedirectToAction("AdministrativeRecord"); 
            }

            ViewBag.AddressID = new SelectList(db.Addresses, "AddressID", "FullAddress", patient.AddressID);
            ViewBag.InsuranceID = new SelectList(db.Insurances, "InsuranceID", "InsuranceFull", patient.InsuranceID);
            ViewBag.MaritalStatusID = new SelectList(db.MaritalStandings, "MaritalStatusID", "MaritalStatusType", patient.MaritalStatusID);
            ViewBag.PhoneNumberID = new SelectList(db.PhoneNumbers, "PhoneNumberID", "PhoneNumber1", patient.PhoneNumberID);
            return View(patient);
        }

        // GET: Patients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            ViewBag.AddressID = new SelectList(db.Addresses, "AddressID", "FullAddress", patient.AddressID);
            ViewBag.InsuranceID = new SelectList(db.Insurances, "InsuranceID", "InsuranceFull", patient.InsuranceID);
            ViewBag.MaritalStatusID = new SelectList(db.MaritalStandings, "MaritalStatusID", "MaritalStatusType", patient.MaritalStatusID);
            ViewBag.PhoneNumberID = new SelectList(db.PhoneNumbers, "PhoneNumberID", "PhoneNumber1", patient.PhoneNumberID);
            return View(patient);
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PatientID,FirstName,MiddleName,LastName,AddressID,PhoneNumberID,MaritalStatusID,InsuranceID,PatientSSN,Email,DateOfBirth")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AddressID = new SelectList(db.Addresses, "AddressID", "FullAddress", patient.AddressID);
            ViewBag.InsuranceID = new SelectList(db.Insurances, "InsuranceID", "InsuranceFull", patient.InsuranceID);
            ViewBag.MaritalStatusID = new SelectList(db.MaritalStandings, "MaritalStatusID", "MaritalStatusType", patient.MaritalStatusID);
            ViewBag.PhoneNumberID = new SelectList(db.PhoneNumbers, "PhoneNumberID", "PhoneNumber1", patient.PhoneNumberID);
            return View(patient);
        }

        // GET: Patients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Patient patient = db.Patients.Find(id);
            db.Patients.Remove(patient);
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
