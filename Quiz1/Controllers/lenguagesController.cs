using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Quiz1.Models;

namespace Quiz1.Controllers
{
    public class lenguagesController : Controller
    {
        private LenguagesEntities db = new LenguagesEntities();

        // GET: lenguages
        public ActionResult Index()
        {
            return View(db.lenguages.ToList());
        }

        // GET: lenguages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lenguages lenguages = db.lenguages.Find(id);
            if (lenguages == null)
            {
                return HttpNotFound();
            }
            return View(lenguages);
        }

        // GET: lenguages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: lenguages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre")] lenguages lenguages)
        {
            if (ModelState.IsValid)
            {
                db.lenguages.Add(lenguages);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lenguages);
        }

        // GET: lenguages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lenguages lenguages = db.lenguages.Find(id);
            if (lenguages == null)
            {
                return HttpNotFound();
            }
            return View(lenguages);
        }

        // POST: lenguages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre")] lenguages lenguages)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lenguages).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lenguages);
        }

        // GET: lenguages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lenguages lenguages = db.lenguages.Find(id);
            if (lenguages == null)
            {
                return HttpNotFound();
            }
            return View(lenguages);
        }

        // POST: lenguages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            lenguages lenguages = db.lenguages.Find(id);
            db.lenguages.Remove(lenguages);
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
