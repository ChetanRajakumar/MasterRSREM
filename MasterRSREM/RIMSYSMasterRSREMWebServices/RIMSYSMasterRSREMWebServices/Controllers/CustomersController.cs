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
    public class CustomersController : ApiController
    {
        private RIMSYSMasterRSREMContext db = new RIMSYSMasterRSREMContext();

        // GET: api/Customers
        public IQueryable<Customer> GetCustomers()
        {
            return db.Customers;
        }

        // GET: api/Customers/GetCustomer/?emailId=chetan.sudeep2004@gmail.com
        [ResponseType(typeof(Customer))]
        [System.Web.Mvc.ActionName("GetCustomer")]
        public Task<Customer> GetCustomer(string emailID)
        {
           return db.Customers.Where(c => c.EmailID == emailID).FirstOrDefaultAsync<Customer>();
        }

        // POST: api/Customers
        [ResponseType(typeof(Customer))]
        public IHttpActionResult PostCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (customer.ID == 0)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
            }
            else
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return Ok(customer);
            }
            return CreatedAtRoute("DefaultApi", new { id = customer.ID }, customer);
        }

        // POST: api/Customers
        //[ResponseType(typeof(Customer))]
        //public IHttpActionResult PostCustomer(byte[] profilePic, string emailID)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    Customer customer = db.Customers.Where(c => c.EmailID == emailID).FirstOrDefaultAsync<Customer>().Result;
        //    customer.ProfilePic = profilePic;
        //    db.Customers.Add(customer);
        //    db.SaveChanges();
        //    return Ok(customer);
        //}


        // DELETE: api/Customers/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult DeleteCustomer(string emailID)
        {
            Customer customer = db.Customers.Where(c => c.EmailID == emailID).FirstOrDefaultAsync<Customer>().Result;
            if (customer == null)
            {
                return NotFound();
            }

            db.Customers.Remove(customer);
            db.SaveChanges();

            return Ok(customer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerExists(string emailID)
        {
            Customer customer = db.Customers.Where(c => c.EmailID == emailID).FirstOrDefaultAsync<Customer>().Result;
            if (customer == null)
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