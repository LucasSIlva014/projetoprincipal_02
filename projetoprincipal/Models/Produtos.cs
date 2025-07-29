using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
using System;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace projetoprincipal.Models
{
    internal class Produtos
    {



        public int id { get; set; }  // Identificador único do produto


        public string descricao { get; set; } // Nome do produtor

        public int idCategoria { get; set; } 

        public int idMarca { get; set; }

        public double valorVenda { get; set; } // valor da venda


        public double estoque { get; set; } // CPF do cliente (Cadastro de Pessoa Física)


        public string foto { get; set; }  // Caminho ou nome do arquivo da foto do produto



        public DataTable Consultar()
        {
            try
            {
                Banco.comando = new MySqlCommand("SELECT p.*,m.marca, c.categoria FROM " +
                                                  "Produtos p inner join Marcas m on (m.id = p.idMarca) " +
                                                  "inner join Categorias c on (c.id = p.idCategoria) " +
                                                  "where p.descricao like @descricao order by p.descricao", Banco.conexao);
                Banco.comando.Parameters.AddWithValue("@descricao", descricao + "%");
                Banco.Adaptador = new MySqlDataAdapter(Banco.comando);
                Banco.datTabela = new DataTable();
                Banco.Adaptador.Fill(Banco.datTabela);
                return Banco.datTabela;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        public void Excluir()
        {
            try
            {
                Banco.conexao.Open();
                Banco.comando = new MySqlCommand("delete from produtos where id = @id", Banco.conexao);
                Banco.comando.Parameters.AddWithValue("@id", id);
                Banco.comando.ExecuteNonQuery();
                Banco.conexao.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void Incluir()
        {
            try
            {
                Banco.conexao.Open();
                Banco.comando = new MySqlCommand
                    ("INSERT INTO produtos (descricao, idCategoria, idMarca, estoque, valorVenda, foto) " +
                    "VALUES (@descricao, @idCategoria, @idMarca, @estoque, @valorVenda, @foto)", Banco.conexao);
                Banco.comando.Parameters.AddWithValue("@descricao", descricao);
                Banco.comando.Parameters.AddWithValue("@idCategoria", idCategoria);
                Banco.comando.Parameters.AddWithValue("@idMarca", idMarca);
                Banco.comando.Parameters.AddWithValue("@estoque", estoque);
                Banco.comando.Parameters.AddWithValue("@valorVenda", valorVenda);
                Banco.comando.Parameters.AddWithValue("@foto", foto);
                Banco.comando.ExecuteNonQuery();
                Banco.conexao.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Alterar()
        {
            try
            {
                Banco.conexao.Open();
                Banco.comando = new MySqlCommand
                     ("UPDATE produtos SET descricao = @descricao, idCategoria = @idCategoria, idMarca = @idMarca, " +
                     "estoque = @estoque, valorVenda = @valorVenda, foto = @foto where id = @id", Banco.conexao);
                Banco.comando.Parameters.AddWithValue("@descricao", descricao);
                Banco.comando.Parameters.AddWithValue("@idCategoria", idCategoria);
                Banco.comando.Parameters.AddWithValue("@idMarca", idMarca);
                Banco.comando.Parameters.AddWithValue("@estoque", estoque);
                Banco.comando.Parameters.AddWithValue("@valorVenda", valorVenda);
                Banco.comando.Parameters.AddWithValue("@foto", foto);
                Banco.comando.Parameters.AddWithValue("@id", id);
                Banco.comando.ExecuteNonQuery();
                Banco.conexao.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void atualizaEstoque(double qtde)
        {
            try
            {
                Banco.conexao.Open();
                Banco.comando = new MySqlCommand(
                    "Update produtos set estoque = estoque - @qtde where id = @id", Banco.conexao);
                Banco.comando.Parameters.AddWithValue("qtde", qtde);
                Banco.comando.Parameters.AddWithValue("id", id);
                Banco.comando.ExecuteNonQuery();
                Banco.conexao.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
