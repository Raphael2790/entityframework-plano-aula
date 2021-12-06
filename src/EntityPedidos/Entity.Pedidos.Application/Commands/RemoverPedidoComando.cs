using Entity.Core.Messages;

namespace Entity.Pedidos.Application.Commands
{
    public class RemoverPedidoComando : Comando
    {
        public int PedidoId { get; set; }
    }
}