using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RIMSYSMasterRSREMWebServices.Models;

namespace RIMSYSMasterRSREMWebServices.Controllers
{
    public class ClubHouseTablesMVCController : Controller
    {
        private RIMSYSMasterRSREMContext db = new RIMSYSMasterRSREMContext();

        // GET: ClubHouseTablesMVC
        public ActionResult Index()
        {
            return View(db.ClubHouseTables.ToList());
        }

        // GET: ClubHouseTablesMVC/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClubHouseTable clubHouseTable = db.ClubHouseTables.Find(id);
            if (clubHouseTable == null)
            {
                return HttpNotFound();
            }
            return View(clubHouseTable);
        }

        // GET: ClubHouseTablesMVC/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClubHouseTablesMVC/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EmailId,Purpose,Description,RequestDate,PaymentStatus")] ClubHouseTable clubHouseTable)
        {
            if (ModelState.IsValid)
            {
                db.ClubHouseTables.Add(clubHouseTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clubHouseTable);
        }

        // GET: ClubHouseTablesMVC/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClubHouseTable clubHouseTable = db.ClubHouseTables.Find(id);
            if (clubHouseTable == null)
            {
                return HttpNotFound();
            }
            return View(clubHouseTable);
        }

        // POST: ClubHouseTablesMVC/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EmailId,Purpose,Description,RequestDate,PaymentStatus")] ClubHouseTable clubHouseTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clubHouseTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clubHouseTable);
        }

        // GET: ClubHouseTablesMVC/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClubHouseTable clubHouseTable = db.ClubHouseTables.Find(id);
            if (clubHouseTable == null)
            {
                return HttpNotFound();
            }
            return View(clubHouseTable);
        }

        // POST: ClubHouseTablesMVC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClubHouseTable clubHouseTable = db.ClubHouseTables.Find(id);
            db.ClubHouseTables.Remove(clubHouseTable);
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
