using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Grupo4.InstitutoEducativo.Models;
using UsandoEntityFramework.Database;
using Microsoft.AspNetCore.Authorization;
using Grupo4.InstitutoEducativo.Models.Enums;

namespace Grupo4.InstitutoEducativo.Controllers
{
    [Authorize(Roles = nameof(Role.Administrador))]
    public class AlumnosController : Controller
    {
        private readonly UsandoEFDbContext _context;

        public AlumnosController(UsandoEFDbContext context)
        {
            _context = context;
        }

        // GET: Alumnos
        public async Task<IActionResult> Index()
        {
            var usandoEFDbContext = _context.Alumno.Include(a => a.Carrera);
            return View(await usandoEFDbContext.ToListAsync());
        }

        // GET: Alumnos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumno = await _context.Alumno
                .Include(a => a.Carrera)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alumno == null)
            {
                return NotFound();
            }

            return View(alumno);
        }

        // GET: Alumnos/Create
        public IActionResult Create()
        {
            ViewData["CarreraId"] = new SelectList(_context.Carrera, "Id", "Nombre");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,Legajo,CarreraId,Username,Role")] Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                alumno.FechaUltimaModificacion = alumno.FechaAlta = DateTime.Now;
                _context.Add(alumno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarreraId"] = new SelectList(_context.Carrera, "Id", "Nombre", alumno.CarreraId);
            return View(alumno);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumno = await _context.Alumno.FindAsync(id);
            if (alumno == null)
            {
                return NotFound();
            }
            ViewData["CarreraId"] = new SelectList(_context.Carrera, "Id", "Nombre", alumno.CarreraId);
            return View(alumno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nombre,Apellido,Legajo,CarreraId,Id")] Alumno alumno)
        {
            ModelState.Remove(nameof(Alumno.Username));
            ModelState.Remove(nameof(Alumno.Role));

            if (id != alumno.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //Alumno existente en la db
                    Alumno alumnodb = _context.Alumno.Find(alumno.Id);

                    alumnodb.Nombre = alumno.Nombre;
                    alumnodb.Apellido = alumno.Apellido;
                    alumnodb.Legajo = alumno.Legajo;
                    alumnodb.CarreraId = alumno.CarreraId;
                    alumnodb.FechaUltimaModificacion = DateTime.Now;
                    
                    _context.Update(alumnodb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlumnoExists(alumno.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarreraId"] = new SelectList(_context.Carrera, "Id", "Nombre", alumno.CarreraId);
            return View(alumno);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumno = await _context.Alumno
                .Include(a => a.Carrera)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alumno == null)
            {
                return NotFound();
            }

            return View(alumno);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alumno = await _context.Alumno.FindAsync(id);
            _context.Alumno.Remove(alumno);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlumnoExists(int id)
        {
            return _context.Alumno.Any(e => e.Id == id);
        }
    }
}
