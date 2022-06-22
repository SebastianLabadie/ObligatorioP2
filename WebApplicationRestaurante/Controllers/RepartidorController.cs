using Dominio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebApplicationRestaurante.Controllers
{
    public class RepartidorController : Controller
    {
        Sistema s = Sistema.GetInstancia();


        public Boolean UsuarioAutorizado()
        {
            int? idLogueado = HttpContext.Session.GetInt32("LogueadoId");
            string rol = HttpContext.Session.GetString("LogueadoRol");

            if (idLogueado != null && idLogueado != 0 && rol.Equals("Repartidor"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult MisServicios()

        {
            List<Servicio> servicios = new List<Servicio>();
            int? idLogueado = HttpContext.Session.GetInt32("LogueadoId");

            if (UsuarioAutorizado())
            {
                servicios = s.GetServiciosByRepartidor((int)idLogueado);

            }
            else
            {
                TempData["msg"] = "Acceso denegado, únicamente los repartidores pueden acceder a ese menú.";
                return RedirectToAction("Index", "Home");
            }

            return View(servicios);
        }

     

    }
}
