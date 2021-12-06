using System.Collections.Generic;
using System.Threading.Tasks;
using Entity.Pedidos.Domain.Entidades;

namespace Entity.Pedidos.Application.Queries
{
    public interface IPedidosQueries
    {
        Task<IEnumerable<Pedido>> BuscarTodosComEndereco();
        Task<Pedido> Buscar(int id);
        Task<Pedido> BuscarComEndereco(int id);
        Task<IEnumerable<Endereco>> BuscarEnderecos();
        Task<bool> PedidoExiste(int id);
    }
}