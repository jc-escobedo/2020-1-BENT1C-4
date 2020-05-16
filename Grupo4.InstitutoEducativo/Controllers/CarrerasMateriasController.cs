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
    public class CarrerasMateriasController : Controller
    {
        private readonly UsandoEFDbContext _context;

        public CarrerasMateriasController(UsandoEFDbContext context)
        {
            _context = context;
        }

        // GET: CarrerasMaterias
        public async Task<IActionResult> Index()
        {
            var usandoEFDbContext = _context.CarreraMateria.Include(c => c.Carrera).Include(c => c.Materia);
            return View(await usandoEFDbContext.ToListAsync());
        }

        // GET: CarrerasMaterias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carreraMateria = await _context.CarreraMateria
                .Include(c => c.Carrera)
                .Include(c => c.Materia)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carreraMateria == null)
            {
                return NotFound();
            }

            return View(carreraMateria);
        }

        // GET: CarrerasMaterias/Create
        public IActionResult Create()
        {
            ViewData["CarreraId"] = new SelectList(_context.Carrera, "Id", "Nombre");
            ViewData["MateriaId"] = new SelectList(_context.Materia, "Id", "Nombre");
            return View();
        }

        // POST: CarrerasMaterias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CarreraId,MateriaId")] CarreraMateria carreraMateria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carreraMateria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarreraId"] = new SelectList(_context.Carrera, "Id", "Nombre", carreraMateria.CarreraId);
            ViewData["MateriaId"] = new SelectList(_context.Materia, "Id", "Nombre", carreraMateria.MateriaId);
            return View(carreraMateria);
        }

        // GET: CarrerasMaterias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carreraMateria = await _context.CarreraMateria.FindAsync(id);
            if (carreraMateria == null)
            {
                return NotFound();
            }
            ViewData["CarreraId"] = new SelectList(_context.Carrera, "Id", "Nombre", carreraMateria.CarreraId);
            ViewData["MateriaId"] = new SelectList(_context.Materia, "Id", "Nombre", carreraMateria.MateriaId);
            return View(carreraMateria);
        }

        // POST: CarrerasMaterias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CarreraId,MateriaId")] CarreraMateria carreraMateria)
        {
            if (id != carreraMateria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carreraMateria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarreraMateriaExists(carreraMateria.Id))
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
            ViewData["CarreraId"] = new SelectList(_context.Carrera, "Id", "Nombre", carreraMateria.CarreraId);
            ViewData["MateriaId"] = new SelectList(_context.Materia, "Id", "Nombre", carreraMateria.MateriaId);
            return View(carreraMateria);
        }

        // GET: CarrerasMaterias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carreraMateria = await _context.CarreraMateria
                .Include(c => c.Carrera)
                .Include(c => c.Materia)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carreraMateria == null)
            {
                return NotFound();
            }

            return View(carreraMateria);
        }

        // POST: CarrerasMaterias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carreraMateria = await _context.CarreraMateria.FindAsync(id);
            _context.CarreraMateria.Remove(carreraMateria);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarreraMateriaExists(int id)
        {
            return _context.CarreraMateria.Any(e => e.Id == id);
        }
    }
}
