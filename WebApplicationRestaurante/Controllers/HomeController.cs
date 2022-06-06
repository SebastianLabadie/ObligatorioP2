﻿using Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationRestaurante.Models;

namespace WebApplicationRestaurante.Controllers
{
    public class HomeController : Controller
    {
        Sistema s = Sistema.GetInstancia();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            int? idLogueado = HttpContext.Session.GetInt32("LogueadoId");


            if (idLogueado != null && idLogueado != 0)
            {
                ViewBag.LogeadoId = idLogueado;
                ViewBag.LogeadoRol = HttpContext.Session.GetString("LogueadoRol");
                string rol = HttpContext.Session.GetString("LogueadoRol");

                ViewBag.msg = $"Bienvenido, usted está logueado su rol es {rol}";
            }
            else
            {
                ViewBag.LogeadoId = 0;
                ViewBag.LogeadoRol = null;
                ViewBag.msg = "Inicie sesión";
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string user,string pass)
        {
            Persona p = s.ValidarDatosLogin(user, pass);

            if (p != null)
            {
                HttpContext.Session.SetInt32("LogueadoId", p.Id);
                HttpContext.Session.SetString("LogueadoRol", p.GetType().Name);
                return RedirectToAction("Index");
            }
            else
            {

                ViewBag.msg = "Datos incorrectos";

                return View();
            }

        }

        public IActionResult LogOut()
        {
            HttpContext.Session.SetInt32("LogueadoId", 0);
            HttpContext.Session.SetString("LogueadoRol", "");
            return  RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
