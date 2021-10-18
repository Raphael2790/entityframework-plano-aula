using System.Collections.Generic;
using System;
using Entity.Pedidos.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Pedidos.Domain.Entidades
{
    [Table("cupons_descontos")]
    public class CupomDesconto
    {
        public CupomDesconto()
        {
            Pedidos = new HashSet<Pedido>();
        }
        public int CupomDescontoId {get;set;}
        public string CodigoCupom { get; set; }
        public decimal? PercentualDesconto { get; set; }
        public decimal? ValorDesconto {get;set;}
        public int Quantidade {get;set;} //quantidade de cupons disponiveis para serem aplicados
        public TipoCupomDesconto TipoCupomDesconto {get;set;}
        public DateTime CriadoEm {get;set;}
        public DateTime AplicadoEm {get;set;}
        public DateTime DataExpiracao {get;set;}
        public bool Ativo {get;set;}
        public bool Aplicado {get;set;}

        //EF Relacionamento
        public virtual ICollection<Pedido> Pedidos {get;set;} 
    }
}