using System.Collections.Generic;
using System.Threading.Tasks;
using Entity.Core.Handlers;
using Entity.Core.Messages;

namespace Entity.Core.Mediator
{
    public interface IMediatorHandler
    {
        Task PublicarEvento<T>(T evento) where T : INotificacao;
        Task RegistrarEventHandler<T>(INotificacaoHandler<T> handler) where T : INotificacao;
        Task RegistrarCommandHandler<T>(IRequestHandler<T> handler) where T : IRequest;
        Task EnviarComando<T>(T comando) where T : IRequest;
    }
}