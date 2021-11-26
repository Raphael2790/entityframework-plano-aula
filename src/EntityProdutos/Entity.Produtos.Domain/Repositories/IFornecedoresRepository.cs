using System.Collections.Generic;
using System.Threading.Tasks;
using Entity.Produtos.Domain.Entidades;

namespace Entity.Produtos.Domain.Repositories
{
    public interface IFornecedoresRepository
    {
         IUnitOfWork UnitOfWork { get;}

        Task<IEnumerable<Fornecedor>> BuscarTodos();
        Task<Fornecedor> Buscar(int id);
        void Adicionar(Fornecedor fornecedor);
        void Deletar(Fornecedor fornecedor);
        void Atualizar(Fornecedor fornecedor);
        Task<IEnumerable<Endereco>> BuscarEnderecos();
        Task<bool> FornecedorExiste(int id);
    }
}