using System;
using System.IO;
using System.Xml.Serialization;
using Imposto.Core.Models;
using Microsoft.Win32;

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
                string path = "C:/NotasFiscais/";
                //string path = GetNotaFiscalPath();                
                Directory.CreateDirectory(path);

                string file = path + "nota_fiscal_" + notaFiscal.NumeroNotaFiscal + ".xml";

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

        /// <summary>
        /// Método que retorna o caminho onde é salvo as notas fiscais em XML.
        /// </summary>
        /// <returns></returns>
        private static string GetNotaFiscalPath()
        {
            RegistryKey rk = Registry.LocalMachine;
            RegistryKey sk1 = rk.OpenSubKey("SOFTWARE\\TesteImposto");

            if (sk1 == null)
            {
                throw new Exception("Por favor, solicitar a configuração do diretório de notas fiscais.");
            }
            else
            {
                return (string)sk1.GetValue("Path_Nota_Fiscal");
            }
        }
    }
}
