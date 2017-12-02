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
    public class DemographicsController : Controller
    {
        private HEAPIFY_540_SoftwareContext db = new HEAPIFY_540_SoftwareContext();

        // GET: Demographics
        public ActionResult Index()
        {
            var demographics = db.Demographics.Include(d => d.ActiveSStanding).Include(d => d.AlchoholStanding).Include(d => d.DrugAbuse).Include(d => d.EmergencyContact).Include(d => d.Ethnicity).Include(d => d.Occupation).Include(d => d.Patient).Include(d => d.Race).Include(d => d.SmokingStanding);

            //List<PhoneNumber> list = db.PhoneNumbers.ToList();
            //ViewBag.PhoneNumberList = new SelectList(list, "PhoneNumberID", "PhoneNumber1");

            return View(demographics.ToList());
            //return View();
        }

        //[HttpPost]
        //public ActionResult Create(EmergencyContact model)
        //{
        //    try
        //    {
        //        HEAPIFY_540_SoftwareContext db = new HEAPIFY_540_SoftwareContext();
        //        //List<PhoneNumber> list = db.PhoneNumbers.ToList();
        //        //ViewBag.PhoneNumberList = new SelectList(list, "PhoneNumberID", "PhoneNumber1");

        //        EmergencyContact e = new EmergencyContact();
        //        e.FirstName = model.FirstName;
        //        e.MiddleName = model.MiddleName;
        //        e.LastName = model.LastName;
        //        //e.PhoneNumberID = model.PhoneNumberID;
        //        e.Email = model.Email;
                

        //        db.EmergencyContacts.Add(e);
        //        db.SaveChanges();

        //        return View();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}

        // GET: Demographics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Demographic demographic = db.Demographics.Find(id);
            if (demographic == null)
            {
                return HttpNotFound();
            }
            return View(demographic);
        }

        // GET: Demographics/Create
        public ActionResult Create()
        {
            ViewBag.ActiveSStatusID = new SelectList(db.ActiveSStandings, "ActiveSStatusID", "ActiveSSType");
            ViewBag.AlcoholStatusID = new SelectList(db.AlchoholStandings, "AlcoholStatusID", "AlcoholStatusType");
            ViewBag.DrugAbuseID = new SelectList(db.DrugAbuses, "DrugAbuseID", "DrugAbuseType");
            ViewBag.EmergencyContactID = new SelectList(db.EmergencyContacts, "EmergencyContactID", "FullName");
            ViewBag.EthnicityID = new SelectList(db.Ethnicities, "EthnicityID", "EthnicityName");
            ViewBag.OccupationID = new SelectList(db.Occupations, "OccupationID", "FullEmployment");
            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "FullName");
            ViewBag.RaceID = new SelectList(db.Races, "RaceID", "RaceName");
            //ViewBag.EmergencyContact.RelationshipID = new SelectList(db.Relationships, "RelationshipID", "RelationshipType");
            ViewBag.SmokingStatusID = new SelectList(db.SmokingStandings, "SmokingStatusID", "SmokingStatusType");
            return View();
        }

        // POST: Demographics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DemographicID,PatientID,OccupationID,EthnicityID,RaceID,EmergencyContactID,SmokingStatusID,AlcoholStatusID,ActiveSStatusID,DrugAbuseID")] Demographic demographic)
        {
            if (ModelState.IsValid)
            {
                db.Demographics.Add(demographic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ActiveSStatusID = new SelectList(db.ActiveSStandings, "ActiveSStatusID", "ActiveSSType", demographic.ActiveSStatusID);
            ViewBag.AlcoholStatusID = new SelectList(db.AlchoholStandings, "AlcoholStatusID", "AlcoholStatusType", demographic.AlcoholStatusID);
            ViewBag.DrugAbuseID = new SelectList(db.DrugAbuses, "DrugAbuseID", "DrugAbuseType", demographic.DrugAbuseID);
            ViewBag.EmergencyContactID = new SelectList(db.EmergencyContacts, "EmergencyContactID", "FullName", demographic.EmergencyContactID);
            ViewBag.EthnicityID = new SelectList(db.Ethnicities, "EthnicityID", "EthnicityName", demographic.EthnicityID);
            ViewBag.OccupationID = new SelectList(db.Occupations, "OccupationID", "PositionTitle", demographic.OccupationID);
            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "FullName", demographic.PatientID);
            ViewBag.RaceID = new SelectList(db.Races, "RaceID", "RaceName", demographic.RaceID);
            ViewBag.SmokingStatusID = new SelectList(db.SmokingStandings, "SmokingStatusID", "SmokingStatusType", demographic.SmokingStatusID);
            return View(demographic);
        }

        // GET: Demographics/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Demographic demographic = db.Demographics.Find(id);
            if (demographic == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActiveSStatusID = new SelectList(db.ActiveSStandings, "ActiveSStatusID", "ActiveSSType", demographic.ActiveSStatusID);
            ViewBag.AlcoholStatusID = new SelectList(db.AlchoholStandings, "AlcoholStatusID", "AlcoholStatusType", demographic.AlcoholStatusID);
            ViewBag.DrugAbuseID = new SelectList(db.DrugAbuses, "DrugAbuseID", "DrugAbuseType", demographic.DrugAbuseID);
            ViewBag.EmergencyContactID = new SelectList(db.EmergencyContacts, "EmergencyContactID", "FullName", demographic.EmergencyContactID);
            ViewBag.EthnicityID = new SelectList(db.Ethnicities, "EthnicityID", "EthnicityName", demographic.EthnicityID);
            ViewBag.OccupationID = new SelectList(db.Occupations, "OccupationID", "PositionTitle", demographic.OccupationID);
            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "FullName", demographic.PatientID);
            ViewBag.RaceID = new SelectList(db.Races, "RaceID", "RaceName", demographic.RaceID);
            ViewBag.SmokingStatusID = new SelectList(db.SmokingStandings, "SmokingStatusID", "SmokingStatusType", demographic.SmokingStatusID);
            return View(demographic);
        }

        // POST: Demographics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DemographicID,PatientID,OccupationID,EthnicityID,RaceID,EmergencyContactID,SmokingStatusID,AlcoholStatusID,ActiveSStatusID,DrugAbuseID")] Demographic demographic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(demographic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ActiveSStatusID = new SelectList(db.ActiveSStandings, "ActiveSStatusID", "ActiveSSType", demographic.ActiveSStatusID);
            ViewBag.AlcoholStatusID = new SelectList(db.AlchoholStandings, "AlcoholStatusID", "AlcoholStatusType", demographic.AlcoholStatusID);
            ViewBag.DrugAbuseID = new SelectList(db.DrugAbuses, "DrugAbuseID", "DrugAbuseType", demographic.DrugAbuseID);
            ViewBag.EmergencyContactID = new SelectList(db.EmergencyContacts, "EmergencyContactID", "FullName", demographic.EmergencyContactID);
            ViewBag.EthnicityID = new SelectList(db.Ethnicities, "EthnicityID", "EthnicityName", demographic.EthnicityID);
            ViewBag.OccupationID = new SelectList(db.Occupations, "OccupationID", "PositionTitle", demographic.OccupationID);
            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "FullName", demographic.PatientID);
            ViewBag.RaceID = new SelectList(db.Races, "RaceID", "RaceName", demographic.RaceID);
            ViewBag.SmokingStatusID = new SelectList(db.SmokingStandings, "SmokingStatusID", "SmokingStatusType", demographic.SmokingStatusID);
            return View(demographic);
        }

        // GET: Demographics/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Demographic demographic = db.Demographics.Find(id);
            if (demographic == null)
            {
                return HttpNotFound();
            }
            return View(demographic);
        }

        // POST: Demographics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Demographic demographic = db.Demographics.Find(id);
            db.Demographics.Remove(demographic);
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
