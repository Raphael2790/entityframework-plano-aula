using System.Collections.Generic;
using System.Threading.Tasks;
using Entity.Core.Messages;

namespace Entity.Core.Mediator
{
    public interface IMediatorHandler
    {
        Task PublicarEvento<T>(T evento) where T : INotificacao;
        Task RegistrarEventHandler<T>(INotificacaoHandler<T> handler) where T : INotificacao;
    }
}