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
using product_api.Models;

namespace product_api.Controllers
{
    public class coffeesController : ApiController
    {
        private productEntities db = new productEntities();

        // GET: api/coffees
        public IQueryable<coffee> Getcoffees()
        {
            return db.coffees;
        }

        // GET: api/coffees/5
        [ResponseType(typeof(coffee))]
        public IHttpActionResult Getcoffee(int id)
        {
            coffee coffee = db.coffees.Find(id);
            if (coffee == null)
            {
                return NotFound();
            }

            return Ok(coffee);
        }

        // PUT: api/coffees/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putcoffee(int id, coffee coffee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != coffee.id)
            {
                return BadRequest();
            }

            db.Entry(coffee).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!coffeeExists(id))
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

        // POST: api/coffees
        [ResponseType(typeof(coffee))]
        public IHttpActionResult Postcoffee(coffee coffee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.coffees.Add(coffee);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = coffee.id }, coffee);
        }

        // DELETE: api/coffees/5
        [ResponseType(typeof(coffee))]
        public IHttpActionResult Deletecoffee(int id)
        {
            coffee coffee = db.coffees.Find(id);
            if (coffee == null)
            {
                return NotFound();
            }

            db.coffees.Remove(coffee);
            db.SaveChanges();

            return Ok(coffee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool coffeeExists(int id)
        {
            return db.coffees.Count(e => e.id == id) > 0;
        }
    }
}