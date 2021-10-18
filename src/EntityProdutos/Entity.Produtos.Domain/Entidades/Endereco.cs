using System;
using System.Collections.Generic;

#nullable disable

namespace Entity.Produtos.Domain.Entidades
{
    public partial class Endereco
    {
        public Endereco()
        {
            Fornecedores = new HashSet<Fornecedor>();
        }

        public int Id { get; set; }
        public string Logradouro { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public virtual ICollection<Fornecedor> Fornecedores { get; set; }
    }
}
