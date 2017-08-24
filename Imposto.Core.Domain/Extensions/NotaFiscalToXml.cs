using System;
using System.IO;
using System.Xml.Serialization;
using Imposto.Core.Models;

namespace Imposto.Core.Domain.Extensions
{
    /// <summary>
    /// Classe responsável por Converter a nota em arquivo XML.
    /// </summary>
    internal static class NotaFiscalToXml
    {
        /// <summary>
        /// Método que serializa a classe nota fiscal e grava em XML.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="file"></param>
        public static bool SaveNotaFiscalXml(NotaFiscal notaFiscal)
        {
            try
            {
                string pathEnv = Environment.GetEnvironmentVariable("Path_Nota_Fiscal", EnvironmentVariableTarget.Machine);

                if (string.IsNullOrWhiteSpace(pathEnv))
                    pathEnv = "C:/NotasFiscais/";

                Directory.CreateDirectory(pathEnv);

                string file = pathEnv + "nota_fiscal_" + notaFiscal.NumeroNotaFiscal + ".xml";

                var serializer = new XmlSerializer(typeof(NotaFiscal));

                using (var writer = new StreamWriter(file))
                {
                    serializer.Serialize(writer, notaFiscal);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
