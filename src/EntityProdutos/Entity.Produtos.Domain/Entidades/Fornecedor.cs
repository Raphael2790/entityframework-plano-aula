using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Produtos.Domain.Entidades
{
    public class Fornecedor
    {
        public int Id {get;set;}
        public string Nome { get; set; }
        public string DocumentoIdentificacao { get; set; }
        public bool Ativo { get; set; }
        [DisplayName("Tipo Fornecedor")]
        public TipoFornecedor TipoFornecedor {get;set;}
        public int EnderecoId { get; set; }

        //EF - Relacionamento
        public virtual List<Produto> Produtos {get;set;}
        public virtual Endereco Endereco {get;set;}

        public bool DocumentoIdentificacaoEhValido()
        {
            var documentoLimpo = DocumentoIdentificacao.Replace(".", "").Replace("-", "");
            return documentoLimpo.Length >= 11 || documentoLimpo.Length >= 14;
        }
    }
}