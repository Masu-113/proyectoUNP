using proyectoUNP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

public class AdquisicionesController : Controller
{
    private Sist_ControlActivos2Context db = new Sist_ControlActivos2Context();

    // GET: Adquisiciones
    public ActionResult Index()
    {
        CargarListasDesplegables();

        var adquisiciones = db.Adquisiciones
            .Include(a => a.Proveedor)
            .Include(a => a.Empleado)
            .ToList();

        ViewBag.Adquisiciones = adquisiciones;

        return View();
    }

    // GET: Adquisiciones/Create
    public ActionResult Create()
    {
        ViewBag.IdProveedor = new SelectList(db.Proveedores, "IdProveedor", "Nombre");
        ViewBag.IdEmpleado = new SelectList(
            db.Empleados.Where(e => e.Estado == 1),  // FILTRO AQUÍ
            "IdEmpleado",
            "PNU"
        );
        return View();
    }

    // POST: Adquisiciones/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Adquisicion adquisicion)
    {
        // Validación específica para tipo Compra
        if (adquisicion.TipoAdquisicion == "Compra")
        {
            // Verificar si está vacío
            if (string.IsNullOrWhiteSpace(adquisicion.NumeroFactura))
            {
                TempData["MensajeError"] = "El número de factura es obligatorio para las compras.";
                return RedirectToAction("Index");
            }

            // Verificar formato (letras, números y guiones, entre 3 y 50 caracteres)
            var regex = new System.Text.RegularExpressions.Regex("^[A-Z0-9\\-]{3,50}$", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            if (!regex.IsMatch(adquisicion.NumeroFactura))
            {
                TempData["MensajeError"] = "El formato del número de factura no es válido. Solo letras, números y guiones, de 3 a 50 caracteres.";
                return RedirectToAction("Index");
            }
        }

        if (ModelState.IsValid)
        {
            db.Adquisiciones.Add(adquisicion);
            db.SaveChanges();
            TempData["MensajeExito"] = "Adquisición registrada exitosamente.";
            return RedirectToAction("Index");
        }

        ViewBag.IdProveedor = new SelectList(db.Proveedores, "IdProveedor", "Nombre", adquisicion.IdProveedor);
        ViewBag.IdEmpleado = new SelectList(db.Empleados, "IdEmpleado", "PNU", adquisicion.IdEmpleado);
        return View(adquisicion);
    }


    private void CargarListasDesplegables()
    {
        ViewBag.Proveedores = db.Proveedores.Select(p => new SelectListItem
        {
            Value = p.IdProveedor.ToString(),
            Text = p.Nombre
        }).ToList();

        ViewBag.Empleados = db.Empleados
            .Where(e => e.Estado == 1)
            .Select(e => new SelectListItem
            {
                Value = e.IdEmpleado.ToString(),
                Text = e.PNU + " " + e.PAU
            }).ToList();
    }
}
