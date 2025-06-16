using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using proyectoUNP.Models;

namespace proyectoUNP.Controllers
{


    public class LoginController : Controller
    {
        private Sist_ControlActivos2Context db = new Sist_ControlActivos2Context();

        public ActionResult Index()
        {
            return View("~/Views/UserPerfile/Login.cshtml"); // Cambia si tu vista tiene otro nombre
        }

        [HttpPost]
        public ActionResult Autenticar(string usuario, string clave)
        {
            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(clave))
            {
                ViewBag.Mensaje = "Debe ingresar ambos campos.";
                return View("~/Views/UserPerfile/Login.cshtml");
            }

            var usuarioEncontrado = db.Users
                .FirstOrDefault(u => u.NombreUsers.ToLower() == usuario.ToLower() && u.Contraseña == clave);

            if (usuarioEncontrado != null)
            {
                Session["Usuario"] = usuarioEncontrado.NombreUsers;
                Session["TipoUsuario"] = usuarioEncontrado.TipoUser?.Nombre ?? "Sin Tipo";

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Mensaje = "Usuario o contraseña incorrectos.";
                return View("~/Views/UserPerfile/Login.cshtml");
            }
        }


        public ActionResult CerrarSesion()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }
    }

}