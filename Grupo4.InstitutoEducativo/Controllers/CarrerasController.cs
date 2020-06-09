using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Grupo4.InstitutoEducativo.Models;
using UsandoEntityFramework.Database;
using Microsoft.EntityFrameworkCore.Internal;

namespace Grupo4.InstitutoEducativo.Controllers
{
    public class CarrerasController : Controller
    {
        private readonly UsandoEFDbContext _context;

        public CarrerasController(UsandoEFDbContext context)
        {
            _context = context;
        }

        // GET: Carreras
        public async Task<IActionResult> Index()
        {
            return View(await _context.Carrera.ToListAsync());
        }

        // GET: Carreras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrera = await _context.Carrera
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carrera == null)
            {
                return NotFound();
            }

            return View(carrera);
        }

        // GET: Carreras/Create
        public IActionResult Create()
        {
            ViewData["MateriasId"] = new MultiSelectList(_context.Materia, nameof(Materia.Id), nameof(Materia.Nombre));
            return View();
        }

        // POST: Carreras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] Carrera carrera, List<int> materiaIds)
        {
            ValidarMaterias(materiaIds);

            if (ModelState.IsValid)
            {
                carrera.Materias = new List<CarreraMateria>();

                foreach(var materiaId in materiaIds)
                {
                    carrera.Materias.Add(new CarreraMateria { Carrera = carrera, MateriaId = materiaId });
                }
                _context.Add(carrera);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MateriasId"] = new MultiSelectList(_context.Materia, "Id", "Nombre", materiaIds);
            return View(carrera);
        }

        // GET: Carreras/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrera =  _context
                .Carrera
                .Include(x => x.Materias)
                .FirstOrDefault(x => x.Id == id);

            if (carrera == null)
            {
                return NotFound();
            }

            ViewData["MateriasId"] = new MultiSelectList(_context.Materia, "Id", "Nombre", carrera.Materias.Select(x => x.MateriaId).ToList());

            return View(carrera);
        }

        // POST: Carreras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Nombre")] Carrera carrera, List<int> materiaIds)
        {
            if (id != carrera.Id)
            {
                return NotFound();
            }

            ValidarMaterias(materiaIds);

            if (ModelState.IsValid)
            {
                try
                {
                    var carreraDb = _context
                        .Carrera
                        .Include(x => x.Materias)
                        .FirstOrDefault(x => x.Id == id);

                    carreraDb.Nombre = carrera.Nombre;

                    foreach(var carreraMateria in carreraDb.Materias)
                    {
                        _context.Remove(carreraMateria);
                    }

                    foreach (var materiaId in materiaIds)
                    {
                        carreraDb.Materias.Add(new CarreraMateria { CarreraId = carreraDb.Id, MateriaId = materiaId });
                    }

                    _context.Update(carreraDb);
                     _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarreraExists(carrera.Id))
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

            ViewData["MateriasId"] = new MultiSelectList(_context.Materia, "Id", "Nombre", materiaIds);

            return View(carrera);
        }

        // GET: Carreras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrera = await _context.Carrera
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carrera == null)
            {
                return NotFound();
            }

            return View(carrera);
        }

        // POST: Carreras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carrera = await _context.Carrera.FindAsync(id);
            _context.Carrera.Remove(carrera);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarreraExists(int id)
        {
            return _context.Carrera.Any(e => e.Id == id);
        }

        private void ValidarMaterias(List<int> materiasId)
        {
            if (materiasId.Count == 0)
            {
                ModelState.AddModelError(nameof(Carrera.Materias), "La carrera debe tener al menos una materia");
            }
        }
    }
}
