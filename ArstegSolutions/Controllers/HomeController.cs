﻿using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ArstegSolutions.Models;

namespace ArstegSolutions.Controllers
{
    public class HomeController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: Home
        public ActionResult Index()
        {
            return View(db.TaxSlabs.ToList());
        }

        // GET: Home/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaxSlab taxSlab = db.TaxSlabs.Find(id);
            if (taxSlab == null)
            {
                return HttpNotFound();
            }
            return View(taxSlab);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SlabId,StartAmount,EndAmount,Percentage")] TaxSlab taxSlab)
        {
            if (ModelState.IsValid)
            {
                db.TaxSlabs.Add(taxSlab);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(taxSlab);
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaxSlab taxSlab = db.TaxSlabs.Find(id);
            if (taxSlab == null)
            {
                return HttpNotFound();
            }
            return View(taxSlab);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SlabId,StartAmount,EndAmount,Percentage")] TaxSlab taxSlab)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taxSlab).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(taxSlab);
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaxSlab taxSlab = db.TaxSlabs.Find(id);
            if (taxSlab == null)
            {
                return HttpNotFound();
            }
            return View(taxSlab);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TaxSlab taxSlab = db.TaxSlabs.Find(id);
            db.TaxSlabs.Remove(taxSlab);
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
