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
    public class MaintainenceRequestEntitiesMVCController : Controller
    {
        private RIMSYSMasterRSREMContext db = new RIMSYSMasterRSREMContext();

        // GET: MaintainenceRequestEntitiesMVC
        public ActionResult Index()
        {
            return View(db.MaintainenceRequestEntities.ToList());
        }

        // GET: MaintainenceRequestEntitiesMVC/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaintainenceRequestEntities maintainenceRequestEntities = db.MaintainenceRequestEntities.Find(id);
            if (maintainenceRequestEntities == null)
            {
                return HttpNotFound();
            }
            return View(maintainenceRequestEntities);
        }

        // GET: MaintainenceRequestEntitiesMVC/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MaintainenceRequestEntitiesMVC/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EmailId,Category,RequestDescription,AccessInstructions,VoiceRequest,ImagesList,RequestDate,Status")] MaintainenceRequestEntities maintainenceRequestEntities)
        {
            if (ModelState.IsValid)
            {
                db.MaintainenceRequestEntities.Add(maintainenceRequestEntities);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(maintainenceRequestEntities);
        }

        // GET: MaintainenceRequestEntitiesMVC/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaintainenceRequestEntities maintainenceRequestEntities = db.MaintainenceRequestEntities.Find(id);
            if (maintainenceRequestEntities == null)
            {
                return HttpNotFound();
            }
            return View(maintainenceRequestEntities);
        }

        // POST: MaintainenceRequestEntitiesMVC/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EmailId,Category,RequestDescription,AccessInstructions,VoiceRequest,ImagesList,RequestDate,Status")] MaintainenceRequestEntities maintainenceRequestEntities)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maintainenceRequestEntities).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(maintainenceRequestEntities);
        }

        // GET: MaintainenceRequestEntitiesMVC/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaintainenceRequestEntities maintainenceRequestEntities = db.MaintainenceRequestEntities.Find(id);
            if (maintainenceRequestEntities == null)
            {
                return HttpNotFound();
            }
            return View(maintainenceRequestEntities);
        }

        // POST: MaintainenceRequestEntitiesMVC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MaintainenceRequestEntities maintainenceRequestEntities = db.MaintainenceRequestEntities.Find(id);
            db.MaintainenceRequestEntities.Remove(maintainenceRequestEntities);
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
