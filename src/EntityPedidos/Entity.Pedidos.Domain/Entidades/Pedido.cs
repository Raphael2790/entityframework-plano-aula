using System.Collections;
using System;
using System.Collections.Generic;
using Entity.Pedidos.Domain.Enums;

#nullable disable

namespace Entity.Pedidos.Domain.Entidades
{
    public partial class Pedido
    {
        public Pedido()
        {
            PedidoItens = new HashSet<PedidoItem>();
        }

        public int Id { get; set; }
        public int Codigo {get;set;} //Código de rastreio do pedido
        public int ClienteId { get; set; }
        public int EnderecoId { get; set; } //Endereço de entrega do pedido
        public decimal Desconto {get;set;}
        public double ValorTotal { get; set; }
        public DateTime Data { get; set; }
        public int VoucherId {get;set;}
        public PedidoStatus PedidoStatus {get;set;}

        public virtual CupomDesconto CupomDesconto {get;set;}
        public virtual ICollection<PedidoItem> PedidoItens {get;set;}
        public virtual Endereco Endereco { get; set;}
    }
}
