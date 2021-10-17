using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Produtos.Domain.Entidades
{
    [Table("categorias")]
    public class Categoria
    {
        public int Id { get; set; }
        public string Descricao {get;set;}
        
        public virtual List<Produto> Produtos {get;set;} 
    }
}