using Dominio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebApplicationRestaurante.Controllers
{
    public class MozoController : Controller
    {
        Sistema s = Sistema.GetInstancia();

        public Boolean UsuarioAutorizado()
        {
            int? idLogueado = HttpContext.Session.GetInt32("LogueadoId");
            string rol = HttpContext.Session.GetString("LogueadoRol");

            if (idLogueado != null && idLogueado != 0 && rol.Equals("Mozo"))
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
            if (UsuarioAutorizado())
            {
               
            }
            else
            {
                TempData["msg"] = "Acceso denegado, únicamente los mozos pueden acceder a ese menú.";
                return RedirectToAction("Index", "Home");
            }

            return View(servicios);
        }

        [HttpPost]
        public IActionResult MisServicios(DateTime f1, DateTime f2)
        {
            List<Servicio> servicios = new List<Servicio>();
            int? idLogueado = HttpContext.Session.GetInt32("LogueadoId");

            if (UsuarioAutorizado())
            {
                if (f1 != null && f2 != null)
                {
                    servicios = s.GetServiciosLocalesByDateMozo(f1, f2, (int)idLogueado);
                }
                
            }
            else
            {
                TempData["msg"] = "Acceso denegado, únicamente los mozos pueden acceder a ese menú.";
                return RedirectToAction("Index", "Home");
            }

            return View(servicios);
        }

    }
}
