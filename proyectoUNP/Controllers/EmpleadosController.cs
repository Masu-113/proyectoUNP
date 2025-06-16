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

    // GET: Empleados
    public ActionResult Index()
    {
        CargarListasDesplegables();

        var listaEmpleados = db.Empleados
            .Include(e => e.Universidad)
            .Include(e => e.Escuela)
            .Include(e => e.Cargo)
            .ToList();

        ViewBag.Empleados = listaEmpleados;

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult CrearEmpleado(Empleado empleado)
    {
        if (!ModelState.IsValid)
        {
            TempData["MensajeError"] = "Por favor revisa los datos ingresados.";
            CargarListasDesplegables();
            ViewBag.Empleados = db.Empleados
                .Include(e => e.Universidad)
                .Include(e => e.Escuela)
                .Include(e => e.Cargo)
                .ToList();
            return View("Index");
        }

        // Validar que la cédula no esté repetida
        bool cedulaDuplicada = db.Empleados.Any(e => e.Cedula == empleado.Cedula);
        if (cedulaDuplicada)
        {
            TempData["MensajeError"] = "Ya existe un empleado con esta cédula.";
            return RedirectToAction("Index");
        }

        db.Empleados.Add(empleado);
        db.SaveChanges();

        TempData["MensajeExito"] = "Empleado registrado exitosamente.";
        return RedirectToAction("Index");
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

    public ActionResult BajaEmpleado()
    {
        // Empleados activos
        var empleadosActivos = db.Empleados
            .Where(e => e.Estado == 1)
            .ToList();

        ViewBag.EmpleadosActivos = empleadosActivos
            .Select(e => new SelectListItem
            {
                Value = e.IdEmpleado.ToString(),
                Text = $"{e.PNU} {e.PAU} - {e.Cedula}"
            }).ToList();

        // Empleados dados de baja
        var empleadosInactivos = db.Empleados
            .Where(e => e.Estado == 0)
            .Include(e => e.Universidad)
            .Include(e => e.Escuela)
            .Include(e => e.Cargo)
            .ToList();

        ViewBag.EmpleadosBaja = empleadosInactivos;

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult DarDeBaja(int IdEmpleado)
    {
        var empleado = db.Empleados.Find(IdEmpleado);
        if (empleado == null)
        {
            TempData["MensajeError"] = "Empleado no encontrado.";
            return RedirectToAction("BajaEmpleado");
        }

        empleado.Estado = 0;
        db.Entry(empleado).State = EntityState.Modified;
        db.SaveChanges();

        TempData["MensajeExito"] = "Empleado dado de baja correctamente.";
        return RedirectToAction("BajaEmpleado");
    }
}
