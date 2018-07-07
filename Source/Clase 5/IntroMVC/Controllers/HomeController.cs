using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IntroMVC.Models;

namespace IntroMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Proyectos()
        {
            List<Proyecto> proyectos = new List<Proyecto>();
            Usuario usuario = new Usuario
            {
                Cedula = "9773541",
                NombreCompleto = "Juan David Pareja Soto"
            };

            proyectos.Add(new Proyecto
            {
                Id = 1,
                Nombre = "Quantica",
                Descripcion = "Aplicacion para el acceso a la información de..."
            });

            proyectos.Add(new Proyecto
            {
                Id = 2,
                Nombre = "MAPS",
                Descripcion = "Otra Aplicacion para el acceso a la información de..."
            });

            proyectos.Add(new Proyecto
            {
                Id = 3,
                Nombre = "PASE",
                Descripcion = "La ultima Aplicacion para el acceso a la información de..."
            });

            Reporte reporte=new Reporte
            {
                Usuario=usuario,
                Proyectos=proyectos
            };
            return View(reporte);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
