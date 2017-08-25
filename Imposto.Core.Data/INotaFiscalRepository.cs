using Imposto.Core.Models;

namespace Imposto.Core.Data
{
    public interface INotaFiscalRepository
    {
        /// <summary>
        /// Persiste no banco de dados informações de uma nota fiscal.
        /// </summary>
        /// <param name="notaFiscal"></param>
        /// <returns></returns>
        int GravarNotaFiscal(NotaFiscal notaFiscal);

        /// <summary>
        /// Persiste no banco de dados informações.
        /// </summary>
        /// <param name="notaFiscalItem"></param>
        void GravarItemNotaFiscal(NotaFiscalItem notaFiscalItem);
    }
}
