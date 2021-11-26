using System;
using Entity.Core.Messages;

namespace Entity.Clientes.Application.Events
{
    public class ClienteCadastradoEvento : Evento
    {
        public ClienteCadastradoEvento(int id, string nome, string observacao)
        {
            Id = id;
            Nome = nome;
            Observacao = observacao;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Observacao { get; set; }
    }
}