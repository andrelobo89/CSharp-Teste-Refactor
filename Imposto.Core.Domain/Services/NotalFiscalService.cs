using Microsoft.Win32;
using System;

namespace Imposto.Core.Domain.Services
{
    public class NotalFiscalService
    {
        public void EmitirNotaFiscal(Pedido pedido)
        {
            var notaFiscal = new NotaFiscal();

            notaFiscal.NumeroNotaFiscal = 99999;
            notaFiscal.Serie = new Random().Next(Int32.MaxValue);
            notaFiscal.NomeCliente = pedido.NomeCliente;
            notaFiscal.EstadoDestino = pedido.EstadoOrigem;
            notaFiscal.EstadoOrigem = pedido.EstadoDestino;

            foreach (PedidoItem itemPedido in pedido.ItensDoPedido)
            {
                NotaFiscalItem notaFiscalItem = new NotaFiscalItem();

                if ((notaFiscal.EstadoOrigem == "SP") && (notaFiscal.EstadoDestino == "RJ"))
                {
                    notaFiscalItem.Cfop = "6.000";
                }
                else if ((notaFiscal.EstadoOrigem == "SP") && (notaFiscal.EstadoDestino == "PE"))
                {
                    notaFiscalItem.Cfop = "6.001";
                }
                else if ((notaFiscal.EstadoOrigem == "SP") && (notaFiscal.EstadoDestino == "MG"))
                {
                    notaFiscalItem.Cfop = "6.002";
                }
                else if ((notaFiscal.EstadoOrigem == "SP") && (notaFiscal.EstadoDestino == "PB"))
                {
                    notaFiscalItem.Cfop = "6.003";
                }
                else if ((notaFiscal.EstadoOrigem == "SP") && (notaFiscal.EstadoDestino == "PR"))
                {
                    notaFiscalItem.Cfop = "6.004";
                }
                else if ((notaFiscal.EstadoOrigem == "SP") && (notaFiscal.EstadoDestino == "PI"))
                {
                    notaFiscalItem.Cfop = "6.005";
                }
                else if ((notaFiscal.EstadoOrigem == "SP") && (notaFiscal.EstadoDestino == "RO"))
                {
                    notaFiscalItem.Cfop = "6.006";
                }
                else if ((notaFiscal.EstadoOrigem == "SP") && (notaFiscal.EstadoDestino == "SE"))
                {
                    notaFiscalItem.Cfop = "6.007";
                }
                else if ((notaFiscal.EstadoOrigem == "SP") && (notaFiscal.EstadoDestino == "TO"))
                {
                    notaFiscalItem.Cfop = "6.008";
                }
                else if ((notaFiscal.EstadoOrigem == "SP") && (notaFiscal.EstadoDestino == "SE"))
                {
                    notaFiscalItem.Cfop = "6.009";
                }
                else if ((notaFiscal.EstadoOrigem == "SP") && (notaFiscal.EstadoDestino == "PA"))
                {
                    notaFiscalItem.Cfop = "6.010";
                }
                else if ((notaFiscal.EstadoOrigem == "MG") && (notaFiscal.EstadoDestino == "RJ"))
                {
                    notaFiscalItem.Cfop = "6.000";
                }
                else if ((notaFiscal.EstadoOrigem == "MG") && (notaFiscal.EstadoDestino == "PE"))
                {
                    notaFiscalItem.Cfop = "6.001";
                }
                else if ((notaFiscal.EstadoOrigem == "MG") && (notaFiscal.EstadoDestino == "MG"))
                {
                    notaFiscalItem.Cfop = "6.002";
                }
                else if ((notaFiscal.EstadoOrigem == "MG") && (notaFiscal.EstadoDestino == "PB"))
                {
                    notaFiscalItem.Cfop = "6.003";
                }
                else if ((notaFiscal.EstadoOrigem == "MG") && (notaFiscal.EstadoDestino == "PR"))
                {
                    notaFiscalItem.Cfop = "6.004";
                }
                else if ((notaFiscal.EstadoOrigem == "MG") && (notaFiscal.EstadoDestino == "PI"))
                {
                    notaFiscalItem.Cfop = "6.005";
                }
                else if ((notaFiscal.EstadoOrigem == "MG") && (notaFiscal.EstadoDestino == "RO"))
                {
                    notaFiscalItem.Cfop = "6.006";
                }
                else if ((notaFiscal.EstadoOrigem == "MG") && (notaFiscal.EstadoDestino == "SE"))
                {
                    notaFiscalItem.Cfop = "6.007";
                }
                else if ((notaFiscal.EstadoOrigem == "MG") && (notaFiscal.EstadoDestino == "TO"))
                {
                    notaFiscalItem.Cfop = "6.008";
                }
                else if ((notaFiscal.EstadoOrigem == "MG") && (notaFiscal.EstadoDestino == "SE"))
                {
                    notaFiscalItem.Cfop = "6.009";
                }
                else if ((notaFiscal.EstadoOrigem == "MG") && (notaFiscal.EstadoDestino == "PA"))
                {
                    notaFiscalItem.Cfop = "6.010";
                }
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
                if (notaFiscalItem.Cfop == "6.009")
                {
                    notaFiscalItem.BaseIcms = itemPedido.ValorItemPedido * 0.90; //redução de base
                }
                else
                {
                    notaFiscalItem.BaseIcms = itemPedido.ValorItemPedido;
                }
                notaFiscalItem.ValorIcms = notaFiscalItem.BaseIcms * notaFiscalItem.AliquotaIcms;

                if (itemPedido.Brinde)
                {
                    notaFiscalItem.TipoIcms = "60";
                    notaFiscalItem.AliquotaIcms = 0.18;
                    notaFiscalItem.ValorIcms = notaFiscalItem.BaseIcms * notaFiscalItem.AliquotaIcms;
                }
                notaFiscalItem.NomeProduto = itemPedido.NomeProduto;
                notaFiscalItem.CodigoProduto = itemPedido.CodigoProduto;
            }

            //grava xml
            //grava banco
        }

        private string Read(string KeyName)
        {
            string subKey = "SOFTWARE\\TESTEIMPOSTO";

            RegistryKey rk = Registry.LocalMachine;
            RegistryKey sk1 = rk.OpenSubKey(subKey);

            if (sk1 == null)
            {
                return null;
            }
            else
            {
                try
                {
                    return (string)sk1.GetValue(KeyName.ToUpper());
                }
                catch (Exception e)
                {
                    //ShowErrorMessage(e, "Reading registry " + KeyName.ToUpper());
                    return null;
                }
            }
        }
    }
}
