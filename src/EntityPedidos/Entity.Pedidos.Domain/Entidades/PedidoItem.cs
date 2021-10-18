//problema ao criar via scaffold em diferentes projetos
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Pedidos.Domain.Entidades
{
    [Table("pedido_itens")]
    public class PedidoItem
    {
        public int PedidoItemId {get;set;}
        public int PedidoId {get;set;}
        public int ProdutoId {get;set;}
        public string NomeProduto {get;set;}
        public int Quantidade {get;set;}
        public decimal ValorUnitario { get; set; }

        //EF Relacionamento
        public virtual Pedido Pedido {get;set;}
    }
}