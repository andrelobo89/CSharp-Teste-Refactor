namespace Imposto.Core.Domain.Extensions
{
    /// <summary>
    /// Classe responsável por aplicar regras de desconto nos itens da nota fiscal.
    /// </summary>
    internal class NotaFiscalDesconto
    {
        /// <summary>
        /// Aplica o desconto para clientes da região sudeste.
        /// </summary>
        /// <param name="estadoDestino"></param>
        /// <returns></returns>
        public double AplicarDesconto(string estadoDestino)
        {
            if (estadoDestino == "SP" ||
                estadoDestino == "MG" ||
                estadoDestino == "RJ" ||
                estadoDestino == "ES")
            {
                return 0.1;
            }

            return 0;
        }
    }
}
