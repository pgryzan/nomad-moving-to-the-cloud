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
    public class coffee_ingredientsController : Controller
    {
        private productEntities db = new productEntities();

        // GET: coffee_ingredients
        public ActionResult Index()
        {
            return View(db.coffee_ingredients.ToList());
        }

        // GET: coffee_ingredients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            coffee_ingredients coffee_ingredients = db.coffee_ingredients.Find(id);
            if (coffee_ingredients == null)
            {
                return HttpNotFound();
            }
            return View(coffee_ingredients);
        }

        // GET: coffee_ingredients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: coffee_ingredients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,coffee_id,ingredient_id,quantity,unit,created_at,updated_at,deleted_at")] coffee_ingredients coffee_ingredients)
        {
            if (ModelState.IsValid)
            {
                db.coffee_ingredients.Add(coffee_ingredients);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(coffee_ingredients);
        }

        // GET: coffee_ingredients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            coffee_ingredients coffee_ingredients = db.coffee_ingredients.Find(id);
            if (coffee_ingredients == null)
            {
                return HttpNotFound();
            }
            return View(coffee_ingredients);
        }

        // POST: coffee_ingredients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,coffee_id,ingredient_id,quantity,unit,created_at,updated_at,deleted_at")] coffee_ingredients coffee_ingredients)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coffee_ingredients).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coffee_ingredients);
        }

        // GET: coffee_ingredients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            coffee_ingredients coffee_ingredients = db.coffee_ingredients.Find(id);
            if (coffee_ingredients == null)
            {
                return HttpNotFound();
            }
            return View(coffee_ingredients);
        }

        // POST: coffee_ingredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            coffee_ingredients coffee_ingredients = db.coffee_ingredients.Find(id);
            db.coffee_ingredients.Remove(coffee_ingredients);
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
