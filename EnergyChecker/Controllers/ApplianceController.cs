using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EnergyChecker.DAL;
using EnergyChecker.Models;

namespace EnergyChecker.Controllers
{
    public class ApplianceController : Controller
    {
        private EnergyCheckerContext db = new EnergyCheckerContext();

        // GET: Appliance
        public ActionResult Index()
        {
            return View(db.Appliance.ToList());
        }

        // GET: Appliance/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appliance appliance = db.Appliance.Find(id);
            if (appliance == null)
            {
                return HttpNotFound();
            }
            return View(appliance);
        }

        // GET: Appliance/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Appliance/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ApplianceID,ApplianceTitle,Make,Watts,MinutesUsedPerDay")] Appliance appliance)
        {
            if (ModelState.IsValid)
            {
                db.Appliance.Add(appliance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(appliance);
        }

        // GET: Appliance/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appliance appliance = db.Appliance.Find(id);
            if (appliance == null)
            {
                return HttpNotFound();
            }
            return View(appliance);
        }

        // POST: Appliance/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ApplianceID,ApplianceTitle,Make,Watts,MinutesUsedPerDay")] Appliance appliance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appliance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(appliance);
        }

        // GET: Appliance/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appliance appliance = db.Appliance.Find(id);
            if (appliance == null)
            {
                return HttpNotFound();
            }
            return View(appliance);
        }

        // POST: Appliance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Appliance appliance = db.Appliance.Find(id);
            db.Appliance.Remove(appliance);
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
