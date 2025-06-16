using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using proyectoUNP.Models;

namespace proyectoUNP.Controllers
{
    public class BarriosController : Controller
    {
        private Sist_ControlActivos2Context db = new Sist_ControlActivos2Context();

        public ActionResult Index()
        {
            var barrios = db.Barrios.Include(b => b.Municipio);
            return View(barrios.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Barrio barrio = db.Barrios.Include(b => b.Municipio).FirstOrDefault(b => b.IdBarrio == id);
            if (barrio == null)
                return HttpNotFound();

            return View(barrio);
        }

        public ActionResult Create()
        {
            ViewBag.IdMunicipio = new SelectList(db.Municipios, "IdMun", "NombreMun");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Barrio barrio)
        {
            if (ModelState.IsValid)
            {
                db.Barrios.Add(barrio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdMunicipio = new SelectList(db.Municipios, "IdMun", "NombreMun", barrio.IdMunicipio);
            return View(barrio);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Barrio barrio = db.Barrios.Find(id);
            if (barrio == null)
                return HttpNotFound();

            ViewBag.IdMunicipio = new SelectList(db.Municipios, "IdMun", "NombreMun", barrio.IdMunicipio);
            return View(barrio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Barrio barrio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(barrio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdMunicipio = new SelectList(db.Municipios, "IdMun", "NombreMun", barrio.IdMunicipio);
            return View(barrio);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Barrio barrio = db.Barrios.Include(b => b.Municipio).FirstOrDefault(b => b.IdBarrio == id);
            if (barrio == null)
                return HttpNotFound();

            return View(barrio);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Barrio barrio = db.Barrios.Find(id);
            db.Barrios.Remove(barrio);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }
    }
}
