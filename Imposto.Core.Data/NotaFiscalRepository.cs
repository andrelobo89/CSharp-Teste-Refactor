using System;
using System.Data;
using System.Data.SqlClient;
using Imposto.Core.Data.Connection;
using Imposto.Core.Models;

namespace Imposto.Core.Data
{
    /// <summary>
    /// Classe responsável por fazer a persistência de NotaFiscal
    /// </summary>
    public class NotaFiscalRepository : INotaFiscalRepository
    {
        #region Public Methods

        /// <summary>
        /// Persiste no banco de dados informações de uma nota fiscal.
        /// </summary>
        /// <param name="notaFiscal"></param>
        /// <returns></returns>
        public int GravarNotaFiscal(NotaFiscal notaFiscal)
        {
            string procedureName = "P_NOTA_FISCAL";

            using (var connection = new SqlConnection(ConnectionManager.GetConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(procedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = 60;

                    var id = new SqlParameter("@pId", notaFiscal.Id);
                    id.Direction = ParameterDirection.InputOutput;

                    command.Parameters.Add(id);
                    command.Parameters.Add(new SqlParameter("@pNumeroNotaFiscal ", notaFiscal.NumeroNotaFiscal));
                    command.Parameters.Add(new SqlParameter("@pSerie", notaFiscal.Serie));
                    command.Parameters.Add(new SqlParameter("@pNomeCliente", notaFiscal.NomeCliente));
                    command.Parameters.Add(new SqlParameter("@pEstadoDestino", notaFiscal.EstadoDestino));
                    command.Parameters.Add(new SqlParameter("@pEstadoOrigem", notaFiscal.EstadoOrigem));

                    command.ExecuteNonQuery();

                    return Convert.ToInt32(command.Parameters["@pId"].Value);
                }
            }            
        }

        /// <summary>
        /// Persiste no banco de dados informações.
        /// </summary>
        /// <param name="notaFiscalItem"></param>
        public void GravarItemNotaFiscal(NotaFiscalItem notaFiscalItem)
        {
            string procedureName = "P_NOTA_FISCAL_ITEM";

            using (var connection = new SqlConnection(ConnectionManager.GetConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(procedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = 60;

                    command.Parameters.Add(new SqlParameter("@pId", notaFiscalItem.Id));
                    command.Parameters.Add(new SqlParameter("@pIdNotaFiscal", notaFiscalItem.IdNotaFiscal));
                    command.Parameters.Add(new SqlParameter("@pCfop", notaFiscalItem.Cfop));
                    command.Parameters.Add(new SqlParameter("@pTipoIcms", notaFiscalItem.TipoIcms));
                    command.Parameters.Add(new SqlParameter("@pBaseIcms", notaFiscalItem.BaseIcms));
                    command.Parameters.Add(new SqlParameter("@pAliquotaIcms", notaFiscalItem.AliquotaIcms));
                    command.Parameters.Add(new SqlParameter("@pValorIcms", notaFiscalItem.ValorIcms));
                    command.Parameters.Add(new SqlParameter("@pBaseIpi", notaFiscalItem.BaseIpi));
                    command.Parameters.Add(new SqlParameter("@pAliquotaIpi", notaFiscalItem.AliquotaIpi));
                    command.Parameters.Add(new SqlParameter("@pValorIpi", notaFiscalItem.ValorIpi));
                    command.Parameters.Add(new SqlParameter("@pNomeProduto", notaFiscalItem.NomeProduto));
                    command.Parameters.Add(new SqlParameter("@pCodigoProduto", notaFiscalItem.CodigoProduto));
                    command.Parameters.Add(new SqlParameter("@pDesconto", notaFiscalItem.Desconto));

                    command.ExecuteNonQuery();
                }
            }
        }

        #endregion
    }
}
