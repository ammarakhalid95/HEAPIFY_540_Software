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
    public class SmokingStandingsController : Controller
    {
        private HEAPIFY_540_SoftwareContext db = new HEAPIFY_540_SoftwareContext();

        // GET: SmokingStandings
        public ActionResult Index()
        {
            return View(db.SmokingStandings.ToList());
        }

        // GET: SmokingStandings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SmokingStanding smokingStanding = db.SmokingStandings.Find(id);
            if (smokingStanding == null)
            {
                return HttpNotFound();
            }
            return View(smokingStanding);
        }

        // GET: SmokingStandings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SmokingStandings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SmokingStatusID,SmokingStatusType")] SmokingStanding smokingStanding)
        {
            if (ModelState.IsValid)
            {
                db.SmokingStandings.Add(smokingStanding);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(smokingStanding);
        }

        // GET: SmokingStandings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SmokingStanding smokingStanding = db.SmokingStandings.Find(id);
            if (smokingStanding == null)
            {
                return HttpNotFound();
            }
            return View(smokingStanding);
        }

        // POST: SmokingStandings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SmokingStatusID,SmokingStatusType")] SmokingStanding smokingStanding)
        {
            if (ModelState.IsValid)
            {
                db.Entry(smokingStanding).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(smokingStanding);
        }

        // GET: SmokingStandings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SmokingStanding smokingStanding = db.SmokingStandings.Find(id);
            if (smokingStanding == null)
            {
                return HttpNotFound();
            }
            return View(smokingStanding);
        }

        // POST: SmokingStandings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SmokingStanding smokingStanding = db.SmokingStandings.Find(id);
            db.SmokingStandings.Remove(smokingStanding);
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
