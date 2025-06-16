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
    public class MunicipiosController : Controller
    {
        private Sist_ControlActivos2Context db = new Sist_ControlActivos2Context();

        public ActionResult Index()
        {
            var municipios = db.Municipios.Include(m => m.Departamento);
            return View(municipios.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Municipio municipio = db.Municipios.Include(m => m.Departamento).FirstOrDefault(m => m.IdMun == id);
            if (municipio == null)
                return HttpNotFound();

            return View(municipio);
        }

        public ActionResult Create()
        {
            ViewBag.IdDepartamento = new SelectList(db.Departamentos, "IdDep", "NombreDep");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Municipio municipio)
        {
            if (ModelState.IsValid)
            {
                db.Municipios.Add(municipio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdDepartamento = new SelectList(db.Departamentos, "IdDep", "NombreDep", municipio.IdDepartamento);
            return View(municipio);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Municipio municipio = db.Municipios.Find(id);
            if (municipio == null)
                return HttpNotFound();

            ViewBag.IdDepartamento = new SelectList(db.Departamentos, "IdDep", "NombreDep", municipio.IdDepartamento);
            return View(municipio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Municipio municipio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(municipio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdDepartamento = new SelectList(db.Departamentos, "IdDep", "NombreDep", municipio.IdDepartamento);
            return View(municipio);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Municipio municipio = db.Municipios.Include(m => m.Departamento).FirstOrDefault(m => m.IdMun == id);
            if (municipio == null)
                return HttpNotFound();

            return View(municipio);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Municipio municipio = db.Municipios.Find(id);
            db.Municipios.Remove(municipio);
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
