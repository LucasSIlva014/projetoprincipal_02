// Namespace que organiza o projeto, agrupando classes relacionadas
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
using System;

namespace projetoprincipal
{
    // Classe Banco, responsável por gerenciar a conexão com o banco de dados MySQL

    public class Banco
    {
        // Variável estática para armazenar a conexão com o banco MySQL
        // Estática para ser compartilhada por todos os métodos da classe
        public static MySqlConnection conexao;

        // Variável estática para armazenar comandos SQL a serem executados
        public static MySqlCommand comando;

        // Variável estática para adaptar dados do banco para objetos .NET (ex.: DataTable)
        public static MySqlDataAdapter Adaptador;

        // Variável estática para armazenar os dados recuperados do banco em formato de tabela
        public static DataTable datTabela;

        // Método estático para abrir a conexão com o banco de dados
        public static void AbrirConexao()
        {
            try
            {
                // Cria uma nova conexão com o MySQL usando a string de conexão
                // - server=localhost: Servidor MySQL está no mesmo computador
                // - port=3307: Porta usada pelo MySQL (diferente da padrão 3306)
                // - uid=root: Usuário do MySQL (root é o administrador padrão)
                // - pwd=: Senha vazia (não recomendada para produção)
                conexao = new MySqlConnection("server=localhost;port=3307;uid=root;pwd=etecjau");

                // Abre a conexão com o banco de dados
                conexao.Open();
            }
            catch (Exception e)
            {
                // Captura qualquer erro que ocorra ao tentar abrir a conexão
                // Exibe uma mensagem de erro em uma caixa de diálogo com o ícone de erro
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método estático para fechar a conexão com o banco de dados
        public static void FecharConexao()
        {
            try
            {
                // Fecha a conexão ativa com o banco de dados
                conexao.Close();
            }
            catch (Exception e)
            {
                // Captura qualquer erro que ocorra ao tentar fechar a conexão
                // Exibe uma mensagem de erro em uma caixa de diálogo
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método estático para criar o banco de dados 'vendas' e a tabela 'Cidades'
        public static void CriarBanco()
        {
            try
            {
                // Chama o método para abrir a conexão com o banco
                AbrirConexao();

                // Cria um comando SQL para:
                // 1. Criar o banco 'vendas' se ele ainda não existir
                // 2. Selecionar o banco 'vendas' para uso
                comando = new MySqlCommand("CREATE DATABASE IF NOT EXISTS vendas; USE vendas", conexao);

                // Executa o comando SQL
                comando.ExecuteNonQuery();

                // Cria um novo comando SQL para criar a tabela 'Cidades' se ela ainda não existir
                // A tabela tem as colunas:
                // - id: Chave primária, auto-incrementada
                // - nome: Nome da cidade (máximo 40 caracteres)
                // - uf: Sigla do estado (2 caracteres)
                comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS Cidades " +
                                           "(id integer auto_increment primary key, " +
                                           "nome char(40), " +
                                           "uf char(02))", conexao);

                // Executa o comando SQL para criar a tabela
                comando.ExecuteNonQuery();

                comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS Marcas " +
                                            "(id integer auto_increment primary key, " +
                                             "marca char(20))", conexao);
                comando.ExecuteNonQuery();




                comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS Categorias " +
                                           "(id integer auto_increment primary key, " +
                                            "categoria char(20))", conexao);

                comando.ExecuteNonQuery();

                comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS Clientes " +
                                          "(id integer auto_increment primary key, " +
                                           "nome char(40), " +
                                           "idCidade integer," +
                                           "dataNasc date, " +
                                           "renda decimal (10,2), " +
                                           "cpf char(14), " + 
                                           "foto varchar(100), "+
                                           "venda boolean)", conexao);

                comando.ExecuteNonQuery();

                comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS Produtos " +
                                          "(id integer auto_increment primary key, " +
                                           "descricao char(40), " +
                                           "idCategoria integer," +
                                           "idMarca integer, " +
                                           "estoque decimal(10,3), " +
                                           "valorVenda decimal(10,2), " +
                                           "foto varchar(100))", conexao);
                                           

                comando.ExecuteNonQuery();

                comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS VendaCab " +
                                          "(Id integer auto_increment primary key, " +
                                           "idCliente int, " +
                                           "data date," +
                                           "total decimal(10,2))", conexao);


                comando.ExecuteNonQuery();

                comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS VendaDet " +
                                          "(Id integer auto_increment primary key, " +
                                           "idVendaCab int, " +
                                           "idProduto int," +
                                           "Qtde decimal(10,3), " +
                                           "ValorUnitario decimal(10,2))", conexao);


                comando.ExecuteNonQuery();


                comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS Contas_Receber " +
                                         "(Id integer auto_increment primary key, " +
                                          "idVenda int, " +
                                          "parcela  tinyint," +
                                          "data_vencto date, " +
                                           "data_pagto  date, " +
                                          "vlr_parcela double (10,2), " +
                                           "status boolan)" , conexao);


                comando.ExecuteNonQuery();



                // Fecha a conexão com o banco após a execução
                FecharConexao();
            }
            catch (Exception e)
            {
                // Captura qualquer erro que ocorra durante a criação do banco/tabela
                // Exibe uma mensagem de erro em uma caixa de diálogo
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}