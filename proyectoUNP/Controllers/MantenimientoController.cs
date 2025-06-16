using System.Linq;
using System.Web.Mvc;
using proyectoUNP.Models;
using System.Data.Entity; // para Include()

public class MantenimientoController : Controller
{
    private Sist_ControlActivos2Context db = new Sist_ControlActivos2Context();

    public ActionResult Index()
    {
        // Obtener lista de mantenimientos con las relaciones necesarias
        var mantenimientos = db.Mantenimientos
            .Include(m => m.TipoMantenimiento)
            .Include(m => m.Activo)
            .ToList();

        ViewBag.Mantenimientos = mantenimientos;

        // Obtener tipos de mantenimiento para el dropdown
        ViewBag.TiposMantenimiento = db.TipoMantenimientos.Select(t => new SelectListItem
        {
            Value = t.IdTM.ToString(),
            Text = t.Nombre // asumo que TipoMantenimiento tiene propiedad Nombre
        }).ToList();

        // Obtener activos para el dropdown
        ViewBag.Activos = db.Activos.Select(a => new SelectListItem
        {
            Value = a.IdActivos.ToString(),
            Text = a.Nombre // asumo que Activos tiene propiedad Nombre
        }).ToList();

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult CrearMantenimiento(Mantenimiento mantenimiento)
    {
        if (ModelState.IsValid)
        {
            db.Mantenimientos.Add(mantenimiento);
            db.SaveChanges();
            TempData["MensajeExito"] = "Mantenimiento registrado correctamente.";
            return RedirectToAction("Index");
        }

        TempData["MensajeError"] = "Error al registrar mantenimiento. Por favor, revise los datos.";
        return RedirectToAction("Index");
    }
}
