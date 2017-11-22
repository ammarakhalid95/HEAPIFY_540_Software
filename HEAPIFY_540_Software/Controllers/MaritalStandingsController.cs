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
    [Authorize(Roles = "IT Administrator")]
    public class MaritalStandingsController : Controller
    {
        private HEAPIFY_540_SoftwareContext db = new HEAPIFY_540_SoftwareContext();

        // GET: MaritalStandings
        public ActionResult Index()
        {
            return View(db.MaritalStandings.ToList());
        }

        // GET: MaritalStandings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaritalStanding maritalStanding = db.MaritalStandings.Find(id);
            if (maritalStanding == null)
            {
                return HttpNotFound();
            }
            return View(maritalStanding);
        }

        // GET: MaritalStandings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MaritalStandings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaritalStatusID,MaritalStatusType")] MaritalStanding maritalStanding)
        {
            if (ModelState.IsValid)
            {
                db.MaritalStandings.Add(maritalStanding);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(maritalStanding);
        }

        // GET: MaritalStandings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaritalStanding maritalStanding = db.MaritalStandings.Find(id);
            if (maritalStanding == null)
            {
                return HttpNotFound();
            }
            return View(maritalStanding);
        }

        // POST: MaritalStandings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaritalStatusID,MaritalStatusType")] MaritalStanding maritalStanding)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maritalStanding).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(maritalStanding);
        }

        // GET: MaritalStandings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaritalStanding maritalStanding = db.MaritalStandings.Find(id);
            if (maritalStanding == null)
            {
                return HttpNotFound();
            }
            return View(maritalStanding);
        }

        // POST: MaritalStandings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MaritalStanding maritalStanding = db.MaritalStandings.Find(id);
            db.MaritalStandings.Remove(maritalStanding);
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
