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
    //[Authorize(Roles = "IT Administrator")]
    public class ImmunizationsController : Controller
    {
        private HEAPIFY_540_SoftwareContext db = new HEAPIFY_540_SoftwareContext();

        // GET: Immunizations
        public ActionResult Index()
        {
            return View(db.Immunizations.ToList());
        }

        // GET: Immunizations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Immunization immunization = db.Immunizations.Find(id);
            if (immunization == null)
            {
                return HttpNotFound();
            }
            return View(immunization);
        }

        // GET: Immunizations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Immunizations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ImmunizationID,Vaccine")] Immunization immunization)
        {
            if (ModelState.IsValid)
            {
                db.Immunizations.Add(immunization);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(immunization);
        }

        // GET: Immunizations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Immunization immunization = db.Immunizations.Find(id);
            if (immunization == null)
            {
                return HttpNotFound();
            }
            return View(immunization);
        }

        // POST: Immunizations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ImmunizationID,Vaccine")] Immunization immunization)
        {
            if (ModelState.IsValid)
            {
                db.Entry(immunization).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(immunization);
        }

        // GET: Immunizations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Immunization immunization = db.Immunizations.Find(id);
            if (immunization == null)
            {
                return HttpNotFound();
            }
            return View(immunization);
        }

        // POST: Immunizations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Immunization immunization = db.Immunizations.Find(id);
            db.Immunizations.Remove(immunization);
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
