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
    public class AnnouncementItemsMVCController : Controller
    {
        private RIMSYSMasterRSREMContext db = new RIMSYSMasterRSREMContext();

        // GET: AnnouncementItemsMVC
        public ActionResult Index()
        {
            return View(db.AnnouncementItems.ToList());
        }

        // GET: AnnouncementItemsMVC/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnnouncementItems announcementItems = db.AnnouncementItems.Find(id);
            if (announcementItems == null)
            {
                return HttpNotFound();
            }
            return View(announcementItems);
        }

        // GET: AnnouncementItemsMVC/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AnnouncementItemsMVC/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,EmailId,Title,Description")] AnnouncementItems announcementItems)
        {
            if (ModelState.IsValid)
            {
                db.AnnouncementItems.Add(announcementItems);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(announcementItems);
        }

        // GET: AnnouncementItemsMVC/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnnouncementItems announcementItems = db.AnnouncementItems.Find(id);
            if (announcementItems == null)
            {
                return HttpNotFound();
            }
            return View(announcementItems);
        }

        // POST: AnnouncementItemsMVC/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,EmailId,Title,Description")] AnnouncementItems announcementItems)
        {
            if (ModelState.IsValid)
            {
                db.Entry(announcementItems).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(announcementItems);
        }

        // GET: AnnouncementItemsMVC/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnnouncementItems announcementItems = db.AnnouncementItems.Find(id);
            if (announcementItems == null)
            {
                return HttpNotFound();
            }
            return View(announcementItems);
        }

        // POST: AnnouncementItemsMVC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AnnouncementItems announcementItems = db.AnnouncementItems.Find(id);
            db.AnnouncementItems.Remove(announcementItems);
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
