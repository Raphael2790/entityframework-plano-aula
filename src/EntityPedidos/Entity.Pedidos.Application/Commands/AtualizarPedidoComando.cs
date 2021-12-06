using Entity.Core.Messages;
using Entity.Pedidos.Domain.Enums;

namespace Entity.Pedidos.Application.Commands
{
    public class AtualizarPedidoComando : Comando
    {
        public int PedidoId { get; set; }
        public string Codigo {get;set;} //Código de rastreio do pedido
        public int ClienteId { get; set; }
        public int EnderecoId { get; set; } //Endereço de entrega do pedido
        public decimal Desconto {get;set;}
        public decimal ValorTotal { get; set; }
        public int? CupomDescontoId {get;set;}
        public PedidoStatus PedidoStatus {get;set;}
    }
}