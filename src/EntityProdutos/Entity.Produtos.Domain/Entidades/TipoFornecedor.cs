using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Produtos.Domain.Entidades
{
    [Table("tipos_fornecedores")]
    public class TipoFornecedor 
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
    }
}