using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using projetoprincipal.Models;


namespace projetoprincipal.Views
{
    public class Categoria
    {
        // Propriedade que representa o identificador único da Categoria (chave primária no banco de dados)
        public int id { get; set; }

        // Propriedade que representa o nome das Categorias
        public string categoria { get; set; }

        public void Incluir()
        {
            try
            {

                // Abre a conexãocom o banco

                Banco.AbrirConexao();

                // Alimenta o método commans com a instrução desejada e indica a conexão utilizada
                Banco.comando = new MySqlCommand("INSERT INTO categorias (categoria) VALUES (@categoria)", Banco.conexao);

                //Cria os parametros utilizados na instrução SQL com seu respectivo conteúdo
                Banco.comando.Parameters.AddWithValue("@categoria", categoria); // Parametro String

                //Executa o camando, no MYSQL, tem a função do raio do Worlbench
                Banco.comando.ExecuteNonQuery();

                //Fecha a conexão
                Banco.FecharConexao();

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
                // Abre a conexão com o banco de dados
                Banco.AbrirConexao();

                // Cria um comando SQL para buscar todas as categoria cujo nome comece com o valor da variável 'nome'
                // A cláusula 'LIKE' é usada para buscas parciais e 'ORDER BY' organiza os resultados alfabeticamente

                Banco.comando = new MySqlCommand("SELECT * FROM Categorias WHERE categoria LIKE @categoria ORDER BY categoria", Banco.conexao);

                // Adiciona o valor do parâmetro @nome com um caractere coringa (%) no final,
                // permitindo encontrar nomes que começam com o texto informado
                Banco.comando.Parameters.AddWithValue("@categoria", categoria + "%");

                // Cria o adaptador de dados, que vai executar o comando e preencher o DataTable
                Banco.Adaptador = new MySqlDataAdapter(Banco.comando);

                // Instancia um novo DataTable para armazenar os dados da consulta
                Banco.datTabela = new DataTable();

                // Preenche o DataTable com os dados retornados pela consulta
                Banco.Adaptador.Fill(Banco.datTabela);

                // Fecha a conexão com o banco de dados
                Banco.FecharConexao();

                // Retorna o DataTable com os resultados da consulta
                return Banco.datTabela;
            }
            catch (Exception e)
            {
                // Em caso de erro, exibe a mensagem para o usuário e retorna null
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }




        public void Alterar()
        {
            try
            {
                // Abre a conexão com o banco de dados
                Banco.AbrirConexao();

                // Cria o comando SQL para atualizar um registro na tabela "categorias"
                // Os valores serão passados por parâmetros para evitar SQL Injection
                Banco.comando = new MySqlCommand("UPDATE categorias SET categoria = @categoria WHERE id = @id", Banco.conexao);

                // Atribui os valores dos parâmetros usando as variáveis da classe
                Banco.comando.Parameters.AddWithValue("@categoria", categoria); // Novo nome da marca

                Banco.comando.Parameters.AddWithValue("@id", id);     // ID da marcas para ser atualizada

                // Executa o comando de atualização no banco de dados
                Banco.comando.ExecuteNonQuery();

                // Fecha a conexão com o banco de dados
                Banco.FecharConexao();
            }
            catch (Exception e)
            {
                // Caso ocorra algum erro, exibe uma mensagem para o usuário
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void Excluir()
        {
            try
            {

                // Abre conexão com o banco
                Banco.AbrirConexao();

                // Alimenta o metodo Command com a instrução desejada e indica a conexão utilizado
                Banco.comando = new MySqlCommand("delete from categorias where id = @id", Banco.conexao);

                // Cria os parametros ultilizados na instrução SQL com seu respectivo conteudo
                Banco.comando.Parameters.AddWithValue("@id", id);

                // Executa o camando, no MYSQL tem a função do raio do Workbench
                Banco.comando.ExecuteNonQuery();

                // Fecha a conexão
                Banco.FecharConexao();
            }
            catch (Exception e)
            {
                // Caso ocorra algum erro, exibe uma mensagem para o usuário
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




    }
}

