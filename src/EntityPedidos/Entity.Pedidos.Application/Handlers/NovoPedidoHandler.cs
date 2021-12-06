using System;
using System.Threading.Tasks;
using Entity.Core.Handlers;
using Entity.Pedidos.Application.Commands;
using Entity.Pedidos.Domain.Entidades;
using Entity.Pedidos.Domain.Repositories;

namespace Entity.Pedidos.Application.Handlers
{
    public class NovoPedidoHandler : IRequestHandler<NovoPedidoComando>
    {
        private readonly IPedidosRepository _pedidosRepository;
        public NovoPedidoHandler(IPedidosRepository pedidoRepository)
        {
            _pedidosRepository = pedidoRepository;
        }

        public async Task Handle(NovoPedidoComando comando)
        {
            var pedido = new Pedido
            {
                Codigo = comando.Codigo,
                Desconto = comando.Desconto,
                ClienteId = comando.ClienteId,
                CupomDescontoId = comando.CupomDescontoId,
                EnderecoId = comando.EnderecoId,
                ValorTotal = comando.ValorTotal,
                PedidoStatus = comando.PedidoStatus,
                Data = DateTime.Now
            };
            _pedidosRepository.Adicionar(pedido);
            await _pedidosRepository.UnitOfWork.Commit();
        }
    }
}