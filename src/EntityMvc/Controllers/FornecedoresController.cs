using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entity.Produtos.Data.Contexto;
using Entity.Produtos.Domain.Entidades;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace entity_framework.Controllers
{
    public class FornecedoresController : Controller
    {
        private readonly ProdutosDbContexto _context;

        public FornecedoresController(ProdutosDbContexto context)
        {
            _context = context;
        }

        // GET: Fornecedores
        public async Task<IActionResult> Index()
        {
            AnalisandoChangeTracker();
            return View(await _context.Fornecedores.ToListAsync());
        }

        // GET: Fornecedores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedor = await _context.Fornecedores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fornecedor == null)
            {
                return NotFound();
            }

            return View(fornecedor);
        }

        // GET: Fornecedores/Create
        public IActionResult Create()
        {
            ViewData["EnderecoId"] = new SelectList(_context.Enderecos, "Id", "Bairro");
            return View();
        }

        // POST: Fornecedores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,DocumentoIdentificacao,Ativo,TipoFornecedor,EnderecoId")] Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fornecedor);
                AnalisandoChangeTracker();
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EnderecoId"] = new SelectList(_context.Enderecos, "Id", "Bairro");
            return View(fornecedor);
        }

        // GET: Fornecedores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedor = await _context.Fornecedores.FindAsync(id);
            if (fornecedor == null)
            {
                return NotFound();
            }
            ViewData["EnderecoId"] = new SelectList(_context.Enderecos, "Id", "Bairro");
            return View(fornecedor);
        }

        // POST: Fornecedores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,DocumentoIdentificacao,Ativo,TipoFornecedor,EnderecoId")] Fornecedor fornecedor)
        {
            if (id != fornecedor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Entry<Fornecedor>(fornecedor).State = EntityState.Modified;
                    _context.Set<Fornecedor>().Update(fornecedor);
                    AnalisandoChangeTracker();
                    await _context.SaveChangesAsync();
                    //_context.Update(fornecedor);
                    //await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FornecedorExiste(fornecedor.Id))
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
            return View(fornecedor);
        }

        // GET: Fornecedores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedor = await _context.Fornecedores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fornecedor == null)
            {
                return NotFound();
            }

            return View(fornecedor);
        }

        // POST: Fornecedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fornecedor = await _context.Fornecedores.FindAsync(id);
            _context.Fornecedores.Remove(fornecedor);
            AnalisandoChangeTracker();
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FornecedorExiste(int id)
        {
            return _context.Fornecedores.Any(e => e.Id == id);
        }

        private void UpdatingByTrackingGraph(ICollection<Fornecedor> fornecedores)
        {
            using (var context = new ProdutosDbContexto())
            {
                context.ChangeTracker.TrackGraph(fornecedores, c => 
                {
                    if (c.Entry.IsKeySet)
                        c.Entry.State = EntityState.Unchanged;

                    if (!c.Entry.IsKeySet)
                        c.Entry.State = EntityState.Added;
                });

                context.SaveChanges();
            }
        }

        public void AnalisandoChangeTracker()
        {
            foreach (var entry in _context.ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("RegisterDate") != null))
            {
                if (entry.State == EntityState.Added)
                    entry.Property("RegisterDate").CurrentValue = DateTime.Now;

                if (entry.State == EntityState.Modified)
                    entry.Property("RegisterDate").IsModified = false;
            }

            //Verifica de há mudanças no contexto
            _context.ChangeTracker.HasChanges();

            //Tras todas entidades que estão em estado adicionado
            var mudancasContexto =_context.ChangeTracker.Entries().Where(e => e.State == EntityState.Modified);

            //Desativa a auto gerenciamento de mudanças
            //_context.ChangeTracker.AutoDetectChangesEnabled = false;

            var valoresIniciais = _context.ChangeTracker.Entries().Where(e => e.State == EntityState.Modified).Select(e => e.OriginalValues).ToList();
        }
    }
}