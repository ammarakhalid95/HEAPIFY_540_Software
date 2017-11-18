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
    public class ModifiesController : Controller
    {
        private HEAPIFY_540_SoftwareContext db = new HEAPIFY_540_SoftwareContext();

        // GET: Modifies
        public ActionResult Index()
        {
            return View(db.Modifies.ToList());
        }

        // GET: Modifies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modify modify = db.Modifies.Find(id);
            if (modify == null)
            {
                return HttpNotFound();
            }
            return View(modify);
        }

        // GET: Modifies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Modifies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ModifyID,ModifyType")] Modify modify)
        {
            if (ModelState.IsValid)
            {
                db.Modifies.Add(modify);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(modify);
        }

        // GET: Modifies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modify modify = db.Modifies.Find(id);
            if (modify == null)
            {
                return HttpNotFound();
            }
            return View(modify);
        }

        // POST: Modifies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ModifyID,ModifyType")] Modify modify)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modify).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(modify);
        }

        // GET: Modifies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modify modify = db.Modifies.Find(id);
            if (modify == null)
            {
                return HttpNotFound();
            }
            return View(modify);
        }

        // POST: Modifies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Modify modify = db.Modifies.Find(id);
            db.Modifies.Remove(modify);
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
