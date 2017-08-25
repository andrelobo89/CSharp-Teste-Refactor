using Imposto.Core.Models;

namespace Imposto.ApplicationService
{
    public interface INotaFiscalApplicationService
    {
        /// <summary>
        /// Método responsável por persistir a nota fiscal no banco de dados e no arquivo XML.
        /// </summary>
        /// <param name="pedido"></param>
        void GerarNotaFiscal(Pedido pedido);
    }
}
