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
    public partial class FrmCidades : Form
    {
        Cidade c;

        public FrmCidades()
        {
            InitializeComponent();
        }

        void LimparControles()
        {
            txtID.Clear();
            txtNome.Clear();
            txtUF.Clear();
            txtPesquisa.Clear();
        }

        void carregarGrid(string pesquisa)
        {
            c = new Cidade()
            {
                nome = pesquisa
            };

            dgvCIdade.DataSource = c.Consultar();
        }

        private void FrmCidades_Load(object sender, EventArgs e)
        {
            LimparControles();
            carregarGrid("");
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == String.Empty) return;
            
                c = new Cidade()
                {
                    nome = txtNome.Text,
                        uf = txtUF.Text
                };

                c.Incluir();

                LimparControles();
                carregarGrid("");
            
        }

        private void dgvCIdade_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCIdade.Rows.Count > 0)
            {
                txtID.Text = dgvCIdade.CurrentRow.Cells["id"].Value.ToString();
                txtNome.Text = dgvCIdade.CurrentRow.Cells["nome"].Value.ToString();
                txtUF.Text = dgvCIdade.CurrentRow.Cells["uf"].Value.ToString();
            }
        }

        private void bntAlterar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == String.Empty) return;

            c = new Cidade()
            {
                id = int.Parse(txtID.Text),
                nome = txtNome.Text,
                uf = txtUF.Text
            };
            c.Alterar();

            LimparControles();
            carregarGrid("");
        }

        private void bntExcluir_Click(object sender, EventArgs e)
        {
            if (txtUF.Text == "") return;

            if (MessageBox.Show("Deseja excluir a cidade?", "Exclusão",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                c = new Cidade()
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
