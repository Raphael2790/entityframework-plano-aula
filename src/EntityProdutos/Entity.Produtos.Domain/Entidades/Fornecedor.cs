using System.Collections.Generic;

namespace Entity.Produtos.Domain.Entidades
{
    public class Fornecedor
    {
        public int Id {get;set;}
        public string Nome { get; set; }
        public string DocumentoIdentificacao { get; set; }
        public TipoFornecedor TipoFornecedor {get;set;}
        public bool Ativo { get; set; }

        public virtual List<Produto> Produtos {get;set;}
        public virtual Endereco Endereco {get;set;}
    }

    public enum TipoFornecedor 
    {
        PessoaJuridica = 0, 
        PessoaFisica = 1
    }
}