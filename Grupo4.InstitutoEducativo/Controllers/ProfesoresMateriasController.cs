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
    public class ProfesoresMateriasController : Controller
    {
        private readonly UsandoEFDbContext _context;

        public ProfesoresMateriasController(UsandoEFDbContext context)
        {
            _context = context;
        }

        // GET: ProfesoresMaterias
        public async Task<IActionResult> Index()
        {
            var usandoEFDbContext = _context.ProfesorMateria.Include(p => p.Materia).Include(p => p.Profesor);
            return View(await usandoEFDbContext.ToListAsync());
        }

        // GET: ProfesoresMaterias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesorMateria = await _context.ProfesorMateria
                .Include(p => p.Materia)
                .Include(p => p.Profesor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profesorMateria == null)
            {
                return NotFound();
            }

            return View(profesorMateria);
        }

        // GET: ProfesoresMaterias/Create
        public IActionResult Create()
        {
            ViewData["MateriaId"] = new SelectList(_context.Materia, "Id", "Nombre");
            ViewData["ProfesorId"] = new SelectList(_context.Profesor, "Id", "NombreApellido");
            return View();
        }

        // POST: ProfesoresMaterias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProfesorId,MateriaId")] ProfesorMateria profesorMateria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(profesorMateria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MateriaId"] = new SelectList(_context.Materia, "Id", "Nombre", profesorMateria.MateriaId);
            ViewData["ProfesorId"] = new SelectList(_context.Profesor, "Id", "NombreApellido", profesorMateria.ProfesorId);
            return View(profesorMateria);
        }

        // GET: ProfesoresMaterias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesorMateria = await _context.ProfesorMateria.FindAsync(id);
            if (profesorMateria == null)
            {
                return NotFound();
            }
            ViewData["MateriaId"] = new SelectList(_context.Materia, "Id", "Nombre", profesorMateria.MateriaId);
            ViewData["ProfesorId"] = new SelectList(_context.Profesor, "Id", "NombreApellido", profesorMateria.ProfesorId);
            return View(profesorMateria);
        }

        // POST: ProfesoresMaterias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProfesorId,MateriaId")] ProfesorMateria profesorMateria)
        {
            if (id != profesorMateria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profesorMateria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfesorMateriaExists(profesorMateria.Id))
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
            ViewData["MateriaId"] = new SelectList(_context.Materia, "Id", "Nombre", profesorMateria.MateriaId);
            ViewData["ProfesorId"] = new SelectList(_context.Profesor, "Id", "NombreApellido", profesorMateria.ProfesorId);
            return View(profesorMateria);
        }

        // GET: ProfesoresMaterias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesorMateria = await _context.ProfesorMateria
                .Include(p => p.Materia)
                .Include(p => p.Profesor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profesorMateria == null)
            {
                return NotFound();
            }

            return View(profesorMateria);
        }

        // POST: ProfesoresMaterias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var profesorMateria = await _context.ProfesorMateria.FindAsync(id);
            _context.ProfesorMateria.Remove(profesorMateria);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfesorMateriaExists(int id)
        {
            return _context.ProfesorMateria.Any(e => e.Id == id);
        }
    }
}
