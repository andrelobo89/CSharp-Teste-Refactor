using Imposto.ApplicationService;
using Imposto.Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Imposto.UnitTest
{
    [TestClass]
    public class NotaFiscalUnitTest
    {
        /// <summary>
        /// Método de teste do método que persiste a nota fiscal no banco de dados e a geração do arquivo XML.
        /// </summary>
        [TestMethod]
        public void TestGerarNotaFiscal()
        {
            INotaFiscalApplicationService _INotaFiscalApplicationService = new NotaFiscalApplicationService();

            Pedido pedido = new Pedido()
            {
                NomeCliente = "Cliente Teste",
                EstadoOrigem = "SP",
                EstadoDestino = "MG"
            };

            pedido.ItensDoPedido.Add(new PedidoItem()
            {
                CodigoProduto = "001",
                NomeProduto = "Produto Teste",
                ValorItemPedido = 1050.00,
                Brinde = false
            });

            pedido.ItensDoPedido.Add(new PedidoItem()
            {
                CodigoProduto = "001",
                NomeProduto = "Produto Teste",
                ValorItemPedido = 1050.00,
                Brinde = true
            });

            _INotaFiscalApplicationService.GerarNotaFiscal(pedido);
        }
    }
}
