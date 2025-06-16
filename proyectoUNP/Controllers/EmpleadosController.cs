using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using proyectoUNP.Models;
using System.Data.Entity;

public class EmpleadosController : Controller
{
    private Sist_ControlActivos2Context db = new Sist_ControlActivos2Context();

    public ActionResult Index()
    {
        CargarListasDesplegables();

        var empleados = db.Empleados
            .Include(e => e.Universidad)
            .Include(e => e.Escuela)
            .Include(e => e.Cargo)
            .ToList();

        ViewBag.Empleados = empleados;

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult CrearEmpleado(Empleado empleado)
    {
        if (ModelState.IsValid)
        {
            // Validación de cédula única
            var existe = db.Empleados.Any(e => e.Cedula == empleado.Cedula);
            if (existe)
            {
                TempData["MensajeError"] = "Ya existe un empleado con esta cédula.";
                return RedirectToAction("Index");
            }

            // Si no existe, guardar el empleado
            db.Empleados.Add(empleado);
            db.SaveChanges();

            TempData["MensajeExito"] = "Empleado registrado exitosamente.";
            return RedirectToAction("Index");
        }

        // Si hay errores de validación del modelo
        CargarListasDesplegables();

        ViewBag.Empleados = db.Empleados
            .Include(e => e.Universidad)
            .Include(e => e.Escuela)
            .Include(e => e.Cargo)
            .ToList();

        return View("Index");
    }

    private void CargarListasDesplegables()
    {
        ViewBag.Universidades = db.Universidades.Select(u => new SelectListItem
        {
            Value = u.IdUniversidad.ToString(),
            Text = u.Nombre
        }).ToList();

        ViewBag.Escuelas = db.Escuelas.Select(e => new SelectListItem
        {
            Value = e.IdEscuela.ToString(),
            Text = e.NombreEscuela
        }).ToList();

        ViewBag.Cargos = db.Cargos.Select(c => new SelectListItem
        {
            Value = c.IdCargo.ToString(),
            Text = c.NombreCargo
        }).ToList();
    }
}
