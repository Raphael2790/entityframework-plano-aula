using System.Threading.Tasks;
using Entity.Clientes.Application.Events;
using Entity.Core.Messages;

namespace Entity.Clientes.Application.Handlers
{
    public class ClienteEventoHandler : INotificacaoHandler<ClienteCadastradoEvento>
    {
        public Task Handle(ClienteCadastradoEvento evento)
        {
            //Mandar um email de boa vindas?
            return Task.CompletedTask;
        }
    }
}