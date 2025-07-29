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
    public partial class FrmProdutos : Form
    {
        Marcas mr;
        Produtos pt;
        Categoria ct;

        public FrmProdutos()
        {
            InitializeComponent();
        }

        void LimpaControles()
        {
            txtID.Clear();
            txtDescricao.Clear();
            cboCategoria.SelectedIndex = -1;
            cboMarca.SelectedIndex = -1;
            txtValorVenda.Clear();
            txtPesquisa.Clear();
            txtEstoque.Clear();
            picFoto.ImageLocation = "";
           

        }


        void carregarGrid(string itens)
        {
            pt = new Produtos()
            {
                descricao = itens 
            };

            dgvProdutos.DataSource = pt.Consultar();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            {
                if (txtDescricao.Text == "") return;

                pt = new Produtos ()
                {
                    descricao = txtDescricao.Text,
                    idCategoria = (int)cboCategoria.SelectedValue,
                    idMarca = (int)cboMarca.SelectedValue,
                    estoque = int.Parse(txtEstoque.Text),
                    valorVenda = double.Parse(txtValorVenda.Text),
                    foto = picFoto.ImageLocation,
                   
                };
                pt.Incluir();
                LimpaControles();
                carregarGrid("");
            }
        }

        private void bntAlterar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;


            pt = new Produtos()
            {
                id = int.Parse(txtID.Text),
                descricao = txtDescricao.Text,
                idCategoria = (int)cboCategoria.SelectedValue,
                idMarca = (int)cboMarca.SelectedValue,
                estoque = double.Parse(txtEstoque.Text),
                valorVenda = double.Parse(txtValorVenda.Text),
                foto = picFoto.ImageLocation,
            };

            pt.Alterar();
            LimpaControles();
            carregarGrid("");
        }

        private void bntCancelar_Click(object sender, EventArgs e)
        {
            LimpaControles();
            carregarGrid("");
        }

        private void bntExcluir_Click(object sender, EventArgs e)
        {

            if (txtDescricao.Text == "") return;

            if (MessageBox.Show("Deseja excluir o produto?", "Exclusão",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                pt = new Produtos()
                {
                    id = int.Parse(txtID.Text)
                };
                pt.Excluir();

                LimpaControles();
                carregarGrid("");
            }
        }

        private void bntFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            carregarGrid(txtPesquisa.Text);
        }

        private void FrmProdutos_Load(object sender, EventArgs e)
        {
            {
               ct = new Categoria();
                mr = new Marcas();
                cboMarca.DataSource = mr.Consultar();
                cboMarca.DisplayMember = "marca";
                cboMarca.ValueMember = "id";

                cboCategoria.DataSource = ct.Consultar();
                cboCategoria.DisplayMember = "categoria";
                cboCategoria.ValueMember = "id";

                LimpaControles();
                carregarGrid("");

                // Deixa invisível colunas do Grid
                dgvProdutos.Columns["idCategoria"].Visible = false;
                dgvProdutos.Columns["idMarca"].Visible = false;
                dgvProdutos.Columns["foto"].Visible = false;
            }
        }

        private void picFoto_Click(object sender, EventArgs e)
        {
            ofdArquivo.InitialDirectory = "X:/fotos/produtos/";
            ofdArquivo.FileName = "";
            ofdArquivo.ShowDialog();
            picFoto.ImageLocation = ofdArquivo.FileName;
        }

        private void dgvProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProdutos.Rows.Count > 0)
            {
                txtID.Text = dgvProdutos.CurrentRow.Cells["id"].Value.ToString();
                txtDescricao.Text = dgvProdutos.CurrentRow.Cells["descricao"].Value.ToString();
                cboMarca.Text = dgvProdutos.CurrentRow.Cells["Marca"].Value.ToString();
                cboCategoria.Text = dgvProdutos.CurrentRow.Cells["Categoria"].Value.ToString();
                txtEstoque.Text = dgvProdutos.CurrentRow.Cells["estoque"].Value.ToString();
                txtValorVenda.Text = dgvProdutos.CurrentRow.Cells["valorVenda"].Value.ToString();
                picFoto.ImageLocation = dgvProdutos.CurrentRow.Cells["foto"].Value.ToString();
            }
        }

        private void cboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCategoria.SelectedIndex != -1)
            {
                DataRowView reg = (DataRowView)cboCategoria.SelectedItem;
                
            }
        }

        private void cboMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMarca.SelectedIndex != -1)
            {
                DataRowView reg = (DataRowView)cboMarca.SelectedItem;
               
            }
        }

  
    }
}
