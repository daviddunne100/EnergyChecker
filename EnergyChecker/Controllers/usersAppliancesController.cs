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
    public class usersAppliancesController : Controller
    {
        private EnergyCheckerContext db = new EnergyCheckerContext();

        // GET: usersAppliances
        public ActionResult Index()
        {
            var usersAppliances = db.usersAppliances.Include(u => u.Appliance).Include(u => u.User);
            return View(usersAppliances.ToList());
        }

        // GET: usersAppliances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usersAppliances usersAppliances = db.usersAppliances.Find(id);
            if (usersAppliances == null)
            {
                return HttpNotFound();
            }
            return View(usersAppliances);
        }

        // GET: usersAppliances/Create
        public ActionResult Create()
        {
            ViewBag.ApplianceID = new SelectList(db.Appliance, "ApplianceID", "ApplianceTitle");
            ViewBag.UserID = new SelectList(db.User, "ID", "LastName");
            return View();
        }

        // POST: usersAppliances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "usersAppliancesID,ApplianceID,UserID,Tariff")] usersAppliances usersAppliances)
        {
            if (ModelState.IsValid)
            {
                db.usersAppliances.Add(usersAppliances);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ApplianceID = new SelectList(db.Appliance, "ApplianceID", "ApplianceTitle", usersAppliances.ApplianceID);
            ViewBag.UserID = new SelectList(db.User, "ID", "LastName", usersAppliances.UserID);
            return View(usersAppliances);
        }

        // GET: usersAppliances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usersAppliances usersAppliances = db.usersAppliances.Find(id);
            if (usersAppliances == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplianceID = new SelectList(db.Appliance, "ApplianceID", "ApplianceTitle", usersAppliances.ApplianceID);
            ViewBag.UserID = new SelectList(db.User, "ID", "LastName", usersAppliances.UserID);
            return View(usersAppliances);
        }

        // POST: usersAppliances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "usersAppliancesID,ApplianceID,UserID,Tariff")] usersAppliances usersAppliances)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usersAppliances).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplianceID = new SelectList(db.Appliance, "ApplianceID", "ApplianceTitle", usersAppliances.ApplianceID);
            ViewBag.UserID = new SelectList(db.User, "ID", "LastName", usersAppliances.UserID);
            return View(usersAppliances);
        }

        // GET: usersAppliances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usersAppliances usersAppliances = db.usersAppliances.Find(id);
            if (usersAppliances == null)
            {
                return HttpNotFound();
            }
            return View(usersAppliances);
        }

        // POST: usersAppliances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            usersAppliances usersAppliances = db.usersAppliances.Find(id);
            db.usersAppliances.Remove(usersAppliances);
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
