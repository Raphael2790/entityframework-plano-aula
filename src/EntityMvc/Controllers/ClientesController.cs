using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Entity.Clientes.Data.Contexto;
using Entity.Clientes.Domain.Entidades;
using Entity.Clientes.Domain.Interfaces.Repositories;
using Entity.Clientes.Domain.Interfaces;

namespace entity_framework.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly ClienteDbContexto _contexto;
        private readonly IClientesQuery _clientesQuery;
        public ClientesController(IClienteRepository clienteRepository, 
                                  ClienteDbContexto contexto,
                                  IClientesQuery clientesQuery)
        {
            _clienteRepository = clienteRepository;
            _contexto = contexto;
            _clientesQuery = clientesQuery;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            var letras = new List<char>() { 'o', 'd' };
            var listaClientes = await _clienteRepository.BuscarTodosCujoNomeContenhaLetras(letras);
            //var dbContexto = _clienteRepository.Clientes.Include(c => c.Endereco);
            var lista = await _clienteRepository.BuscarTodosComEndereco();
            return View(lista);
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int id)
        {
        
            var cliente = await _clienteRepository.BuscarComEndereco(id);

            if (cliente == null)
            {
                return NotFound();
            }


            // var clientes = from c in _clienteRepository.Clientes
            //     join e in _clienteRepository.Enderecos on c.EnderecoId equals e.Id
            //     join p in _clienteRepository.Pedidos on c.Id equals p.ClienteId
            //     join pp in _clienteRepository.PedidosProdutos on p.Id equals pp.PedidoId
            //     join produto in _clienteRepository.Produtos on pp.ProdutoId equals produto.Id
            //     where c.Nome == "Danilo" && c.Id == 1
            //     select new {
            //         Nome = c.Nome,
            //         Endereco = e.Logradouro,
            //         PedidoId = p.Id,
            //         Quantidade = pp.Quantidade,
            //         NomeProduto = produto.Nome,
            //     };

            // foreach (var cli in clientes)
            // {
            //     Console.WriteLine(cli);
            // }


            // var clientes = from c in _clienteRepository.Clientes
            // join p in _clienteRepository.Pedidos on c.Id equals p.ClienteId
            // group p by c.Nome into grouping
            // select new {
            //     Nome = grouping.Key,
            //     Total = grouping.Sum( g => g.ValorTotal)
            // };

            // var clientes = from c in _clienteRepository.Clientes
            // join p in _clienteRepository.Pedidos on c.Id equals p.ClienteId
            // join pp in _clienteRepository.PedidosProdutos on p.Id equals pp.PedidoId
            // group p by new { c.Nome, pp.Quantidade } into grouping
            // select new {
            //     Nome = grouping.Key.Nome,
            //     Quantidade = grouping.Key.Quantidade,
            //     Total = grouping.Sum( g => g.ValorTotal)
            // };


        // var clientes = from c in _clienteRepository.Clientes
        // where (
        //     from p in _clienteRepository.Pedidos
        //     where p.ClienteId == c.Id
        //     select p
        // ).Count() >= 2
        // select c.Nome;

        // foreach (var cli in clientes)
        // {
        //     Console.WriteLine(cli);
        // }


            var x = "";


            

            // var pedidosContext = _clienteRepository.Clientes;
            // var pedidosSql = pedidosContext.Join(
            //     _clienteRepository.Pedidos,
            //     cli => cli.Id,
            //     ped => ped.ClienteId,
            //     (cli, ped) => new ClientePedido {
            //         Cliente = cli.Nome,
            //         ValorTotal = ped.ValorTotal
            //     }
            // ).GroupBy(p => p.Cliente).Select(c => new {
            //     Nome = c.Key,
            //     ValorTotal = c.Sum( cp => cp.ValorTotal )
            // }).ToQueryString();

            //  var pedidos = await pedidosContext.Join(
            //     _clienteRepository.Pedidos,
            //     cli => cli.Id,
            //     ped => ped.ClienteId,
            //     (cli, ped) => new ClientePedido {
            //         Cliente = cli.Nome,
            //         ValorTotal = ped.ValorTotal
            //     }
            // ).GroupBy(p => p.Cliente).Select(c => new {
            //     Nome = c.Key,
            //     ValorTotal = c.Sum( cp => cp.ValorTotal )
            // }).ToListAsync();


            /*
            using(var command = _clienteRepository.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SELECT clientes.nome, sum(pedidos.valor_total) as valor_total FROM pedidos inner join clientes on clientes.id = pedidos.cliente_id group by clientes.id";
                _clienteRepository.Database.OpenConnection();

                using(var result = await command.ExecuteReaderAsync())
                {
                    var pedidos_agrupados = new List<dynamic>();
                    while(result.Read())
                    {
                        pedidos_agrupados.Add(new {
                            Nome = result["nome"].ToString(),
                            ValorTotal = Convert.ToDouble(result["valor_total"]),
                        });
                    }

                    ViewBag.pedidos = pedidos_agrupados;
                }
                _clienteRepository.Database.CloseConnection();
            }*/

            /*using(var command = _clienteRepository.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "select clientes.nome as cliente, pedidos.valor_total, produtos.nome as produto, pedidos_produtos.quantidade, pedidos_produtos.valor  " +
                    "from clientes " + 
                    "inner join pedidos on pedidos.cliente_id = clientes.id " + 
                    "inner join pedidos_produtos on pedidos_produtos.pedido_id = pedidos.id " +
                    "inner join produtos on produtos.id = pedidos_produtos.produto_id " +
                    "where clientes.id = " + cliente.Id;
                _clienteRepository.Database.OpenConnection();

                using(var result = await command.ExecuteReaderAsync())
                {
                    var pedidos = new List<ClientePedido>();
                    while(result.Read())
                    {
                        pedidos.Add(new ClientePedido{
                            Cliente = result["cliente"].ToString(),
                            ValorTotal = Convert.ToDouble(result["valor_total"]),
                            Quantidade = Convert.ToInt32(result["quantidade"]),
                            Produto = result["produto"].ToString(),
                            Valor = Convert.ToDouble(result["valor"]),
                        });
                    }

                    ViewBag.pedidos = pedidos;
                }
                _clienteRepository.Database.CloseConnection();
            }*/

            /*var pedidosContext = _clienteRepository.Clientes.Where(c => c.Id  == cliente.Id);
            var pedidos =  pedidosContext.Join(
                _clienteRepository.Pedidos,
                cli => cli.Id,
                ped => ped.ClienteId,
                (cli, ped) => new ClientePedido {
                    Cliente = cli.Nome,
                    ValorTotal = ped.ValorTotal,
                    PedidoId = ped.Id
                }
            ).Join(
                _clienteRepository.PedidosProdutos,
                pCliente => pCliente.PedidoId,
                pp => pp.PedidoId,
                (pCliente, pp) => new ClientePedido {
                    Cliente = pCliente.Cliente,
                    ValorTotal = pCliente.ValorTotal,
                    PedidoId = pCliente.PedidoId,
                    Quantidade = pp.Quantidade,
                    Valor = pp.Valor,
                    ProdutoId = pp.ProdutoId,
                }
            ).Join(
                _clienteRepository.Produtos,
                pCliente => pCliente.ProdutoId,
                produto => produto.Id,
                (pCliente, produto) => new ClientePedido {
                    Cliente = pCliente.Cliente,
                    ValorTotal = pCliente.ValorTotal,
                    PedidoId = pCliente.PedidoId,
                    Quantidade = pCliente.Quantidade,
                    Valor = pCliente.Valor,
                    Produto = produto.Nome,
                }
            ).ToListAsync(); //.ToQueryString(); // mostra o SQL GERADO
            */
            /*
            SET @__cliente_Id_0 = 1;

            SELECT 
            c.nome AS Cliente, 
            p.valor_total AS ValorTotal, 
            p.id AS PedidoId, 
            p0.quantidade AS Quantidade, 
            p0.valor AS Valor, 
            p1.nome AS Produto
            FROM clientes AS c
            INNER JOIN pedidos AS p ON c.id = p.cliente_id
            INNER JOIN pedidos_produtos AS p0 ON p.id = p0.pedido_id
            INNER JOIN produtos AS p1 ON p0.produto_id = p1.id
            WHERE c.id = @__cliente_Id_0
            */

            // ViewBag.pedidos = pedidos;
            return View(cliente);
        }

        // GET: Clientes/Create
        public async Task<IActionResult> Create()
        {
            ViewData["EnderecoId"] = new SelectList(await _clienteRepository.BuscarEnderecosClientesCadastrados(), "Id", "Bairro");
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Observacao,DataCadastro,EnderecoId")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                cliente.DataCadastro = DateTime.Now;
                await _clienteRepository.Salvar(cliente);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EnderecoId"] = new SelectList(await _clienteRepository.BuscarEnderecosClientesCadastrados(), "Id", "Bairro", cliente.EnderecoId);
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            //var cliente = await _clienteRepository.Buscar(id);
            var cliente = await _clientesQuery.Buscar(id);
            if (cliente == null)
            {
                return NotFound();
            }
            ViewData["EnderecoId"] = new SelectList(await _clienteRepository.BuscarEnderecosClientesCadastrados(), "Id", "Bairro", cliente.EnderecoId);
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Observacao,EnderecoId")] Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if(await ClienteExists(id))
                        _clienteRepository.Atualizar(cliente);
                        
                    await _contexto.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!(await ClienteExists(cliente.Id)))
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
            ViewData["EnderecoId"] = new SelectList(await _clienteRepository.BuscarEnderecosClientesCadastrados(), "Id", "Bairro", cliente.EnderecoId);
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var cliente = await _clienteRepository.BuscarComEndereco(id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = await _clienteRepository.Buscar(id);
            if(cliente != null ){
                _clienteRepository.Deletar(cliente);
                await _contexto.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ClienteExists(int id) => await _clientesQuery.ClienteJaCadastrado(id);
    }
}
