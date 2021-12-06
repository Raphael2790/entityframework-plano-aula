using Entity.Core.Messages;
using Entity.Core.Messages.IntegrationMessages;
using System.Threading.Tasks;
using Entity.Produtos.Application.Events;

namespace Entity.Produtos.Application.Handlers
{
    public class ProdutosPedidosEventoHandler : INotificacaoHandler<PedidoAprovadoEvento>
    {
        public Task Handle(PedidoAprovadoEvento evento)
        {
            //Talvez reservar o estoque ou encaminhar notificação para transportadora
            return Task.CompletedTask;
        }

        public Task Handle(EstoqueBaixoEvento evento)
        {
            //Talvez reservar o estoque ou encaminhar notificação para transportadora
            return Task.CompletedTask;
        }
    }
}