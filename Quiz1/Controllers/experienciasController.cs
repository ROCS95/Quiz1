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
    public class experienciasController : Controller
    {
        private ExperienciaEntities db = new ExperienciaEntities();

        // GET: experiencias
        public ActionResult Index()
        {
            return View(db.experiencia.ToList());
        }

        // GET: experiencias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            experiencia experiencia = db.experiencia.Find(id);
            if (experiencia == null)
            {
                return HttpNotFound();
            }
            return View(experiencia);
        }

        // GET: experiencias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: experiencias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "puesto,lugar,detalles,id")] experiencia experiencia)
        {
            if (ModelState.IsValid)
            {
                db.experiencia.Add(experiencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(experiencia);
        }

        // GET: experiencias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            experiencia experiencia = db.experiencia.Find(id);
            if (experiencia == null)
            {
                return HttpNotFound();
            }
            return View(experiencia);
        }

        // POST: experiencias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "puesto,lugar,detalles,id")] experiencia experiencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(experiencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(experiencia);
        }

        // GET: experiencias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            experiencia experiencia = db.experiencia.Find(id);
            if (experiencia == null)
            {
                return HttpNotFound();
            }
            return View(experiencia);
        }

        // POST: experiencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            experiencia experiencia = db.experiencia.Find(id);
            db.experiencia.Remove(experiencia);
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
