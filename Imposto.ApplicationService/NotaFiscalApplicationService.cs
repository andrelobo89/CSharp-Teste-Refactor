using System;
using Imposto.Core.Models;
using Imposto.Core.Domain.Services;

namespace Imposto.ApplicationService
{
    public class NotaFiscalApplicationService : INotaFiscalApplicationService
    {
        #region Variables

        private INotaFiscalService _notaFiscalService;

        #endregion

        #region Constructor

        public NotaFiscalApplicationService()
        {
            _notaFiscalService = new NotalFiscalService();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Método responsável por persistir a nota fiscal no banco de dados e no arquivo XML.
        /// </summary>
        /// <param name="pedido"></param>
        public void GerarNotaFiscal(Pedido pedido)
        {
            try
            {
                _notaFiscalService.EmitirNotaFiscal(pedido);
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        #endregion
    }
}
