﻿using System;
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
    public class EventsController : ApiController
    {
        private RIMSYSMasterRSREMContext db = new RIMSYSMasterRSREMContext();

        // GET: api/Events
        public IQueryable<Events> GetEvents()
        {
            return db.Events;
        }

        // GET: api/Events/5
        [ResponseType(typeof(Events))]
        public IHttpActionResult GetEvents(int id)
        {
            Events events = db.Events.Find(id);
            if (events == null)
            {
                return NotFound();
            }

            return Ok(events);
        }

        // GET: api/Events/5
        // GET: api/Events/GetEventsByTitle/?emailId=chetan.sudeep2004@gmail.com
        [ResponseType(typeof(Events))]
        [System.Web.Mvc.ActionName("GetEventsByTitle")]
        public Task<Events> GetEventsByTitle(string title)
        {
            return db.Events.Where(c => c.Title == title).FirstOrDefaultAsync<Events>();
        }

        // PUT: api/Events/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEvents(int id, Events events)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != events.Id)
            {
                return BadRequest();
            }

            db.Entry(events).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Events
        [ResponseType(typeof(Events))]
        public IHttpActionResult PostEvents(Events events)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Events.Add(events);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = events.Id }, events);
        }

        // DELETE: api/Events/5
        [ResponseType(typeof(Events))]
        public IHttpActionResult DeleteEvents(int id)
        {
            Events events = db.Events.Find(id);
            if (events == null)
            {
                return NotFound();
            }

            db.Events.Remove(events);
            db.SaveChanges();

            return Ok(events);
        }

        // DELETE: api/Events/title
        [ResponseType(typeof(Events))]
        public IHttpActionResult DeleteEvents(string title)
        {
            Events events = db.Events.Where(c => c.Title == title).FirstOrDefaultAsync<Events>().Result;
            if (events == null)
            {
                return NotFound();
            }

            db.Events.Remove(events);
            db.SaveChanges();

            return Ok(events);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EventsExists(int id)
        {
            return db.Events.Count(e => e.Id == id) > 0;
        }
    }
}