using proyectoUNP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyectoUNP.Controllers
{
    public class DetallesMantenimientoController : Controller
    {
        private Sist_ControlActivos2Context db = new Sist_ControlActivos2Context();

        public ActionResult Index()
        {
            return View(db.DetallesMantenimientos.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(DetallesMantenimiento detalle)
        {
            if (ModelState.IsValid)
            {
                db.DetallesMantenimientos.Add(detalle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(detalle);
        }
    }

}