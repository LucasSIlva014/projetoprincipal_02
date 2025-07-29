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
    public partial class FrmMarcas : Form
    {



        Marcas m;


        public FrmMarcas()
        {
            InitializeComponent();
        }



        void LimparControles()
        {
            txtID.Clear();
            txtMarca.Clear();
            txtPesquisa.Clear();
        }

        void carregarGrid(string pesquisa)
        {
            m = new Marcas()
            {
                marca = pesquisa
            };

            dgvMarcas.DataSource = m.Consultar();
        }

        private void FrmMarcas_Load(object sender, EventArgs e)
        {
            LimparControles();
            carregarGrid("");
        }

        private void dgvMarcas_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvMarcas.Rows.Count > 0)
            {
                txtID.Text = dgvMarcas.CurrentRow.Cells["id"].Value.ToString();
                txtMarca.Text = dgvMarcas.CurrentRow.Cells["marca"].Value.ToString();

            }
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {

            if (txtMarca.Text == String.Empty) return;

            m = new Marcas()
            {
                marca = txtMarca.Text,

            };

            m.Incluir();

            LimparControles();
            carregarGrid("");
        }

        private void bntAlterar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == String.Empty) return;

            m = new Marcas()
            {
                id = int.Parse(txtID.Text),
                marca = txtMarca.Text,

            };
            m.Alterar();

            LimparControles();
            carregarGrid("");
        }

        private void bntExcluir_Click(object sender, EventArgs e)
        {
            if (txtMarca.Text == "") return;

            if (MessageBox.Show("Deseja excluir a Marca?", "Exclusão",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                m = new Marcas()
                {
                    id = int.Parse(txtID.Text)
                };
                m.Excluir();

                LimparControles();
                carregarGrid("");
            }
        }

        private void bntFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bntCancelar_Click(object sender, EventArgs e)
        {
            LimparControles();
            carregarGrid("");
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            carregarGrid(txtPesquisa.Text);
        }

    
    }
}
