using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Grupo4.InstitutoEducativo.Models;
using UsandoEntityFramework.Database;
using Grupo4.InstitutoEducativo.Models.Enums;
using Grupo4.InstitutoEducativo.Extensions;
using System;

namespace Grupo4.InstitutoEducativo.Controllers
{
    public class HomeController : Controller
    {
        private readonly UsandoEFDbContext _context;
        public HomeController(UsandoEFDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var primerLogin = TempData["primerLogin"] as bool?;
            ViewBag.PrimerLogin = primerLogin ?? false;

            Seed();

            return View();
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

        private void Seed()
        {
            if (!_context.Profesor.Any())
            {
                _context.Add(new Profesor()
                {
                    Username = "profesor",
                    Role = Role.Administrador,
                    Password = "123456".Encriptar()
                });
                _context.SaveChanges();
            }
            if (!_context.Alumno.Any())
            {
                _context.Add(new Alumno()
                {
                    Username = "alumno",
                    Role = Role.Cliente,
                    Password = "123456".Encriptar()
                });
                _context.SaveChanges();
            }
        }
    }
}
