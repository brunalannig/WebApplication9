using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication9.Data;
using WebApplication9.Models;

namespace WebApplication9.Controllers
{
    public class EstadoCivilController : Controller
    {
        private readonly WebApplication9Context _context;

        public EstadoCivilController(WebApplication9Context context)
        {
            _context = context;
        }

        // GET: EstadoCivil
        public async Task<IActionResult> Index()
        {
            return View(await _context.EstadoCivil.ToListAsync());
        }

        // GET: EstadoCivil/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoCivil = await _context.EstadoCivil
                .FirstOrDefaultAsync(m => m.IdEstadoCivil == id);
            if (estadoCivil == null)
            {
                return NotFound();
            }

            return View(estadoCivil);
        }

        // GET: EstadoCivil/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EstadoCivil/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEstadoCivil,Descricao")] EstadoCivil estadoCivil)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estadoCivil);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estadoCivil);
        }

        // GET: EstadoCivil/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoCivil = await _context.EstadoCivil.FindAsync(id);
            if (estadoCivil == null)
            {
                return NotFound();
            }
            return View(estadoCivil);
        }

        // POST: EstadoCivil/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEstadoCivil,Descricao")] EstadoCivil estadoCivil)
        {
            if (id != estadoCivil.IdEstadoCivil)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadoCivil);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadoCivilExists(estadoCivil.IdEstadoCivil))
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
            return View(estadoCivil);
        }

        // GET: EstadoCivil/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoCivil = await _context.EstadoCivil
                .FirstOrDefaultAsync(m => m.IdEstadoCivil == id);
            if (estadoCivil == null)
            {
                return NotFound();
            }

            return View(estadoCivil);
        }

        // POST: EstadoCivil/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estadoCivil = await _context.EstadoCivil.FindAsync(id);
            if (estadoCivil != null)
            {
                _context.EstadoCivil.Remove(estadoCivil);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadoCivilExists(int id)
        {
            return _context.EstadoCivil.Any(e => e.IdEstadoCivil == id);
        }
    }
}
