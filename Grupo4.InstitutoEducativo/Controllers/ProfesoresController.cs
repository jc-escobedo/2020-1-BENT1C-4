using System;
using System.Collections.Generic;
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
    public class ProfesoresController : Controller
    {
        private readonly UsandoEFDbContext _context;

        public ProfesoresController(UsandoEFDbContext context)
        {
            _context = context;
        }

        // GET: Profesores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Profesor.ToListAsync());
        }

        // GET: Profesores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesor = await _context.Profesor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profesor == null)
            {
                return NotFound();
            }

            return View(profesor);
        }

        [Authorize(Roles = nameof(Role.Administrador))]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = nameof(Role.Administrador))]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,Legajo,Username")] Profesor profesor)
        {
            if (ModelState.IsValid)
            {
                profesor.FechaUltimaModificacion = profesor.FechaAlta = DateTime.Now;
                _context.Add(profesor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(profesor);
        }

        [Authorize(Roles = nameof(Role.Administrador))]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesor = await _context.Profesor.FindAsync(id);
            if (profesor == null)
            {
                return NotFound();
            }
            return View(profesor);
        }

        [Authorize(Roles = nameof(Role.Administrador))]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nombre,Apellido,Legajo,MateriasAplicables,Id")] Profesor profesor)
        {
            
            ModelState.Remove(nameof(Profesor.Username));

            if (id != profesor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //Profesor existente en la db
                    Profesor profesordb = _context.Profesor.Find(profesor.Id);

                    profesordb.Nombre = profesor.Nombre;
                    profesordb.Apellido = profesor.Apellido;
                    profesordb.Legajo = profesor.Legajo;
                    profesordb.MateriasAplicables = profesor.MateriasAplicables;
                    profesordb.FechaUltimaModificacion = DateTime.Now;

                    _context.Update(profesordb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfesorExists(profesor.Id))
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
            return View(profesor);
        }

        [Authorize(Roles = nameof(Role.Administrador))]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesor = await _context.Profesor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profesor == null)
            {
                return NotFound();
            }

            return View(profesor);
        }

        // POST: Profesores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var profesor = await _context.Profesor.FindAsync(id);
            _context.Profesor.Remove(profesor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfesorExists(int id)
        {
            return _context.Profesor.Any(e => e.Id == id);
        }
    }
}
