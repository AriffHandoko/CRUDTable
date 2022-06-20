using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRUDTable.Models;

namespace CRUDTable.Controllers
{
    public class EmployeController : Controller
    {
        private CRUDTableEntities1 db = new CRUDTableEntities1();

        // GET: Employe
        public ActionResult Index()
        {
            return View(db.EmployeMasters.ToList());
        }

        // GET: Employe/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeMaster employeMaster = db.EmployeMasters.Find(id);
            if (employeMaster == null)
            {
                return HttpNotFound();
            }
            return View(employeMaster);
        }

        // GET: Employe/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,EmpCode,EmpName,Designation,Salary")] EmployeMaster employeMaster)
        {
            if (ModelState.IsValid)
            {
                db.EmployeMasters.Add(employeMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employeMaster);
        }

        // GET: Employe/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeMaster employeMaster = db.EmployeMasters.Find(id);
            if (employeMaster == null)
            {
                return HttpNotFound();
            }
            return View(employeMaster);
        }

        // POST: Employe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,EmpCode,EmpName,Designation,Salary")] EmployeMaster employeMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeMaster);
        }

        // GET: Employe/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeMaster employeMaster = db.EmployeMasters.Find(id);
            if (employeMaster == null)
            {
                return HttpNotFound();
            }
            return View(employeMaster);
        }

        // POST: Employe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeMaster employeMaster = db.EmployeMasters.Find(id);
            db.EmployeMasters.Remove(employeMaster);
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
