using Entity.Core.Messages;

namespace Entity.Produtos.Application.Events
{
    public class EstoqueBaixoEvento : Evento
    {
        public EstoqueBaixoEvento(int id, string nome, double valor, int categoriaId, int fornecedorId)
        {
            Id = id;
            Nome = nome;
            Valor = valor;
            CategoriaId = categoriaId;
            FornecedorId = fornecedorId;
        }

        //Dados do produto que está com estoque baixo
        public int Id { get;}
        public string Nome { get; }
        public double Valor { get; }
        public int CategoriaId { get;  }
        public int FornecedorId { get;  }
    }
}