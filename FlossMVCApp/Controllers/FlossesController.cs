using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FlossMVCApp;
using FlossMVCApp.Models;

namespace FlossMVCApp.Controllers
{
    public class FlossesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Flosses
        public ActionResult Index()
        {
            var flosses = db.Flosses.Include(f => f.Company);
            return View(flosses.ToList());
        }

        // GET: Flosses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Floss floss = db.Flosses.Find(id);
            if (floss == null)
            {
                return HttpNotFound();
            }
            return View(floss);
        }

        // GET: Flosses/Create
        public ActionResult Create()
        {
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "Name");
            return View();
        }

        // POST: Flosses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FlossId,Number,Color,CompanyId,Skein,Comment")] Floss floss)
        {
            if (ModelState.IsValid)
            {
                db.Flosses.Add(floss);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "Name", floss.CompanyId);
            return View(floss);
        }

        // GET: Flosses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Floss floss = db.Flosses.Find(id);
            if (floss == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "Name", floss.CompanyId);
            return View(floss);
        }

        // POST: Flosses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FlossId,Number,Color,CompanyId,Skein,Comment")] Floss floss)
        {
            if (ModelState.IsValid)
            {
                db.Entry(floss).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "Name", floss.CompanyId);
            return View(floss);
        }

        // GET: Flosses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Floss floss = db.Flosses.Find(id);
            if (floss == null)
            {
                return HttpNotFound();
            }
            return View(floss);
        }

        // POST: Flosses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Floss floss = db.Flosses.Find(id);
            db.Flosses.Remove(floss);
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
