using System;
using System.Data;
using System.Windows.Forms;
using Imposto.Core.Models;
using Imposto.ApplicationService;

namespace TesteImposto
{
    public partial class FormImposto : Form
    {
        #region Variables

        private INotaFiscalApplicationService _INotaFiscalApplicationService;
        private Pedido pedido = new Pedido();

        #endregion

        #region Constructor

        public FormImposto()
        {
            InitializeComponent();

            _INotaFiscalApplicationService = new NotaFiscalApplicationService();

            CleanForm();
        }

        #endregion

        #region Control Events

        private void buttonGerarNotaFiscal_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                pedido.EstadoOrigem = cbxEstadoOrigem.SelectedItem.ToString();
                pedido.EstadoDestino = cbxEstadoDestino.SelectedItem.ToString();
                pedido.NomeCliente = textBoxNomeCliente.Text;

                DataTable table = (DataTable)dataGridViewPedidos.DataSource;

                foreach (DataRow row in table.Rows)
                {
                    pedido.ItensDoPedido.Add(
                        new PedidoItem()
                        {
                            NomeProduto = row["NomeProduto"].ToString(),
                            CodigoProduto = row["CodigoProduto"].ToString(),
                            Brinde = row["Brinde"].ToString() == "" ? false : true,
                            ValorItemPedido = Convert.ToDouble(row["Valor"].ToString())
                        });
                }

                try
                {
                    _INotaFiscalApplicationService.GerarNotaFiscal(pedido);                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro: " + ex.Message);
                    return;
                }

                MessageBox.Show("Operação efetuada com sucesso");
                CleanForm();
            }
        }

        private void buttonLimparFormulario_Click(object sender, EventArgs e)
        {
            CleanForm();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Organiza as colunas do grid de itens do pedido.
        /// </summary>
        private void ResizeColumns()
        {
            double mediaWidth = dataGridViewPedidos.Width / dataGridViewPedidos.Columns.GetColumnCount(DataGridViewElementStates.Visible);

            for (int i = dataGridViewPedidos.Columns.Count - 1; i >= 0; i--)
            {
                var coluna = dataGridViewPedidos.Columns[i];
                coluna.Width = Convert.ToInt32(mediaWidth);
            }
        }

        /// <summary>
        /// Cria o datatable para geração do grid de itens do pedido.
        /// </summary>
        /// <returns></returns>
        private object GetTablePedidos()
        {
            DataTable table = new DataTable("pedidos");
            table.Columns.Add(new DataColumn("NomeProduto", typeof(string)));
            table.Columns.Add(new DataColumn("CodigoProduto", typeof(string)));
            table.Columns.Add(new DataColumn("Valor", typeof(string)));
            table.Columns.Add(new DataColumn("Brinde", typeof(bool)));

            return table;
        }

        /// <summary>
        /// Limpa o formulário voltando ao seu estado inicial.
        /// </summary>
        private void CleanForm()
        {
            textBoxNomeCliente.Text = string.Empty;
            cbxEstadoOrigem.SelectedIndex = 0;
            cbxEstadoDestino.SelectedIndex = 0;

            dataGridViewPedidos.AutoGenerateColumns = true;
            dataGridViewPedidos.DataSource = GetTablePedidos();

            ResizeColumns();
        }

        /// <summary>
        /// Validação do formulário para ser executado antes de enviar as informações à Application Service.
        /// </summary>
        /// <returns></returns>
        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(textBoxNomeCliente.Text.ToString()))
            {
                MessageBox.Show("Preencha o nome do cliente.");
                return false;
            }

            if (cbxEstadoOrigem.SelectedIndex == 0)
            {
                MessageBox.Show("Selecione o estado de origem.");
                return false;
            }

            if (cbxEstadoDestino.SelectedIndex == 0)
            {
                MessageBox.Show("Selecione o estado destino.");
                return false;
            }

            var table = (DataTable)dataGridViewPedidos.DataSource;
            if (table.Rows.Count == 0)
            {
                MessageBox.Show("Por favor, inserir ao menos 1 item na nota fiscal.");
                return false;
            }
            else
            {
                int index = 1;
                foreach (DataRow row in table.Rows)
                {
                    if (string.IsNullOrWhiteSpace(row["NomeProduto"].ToString()))
                    {
                        MessageBox.Show(string.Format("Informe o nome do produto no item da linha {0}.", index));
                        return false;
                    }

                    if (string.IsNullOrWhiteSpace(row["CodigoProduto"].ToString()))
                    {
                        MessageBox.Show(string.Format("Informe o código do produto no item da linha {0}.", index));
                        return false;
                    }

                    double valor;
                    if (!Double.TryParse(row["Valor"].ToString(), out valor))
                    {
                        MessageBox.Show(string.Format("Valor não informado ou inválido do item da linha {0}.", index));
                        return false;
                    }

                    index++;
                }
            }

            return true;
        }

        #endregion        
    }
}
