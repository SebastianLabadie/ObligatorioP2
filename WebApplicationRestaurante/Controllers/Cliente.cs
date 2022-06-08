using Dominio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationRestaurante.Controllers
{
    public class Cliente : Controller
    {
        Sistema s = Sistema.GetInstancia();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult create()
        {
            return View();
        }

        public IActionResult MisServicios()
        {
            List<Servicio> servicios = s.GetServicios();
            return View(servicios);
        }
    }
}
