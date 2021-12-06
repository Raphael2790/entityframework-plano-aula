using System.Threading.Tasks;
using Entity.Core.Messages;

namespace Entity.Core.Handlers
{
    public interface IRequestHandler<T> where T : IRequest
    {
        Task Handle(T comando);
    }
}