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
    //[Authorize(Roles = "Medical Staff")]
    public class PatientProblemsController : Controller
    {
        private HEAPIFY_540_SoftwareContext db = new HEAPIFY_540_SoftwareContext();

        // GET: PatientProblems
        public ActionResult Index()
        {
            ProblemsModel pp = new ProblemsModel();

            using (HEAPIFY_540_SoftwareContext hsc = new HEAPIFY_540_SoftwareContext())
            {
                pp.P = hsc.Problems.ToList<Problem>();
            }
            return View(pp);

            //    var patientProblems = db.PatientProblems.Include(p => p.Patient).Include(p => p.Problem);
            //return View(patientProblems.ToList());
        }

        // GET: PatientProblems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientProblem patientProblem = db.PatientProblems.Find(id);
            if (patientProblem == null)
            {
                return HttpNotFound();
            }
            return View(patientProblem);
        }

        // GET: PatientProblems/Create
        public ActionResult Create()
        {
            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "FirstName");
            ViewBag.ProblemID = new SelectList(db.Problems, "ProblemID", "ProblemsName");
            return View();
        }

        // POST: PatientProblems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PatientProblemID,PatientID,ProblemID")] PatientProblem patientProblem)
        {
            if (ModelState.IsValid)
            {
                db.PatientProblems.Add(patientProblem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "FirstName", patientProblem.PatientID);
            ViewBag.ProblemID = new SelectList(db.Problems, "ProblemID", "ProblemsName", patientProblem.ProblemID);
            return View(patientProblem);
        }

        // GET: PatientProblems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientProblem patientProblem = db.PatientProblems.Find(id);
            if (patientProblem == null)
            {
                return HttpNotFound();
            }
            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "FirstName", patientProblem.PatientID);
            ViewBag.ProblemID = new SelectList(db.Problems, "ProblemID", "ProblemsName", patientProblem.ProblemID);
            return View(patientProblem);
        }

        // POST: PatientProblems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PatientProblemID,PatientID,ProblemID")] PatientProblem patientProblem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patientProblem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "FirstName", patientProblem.PatientID);
            ViewBag.ProblemID = new SelectList(db.Problems, "ProblemID", "ProblemsName", patientProblem.ProblemID);
            return View(patientProblem);
        }

        // GET: PatientProblems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientProblem patientProblem = db.PatientProblems.Find(id);
            if (patientProblem == null)
            {
                return HttpNotFound();
            }
            return View(patientProblem);
        }

        // POST: PatientProblems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PatientProblem patientProblem = db.PatientProblems.Find(id);
            db.PatientProblems.Remove(patientProblem);
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
