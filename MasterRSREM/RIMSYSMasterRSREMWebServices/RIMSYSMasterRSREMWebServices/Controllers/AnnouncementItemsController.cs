using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using RIMSYSMasterRSREMWebServices.Models;

namespace RIMSYSMasterRSREMWebServices.Controllers
{
    public class AnnouncementItemsController : ApiController
    {
        private RIMSYSMasterRSREMContext db = new RIMSYSMasterRSREMContext();

        // GET: api/AnnouncementItems
        public IQueryable<AnnouncementItems> GetAnnouncementItems()
        {
            return db.AnnouncementItems;
        }

        // GET: api/AnnouncementItems/5
        // GET: api/Customers/GetCustomer/?emailId=chetan.sudeep2004@gmail.com
        [ResponseType(typeof(AnnouncementItems))]
        [System.Web.Mvc.ActionName("GetAnnouncementItems")]
        public Task<AnnouncementItems> GetAnnouncementItems(string title)
        {
            return db.AnnouncementItems.Where(c => c.Title == title).FirstOrDefaultAsync<AnnouncementItems>();
        }

        // POST: api/AnnouncementItems
        [ResponseType(typeof(AnnouncementItems))]
        public IHttpActionResult PostAnnouncementItems(AnnouncementItems announcementItems)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AnnouncementItems.Add(announcementItems);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = announcementItems.ID }, announcementItems);
        }

        // DELETE: api/AnnouncementItems/5
        [ResponseType(typeof(AnnouncementItems))]
        public IHttpActionResult DeleteAnnouncementItems(string title)
        {
            AnnouncementItems announcementItems = db.AnnouncementItems.Where(c => c.Title == title).FirstOrDefaultAsync<AnnouncementItems>().Result;
            if (announcementItems == null)
            {
                return NotFound();
            }

            db.AnnouncementItems.Remove(announcementItems);
            db.SaveChanges();

            return Ok(announcementItems);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AnnouncementItemsExists(string title)
        {
            AnnouncementItems announcementItems = db.AnnouncementItems.Where(c => c.Title == title).FirstOrDefaultAsync<AnnouncementItems>().Result;
            if (announcementItems == null)
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