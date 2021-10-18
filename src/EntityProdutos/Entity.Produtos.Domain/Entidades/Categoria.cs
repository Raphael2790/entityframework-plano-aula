using System;
using System.Collections.Generic;

#nullable disable

namespace Entity.Produtos.Domain.Entidades
{
    public partial class Categoria
    {
        public Categoria()
        {
            Produtos = new HashSet<Produto>();
        }

        public int Id { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
