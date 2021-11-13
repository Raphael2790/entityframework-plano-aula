using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entity.Clientes.Domain.Entidades;

namespace Entity.Clientes.Domain.Interfaces.Repositories
{
    public interface IClienteRepository : IClientesQuery
    {
        Task Salvar(Cliente cliente);
        void Atualizar(Cliente cliente);
        void Deletar(Cliente cliente);
        Task<IEnumerable<Endereco>> BuscarEnderecosClientesCadastrados();
    }
}