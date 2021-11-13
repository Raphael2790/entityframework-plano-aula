using System.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Entity.Clientes.Domain.Entidades;
using Entity.Clientes.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using MySqlConnector;

namespace Entity.Clientes.Data.Queries
{
    public class ClientesConsultas : IClientesQuery
    {
        private string _connectionString;
        public ClientesConsultas(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<Cliente> Buscar(int id)
        {
            var sql = @"SELECT * FROM clientes WHERE id = @clienteId";
            var parametros = new DynamicParameters();
            parametros.Add("clienteId", id);

            using(var connection = new MySqlConnection(_connectionString))
            {
                //return await connection.QueryFirstOrDefaultAsync<Cliente>(sql, new { clienteId = id });
                return await connection.QueryFirstOrDefaultAsync<Cliente>(sql, parametros, commandType : CommandType.Text);
            }
        }

        public Task<Cliente> BuscarComEndereco(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Cliente>> BuscarTodosComEndereco()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Cliente>> BuscarTodosCujoNomeContenhaLetras(IEnumerable<char> letras)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> ClienteJaCadastrado(int id)
        {
            var sql = @"SELECT 
                        CASE 
                            WHEN COUNT(1) > 0 THEN 1
                            ELSE 0
                        END
                        FROM clientes WHERE id = @clienteId";
            var parametros = new DynamicParameters();
            parametros.Add("clienteId", id);

            using(var connection = new MySqlConnection(_connectionString))
            {
                return (await connection.ExecuteScalarAsync<bool>(sql, parametros, commandType : CommandType.Text));
            }
        }
    }
}