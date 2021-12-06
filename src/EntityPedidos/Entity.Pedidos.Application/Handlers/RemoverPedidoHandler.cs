using System;
using System.Threading.Tasks;
using Entity.Core.Handlers;
using Entity.Pedidos.Application.Commands;
using Entity.Pedidos.Domain.Repositories;

namespace Entity.Pedidos.Application.Handlers
{
    public class RemoverPedidoHandler: IRequestHandler<RemoverPedidoComando>
    {
        private readonly IPedidosRepository _pedidosRepository;
        public RemoverPedidoHandler(IPedidosRepository pedidoRepository)
        {
            _pedidosRepository = pedidoRepository;
        }

        public async Task Handle(RemoverPedidoComando comando)
        {
            var pedido = await _pedidosRepository.Buscar(comando.PedidoId);

            if(pedido is null)
                throw new Exception("Pedido já foi removido ou não existe!");
                
            _pedidosRepository.Deletar(pedido);
            await _pedidosRepository.UnitOfWork.Commit();
        }
    }
}