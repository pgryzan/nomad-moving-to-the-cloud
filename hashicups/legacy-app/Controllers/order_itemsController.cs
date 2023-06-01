using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using legacy_app.Models;

namespace legacy_app.Controllers
{
    public class order_itemsController : Controller
    {
        private productEntities db = new productEntities();

        // GET: order_items
        public ActionResult Index()
        {
            return View(db.order_items.ToList());
        }

        // GET: order_items/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order_items order_items = db.order_items.Find(id);
            if (order_items == null)
            {
                return HttpNotFound();
            }
            return View(order_items);
        }

        // GET: order_items/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: order_items/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,order_id,coffee_id,quantity,created_at,updated_at,deleted_at")] order_items order_items)
        {
            if (ModelState.IsValid)
            {
                db.order_items.Add(order_items);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(order_items);
        }

        // GET: order_items/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order_items order_items = db.order_items.Find(id);
            if (order_items == null)
            {
                return HttpNotFound();
            }
            return View(order_items);
        }

        // POST: order_items/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,order_id,coffee_id,quantity,created_at,updated_at,deleted_at")] order_items order_items)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order_items).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(order_items);
        }

        // GET: order_items/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order_items order_items = db.order_items.Find(id);
            if (order_items == null)
            {
                return HttpNotFound();
            }
            return View(order_items);
        }

        // POST: order_items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            order_items order_items = db.order_items.Find(id);
            db.order_items.Remove(order_items);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
