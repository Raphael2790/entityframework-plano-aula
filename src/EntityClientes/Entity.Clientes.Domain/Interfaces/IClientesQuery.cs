using System.Collections.Generic;
using System.Threading.Tasks;
using Entity.Clientes.Domain.Entidades;

namespace Entity.Clientes.Domain.Interfaces
{
    public interface IClientesQuery
    {
         Task<IEnumerable<Cliente>> BuscarTodosComEndereco();
        Task<Cliente> Buscar(int id);
        Task<IEnumerable<Cliente>> BuscarTodosCujoNomeContenhaLetras(IEnumerable<char> letras);
        Task<Cliente> BuscarComEndereco(int id);
        Task<bool> ClienteJaCadastrado(int id);
    }
}