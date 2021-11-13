using System.Collections.Generic;
using System.Threading.Tasks;
using Entity.Clientes.Domain.Entidades;
using Entity.Clientes.Domain.Interfaces.Repositories;
using Entity.Clientes.Data.Contexto;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Entity.Clientes.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ClienteDbContexto _contexto;
        public ClienteRepository(ClienteDbContexto contexto)
        {
            _contexto = contexto;
        }

        public void Atualizar(Cliente cliente) => _contexto.Clientes.Update(cliente);

        public async Task<Cliente> BuscarComEndereco(int id) => 
            await _contexto.Clientes.Include(x => x.Endereco).FirstOrDefaultAsync(x => x.Id == id);

        public async Task<Cliente> Buscar(int id) => await _contexto.Clientes.FindAsync(id);

        public async Task<IEnumerable<Cliente>> BuscarTodosComEndereco() =>
            await _contexto.Clientes.Include(x => x.Endereco).ToListAsync();

        public void Deletar(Cliente cliente) => _contexto.Clientes.Remove(cliente);

        public async Task Salvar(Cliente cliente) => await _contexto.Clientes.AddAsync(cliente);

        public async Task<IEnumerable<Cliente>> BuscarTodosCujoNomeContenhaLetras(IEnumerable<char> letras) {
            var query = _contexto.Clientes;
            if(letras.Any())
            foreach (var letra in letras)
                query.Where(x => x.Nome.ToLower().Contains(letra));

            return await query.ToListAsync();
        }
            

        public async Task<IEnumerable<Endereco>> BuscarEnderecosClientesCadastrados() => await _contexto.Enderecos.ToListAsync();

        public async Task<bool> ClienteJaCadastrado(int id) => await _contexto.Clientes.AnyAsync(x => x.Id == id);
    }
}