using Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationRestaurante.Controllers
{
    public class PlatosController : Controller
    {
        Sistema s = Sistema.GetInstancia();
        // GET: PlatosController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListPlatos()
        {
            
            return View(s.getListaPlatos());
        }

        public IActionResult Like(int id)
        {

            s.Likear(id);
            TempData["msg"] = $"Plato #{id} likeado con éxito";
            return RedirectToAction("ListPlatos");
        }

    }
}
