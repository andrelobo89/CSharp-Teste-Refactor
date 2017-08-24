using Imposto.Core.Domain;

namespace Imposto.ApplicationService
{
    public interface INotaFiscalService
    {
        void GerarNotaFiscal(Pedido pedido);
    }
}
