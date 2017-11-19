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
    [Authorize(Roles = "IT Administrator")]
    public class AccountsAdminsController : Controller
    {
        private HEAPIFY_540_SoftwareContext db = new HEAPIFY_540_SoftwareContext();

        // GET: AccountsAdmins
        public ActionResult Index()
        {
            var accountsAdmins = db.AccountsAdmins.Include(a => a.AccountType).Include(a => a.Employee).Include(a => a.Modify);
            return View(accountsAdmins.ToList());
        }

        // GET: AccountsAdmins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountsAdmin accountsAdmin = db.AccountsAdmins.Find(id);
            if (accountsAdmin == null)
            {
                return HttpNotFound();
            }
            return View(accountsAdmin);
        }

        // GET: AccountsAdmins/Create
        public ActionResult Create()
        {
            ViewBag.AccountTypeID = new SelectList(db.AccountTypes, "AccountTypeID", "AccountTypeName");
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FirstName");
            ViewBag.ModifyID = new SelectList(db.Modifies, "ModifyID", "ModifyType");
            return View();
        }

        // POST: AccountsAdmins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdminAccountID,EmployeeID,Date,AccountTypeID,ModifyID,History")] AccountsAdmin accountsAdmin)
        {
            if (ModelState.IsValid)
            {
                db.AccountsAdmins.Add(accountsAdmin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountTypeID = new SelectList(db.AccountTypes, "AccountTypeID", "AccountTypeName", accountsAdmin.AccountTypeID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FirstName", accountsAdmin.EmployeeID);
            ViewBag.ModifyID = new SelectList(db.Modifies, "ModifyID", "ModifyType", accountsAdmin.ModifyID);
            return View(accountsAdmin);
        }

        // GET: AccountsAdmins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountsAdmin accountsAdmin = db.AccountsAdmins.Find(id);
            if (accountsAdmin == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountTypeID = new SelectList(db.AccountTypes, "AccountTypeID", "AccountTypeName", accountsAdmin.AccountTypeID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FirstName", accountsAdmin.EmployeeID);
            ViewBag.ModifyID = new SelectList(db.Modifies, "ModifyID", "ModifyType", accountsAdmin.ModifyID);
            return View(accountsAdmin);
        }

        // POST: AccountsAdmins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AdminAccountID,EmployeeID,Date,AccountTypeID,ModifyID,History")] AccountsAdmin accountsAdmin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accountsAdmin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountTypeID = new SelectList(db.AccountTypes, "AccountTypeID", "AccountTypeName", accountsAdmin.AccountTypeID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FirstName", accountsAdmin.EmployeeID);
            ViewBag.ModifyID = new SelectList(db.Modifies, "ModifyID", "ModifyType", accountsAdmin.ModifyID);
            return View(accountsAdmin);
        }

        // GET: AccountsAdmins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountsAdmin accountsAdmin = db.AccountsAdmins.Find(id);
            if (accountsAdmin == null)
            {
                return HttpNotFound();
            }
            return View(accountsAdmin);
        }

        // POST: AccountsAdmins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AccountsAdmin accountsAdmin = db.AccountsAdmins.Find(id);
            db.AccountsAdmins.Remove(accountsAdmin);
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
