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
    public class coffeesController : Controller
    {
        private productEntities db = new productEntities();

        // GET: coffees
        public ActionResult Index()
        {
            return View(db.coffees.ToList());
        }

        // GET: coffees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            coffee coffee = db.coffees.Find(id);
            if (coffee == null)
            {
                return HttpNotFound();
            }
            return View(coffee);
        }

        // GET: coffees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: coffees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,teaser,description,price,image,created_at,updated_at,deleted_at")] coffee coffee)
        {
            if (ModelState.IsValid)
            {
                db.coffees.Add(coffee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(coffee);
        }

        // GET: coffees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            coffee coffee = db.coffees.Find(id);
            if (coffee == null)
            {
                return HttpNotFound();
            }
            return View(coffee);
        }

        // POST: coffees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,teaser,description,price,image,created_at,updated_at,deleted_at")] coffee coffee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coffee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coffee);
        }

        // GET: coffees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            coffee coffee = db.coffees.Find(id);
            if (coffee == null)
            {
                return HttpNotFound();
            }
            return View(coffee);
        }

        // POST: coffees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            coffee coffee = db.coffees.Find(id);
            db.coffees.Remove(coffee);
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
