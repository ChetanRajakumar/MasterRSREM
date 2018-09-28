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
    public class CategoriesController : ApiController
    {
        private RIMSYSMasterRSREMContext db = new RIMSYSMasterRSREMContext();

        // GET: api/Categories
        public IQueryable<Categories> GetCategories()
        {
            return db.Categories;
        }

        // GET: api/Categories/5
        [ResponseType(typeof(Categories))]
        [System.Web.Mvc.ActionName("GetCategories")]
        public Task<Categories> GetCategories(string category)
        {
            return db.Categories.Where(c => c.Category == category).FirstOrDefaultAsync<Categories>();
        }

       
        // POST: api/Categories
        [ResponseType(typeof(Categories))]
        public IHttpActionResult PostCategories(Categories categories)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Categories.Add(categories);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = categories.ID }, categories);
        }

        // DELETE: api/Categories/5
        [ResponseType(typeof(Categories))]
        public IHttpActionResult DeleteCategories(string category)
        {
            Categories categories = db.Categories.Where(c => c.Category == category).FirstOrDefaultAsync<Categories>().Result;
            if (categories == null)
            {
                return NotFound();
            }

            db.Categories.Remove(categories);
            db.SaveChanges();

            return Ok(categories);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoriesExists(string category)
        {
            Categories categories = db.Categories.Where(c => c.Category == category).FirstOrDefaultAsync<Categories>().Result;
            if (categories == null)
            {
                return false;
            }
            else
            { return true; }
        }
    }
}