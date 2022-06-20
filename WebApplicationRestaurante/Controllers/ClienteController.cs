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
        

        public IActionResult MisServicios()

        {
            List<Servicio> servicios = new List<Servicio>();
            int? idLogueado = HttpContext.Session.GetInt32("LogueadoId");
            string rol = HttpContext.Session.GetString("LogueadoRol");

            if (idLogueado != null && idLogueado != 0 && rol.Equals("Cliente"))
            {
                servicios = s.GetServicios((int)idLogueado);

            }
            else
            {
                //redirect to login
               
            }

            return View(servicios);
        }

        [HttpPost]
        public IActionResult MisServicios(DateTime f1, DateTime f2)
        {
            //List<Contenido> l = s.BuscarContenidoEntreFechas(f1, f2);
            List<Servicio> servicios = new List<Servicio>();
            int? idLogueado = HttpContext.Session.GetInt32("LogueadoId");
            string rol = HttpContext.Session.GetString("LogueadoRol");

            if (idLogueado != null && idLogueado != 0 && rol.Equals("Cliente"))
            {
                servicios = s.GetServiciosByDate(f1,f2,(int)idLogueado);

            }
            else
            {
                //redirect to login
            }

            return View(servicios);
        }

        public IActionResult Platos(int id)
        {
            Servicio serv = s.GetServicioById(id);
            List<Plato> platos = s.GetPlatos();
            ViewBag.platos = platos;


            return View(serv);
        }

        [HttpPost]
        public IActionResult Platos(int platoId,int cantidad,int servicioId)
        {
            s.AgregarPlatoById(platoId, cantidad, servicioId);

            return RedirectToAction("Platos");
        }


        public IActionResult MisServiciosPorPlato()

        {
            List<Plato> platos = s.GetPlatos();
            ViewBag.platos = platos;

            List<Servicio> servicios = new List<Servicio>();
            
            return View(servicios);
        }

        [HttpPost]
        public IActionResult MisServiciosPorPlato(int pId)

        {
            List<Plato> platos = s.GetPlatos();
            ViewBag.platos = platos;

            List<Servicio> servicios = new List<Servicio>();

            int? idLogueado = HttpContext.Session.GetInt32("LogueadoId");
            string rol = HttpContext.Session.GetString("LogueadoRol");

            if (idLogueado != null && idLogueado != 0 && rol.Equals("Cliente"))
            {
                servicios = s.GetServiciosByPlato((int)idLogueado,pId);

            }
            else
            {
                //redirect to login

            }

            return View(servicios);
        }


        public IActionResult Cerrar(int Id)
        {
            string msg = "";
            if (Id > 0)
            {
               msg = s.SetServicioEstadoById(Id);
            }
            ViewBag.msg = msg;
            return RedirectToAction("MisServicios"); //View();
        }


        public IActionResult SolicitarServicio()
        {
          
            return  View();
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
            string rol = HttpContext.Session.GetString("LogueadoRol");

            if (idLogueado != null && idLogueado != 0 && rol.Equals("Cliente"))
            {
                ser = s.GetServiciosMasCaros((int)idLogueado);
            }
            return View(ser);
        }

        public IActionResult SolicitarServicioLocal()
        {

            List<Mozo> mo = s.GetMozos();
            ViewBag.mozos = mo;
            return View();
        }
       
        [HttpPost]
        public IActionResult SolicitarServicioLocal(int NroMesa, int CantComensales, int mozoId)
        {
            int? idLogueado = HttpContext.Session.GetInt32("LogueadoId");
            string rol = HttpContext.Session.GetString("LogueadoRol");

            if (idLogueado != null && idLogueado != 0 && rol.Equals("Cliente"))
            {
                Cliente cli = s.GetClienteById((int)idLogueado);
                Mozo mo = s.GetMozoById(mozoId);
                s.AltaLocal(DateTime.Now, NroMesa, CantComensales, mo, cli);
            
            }
            return RedirectToAction("SolicitarServicioLocal");
            
        }

        public IActionResult SolicitarServicioDelivery()
        {

            List<Repartidor> re = s.GetRepartidores();
            ViewBag.repartidores = re;
            return View();
        }

        [HttpPost]
        public IActionResult SolicitarServicioDelivery(string DireccionEnvio,double DistanciaARestaurante,int repartidorId)
        {
            int? idLogueado = HttpContext.Session.GetInt32("LogueadoId");
            string rol = HttpContext.Session.GetString("LogueadoRol");

            if (idLogueado != null && idLogueado != 0 && rol.Equals("Cliente"))
            {
                Cliente cli = s.GetClienteById((int)idLogueado);
                Repartidor re = s.GetRepartidorById(repartidorId);
                s.AltaDelivery(DateTime.Now,DireccionEnvio,DistanciaARestaurante,re, cli);

            }
            return RedirectToAction("SolicitarServicioDelivery");

        }





    }
}
