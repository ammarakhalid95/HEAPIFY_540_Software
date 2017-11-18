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
    public class ActiveSStandingsController : Controller
    {
        private HEAPIFY_540_SoftwareContext db = new HEAPIFY_540_SoftwareContext();

        // GET: ActiveSStandings
        public ActionResult Index()
        {
            return View(db.ActiveSStandings.ToList());
        }

        // GET: ActiveSStandings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActiveSStanding activeSStanding = db.ActiveSStandings.Find(id);
            if (activeSStanding == null)
            {
                return HttpNotFound();
            }
            return View(activeSStanding);
        }

        // GET: ActiveSStandings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ActiveSStandings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ActiveSStatusID,ActiveSSType")] ActiveSStanding activeSStanding)
        {
            if (ModelState.IsValid)
            {
                db.ActiveSStandings.Add(activeSStanding);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(activeSStanding);
        }

        // GET: ActiveSStandings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActiveSStanding activeSStanding = db.ActiveSStandings.Find(id);
            if (activeSStanding == null)
            {
                return HttpNotFound();
            }
            return View(activeSStanding);
        }

        // POST: ActiveSStandings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ActiveSStatusID,ActiveSSType")] ActiveSStanding activeSStanding)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activeSStanding).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(activeSStanding);
        }

        // GET: ActiveSStandings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActiveSStanding activeSStanding = db.ActiveSStandings.Find(id);
            if (activeSStanding == null)
            {
                return HttpNotFound();
            }
            return View(activeSStanding);
        }

        // POST: ActiveSStandings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ActiveSStanding activeSStanding = db.ActiveSStandings.Find(id);
            db.ActiveSStandings.Remove(activeSStanding);
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
