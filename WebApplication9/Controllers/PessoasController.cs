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
    public class PessoasController : Controller
    {
        private readonly WebApplication9Context _context;

        public PessoasController(WebApplication9Context context)
        {
            _context = context;
        }

        // GET: Pessoas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pessoa.ToListAsync());
        }
        public async Task<IActionResult> FiltroEstadoCivil
                        (string p_nome, string criteriobusca)
        {   // parte do código que preenche o list da cidade
            var v_estadoCivil = from x in _context.EstadoCivil select x.Descricao;
            @ViewBag.pDescricao = new SelectList(await v_estadoCivil.ToListAsync());

            var pedidosfiltro = from x in _context.Pessoa select x;

            if (!String.IsNullOrEmpty(p_nome))
            {
                pedidosfiltro = from x in _context.Pessoa
                                join y in _context.EstadoCivil on x.IdEstadoCivil equals y.IdEstadoCivil
                                where y.Descricao == p_nome
                                select x;
            }
            if (!String.IsNullOrEmpty(criteriobusca))
            {
                pedidosfiltro = pedidosfiltro.Where(zz => zz.Idade == int.Parse(criteriobusca));
            }

            return View(await pedidosfiltro.ToListAsync());
        }

        // GET: Pessoas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoa = await _context.Pessoa
                .FirstOrDefaultAsync(m => m.IdPessoa == id);
            if (pessoa == null)
            {
                return NotFound();
            }

            return View(pessoa);
        }

        // GET: Pessoas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pessoas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPessoa,Nome,IdEstadoCivil,Idade")] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pessoa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pessoa);
        }

        // GET: Pessoas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoa = await _context.Pessoa.FindAsync(id);
            if (pessoa == null)
            {
                return NotFound();
            }
            return View(pessoa);
        }

        // POST: Pessoas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPessoa,Nome,IdEstadoCivil,Idade")] Pessoa pessoa)
        {
            if (id != pessoa.IdPessoa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pessoa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PessoaExists(pessoa.IdPessoa))
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
            return View(pessoa);
        }

        // GET: Pessoas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoa = await _context.Pessoa
                .FirstOrDefaultAsync(m => m.IdPessoa == id);
            if (pessoa == null)
            {
                return NotFound();
            }

            return View(pessoa);
        }

        // POST: Pessoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pessoa = await _context.Pessoa.FindAsync(id);
            if (pessoa != null)
            {
                _context.Pessoa.Remove(pessoa);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PessoaExists(int id)
        {
            return _context.Pessoa.Any(e => e.IdPessoa == id);
        }
    }
}
