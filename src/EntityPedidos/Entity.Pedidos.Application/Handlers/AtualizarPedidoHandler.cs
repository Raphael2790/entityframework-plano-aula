using System;
using System.Threading.Tasks;
using Entity.Core.Handlers;
using Entity.Pedidos.Application.Commands;
using Entity.Pedidos.Domain.Entidades;
using Entity.Pedidos.Domain.Repositories;

namespace Entity.Pedidos.Application.Handlers
{
    public class AtualizarPedidoHandler: IRequestHandler<AtualizarPedidoComando>
    {
        private readonly IPedidosRepository _pedidosRepository;
        public AtualizarPedidoHandler(IPedidosRepository pedidoRepository)
        {
            _pedidosRepository = pedidoRepository;
        }

        public async Task Handle(AtualizarPedidoComando comando)
        {
            var pedidoExiste = await _pedidosRepository.PedidoExiste(comando.PedidoId);

            if(pedidoExiste)
                throw new Exception("Pedido já existe!");

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
            _pedidosRepository.Atualizar(pedido);
            await _pedidosRepository.UnitOfWork.Commit();
        }
    }
}