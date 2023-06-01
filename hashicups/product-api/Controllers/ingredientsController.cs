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
    public class ingredientsController : ApiController
    {
        private productEntities db = new productEntities();

        // GET: api/ingredients
        public IQueryable<ingredient> Getingredients()
        {
            return db.ingredients;
        }

        // GET: api/ingredients/5
        [ResponseType(typeof(ingredient))]
        public IHttpActionResult Getingredient(int id)
        {
            ingredient ingredient = db.ingredients.Find(id);
            if (ingredient == null)
            {
                return NotFound();
            }

            return Ok(ingredient);
        }

        // PUT: api/ingredients/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putingredient(int id, ingredient ingredient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ingredient.id)
            {
                return BadRequest();
            }

            db.Entry(ingredient).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ingredientExists(id))
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

        // POST: api/ingredients
        [ResponseType(typeof(ingredient))]
        public IHttpActionResult Postingredient(ingredient ingredient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ingredients.Add(ingredient);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ingredientExists(ingredient.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ingredient.id }, ingredient);
        }

        // DELETE: api/ingredients/5
        [ResponseType(typeof(ingredient))]
        public IHttpActionResult Deleteingredient(int id)
        {
            ingredient ingredient = db.ingredients.Find(id);
            if (ingredient == null)
            {
                return NotFound();
            }

            db.ingredients.Remove(ingredient);
            db.SaveChanges();

            return Ok(ingredient);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ingredientExists(int id)
        {
            return db.ingredients.Count(e => e.id == id) > 0;
        }
    }
}