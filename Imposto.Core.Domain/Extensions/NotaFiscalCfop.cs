namespace Imposto.Core.Domain.Extensions
{
    internal class NotaFiscalCfop
    {
        public string AplicarCfop(string estadoOrigem, string estadoDestino)
        {
            if (estadoOrigem == "SP")
            {
                switch (estadoDestino)
                {
                    case "RJ":
                        return "6.000";
                        
                    case "PE":
                        return "6.001";

                    case "MG":
                        return "6.002";

                    case "PB":
                        return "6.003";

                    case "PR":
                        return "6.004";

                    case "PI":
                        return "6.005";

                    case "RO":
                        return "6.006";

                    case "TO":
                        return "6.008";

                    case "SE":
                        return "6.009";

                    case "PA":
                        return "6.010";

                    default:
                        return "0";
                }
            }
            else if (estadoOrigem == "MG")
            {
                switch (estadoDestino)
                {
                    case "RJ":
                        return "6.000";

                    case "PE":
                        return "6.001";

                    case "MG":
                        return "6.002";

                    case "PB":
                        return "6.003";

                    case "PR":
                        return "6.004";

                    case "PI":
                        return "6.005";

                    case "RO":
                        return "6.006";

                    case "SE":
                        return "6.007";

                    case "TO":
                        return "6.008";

                    case "PA":
                        return "6.010";

                    default:
                        return "0";                                
                }
            }
            else
            {
                return "0";
            }
        }
    }
}
