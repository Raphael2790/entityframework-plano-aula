using System.Threading.Tasks;
using Entity.Core.Messages;
using Entity.Produtos.Application.Events;

namespace Entity.Produtos.Application.Handlers
{
    public class ProdutosEstoqueBaixoHandler : INotificacaoHandler<EstoqueBaixoEvento>
    {
        //Enviar um email solicitando cotação ou um pedido padrão
        public Task Handle(EstoqueBaixoEvento evento)
        {
            throw new System.NotImplementedException();
        }
    }
}