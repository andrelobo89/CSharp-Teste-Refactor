using System;
using Imposto.Core.Models;
using Imposto.Core.Data;
using Imposto.Core.Domain.Extensions;

namespace Imposto.Core.Domain.Services
{
    public class NotalFiscalService : INotaFiscalService
    {
        #region Variables

        private INotaFiscalRepository _INotaFiscalRepository;
        private INotaFiscalItemRepository _INotaFiscalItemRepository;

        #endregion

        #region Constructor

        public NotalFiscalService()
        {
            _INotaFiscalRepository = new NotaFiscalRepository();
            _INotaFiscalItemRepository = new NotaFiscalItemRepository();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Método que persiste a nota fiscal no banco de dados e gera seu xml. Contém toda a regra de negócio da nota fiscal.
        /// </summary>
        /// <param name="pedido">Classe pedido com as informações da nota fiscal.</param>
        public void EmitirNotaFiscal(Pedido pedido)
        {
            var notaFiscal = new NotaFiscal();
            notaFiscal.NumeroNotaFiscal = new Random().Next(Int32.MaxValue);
            notaFiscal.Serie = new Random().Next(Int32.MaxValue);
            notaFiscal.NomeCliente = pedido.NomeCliente;
            notaFiscal.EstadoOrigem = pedido.EstadoOrigem;
            notaFiscal.EstadoDestino = pedido.EstadoDestino;            

            foreach (PedidoItem itemPedido in pedido.ItensDoPedido)
            {
                NotaFiscalItem notaFiscalItem = new NotaFiscalItem();

                /* Aplicação do Cfop */
                var notaFiscalCfop = new NotaFiscalCfop();
                notaFiscalItem.Cfop = notaFiscalCfop.AplicarCfop(pedido.EstadoOrigem, pedido.EstadoDestino);

                /* ICMS */
                if (notaFiscal.EstadoDestino == notaFiscal.EstadoOrigem)
                {
                    notaFiscalItem.TipoIcms = "60";
                    notaFiscalItem.AliquotaIcms = 0.18;
                }
                else
                {
                    notaFiscalItem.TipoIcms = "10";
                    notaFiscalItem.AliquotaIcms = 0.17;
                }

                /* Redução de base */
                if (notaFiscalItem.Cfop == "6.009")
                {
                    notaFiscalItem.BaseIcms = itemPedido.ValorItemPedido * 0.90; 
                }
                else
                {
                    notaFiscalItem.BaseIcms = itemPedido.ValorItemPedido;
                }

                notaFiscalItem.ValorIcms = notaFiscalItem.BaseIcms * notaFiscalItem.AliquotaIcms;
                notaFiscalItem.BaseIpi = itemPedido.ValorItemPedido;

                if (itemPedido.Brinde)
                {
                    notaFiscalItem.TipoIcms = "60";
                    notaFiscalItem.AliquotaIcms = 0.18;
                    notaFiscalItem.ValorIcms = notaFiscalItem.BaseIcms * notaFiscalItem.AliquotaIcms;
                    notaFiscalItem.AliquotaIpi = 0;
                }
                else
                {
                    notaFiscalItem.AliquotaIpi = 0.1;
                }

                notaFiscalItem.ValorIpi = notaFiscalItem.BaseIpi * notaFiscalItem.AliquotaIpi;                
                notaFiscalItem.NomeProduto = itemPedido.NomeProduto;
                notaFiscalItem.CodigoProduto = itemPedido.CodigoProduto;

                /* Aplicação da regra de negócio do Desconto */
                var desconto = new NotaFiscalDesconto();
                notaFiscalItem.Desconto = desconto.AplicarDesconto(notaFiscal.EstadoDestino);

                notaFiscal.ItensDaNotaFiscal.Add(notaFiscalItem);
            }

            try
            {
                /* Persistência no XML */
                if (NotaFiscalToXml.SaveNotaFiscalXml(notaFiscal))
                {
                    /* Persistência no Banco de Dados */
                    int idNota = _INotaFiscalRepository.GravarNotaFiscal(notaFiscal);
                    foreach (var item in notaFiscal.ItensDaNotaFiscal)
                    {
                        item.IdNotaFiscal = idNota;
                        _INotaFiscalItemRepository.GravarItemNotaFiscal(item);
                    }
                }                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion        
    }
}
