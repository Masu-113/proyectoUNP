using proyectoUNP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

public class ActivosController : Controller
{
    private Sist_ControlActivos2Context db = new Sist_ControlActivos2Context();

    public ActionResult Index()
    {
        CargarListasDesplegables();
        ViewBag.Adquisiciones = ObtenerAdquisiciones();

        var activos = db.Activos
            .Include(a => a.TipoDeActivo)
            .Include(a => a.Marca)
            .Include(a => a.EstadoActual)
            .Include(a => a.Proveedor)
            .Include(a => a.Empleado)
            .Include(a => a.Ubicacion)
            .ToList();

        ViewBag.Activos = activos;
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult CrearActivo(Activos activos)
    {
        if (ModelState.IsValid)
        {
            var existe = db.Activos.Any(e => e.NumeroSerie == activos.NumeroSerie);
            if (existe)
            {
                TempData["MensajeError"] = "Este activo ya está registrado con el mismo número de serie.";
                return RedirectToAction("Index");
            }

            activos.FechaCreacion = DateTime.Now;
            db.Activos.Add(activos);
            db.SaveChanges();

            TempData["MensajeExito"] = "Activo registrado exitosamente.";
            return RedirectToAction("Index");
        }
        else
        {
            // Mostrar los errores de validación en la consola de Visual Studio
            foreach (var clave in ModelState.Keys)
            {
                var errores = ModelState[clave].Errors;
                foreach (var error in errores)
                {
                    System.Diagnostics.Debug.WriteLine($"ERROR en {clave}: {error.ErrorMessage}");
                }
            }

            TempData["MensajeError"] = "Error de validación: verifique los campos del formulario.";
            CargarListasDesplegables();
            ViewBag.Adquisiciones = ObtenerAdquisiciones();

            ViewBag.Activos = db.Activos
                .Include(a => a.TipoDeActivo)
                .Include(a => a.Marca)
                .Include(a => a.EstadoActual)
                .Include(a => a.Proveedor)
                .Include(a => a.Empleado)
                .Include(a => a.Ubicacion)
                .ToList();

            return View("Index", activos); // <- Este return es necesario para que todos los caminos devuelvan algo
        }
    }


    private void CargarListasDesplegables()
    {
        ViewBag.Tipos = db.TipoDeActivos.Select(t => new SelectListItem
        {
            Value = t.IdTipo.ToString(),
            Text = t.Nombre
        }).ToList();

        ViewBag.Marcas = db.Marcas.Select(m => new SelectListItem
        {
            Value = m.IdMarca.ToString(),
            Text = m.Nombre
        }).ToList();

        ViewBag.Estados = db.EstadoActuals.Select(e => new SelectListItem
        {
            Value = e.IdEstAct.ToString(),
            Text = e.Estado_Actual
        }).ToList();

        ViewBag.Proveedores = db.Proveedores.Select(p => new SelectListItem
        {
            Value = p.IdProveedor.ToString(),
            Text = p.Nombre
        }).ToList();

        ViewBag.Empleados = db.Empleados.Select(e => new SelectListItem
        {
            Value = e.IdEmpleado.ToString(),
            Text = e.PNU + " " + e.PAU
        }).ToList();

        ViewBag.Ubicaciones = db.Ubicaciones.Select(u => new SelectListItem
        {
            Value = u.IdUbicacion.ToString(),
            Text = u.Direccion
        }).ToList();
    }

    private List<SelectListItem> ObtenerAdquisiciones()
    {
        var adquisicionesDatos = (from a in db.Adquisiciones
                                  join p in db.Proveedores on a.IdProveedor equals p.IdProveedor into provs
                                  from p in provs.DefaultIfEmpty()
                                  join e in db.Empleados on a.IdEmpleado equals e.IdEmpleado into emps
                                  from e in emps.DefaultIfEmpty()
                                  select new
                                  {
                                      a.IdAdquisicion,
                                      a.NumeroFactura,
                                      a.Fecha,
                                      a.Monto,
                                      ProveedorNombre = p != null ? p.Nombre : "Sin Proveedor",
                                      EmpleadoNombre = e != null ? (e.PNU + " " + e.PAU) : "Sin Empleado",
                                      IdProveedor = a.IdProveedor,
                                      IdEmpleado = a.IdEmpleado
                                  }).ToList();

        var lista = adquisicionesDatos.Select(a => new SelectListItem
        {
            Value = a.IdAdquisicion.ToString(),
            Text = string.Join("|", new string[]
            {
                a.NumeroFactura ?? "Sin Número",
                a.Fecha.ToString("yyyy-MM-dd"),
                a.Monto.HasValue ? a.Monto.Value.ToString("F2") : "0.00",
                a.ProveedorNombre,
                a.EmpleadoNombre,
                a.IdProveedor.HasValue ? a.IdProveedor.Value.ToString() : "",
                a.IdEmpleado.HasValue ? a.IdEmpleado.Value.ToString() : ""
            })
        }).ToList();

        return lista;
    }
}
