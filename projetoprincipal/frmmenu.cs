using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using projetoprincipal.Views;

namespace projetoprincipal
{
    public partial class frmmenu : Form
    {
        public frmmenu()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Banco.CriarBanco();
        }

        private void cadastrosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        // Evento disparado quando o item de menu "Marcas" é clicado
        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // Cria uma nova instância do formulário FrmMarcas
            FrmMarcas form = new FrmMarcas();

            // Exibe o formulário na tela de forma não modal,
            // ou seja, permite continuar usando o formulário principal
            form.Show();

            // Se você quiser abrir o formulário como modal (bloqueia o principal até fechar), use:
            // form.ShowDialog();

        }

        private void cidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCidades form = new FrmCidades();
            form.Show();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCategorias form = new FrmCategorias();
            form.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmClientes form = new FrmClientes();
            form.Show();
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProdutos form = new FrmProdutos();
            form.Show();
        }

        private void movimentaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVenda form = new FrmVenda();
            form.Show();
        }
    }
}
