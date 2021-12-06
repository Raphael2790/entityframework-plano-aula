using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Entity.Core.Messages;
using Entity.Core.Handlers;

namespace Entity.Core.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        public List<object> EventoHandlers { get; private set; }
        public List<object> ComandoHandlers { get; private set; }

        public MediatorHandler()
        {
            EventoHandlers = new List<object>();
            ComandoHandlers = new List<object>();
        }
        public Task PublicarEvento<T>(T evento) where T : INotificacao
        {
            var handlers = EventoHandlers.Where(x => x.GetType().GetInterfaces().Any(x => x.FullName.Contains(evento.GetType().Name)));
            
            foreach (var handler in handlers)
            {
                var notificationHandler = (INotificacaoHandler<T>)handler;
                notificationHandler.Handle(evento);
            }

            return Task.CompletedTask;
        }

        public Task RegistrarEventHandler<T>(INotificacaoHandler<T> handler) where T : INotificacao 
        {
            EventoHandlers.Add(handler);
            return Task.CompletedTask;
        }

        public Task RegistrarCommandHandler<T>(IRequestHandler<T> handler) where T : IRequest
        {
            ComandoHandlers.Add(handler);
            return Task.CompletedTask;
        }

        public Task EnviarComando<T>(T comando) where T : IRequest
        {
            var handlers = ComandoHandlers.Where(x => x.GetType().GetInterfaces().Any(x => x.FullName.Contains(comando.GetType().Name)));
            
            foreach (var handler in handlers)
            {
                var notificationHandler = (IRequestHandler<T>)handler;
                notificationHandler.Handle(comando);
            }

            return Task.CompletedTask;
        }
    }
}