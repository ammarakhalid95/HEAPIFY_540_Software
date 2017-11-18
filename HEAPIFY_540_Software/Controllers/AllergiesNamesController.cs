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
    public class AllergiesNamesController : Controller
    {
        private HEAPIFY_540_SoftwareContext db = new HEAPIFY_540_SoftwareContext();

        // GET: AllergiesNames
        public ActionResult Index()
        {
            var allergiesNames = db.AllergiesNames.Include(a => a.AllergyType);
            return View(allergiesNames.ToList());
        }

        // GET: AllergiesNames/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllergiesName allergiesName = db.AllergiesNames.Find(id);
            if (allergiesName == null)
            {
                return HttpNotFound();
            }
            return View(allergiesName);
        }

        // GET: AllergiesNames/Create
        public ActionResult Create()
        {
            ViewBag.AllergyTypeID = new SelectList(db.AllergyTypes, "AllergyTypeID", "AllergyTypeName");
            return View();
        }

        // POST: AllergiesNames/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AllergiesID,AllergyTypeID,AllergyName")] AllergiesName allergiesName)
        {
            if (ModelState.IsValid)
            {
                db.AllergiesNames.Add(allergiesName);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AllergyTypeID = new SelectList(db.AllergyTypes, "AllergyTypeID", "AllergyTypeName", allergiesName.AllergyTypeID);
            return View(allergiesName);
        }

        // GET: AllergiesNames/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllergiesName allergiesName = db.AllergiesNames.Find(id);
            if (allergiesName == null)
            {
                return HttpNotFound();
            }
            ViewBag.AllergyTypeID = new SelectList(db.AllergyTypes, "AllergyTypeID", "AllergyTypeName", allergiesName.AllergyTypeID);
            return View(allergiesName);
        }

        // POST: AllergiesNames/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AllergiesID,AllergyTypeID,AllergyName")] AllergiesName allergiesName)
        {
            if (ModelState.IsValid)
            {
                db.Entry(allergiesName).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AllergyTypeID = new SelectList(db.AllergyTypes, "AllergyTypeID", "AllergyTypeName", allergiesName.AllergyTypeID);
            return View(allergiesName);
        }

        // GET: AllergiesNames/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllergiesName allergiesName = db.AllergiesNames.Find(id);
            if (allergiesName == null)
            {
                return HttpNotFound();
            }
            return View(allergiesName);
        }

        // POST: AllergiesNames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AllergiesName allergiesName = db.AllergiesNames.Find(id);
            db.AllergiesNames.Remove(allergiesName);
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
