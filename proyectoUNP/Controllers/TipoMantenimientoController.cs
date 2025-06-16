using proyectoUNP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace proyectoUNP.Controllers
{
    public class TipoMantenimientoController : Controller
    {
        private Sist_ControlActivos2Context db = new Sist_ControlActivos2Context();

        public ActionResult Index()
        {
            var tipos = db.TipoMantenimientos.Include(t => t.DetallesMantenimiento).ToList();
            return View(tipos);
        }

        public ActionResult Create()
        {
            ViewBag.IdDetallesMantenimiento = new SelectList(db.DetallesMantenimientos, "IdDM", "DetallesDelMantenimiento");
            return View();
        }

        [HttpPost]
        public ActionResult Create(TipoMantenimiento tipo)
        {
            if (ModelState.IsValid)
            {
                db.TipoMantenimientos.Add(tipo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdDetallesMantenimiento = new SelectList(db.DetallesMantenimientos, "IdDM", "DetallesDelMantenimiento", tipo.IdDetallesMantenimiento);
            return View(tipo);
        }
    }

}