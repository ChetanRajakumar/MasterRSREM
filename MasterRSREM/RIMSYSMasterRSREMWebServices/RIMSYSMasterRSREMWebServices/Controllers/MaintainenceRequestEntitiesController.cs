using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using RIMSYSMasterRSREMWebServices.Models;

namespace RIMSYSMasterRSREMWebServices.Controllers
{
    public class MaintainenceRequestEntitiesController : ApiController
    {
        private RIMSYSMasterRSREMContext db = new RIMSYSMasterRSREMContext();

        // GET: api/MaintainenceRequestEntities
        public IQueryable<MaintainenceRequestEntities> GetMaintainenceRequestEntities()
        {
            return db.MaintainenceRequestEntities;
        }

        // GET: api/MaintainenceRequestEntities/GetMaintainenceRequestEntities/?emailId=chetan.sudeep2004@gmail.com
        [ResponseType(typeof(MaintainenceRequestEntities))]
        [System.Web.Mvc.ActionName("GetMaintainenceRequestEntities")]
        public IQueryable<MaintainenceRequestEntities> GetMaintainenceRequestEntities(string emailID)
        {
            return db.MaintainenceRequestEntities.Where(c => c.EmailId== emailID);
        }

        // POST: api/MaintainenceRequestEntities
        [ResponseType(typeof(MaintainenceRequestEntities))]
        public IHttpActionResult PostMaintainenceRequestEntities(MaintainenceRequestEntities maintainenceRequestEntities)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MaintainenceRequestEntities.Add(maintainenceRequestEntities);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = maintainenceRequestEntities.Id }, maintainenceRequestEntities);
        }

        // DELETE: api/MaintainenceRequestEntities/?emailId=chetan.sudeep2004@gmail.com
        [ResponseType(typeof(MaintainenceRequestEntities))]
        public IHttpActionResult DeleteMaintainenceRequestEntities(string emailID)
        {
            MaintainenceRequestEntities maintainenceRequestEntities = db.MaintainenceRequestEntities.Where(c => c.EmailId == emailID).FirstOrDefaultAsync<MaintainenceRequestEntities>().Result;
            if (maintainenceRequestEntities == null)
            {
                return NotFound();
            }

            db.MaintainenceRequestEntities.Remove(maintainenceRequestEntities);
            db.SaveChanges();

            return Ok(maintainenceRequestEntities);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MaintainenceRequestEntitiesExists(string emailID)
        {
            MaintainenceRequestEntities maintainenceRequestEntities = db.MaintainenceRequestEntities.Where(c => c.EmailId == emailID).FirstOrDefaultAsync<MaintainenceRequestEntities>().Result;
            if (maintainenceRequestEntities == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}