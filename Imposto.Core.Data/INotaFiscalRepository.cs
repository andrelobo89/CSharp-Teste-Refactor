using Imposto.Core.Models;

namespace Imposto.Core.Data
{
    public interface INotaFiscalRepository
    {
        int GravarNotaFiscal(NotaFiscal notaFiscal);
        void GravarItemNotaFiscal(NotaFiscalItem notaFiscalItem);
    }
}
