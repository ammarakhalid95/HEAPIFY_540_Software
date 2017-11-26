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
    public class PhoneTypesController : Controller
    {
        private HEAPIFY_540_SoftwareContext db = new HEAPIFY_540_SoftwareContext();

        // GET: PhoneTypes
        public ActionResult Index()
        {
            return View(db.PhoneTypes.ToList());
        }

        // GET: PhoneTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhoneType phoneType = db.PhoneTypes.Find(id);
            if (phoneType == null)
            {
                return HttpNotFound();
            }
            return View(phoneType);
        }

        // GET: PhoneTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PhoneTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PhoneTypeID,PhoneTypeName")] PhoneType phoneType)
        {
            if (ModelState.IsValid)
            {
                db.PhoneTypes.Add(phoneType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(phoneType);
        }

        // GET: PhoneTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhoneType phoneType = db.PhoneTypes.Find(id);
            if (phoneType == null)
            {
                return HttpNotFound();
            }
            return View(phoneType);
        }

        // POST: PhoneTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PhoneTypeID,PhoneTypeName")] PhoneType phoneType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phoneType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phoneType);
        }

        // GET: PhoneTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhoneType phoneType = db.PhoneTypes.Find(id);
            if (phoneType == null)
            {
                return HttpNotFound();
            }
            return View(phoneType);
        }

        // POST: PhoneTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhoneType phoneType = db.PhoneTypes.Find(id);
            db.PhoneTypes.Remove(phoneType);
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
