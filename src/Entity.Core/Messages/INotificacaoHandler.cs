using System.Threading.Tasks;

namespace Entity.Core.Messages
{
    public interface INotificacaoHandler<T> where T : INotificacao
    {
        Task Handle(T evento);
    }
}