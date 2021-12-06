using System.Collections.Generic;
using System.Threading.Tasks;
using Entity.Pedidos.Domain.Entidades;
using Entity.Pedidos.Domain.Repositories;

namespace Entity.Pedidos.Application.Queries
{
    public class PedidoQueries : IPedidosQueries
    {
        private readonly IPedidosRepository _pedidosRepository;

        public PedidoQueries(IPedidosRepository pedidosRepository)
        {
            _pedidosRepository = pedidosRepository;
        }

        public async Task<Pedido> Buscar(int id) => await _pedidosRepository.Buscar(id);

        public async Task<Pedido> BuscarComEndereco(int id) => await _pedidosRepository.BuscarComEndereco(id);

        public async Task<IEnumerable<Endereco>> BuscarEnderecos() => await _pedidosRepository.BuscarEnderecos();

        public async Task<IEnumerable<Pedido>> BuscarTodosComEndereco() => await _pedidosRepository.BuscarTodosComEndereco();

        public async Task<bool> PedidoExiste(int id) => await _pedidosRepository.PedidoExiste(id);
    }
}