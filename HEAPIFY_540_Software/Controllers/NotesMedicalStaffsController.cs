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
    public class NotesMedicalStaffsController : Controller
    {
        private HEAPIFY_540_SoftwareContext db = new HEAPIFY_540_SoftwareContext();

        // GET: NotesMedicalStaffs
        public ActionResult Index()
        {
            var notesMedicalStaffs = db.NotesMedicalStaffs.Include(n => n.Patient);
            return View(notesMedicalStaffs.ToList());
        }

        // GET: NotesMedicalStaffs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NotesMedicalStaff notesMedicalStaff = db.NotesMedicalStaffs.Find(id);
            if (notesMedicalStaff == null)
            {
                return HttpNotFound();
            }
            return View(notesMedicalStaff);
        }

        // GET: NotesMedicalStaffs/Create
        public ActionResult Create()
        {
            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "FirstName");
            return View();
        }

        // POST: NotesMedicalStaffs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NotesID,Date_Time_Recorded,Notes,PatientID")] NotesMedicalStaff notesMedicalStaff)
        {
            if (ModelState.IsValid)
            {
                db.NotesMedicalStaffs.Add(notesMedicalStaff);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "FirstName", notesMedicalStaff.PatientID);
            return View(notesMedicalStaff);
        }

        // GET: NotesMedicalStaffs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NotesMedicalStaff notesMedicalStaff = db.NotesMedicalStaffs.Find(id);
            if (notesMedicalStaff == null)
            {
                return HttpNotFound();
            }
            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "FirstName", notesMedicalStaff.PatientID);
            return View(notesMedicalStaff);
        }

        // POST: NotesMedicalStaffs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NotesID,Date_Time_Recorded,Notes,PatientID")] NotesMedicalStaff notesMedicalStaff)
        {
            if (ModelState.IsValid)
            {
                db.Entry(notesMedicalStaff).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "FirstName", notesMedicalStaff.PatientID);
            return View(notesMedicalStaff);
        }

        // GET: NotesMedicalStaffs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NotesMedicalStaff notesMedicalStaff = db.NotesMedicalStaffs.Find(id);
            if (notesMedicalStaff == null)
            {
                return HttpNotFound();
            }
            return View(notesMedicalStaff);
        }

        // POST: NotesMedicalStaffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NotesMedicalStaff notesMedicalStaff = db.NotesMedicalStaffs.Find(id);
            db.NotesMedicalStaffs.Remove(notesMedicalStaff);
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
