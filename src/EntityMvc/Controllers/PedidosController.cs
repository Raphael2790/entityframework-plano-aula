using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Entity.Pedidos.Domain.Entidades;
using Entity.Core.Mediator;
using Entity.Pedidos.Application.Commands;
using Entity.Pedidos.Application.Queries;

namespace entity_framework.Controllers
{
    public class PedidosController : Controller
    {
        private readonly IPedidosQueries _pedidosQueries;
        private readonly IMediatorHandler _mediator;
        public PedidosController(IPedidosQueries pedidosQueries, 
                                 IMediatorHandler mediator)
        {
            _pedidosQueries = pedidosQueries;
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _pedidosQueries.BuscarTodosComEndereco());
        }

        public async Task<IActionResult> Details(int id)
        {

            var pedido = await _pedidosQueries.Buscar(id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        public async Task<IActionResult> Create()
        {
            ViewData["EnderecoId"] = new SelectList(await _pedidosQueries.BuscarEnderecos(), "Id", "Bairro");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClienteId,EnderecoId,ValorTotal,Data")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                await _mediator.EnviarComando(new NovoPedidoComando
                {
                    Codigo = pedido?.Codigo,
                    Desconto = pedido.Desconto,
                    ClienteId = pedido.ClienteId,
                    CupomDescontoId = pedido.CupomDescontoId,
                    EnderecoId = pedido.EnderecoId,
                    ValorTotal = pedido.ValorTotal,
                    PedidoStatus = pedido.PedidoStatus,
                });
                return RedirectToAction(nameof(Index));
            }
            
            ViewData["EnderecoId"] = new SelectList(await _pedidosQueries.BuscarEnderecos(), "Id", "Bairro", pedido.EnderecoId);
            return View(pedido);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var pedido = await _pedidosQueries.Buscar(id);
            if (pedido == null)
            {
                return NotFound();
            }
            ViewData["EnderecoId"] = new SelectList(await _pedidosQueries.BuscarEnderecos(), "Id", "Bairro", pedido.EnderecoId);
            return View(pedido);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClienteId,EnderecoId,ValorTotal,Data")] Pedido pedido)
        {
            if (id != pedido.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _mediator.EnviarComando(new AtualizarPedidoComando
                    {
                        PedidoId = id,
                        Codigo = pedido.Codigo,
                        Desconto = pedido.Desconto,
                        ClienteId = pedido.ClienteId,
                        CupomDescontoId = pedido.CupomDescontoId,
                        EnderecoId = pedido.EnderecoId,
                        ValorTotal = pedido.ValorTotal,
                        PedidoStatus = pedido.PedidoStatus
                    });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await PedidoExists(pedido.Id))
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
            ViewData["EnderecoId"] = new SelectList(await _pedidosQueries.BuscarEnderecos(), "Id", "Bairro", pedido.EnderecoId);
            return View(pedido);
        }

        public async Task<IActionResult> Delete(int id)
        {

            var pedido = await _pedidosQueries.BuscarComEndereco(id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _mediator.EnviarComando(new RemoverPedidoComando
            {
                PedidoId = id
            });
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> PedidoExists(int id) => await _pedidosQueries.PedidoExiste(id);
    }
}
