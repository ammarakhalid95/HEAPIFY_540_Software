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
    public class AllergyTypesController : Controller
    {
        private HEAPIFY_540_SoftwareContext db = new HEAPIFY_540_SoftwareContext();

        // GET: AllergyTypes
        public ActionResult Index()
        {
            return View(db.AllergyTypes.ToList());
        }

        // GET: AllergyTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllergyType allergyType = db.AllergyTypes.Find(id);
            if (allergyType == null)
            {
                return HttpNotFound();
            }
            return View(allergyType);
        }

        // GET: AllergyTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AllergyTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AllergyTypeID,AllergyTypeName")] AllergyType allergyType)
        {
            if (ModelState.IsValid)
            {
                db.AllergyTypes.Add(allergyType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(allergyType);
        }

        // GET: AllergyTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllergyType allergyType = db.AllergyTypes.Find(id);
            if (allergyType == null)
            {
                return HttpNotFound();
            }
            return View(allergyType);
        }

        // POST: AllergyTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AllergyTypeID,AllergyTypeName")] AllergyType allergyType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(allergyType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(allergyType);
        }

        // GET: AllergyTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllergyType allergyType = db.AllergyTypes.Find(id);
            if (allergyType == null)
            {
                return HttpNotFound();
            }
            return View(allergyType);
        }

        // POST: AllergyTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AllergyType allergyType = db.AllergyTypes.Find(id);
            db.AllergyTypes.Remove(allergyType);
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
