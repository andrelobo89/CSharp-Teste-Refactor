using Imposto.Core.Models;

namespace Imposto.Core.Domain.Services
{
    public interface INotaFiscalService
    {
        /// <summary>
        /// Método que persiste a nota fiscal no banco de dados e gera seu xml. Contém toda a regra de negócio da nota fiscal.
        /// </summary>
        /// <param name="pedido"></param>
        void EmitirNotaFiscal(Pedido pedido);
    }
}
