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
    public class coffee_ingredientsController : ApiController
    {
        private productEntities db = new productEntities();

        // GET: api/coffee_ingredients
        public IQueryable<coffee_ingredients> Getcoffee_ingredients()
        {
            return db.coffee_ingredients;
        }

        // GET: api/coffee_ingredients/5
        [ResponseType(typeof(coffee_ingredients))]
        public IHttpActionResult Getcoffee_ingredients(int id)
        {
            coffee_ingredients coffee_ingredients = db.coffee_ingredients.Find(id);
            if (coffee_ingredients == null)
            {
                return NotFound();
            }

            return Ok(coffee_ingredients);
        }

        // PUT: api/coffee_ingredients/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putcoffee_ingredients(int id, coffee_ingredients coffee_ingredients)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != coffee_ingredients.id)
            {
                return BadRequest();
            }

            db.Entry(coffee_ingredients).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!coffee_ingredientsExists(id))
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

        // POST: api/coffee_ingredients
        [ResponseType(typeof(coffee_ingredients))]
        public IHttpActionResult Postcoffee_ingredients(coffee_ingredients coffee_ingredients)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.coffee_ingredients.Add(coffee_ingredients);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = coffee_ingredients.id }, coffee_ingredients);
        }

        // DELETE: api/coffee_ingredients/5
        [ResponseType(typeof(coffee_ingredients))]
        public IHttpActionResult Deletecoffee_ingredients(int id)
        {
            coffee_ingredients coffee_ingredients = db.coffee_ingredients.Find(id);
            if (coffee_ingredients == null)
            {
                return NotFound();
            }

            db.coffee_ingredients.Remove(coffee_ingredients);
            db.SaveChanges();

            return Ok(coffee_ingredients);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool coffee_ingredientsExists(int id)
        {
            return db.coffee_ingredients.Count(e => e.id == id) > 0;
        }
    }
}