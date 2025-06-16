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
    public class ProveedoresController : Controller
    {
        private Sist_ControlActivos2Context db = new Sist_ControlActivos2Context();

        public ActionResult Index()
        {
            var proveedores = db.Proveedores.Include(p => p.Barrio);
            return View(proveedores.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Proveedor proveedor = db.Proveedores.Include(p => p.Barrio).FirstOrDefault(p => p.IdProveedor == id);
            if (proveedor == null)
                return HttpNotFound();

            return View(proveedor);
        }

        public ActionResult Create()
        {
            ViewBag.IdBarrio = new SelectList(db.Barrios, "IdBarrio", "NombreBarrio");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                db.Proveedores.Add(proveedor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdBarrio = new SelectList(db.Barrios, "IdBarrio", "NombreBarrio", proveedor.IdBarrio);
            return View(proveedor);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Proveedor proveedor = db.Proveedores.Find(id);
            if (proveedor == null)
                return HttpNotFound();

            ViewBag.IdBarrio = new SelectList(db.Barrios, "IdBarrio", "NombreBarrio", proveedor.IdBarrio);
            return View(proveedor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proveedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdBarrio = new SelectList(db.Barrios, "IdBarrio", "NombreBarrio", proveedor.IdBarrio);
            return View(proveedor);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Proveedor proveedor = db.Proveedores.Include(p => p.Barrio).FirstOrDefault(p => p.IdProveedor == id);
            if (proveedor == null)
                return HttpNotFound();

            return View(proveedor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Proveedor proveedor = db.Proveedores.Find(id);
            db.Proveedores.Remove(proveedor);
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
