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
    public partial class FrmCategorias : Form
    {
        Categoria c;

        public FrmCategorias()
        {
            InitializeComponent();
        }



        void LimparControles()
        {
            txtID.Clear();
            txtCategoria.Clear();
            txtPesquisa.Clear();
        }

        void carregarGrid(string pesquisa)
        {
            c = new Categoria()
            {
                categoria = pesquisa
            };

            dgvCategoria.DataSource = c.Consultar();
        }

        private void FrmMarcas_Load(object sender, EventArgs e)
        {
            LimparControles();
            carregarGrid("");
        }

      

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtCategoria.Text == String.Empty) return;

            c = new Categoria()
            {
                categoria = txtCategoria.Text,

            };

            c.Incluir();

            LimparControles();
            carregarGrid("");
        }

        private void bntAlterar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == String.Empty) return;

            c = new Categoria()
            {
                id = int.Parse(txtID.Text),
                categoria = txtCategoria.Text,

            };
            c.Alterar();

            LimparControles();
            carregarGrid("");
        }

        private void bntCancelar_Click(object sender, EventArgs e)
        {

        }

        private void bntExcluir_Click(object sender, EventArgs e)
        {
            if (txtCategoria.Text == "") return;

            if (MessageBox.Show("Deseja excluir a Categoria?", "Exclusão",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                c = new Categoria()
                {
                    id = int.Parse(txtID.Text)
                };
                c.Excluir();

                LimparControles();
                carregarGrid("");
            }
        }

        private void bntFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvCategoria_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvCategoria.Rows.Count > 0)
            {
                txtID.Text = dgvCategoria.CurrentRow.Cells["id"].Value.ToString();
                txtCategoria.Text = dgvCategoria.CurrentRow.Cells["categoria"].Value.ToString();

            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            carregarGrid(txtPesquisa.Text);
        }

        private void FrmCategorias_Load(object sender, EventArgs e)
        {
            LimparControles();
            carregarGrid("");
        }
    }
}
