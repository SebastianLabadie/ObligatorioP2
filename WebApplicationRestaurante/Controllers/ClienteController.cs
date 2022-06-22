using Dominio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebApplicationRestaurante.Controllers
{
    public class ClienteController : Controller
    {
        Sistema s = Sistema.GetInstancia();
        public IActionResult Index()
        {
            return View();
        }
        
        public Boolean UsuarioAutorizado()
        {
            int? idLogueado = HttpContext.Session.GetInt32("LogueadoId");
            string rol = HttpContext.Session.GetString("LogueadoRol");

            if (idLogueado != null && idLogueado != 0 && rol.Equals("Cliente"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IActionResult MisServicios()

        {
            int? idLogueado = HttpContext.Session.GetInt32("LogueadoId");
            List<Servicio> servicios = new List<Servicio>();
           

            if (UsuarioAutorizado())
            {
                servicios = s.GetServicios((int)idLogueado);

            }
            else
            {
                TempData["msg"] = "Acceso denegado, únicamente los clientes pueden acceder a ese menú.";
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
                if (f1 != null && f2 != null )
                {
                    servicios = s.GetServiciosByDate(f1, f2, (int)idLogueado);
                }
               

            }
            else
            {
                TempData["msg"] = "Acceso denegado, únicamente los clientes pueden acceder a ese menú.";
                return RedirectToAction("Index", "Home");
            }

            return View(servicios);
        }

        public IActionResult Platos(int id)
        {

            Servicio serv = null;
            if (UsuarioAutorizado())
            {
                List<Plato> platos = s.GetPlatos();
                ViewBag.platos = platos;
                serv = s.GetServicioById(id);
            }
            else
            {
                TempData["msg"] = "Acceso denegado, únicamente los clientes pueden acceder a ese menú.";
                return RedirectToAction("Index", "Home");
            }

            return View(serv);
        }

        [HttpPost]
        public IActionResult Platos(int platoId,int cantidad,int servicioId)
        {
            if (UsuarioAutorizado())
            {
                s.AgregarPlatoById(platoId, cantidad, servicioId);
                TempData["msg"] = $"Plato agregado con éxito al servicio #{servicioId}";
            }
            else
            {
                TempData["msg"] = "Acceso denegado, únicamente los clientes pueden acceder a ese menú.";
                return RedirectToAction("Index", "Home");
            }


            return RedirectToAction("Platos");
        }


        public IActionResult MisServiciosPorPlato()

        {
            List<Servicio> servicios = new List<Servicio>();
            List<Plato> platos = s.GetPlatos();

            if (UsuarioAutorizado())
            {
                ViewBag.platos = platos;

            }
            else
            {
                TempData["msg"] = "Acceso denegado, únicamente los clientes pueden acceder a ese menú.";
                return RedirectToAction("Index", "Home");
            }

            
            return View(servicios);
        }

        [HttpPost]
        public IActionResult MisServiciosPorPlato(int pId)

        {
            List<Plato> platos = s.GetPlatos();
            List<Servicio> servicios = new List<Servicio>();
            int? idLogueado = HttpContext.Session.GetInt32("LogueadoId");

            if (UsuarioAutorizado())
            {
                ViewBag.platos = platos;
                servicios = s.GetServiciosByPlato((int)idLogueado, pId);
            }
            else
            {
                TempData["msg"] = "Acceso denegado, únicamente los clientes pueden acceder a ese menú.";
                return RedirectToAction("Index", "Home");
            }


            return View(servicios);
        }


        public IActionResult Cerrar(int Id)
        {
            string msg = "";

            if (UsuarioAutorizado() )
            {
                if (Id > 0)
                {
                    msg = s.SetServicioEstadoById(Id);
                    TempData["msg"] = msg;
                }
            }
            else
            {
                TempData["msg"] = "Acceso denegado, únicamente los clientes pueden acceder a ese menú.";
                return RedirectToAction("Index", "Home");
            }


            return RedirectToAction("MisServicios"); 
        }


        public IActionResult SolicitarServicio()
        {
            if (UsuarioAutorizado())
            {
                return View();
            }
            else
            {
                TempData["msg"] = "Acceso denegado, únicamente los clientes pueden acceder a ese menú.";
                return RedirectToAction("Index", "Home");
            }
            
        }

        [HttpPost]
        public IActionResult ServicioTipo(string ServicioTipo)
        {

            return RedirectToAction("SolicitarServicio"+ ServicioTipo); //View();
        }

        public IActionResult ServicioMasCaro()
        {
            List<Servicio> ser = new List<Servicio>();
            int? idLogueado = HttpContext.Session.GetInt32("LogueadoId");
           
            if (UsuarioAutorizado())
            {
                ser = s.GetServiciosMasCaros((int)idLogueado);
            }
            else
            {
                TempData["msg"] = "Acceso denegado, únicamente los clientes pueden acceder a ese menú.";
                return RedirectToAction("Index", "Home");
            }

            return View(ser);
        }

        public IActionResult SolicitarServicioLocal()
        {
            if (UsuarioAutorizado())
            {
                List<Mozo> mo = s.GetMozos();
                ViewBag.mozos = mo;
                return View();
            }
            else
            {
                TempData["msg"] = "Acceso denegado, únicamente los clientes pueden acceder a ese menú.";
                return RedirectToAction("Index", "Home");
            }
           
        }
       
        [HttpPost]
        public IActionResult SolicitarServicioLocal(int NroMesa, int CantComensales, int mozoId)
        {
           
            int? idLogueado = HttpContext.Session.GetInt32("LogueadoId");
            if (UsuarioAutorizado())
            {
                Cliente cli = s.GetClienteById((int)idLogueado);
                Mozo mo = s.GetMozoById(mozoId);
                Local l = s.AltaLocal(DateTime.Now, NroMesa, CantComensales, mo, cli);
                if (l != null)
                {
                    TempData["msg"] = "Servicio Local creado correctamente";
                    
                }
                else
                {
                    TempData["msg"] = "Error al crear Servicio Local";
                }
                return RedirectToAction("SolicitarServicioLocal");

            }
            else
            {
                TempData["msg"] = "Acceso denegado, únicamente los clientes pueden acceder a ese menú.";
                return RedirectToAction("Index", "Home");
            }


               
            

            
            
        }

        public IActionResult SolicitarServicioDelivery()
        {
            if (UsuarioAutorizado())
            {
                List<Repartidor> re = s.GetRepartidores();
                ViewBag.repartidores = re;
                return View();
            }
            else
            {
                TempData["msg"] = "Acceso denegado, únicamente los clientes pueden acceder a ese menú.";
                return RedirectToAction("Index", "Home");
            }
            
        }

        [HttpPost]
        public IActionResult SolicitarServicioDelivery(string DireccionEnvio,double DistanciaARestaurante,int repartidorId)
        {
            int? idLogueado = HttpContext.Session.GetInt32("LogueadoId");
            if (UsuarioAutorizado())
            {
                Cliente cli = s.GetClienteById((int)idLogueado);
                Repartidor re = s.GetRepartidorById(repartidorId);
                Delivery del = s.AltaDelivery(DateTime.Now, DireccionEnvio, DistanciaARestaurante, re, cli);
                if (del != null)
                {
                    TempData["msg"] = "Delivery Creado con exito.";
                }
                else
                {
                    TempData["msg"] = "Error al crear delivery";
                }
                
                return RedirectToAction("SolicitarServicioDelivery");
            }
            else
            {
                TempData["msg"] = "Acceso denegado, únicamente los clientes pueden acceder a ese menú.";
                return RedirectToAction("Index", "Home");
            }

        }
       
            
            

        





    }
}
