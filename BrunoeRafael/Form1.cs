using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrunoeRafael
{
    public partial class Form1 : Form
    {
        double valorTotal;
        double vendas = 1;
        public Form1()
        {
            InitializeComponent();
        }


        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {   
           
           double total = double.Parse(txtQtd.Text) * double.Parse(txtValor.Text);
            
            valorTotal += total;

            dgvProdutos.Rows.Add(txtProduto.Text, txtQtd.Text, txtValor.Text, total);

 
            lblTotal.Text = valorTotal.ToString("C");
            

            MessageBox.Show("Produto Incluido com sucesso", "Inclusao",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            txtProduto.Clear();
            txtQtd.Clear();
            txtValor.Clear();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (dgvProdutos.RowCount > 0)
            {   
                double remover = double.Parse(dgvProdutos.CurrentRow.Cells[1].Value.ToString()) * double.Parse(dgvProdutos.CurrentRow.Cells[2].Value.ToString());

                dgvProdutos.Rows.RemoveAt(dgvProdutos.CurrentRow.Index); 
                valorTotal -= remover;
                lblTotal.Text = valorTotal.ToString("C");

                MessageBox.Show("Produto Excluido com Sucesso.", "Exclusão",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        private void dgvProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProdutos.RowCount > 0)
            {
                txtAlterar.Text = dgvProdutos.CurrentRow.Cells[1].Value.ToString();
         

            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtAlterar.Text != "")
            {
                double tot = double.Parse(dgvProdutos.CurrentRow.Cells[1].Value.ToString()) * double.Parse(dgvProdutos.CurrentRow.Cells[2].Value.ToString());
                dgvProdutos.CurrentRow.Cells[1].Value = txtAlterar.Text;
                double ago = double.Parse(dgvProdutos.CurrentRow.Cells[1].Value.ToString()) * double.Parse(dgvProdutos.CurrentRow.Cells[2].Value.ToString());


                valorTotal = (valorTotal - tot) + ago;

                lblTotal.Text = valorTotal.ToString("C");

                txtAlterar.Clear();
          

                MessageBox.Show("Aluno Alterado com Sucesso", "Alteração",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            vendas += 1;
            lblVenda.Text = vendas.ToString();
            lblTotal.Text = "R$ 0";
            valorTotal = 0;
            

            dgvProdutos.Rows.Clear();
            txtAlterar.Clear();




        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            dgvProdutos.Rows.Clear();
            txtAlterar.Clear();
            lblTotal.Text = "R$ 0";
         
            valorTotal = 0;
        }

      
    }
}
