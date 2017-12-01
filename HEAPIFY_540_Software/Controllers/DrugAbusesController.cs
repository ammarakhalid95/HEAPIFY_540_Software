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
    public class DrugAbusesController : Controller
    {
        private HEAPIFY_540_SoftwareContext db = new HEAPIFY_540_SoftwareContext();

        // GET: DrugAbuses
        public ActionResult Index()
        {
            return View(db.DrugAbuses.ToList());
        }

        // GET: DrugAbuses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrugAbuse drugAbuse = db.DrugAbuses.Find(id);
            if (drugAbuse == null)
            {
                return HttpNotFound();
            }
            return View(drugAbuse);
        }

        // GET: DrugAbuses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DrugAbuses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DrugAbuseID,DrugAbuseType")] DrugAbuse drugAbuse)
        {
            if (ModelState.IsValid)
            {
                db.DrugAbuses.Add(drugAbuse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(drugAbuse);
        }

        // GET: DrugAbuses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrugAbuse drugAbuse = db.DrugAbuses.Find(id);
            if (drugAbuse == null)
            {
                return HttpNotFound();
            }
            return View(drugAbuse);
        }

        // POST: DrugAbuses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DrugAbuseID,DrugAbuseType")] DrugAbuse drugAbuse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(drugAbuse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(drugAbuse);
        }

        // GET: DrugAbuses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrugAbuse drugAbuse = db.DrugAbuses.Find(id);
            if (drugAbuse == null)
            {
                return HttpNotFound();
            }
            return View(drugAbuse);
        }

        // POST: DrugAbuses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DrugAbuse drugAbuse = db.DrugAbuses.Find(id);
            db.DrugAbuses.Remove(drugAbuse);
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
