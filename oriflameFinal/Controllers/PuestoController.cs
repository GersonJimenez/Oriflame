using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using oriflameFinal.Models;

namespace oriflameFinal.Controllers
{
    public class PuestoController : Controller
    {
        private readonly oriflameContext _context;

        public PuestoController(oriflameContext context)
        {
            _context = context;
        }

        // GET: Puesto
        public async Task<IActionResult> Index()
        {
            var oriflameContext = _context.Puestos.Include(p => p.IdDepartamentoNavigation).Include(p => p.IdJerarquiaNavigation);
            return View(await oriflameContext.ToListAsync());
        }
        [Authorize]
        // GET: Puesto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Puestos == null)
            {
                return NotFound();
            }

            var puesto = await _context.Puestos
                .Include(p => p.IdDepartamentoNavigation)
                .Include(p => p.IdJerarquiaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (puesto == null)
            {
                return NotFound();
            }

            return View(puesto);
        }

        // GET: Puesto/Create
        public IActionResult Create()
        {
            ViewData["IdDepartamento"] = new SelectList(_context.Departamentos, "Id", "Descripcion");
            ViewData["IdJerarquia"] = new SelectList(_context.Puestos, "Id", "Descripcion");
            return View();
        }

        // POST: Puesto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion,IdJerarquia,Estado,IdDepartamento")] Puesto puesto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(puesto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDepartamento"] = new SelectList(_context.Departamentos, "Id", "Id", puesto.IdDepartamento);
            ViewData["IdJerarquia"] = new SelectList(_context.Puestos, "Id", "Id", puesto.IdJerarquia);
            return View(puesto);
        }

        [HttpPost]
        public JsonResult GetJerarquiaDepto(string DeptoId)
        {
            var DataJerarquia = _context.Puestos.Where(x => x.IdDepartamento == Convert.ToInt32(DeptoId));
            return Json(new SelectList(DataJerarquia,"Id","Descripcion"));
        }

        // GET: Puesto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Puestos == null)
            {
                return NotFound();
            }

            var puesto = await _context.Puestos.FindAsync(id);
            if (puesto == null)
            {
                return NotFound();
            }
            ViewData["IdDepartamento"] = new SelectList(_context.Departamentos, "Id", "Id", puesto.IdDepartamento);
            ViewData["IdJerarquia"] = new SelectList(_context.Puestos, "Id", "Id", puesto.IdJerarquia);
            return View(puesto);
        }

        // POST: Puesto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,IdJerarquia,Estado,IdDepartamento")] Puesto puesto)
        {
            if (id != puesto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(puesto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PuestoExists(puesto.Id))
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
            ViewData["IdDepartamento"] = new SelectList(_context.Departamentos, "Id", "Id", puesto.IdDepartamento);
            ViewData["IdJerarquia"] = new SelectList(_context.Puestos, "Id", "Id", puesto.IdJerarquia);
            return View(puesto);
        }

        // GET: Puesto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Puestos == null)
            {
                return NotFound();
            }

            var puesto = await _context.Puestos
                .Include(p => p.IdDepartamentoNavigation)
                .Include(p => p.IdJerarquiaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (puesto == null)
            {
                return NotFound();
            }

            return View(puesto);
        }

        // POST: Puesto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Puestos == null)
            {
                return Problem("Entity set 'oriflameContext.Puestos'  is null.");
            }
            var puesto = await _context.Puestos.FindAsync(id);
            if (puesto != null)
            {
                _context.Puestos.Remove(puesto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PuestoExists(int id)
        {
          return _context.Puestos.Any(e => e.Id == id);
        }
    }
}
