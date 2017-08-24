using Imposto.Core.Models;

namespace Imposto.Core.Domain.Services
{
    public interface INotaFiscalService
    {
        void EmitirNotaFiscal(Pedido pedido);
    }
}
