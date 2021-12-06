using System;

namespace Entity.Core.Messages.IntegrationMessages
{
    public class PedidoAprovadoEvento : Evento
    {
        //Dados que são relevantes para um pedido aprovado
        public string Codigo {get;set;} //Código de rastreio do pedido
        public int ClienteId { get; set; }
        public int EnderecoId { get; set; } //Endereço de entrega do pedido
        public decimal Desconto {get;set;}
        public decimal ValorTotal { get; set; }
        public DateTime Data { get; set; }
    }
}