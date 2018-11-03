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
    public class ClubHouseTablesController : ApiController
    {
        private RIMSYSMasterRSREMContext db = new RIMSYSMasterRSREMContext();

        // GET: api/ClubHouseTables
        public IQueryable<ClubHouseTable> GetClubHouseTables()
        {
            return db.ClubHouseTables;
        }

        // GET: api/ClubHouseTables/5
        [ResponseType(typeof(ClubHouseTable))]
        public IHttpActionResult GetClubHouseTable(int id)
        {
            ClubHouseTable clubHouseTable = db.ClubHouseTables.Find(id);
            if (clubHouseTable == null)
            {
                return NotFound();
            }

            return Ok(clubHouseTable);
        }

        // PUT: api/ClubHouseTables/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClubHouseTable(int id, ClubHouseTable clubHouseTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != clubHouseTable.Id)
            {
                return BadRequest();
            }

            db.Entry(clubHouseTable).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClubHouseTableExists(id))
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

        // POST: api/ClubHouseTables
        [ResponseType(typeof(ClubHouseTable))]
        public IHttpActionResult PostClubHouseTable(ClubHouseTable clubHouseTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ClubHouseTables.Add(clubHouseTable);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = clubHouseTable.Id }, clubHouseTable);
        }

        // DELETE: api/ClubHouseTables/5
        [ResponseType(typeof(ClubHouseTable))]
        public IHttpActionResult DeleteClubHouseTable(int id)
        {
            ClubHouseTable clubHouseTable = db.ClubHouseTables.Find(id);
            if (clubHouseTable == null)
            {
                return NotFound();
            }

            db.ClubHouseTables.Remove(clubHouseTable);
            db.SaveChanges();

            return Ok(clubHouseTable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClubHouseTableExists(int id)
        {
            return db.ClubHouseTables.Count(e => e.Id == id) > 0;
        }
    }
}