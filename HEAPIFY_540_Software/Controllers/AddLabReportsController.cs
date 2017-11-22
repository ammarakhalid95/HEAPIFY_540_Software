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
    public class AddLabReportsController : Controller
    {
        private HEAPIFY_540_SoftwareContext db = new HEAPIFY_540_SoftwareContext();

        // GET: AddLabReports
        public ActionResult Index()
        {
            var addLabReports = db.AddLabReports.Include(a => a.Patient);
            return View(addLabReports.ToList());
        }

        // GET: AddLabReports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddLabReport addLabReport = db.AddLabReports.Find(id);
            if (addLabReport == null)
            {
                return HttpNotFound();
            }
            return View(addLabReport);
        }

        // GET: AddLabReports/Create
        public ActionResult Create()
        {
            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "FirstName");
            return View();
        }

        // POST: AddLabReports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AddLabReportID,PatientID,WhereOrder,ResultDate,Type,Diagnoses,Lab")] AddLabReport addLabReport)
        {
            if (ModelState.IsValid)
            {
                db.AddLabReports.Add(addLabReport);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "FirstName", addLabReport.PatientID);
            return View(addLabReport);
        }

        // GET: AddLabReports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddLabReport addLabReport = db.AddLabReports.Find(id);
            if (addLabReport == null)
            {
                return HttpNotFound();
            }
            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "FirstName", addLabReport.PatientID);
            return View(addLabReport);
        }

        // POST: AddLabReports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AddLabReportID,PatientID,WhereOrder,ResultDate,Type,Diagnoses,Lab")] AddLabReport addLabReport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(addLabReport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "FirstName", addLabReport.PatientID);
            return View(addLabReport);
        }

        // GET: AddLabReports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddLabReport addLabReport = db.AddLabReports.Find(id);
            if (addLabReport == null)
            {
                return HttpNotFound();
            }
            return View(addLabReport);
        }

        // POST: AddLabReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AddLabReport addLabReport = db.AddLabReports.Find(id);
            db.AddLabReports.Remove(addLabReport);
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
