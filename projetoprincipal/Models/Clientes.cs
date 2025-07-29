using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
using System;


namespace projetoprincipal.Models
{
    internal class Clientes
    {
                                    
        public int id { get; set; }  // Identificador único do cliente

        
        public string nome { get; set; } // Nome completo do cliente

        
        public int idCidade { get; set; }   // Identificador da cidade associada ao cliente

        
        public DateTime dataNasc { get; set; } // Data de nascimento do cliente

        
        public double renda { get; set; } // Renda mensal do cliente

        
        public string cpf { get; set; } // CPF do cliente (Cadastro de Pessoa Física)

        
        public string foto { get; set; }  // Caminho ou nome do arquivo da foto do cliente

        
        public bool venda { get; set; } // Indica se o cliente está ativo para vendas




        public void Incluir()
        {
            try
            {
                Banco.conexao.Open();
                Banco.comando = new MySqlCommand
                    ("INSERT INTO clientes (nome, idCidade, dataNasc, renda, cpf, foto, venda) " +
                    "VALUES (@nome, @idCidade, @dataNasc, @renda, @cpf, @foto, @venda)", Banco.conexao);
                Banco.comando.Parameters.AddWithValue("@nome", nome);
                Banco.comando.Parameters.AddWithValue("@idCidade", idCidade);
                Banco.comando.Parameters.AddWithValue("@dataNasc",dataNasc);
                Banco.comando.Parameters.AddWithValue("@renda", renda);
                Banco.comando.Parameters.AddWithValue("@cpf", cpf);
                Banco.comando.Parameters.AddWithValue("@foto", foto);
                Banco.comando.Parameters.AddWithValue("@venda", venda);
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
                     ("UPDATE clientes SET nome = @nome, idCidade = @idCidade, dataNasc = @dataNasc, " +
                     "renda = @renda, cpf = @cpf, foto = @foto, venda = @venda where id = @id", Banco.conexao);

                Banco.comando.Parameters.AddWithValue("@nome", nome);
                Banco.comando.Parameters.AddWithValue("@idCidade", idCidade);
                Banco.comando.Parameters.AddWithValue("@dataNasc", dataNasc);
                Banco.comando.Parameters.AddWithValue("@renda", renda);
                Banco.comando.Parameters.AddWithValue("@cpf", cpf);
                Banco.comando.Parameters.AddWithValue("@foto", foto);
                Banco.comando.Parameters.AddWithValue("@venda", venda);
                Banco.comando.Parameters.AddWithValue("@id", id);
                Banco.comando.ExecuteNonQuery();
                Banco.conexao.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void Excluir()
        {
            try
            {
                Banco.conexao.Open();
                Banco.comando = new MySqlCommand("delete from clientes where id = @id", Banco.conexao);
                Banco.comando.Parameters.AddWithValue("@id", id);
                Banco.comando.ExecuteNonQuery();
                Banco.conexao.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        public DataTable Consultar()
        {
            try
            {
                Banco.comando = new MySqlCommand("SELECT cl.*, ci.nome cidade, " +
                    "ci.uf FROM Clientes cl inner join Cidades ci on (ci.id = cl.idCidade) " +
                    "where cl.nome like ?Nome order by cl.nome", Banco.conexao);

                Banco.comando.Parameters.AddWithValue("@nome", nome + "%");
                Banco.Adaptador = new MySqlDataAdapter(Banco.comando);
                Banco.datTabela = new DataTable();
                Banco.Adaptador.Fill(Banco.datTabela);
                return Banco.datTabela;
            }
            catch ( Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }

        

    }
}