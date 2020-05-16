using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Grupo4.InstitutoEducativo.Models;
using UsandoEntityFramework.Database;

namespace Grupo4.InstitutoEducativo.Controllers
{
    public class MateriasCursadasAlumnosController : Controller
    {
        private readonly UsandoEFDbContext _context;

        public MateriasCursadasAlumnosController(UsandoEFDbContext context)
        {
            _context = context;
        }

        // GET: MateriasCursadasAlumnos
        public async Task<IActionResult> Index()
        {
            var usandoEFDbContext = _context.MateriaCursadaAlumno.Include(m => m.Alumno).Include(m => m.MateriaCursada);
            return View(await usandoEFDbContext.ToListAsync());
        }

        // GET: MateriasCursadasAlumnos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materiaCursadaAlumno = await _context.MateriaCursadaAlumno
                .Include(m => m.Alumno)
                .Include(m => m.MateriaCursada)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (materiaCursadaAlumno == null)
            {
                return NotFound();
            }

            return View(materiaCursadaAlumno);
        }

        // GET: MateriasCursadasAlumnos/Create
        public IActionResult Create()
        {
            ViewData["AlumnoId"] = new SelectList(_context.Alumno, "Id", "NombreApellidoLegajo");
            ViewData["MateriaCursadaId"] = new SelectList(_context.MateriaCursada, "Id", "Nombre");
            return View();
        }

        // POST: MateriasCursadasAlumnos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MateriaCursadaId,AlumnoId")] MateriaCursadaAlumno materiaCursadaAlumno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(materiaCursadaAlumno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlumnoId"] = new SelectList(_context.Alumno, "Id", "NombreApellidoLegajo", materiaCursadaAlumno.AlumnoId);
            ViewData["MateriaCursadaId"] = new SelectList(_context.MateriaCursada, "Id", "Nombre", materiaCursadaAlumno.MateriaCursadaId);
            return View(materiaCursadaAlumno);
        }

        // GET: MateriasCursadasAlumnos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materiaCursadaAlumno = await _context.MateriaCursadaAlumno.FindAsync(id);
            if (materiaCursadaAlumno == null)
            {
                return NotFound();
            }
            ViewData["AlumnoId"] = new SelectList(_context.Alumno, "Id", "NombreApellidoLegajo", materiaCursadaAlumno.AlumnoId);
            ViewData["MateriaCursadaId"] = new SelectList(_context.MateriaCursada, "Id", "Nombre", materiaCursadaAlumno.MateriaCursadaId);
            return View(materiaCursadaAlumno);
        }

        // POST: MateriasCursadasAlumnos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MateriaCursadaId,AlumnoId")] MateriaCursadaAlumno materiaCursadaAlumno)
        {
            if (id != materiaCursadaAlumno.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(materiaCursadaAlumno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MateriaCursadaAlumnoExists(materiaCursadaAlumno.Id))
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
            ViewData["AlumnoId"] = new SelectList(_context.Alumno, "Id", "NombreApellidoLegajo", materiaCursadaAlumno.AlumnoId);
            ViewData["MateriaCursadaId"] = new SelectList(_context.MateriaCursada, "Id", "Nombre", materiaCursadaAlumno.MateriaCursadaId);
            return View(materiaCursadaAlumno);
        }

        // GET: MateriasCursadasAlumnos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materiaCursadaAlumno = await _context.MateriaCursadaAlumno
                .Include(m => m.Alumno)
                .Include(m => m.MateriaCursada)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (materiaCursadaAlumno == null)
            {
                return NotFound();
            }

            return View(materiaCursadaAlumno);
        }

        // POST: MateriasCursadasAlumnos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var materiaCursadaAlumno = await _context.MateriaCursadaAlumno.FindAsync(id);
            _context.MateriaCursadaAlumno.Remove(materiaCursadaAlumno);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MateriaCursadaAlumnoExists(int id)
        {
            return _context.MateriaCursadaAlumno.Any(e => e.Id == id);
        }
    }
}
