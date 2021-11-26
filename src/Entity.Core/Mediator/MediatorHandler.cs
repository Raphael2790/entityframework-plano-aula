using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Entity.Core.Messages;

namespace Entity.Core.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        public List<object> Handlers { get; private set; }

        public MediatorHandler()
        {
            Handlers = new List<object>();
        }
        public Task PublicarEvento<T>(T evento) where T : INotificacao
        {
            var handlers = Handlers.Where(x => x.GetType().GetInterfaces().Any(x => x.FullName.Contains(evento.GetType().Name)));
            
            foreach (var handler in handlers)
            {
                var notificationHandler = (INotificacaoHandler<T>)handler;
                notificationHandler.Handle(evento);
            }

            return Task.CompletedTask;
        }

        public Task RegistrarEventHandler<T>(INotificacaoHandler<T> handler) where T : INotificacao 
        {
            Handlers.Add(handler);
            return Task.CompletedTask;
        } 
    }
}