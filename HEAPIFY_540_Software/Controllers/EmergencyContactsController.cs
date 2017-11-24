using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HEAPIFY_540_Software.Models;
using Newtonsoft.Json;

namespace HEAPIFY_540_Software.Controllers
{
    [Authorize]
    public class EmergencyContactsController : Controller
    {
        private HEAPIFY_540_SoftwareContext db = new HEAPIFY_540_SoftwareContext();

        // GET: EmergencyContacts
        public ActionResult Index()
        {
            var emergencyContacts = db.EmergencyContacts.Include(e => e.PhoneNumber).Include(e => e.Relationship);
            return View(emergencyContacts.ToList());
        }

        // GET: EmergencyContacts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmergencyContact emergencyContact = db.EmergencyContacts.Find(id);
            if (emergencyContact == null)
            {
                return HttpNotFound();
            }
            return View(emergencyContact);
        }

        // GET: EmergencyContacts/Create
        public ActionResult Create()
        {
            ViewBag.PhoneNumberID = new SelectList(db.PhoneNumbers, "PhoneNumberID", "PhoneNumber1");
            ViewBag.RelationshipID = new SelectList(db.Relationships, "RelationshipID", "RelationshipType");
            return View();
        }

        // POST: EmergencyContacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmergencyContactID,FirstName,MiddleName,LastName,PhoneNumberID,Email,RelationshipID")] EmergencyContact emergencyContact)
        {
            if (ModelState.IsValid)
            {
                db.EmergencyContacts.Add(emergencyContact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PhoneNumberID = new SelectList(db.PhoneNumbers, "PhoneNumberID", "PhoneNumber1", emergencyContact.PhoneNumberID);
            ViewBag.RelationshipID = new SelectList(db.Relationships, "RelationshipID", "RelationshipType", emergencyContact.RelationshipID);
            return View(emergencyContact);
        }

        // GET: EmergencyContacts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmergencyContact emergencyContact = db.EmergencyContacts.Find(id);
            if (emergencyContact == null)
            {
                return HttpNotFound();
            }
            ViewBag.PhoneNumberID = new SelectList(db.PhoneNumbers, "PhoneNumberID", "PhoneNumber1", emergencyContact.PhoneNumberID);
            ViewBag.RelationshipID = new SelectList(db.Relationships, "RelationshipID", "RelationshipType", emergencyContact.RelationshipID);
            return View(emergencyContact);
        }

        // POST: EmergencyContacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmergencyContactID,FirstName,MiddleName,LastName,PhoneNumberID,Email,RelationshipID")] EmergencyContact emergencyContact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emergencyContact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PhoneNumberID = new SelectList(db.PhoneNumbers, "PhoneNumberID", "PhoneNumber1", emergencyContact.PhoneNumberID);
            ViewBag.RelationshipID = new SelectList(db.Relationships, "RelationshipID", "RelationshipType", emergencyContact.RelationshipID);
            return View(emergencyContact);
        }

        // GET: EmergencyContacts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmergencyContact emergencyContact = db.EmergencyContacts.Find(id);
            if (emergencyContact == null)
            {
                return HttpNotFound();
            }
            return View(emergencyContact);
        }

        // POST: EmergencyContacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmergencyContact emergencyContact = db.EmergencyContacts.Find(id);
            db.EmergencyContacts.Remove(emergencyContact);
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

        public ActionResult ModalPopUp()
        {
            return View();
        }
    }
}
