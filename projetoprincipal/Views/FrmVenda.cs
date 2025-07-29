using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using projetoprincipal.Models;

namespace projetoprincipal.Views
{
    public partial class FrmVenda : Form
    {

        double total;

        Clientes c;
        Produtos p;
        VendaCab vc;
        VendaDet vd;




        public FrmVenda()
        {
            InitializeComponent();
        }

        void LimpaProduto()
        {
            cboProdutos.SelectedIndex = -1;
            txtEstoque.Clear();
            txtPreco.Clear();
            txtQuantidade.Clear();
            txtMarca.Clear();
            txtCategoria.Clear();
            picProduto.ImageLocation = "";
        }


        

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            dgvProdutos.RowCount= 0;
            cboClientes.SelectedIndex = -1;
            txtCidade.Clear();
            txtUF.Clear();
            txtRenda.Clear();
            mskCPF.Clear();
            mskDataNasc.Clear();
            chkVenda.Checked = false;
            picCliente.ImageLocation = "";
            total = 0;
            lblTotal.Text = total.ToString("C");
            grbCliente.Enabled = true;
            grbProduto.Enabled = false;
            LimpaProduto();
        }

        private void FrmVenda_Load(object sender, EventArgs e)
        {
            c = new Clientes();

            cboClientes.DataSource = c.Consultar();
            cboClientes.DisplayMember = "nome";
            cboClientes.ValueMember = "id";

            p = new Produtos();

            cboProdutos.DataSource = p.Consultar();
            cboProdutos.DisplayMember = "descricao";
            cboProdutos.ValueMember = "id";

            btnCancelar.PerformClick();
        }

      

        private void cboClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboClientes.SelectedIndex != -1)

            {
                DataRowView reg = (DataRowView) cboClientes.SelectedItem;
                txtCidade.Text = reg["CIDADE"].ToString (); 
                txtUF.Text= reg["UF"].ToString();
                txtRenda.Text = reg["RENDA"].ToString() ;
                mskCPF.Text = reg["CPF"].ToString () ;
                mskDataNasc.Text = reg["DATANASC"].ToString();
                picCliente.ImageLocation = reg["FOTO"].ToString();
                chkVenda.Checked = (bool)reg["VENDA"];
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (cboClientes.SelectedIndex != -1)   // Verifica se tem um cliente selecionado?

            {
                if (chkVenda.Checked)   // Checa se a caixinha está ativa, sendo o cliente pode está bloquado!
                {
                    MessageBox.Show("Cliente bloqueado para venda", "Vendas", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnCancelar.PerformClick ();
                    return;
                }
                grbCliente.Enabled = false;
                grbProduto.Enabled = true;
            }
        }

        private void cboProdutos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProdutos.SelectedIndex != -1)
            {
                DataRowView reg = (DataRowView)cboProdutos.SelectedItem;
                txtEstoque.Text = reg["estoque"].ToString ();
                txtPreco.Text = reg["valorVenda"].ToString();
                txtMarca.Text = reg["Marca"].ToString() ;
                txtCategoria.Text = reg["Categoria"].ToString () ;
                picProduto.ImageLocation = reg["foto"].ToString();
            }
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            double quantidade = double.Parse(txtQuantidade.Text);
            double estoque = double.Parse(txtEstoque.Text);

            if (quantidade > estoque)
            {
                MessageBox.Show("Estoque insuficiente", "Vendas",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtQuantidade.SelectAll ();
                return;
            }

            dgvProdutos.Rows.Add (cboProdutos.SelectedValue, cboProdutos.Text,
                                   txtQuantidade.Text, txtPreco.Text);  

            double preco = double .Parse(txtPreco.Text);

            total += quantidade * preco;
            lblTotal.Text = total.ToString("C");
            LimpaProduto();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (dgvProdutos.RowCount > 0)
            {
                double quantidade = double.Parse(dgvProdutos.CurrentRow.Cells[2].Value.ToString());
                double preco = double.Parse(dgvProdutos.CurrentRow.Cells[2].Value.ToString());

                total -= quantidade * preco;
                lblTotal.Text = total.ToString("C");

                dgvProdutos.Rows.RemoveAt(dgvProdutos.CurrentRow.Index);
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            vc = new VendaCab()
            {
                idCliente = (int)cboClientes.SelectedValue,
                data = DateTime.Now,
                total = total
            };

            int idVenda = vc.incluir();

            foreach (DataGridViewRow linha in dgvProdutos.Rows)
            {
                vd = new VendaDet()
                {
                    idVendaCab = idVenda,
                    idProduto = Convert.ToInt32(linha.Cells[0].Value),
                    qtde = Convert.ToDouble(linha.Cells[2].Value),
                    valorUnitario = Convert.ToDouble(linha.Cells[3].Value)
                };

                vd.Incluir();

                p = new Produtos()
                {
                    id = (int)linha.Cells[0].Value,
                };
                p.atualizaEstoque(Convert.ToDouble(linha.Cells[2].Value));

                btnCancelar.PerformClick();
            }
        }

        private void dgvProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
