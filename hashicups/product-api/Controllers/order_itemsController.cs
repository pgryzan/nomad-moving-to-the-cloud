﻿using System;
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
    public class order_itemsController : ApiController
    {
        private productEntities db = new productEntities();

        // GET: api/order_items
        public IQueryable<order_items> Getorder_items()
        {
            return db.order_items;
        }

        // GET: api/order_items/5
        [ResponseType(typeof(order_items))]
        public IHttpActionResult Getorder_items(int id)
        {
            order_items order_items = db.order_items.Find(id);
            if (order_items == null)
            {
                return NotFound();
            }

            return Ok(order_items);
        }

        // PUT: api/order_items/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putorder_items(int id, order_items order_items)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != order_items.id)
            {
                return BadRequest();
            }

            db.Entry(order_items).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!order_itemsExists(id))
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

        // POST: api/order_items
        [ResponseType(typeof(order_items))]
        public IHttpActionResult Postorder_items(order_items order_items)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.order_items.Add(order_items);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = order_items.id }, order_items);
        }

        // DELETE: api/order_items/5
        [ResponseType(typeof(order_items))]
        public IHttpActionResult Deleteorder_items(int id)
        {
            order_items order_items = db.order_items.Find(id);
            if (order_items == null)
            {
                return NotFound();
            }

            db.order_items.Remove(order_items);
            db.SaveChanges();

            return Ok(order_items);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool order_itemsExists(int id)
        {
            return db.order_items.Count(e => e.id == id) > 0;
        }
    }
}