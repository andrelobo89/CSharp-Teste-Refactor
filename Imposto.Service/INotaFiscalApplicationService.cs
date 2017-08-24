using Imposto.Core.Models;

namespace Imposto.ApplicationService
{
    public interface INotaFiscalApplicationService
    {
        void GerarNotaFiscal(Pedido pedido);
    }
}
