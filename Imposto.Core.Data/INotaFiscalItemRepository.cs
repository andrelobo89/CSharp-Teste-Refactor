using Imposto.Core.Models;

namespace Imposto.Core.Data
{
    public interface INotaFiscalItemRepository
    {
        void GravarItemNotaFiscal(NotaFiscalItem notaFiscalItem);
    }
}
