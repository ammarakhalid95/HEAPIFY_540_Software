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
    public class AlchoholStandingsController : Controller
    {
        private HEAPIFY_540_SoftwareContext db = new HEAPIFY_540_SoftwareContext();

        // GET: AlchoholStandings
        public ActionResult Index()
        {
            return View(db.AlchoholStandings.ToList());
        }

        // GET: AlchoholStandings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlchoholStanding alchoholStanding = db.AlchoholStandings.Find(id);
            if (alchoholStanding == null)
            {
                return HttpNotFound();
            }
            return View(alchoholStanding);
        }

        // GET: AlchoholStandings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AlchoholStandings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlcoholStatusID,AlcoholStatusType")] AlchoholStanding alchoholStanding)
        {
            if (ModelState.IsValid)
            {
                db.AlchoholStandings.Add(alchoholStanding);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(alchoholStanding);
        }

        // GET: AlchoholStandings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlchoholStanding alchoholStanding = db.AlchoholStandings.Find(id);
            if (alchoholStanding == null)
            {
                return HttpNotFound();
            }
            return View(alchoholStanding);
        }

        // POST: AlchoholStandings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlcoholStatusID,AlcoholStatusType")] AlchoholStanding alchoholStanding)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alchoholStanding).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(alchoholStanding);
        }

        // GET: AlchoholStandings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlchoholStanding alchoholStanding = db.AlchoholStandings.Find(id);
            if (alchoholStanding == null)
            {
                return HttpNotFound();
            }
            return View(alchoholStanding);
        }

        // POST: AlchoholStandings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AlchoholStanding alchoholStanding = db.AlchoholStandings.Find(id);
            db.AlchoholStandings.Remove(alchoholStanding);
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
