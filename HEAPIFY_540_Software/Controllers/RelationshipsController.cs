﻿using System;
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
    public class RelationshipsController : Controller
    {
        private HEAPIFY_540_SoftwareContext db = new HEAPIFY_540_SoftwareContext();

        // GET: Relationships
        public ActionResult Index()
        {
            return View(db.Relationships.ToList());
        }

        // GET: Relationships/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Relationship relationship = db.Relationships.Find(id);
            if (relationship == null)
            {
                return HttpNotFound();
            }
            return View(relationship);
        }

        // GET: Relationships/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Relationships/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RelationshipID,RelationshipType")] Relationship relationship)
        {
            if (ModelState.IsValid)
            {
                db.Relationships.Add(relationship);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(relationship);
        }

        // GET: Relationships/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Relationship relationship = db.Relationships.Find(id);
            if (relationship == null)
            {
                return HttpNotFound();
            }
            return View(relationship);
        }

        // POST: Relationships/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RelationshipID,RelationshipType")] Relationship relationship)
        {
            if (ModelState.IsValid)
            {
                db.Entry(relationship).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(relationship);
        }

        // GET: Relationships/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Relationship relationship = db.Relationships.Find(id);
            if (relationship == null)
            {
                return HttpNotFound();
            }
            return View(relationship);
        }

        // POST: Relationships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Relationship relationship = db.Relationships.Find(id);
            db.Relationships.Remove(relationship);
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
