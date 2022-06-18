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
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult MisServicios()

        {
            List<Servicio> servicios = new List<Servicio>();
            return View(servicios);
        }

        [HttpPost]
        public IActionResult MisServicios(DateTime f1, DateTime f2)
        {
            //List<Contenido> l = s.BuscarContenidoEntreFechas(f1, f2);
            List<Servicio> servicios = new List<Servicio>();
            int? idLogueado = HttpContext.Session.GetInt32("LogueadoId");
            string rol = HttpContext.Session.GetString("LogueadoRol");

            if (idLogueado != null && idLogueado != 0 && rol.Equals("Mozo"))
            {
                servicios = s.GetServiciosLocalesByDateMozo(f1,f2,(int)idLogueado);

            }
            else
            {
                //redirect to login
            }

            return View(servicios);
        }

    }
}
