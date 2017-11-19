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
    public class AdjustmentCodesController : Controller
    {
        private HEAPIFY_540_SoftwareContext db = new HEAPIFY_540_SoftwareContext();

        // GET: AdjustmentCodes
        public ActionResult Index()
        {
            return View(db.AdjustmentCodes.ToList());
        }

        // GET: AdjustmentCodes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdjustmentCode adjustmentCode = db.AdjustmentCodes.Find(id);
            if (adjustmentCode == null)
            {
                return HttpNotFound();
            }
            return View(adjustmentCode);
        }

        // GET: AdjustmentCodes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdjustmentCodes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdjustmentCodeID,AdjustmentDescription")] AdjustmentCode adjustmentCode)
        {
            if (ModelState.IsValid)
            {
                db.AdjustmentCodes.Add(adjustmentCode);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adjustmentCode);
        }

        // GET: AdjustmentCodes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdjustmentCode adjustmentCode = db.AdjustmentCodes.Find(id);
            if (adjustmentCode == null)
            {
                return HttpNotFound();
            }
            return View(adjustmentCode);
        }

        // POST: AdjustmentCodes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AdjustmentCodeID,AdjustmentDescription")] AdjustmentCode adjustmentCode)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adjustmentCode).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adjustmentCode);
        }

        // GET: AdjustmentCodes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdjustmentCode adjustmentCode = db.AdjustmentCodes.Find(id);
            if (adjustmentCode == null)
            {
                return HttpNotFound();
            }
            return View(adjustmentCode);
        }

        // POST: AdjustmentCodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdjustmentCode adjustmentCode = db.AdjustmentCodes.Find(id);
            db.AdjustmentCodes.Remove(adjustmentCode);
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
