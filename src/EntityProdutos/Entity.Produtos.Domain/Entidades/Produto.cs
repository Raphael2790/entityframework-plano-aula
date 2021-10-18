using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Entity.Produtos.Domain.Entidades
{
    [Table("produtos")]
    public partial class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string UrlImagem { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }

        public virtual Categoria Categoria {get;set;}
    }
}
