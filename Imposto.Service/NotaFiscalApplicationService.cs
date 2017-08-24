using Imposto.Core.Domain;

namespace Imposto.ApplicationService
{
    public class NotaFiscalService : INotaFiscalService
    {
        #region Variables

        private NotaFiscal _notaFiscal;

        #endregion

        #region Constructor

        public NotaFiscalService()
        {
            NotaFiscal _notaFiscal = new NotaFiscal();
        }

        #endregion

        #region Methods

        public void GerarNotaFiscal(Pedido pedido)
        {            
            _notaFiscal.EmitirNotaFiscal(pedido);            
        }

        #endregion
    }
}
