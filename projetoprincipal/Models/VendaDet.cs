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

namespace projetoprincipal.Models
{
    public class VendaDet
    {
        public int id {  get; set; }

        public int idVendaCab { get; set; }
        
        public int idProduto { get; set; } 

        public double qtde { get; set; }

        public double valorUnitario { get; set; }





        public void Incluir()
        {
            try
            {
                Banco.conexao.Open();
                Banco.comando = new MySqlCommand(
                    "INSERT INTO vendadet (idVendaCab, idProduto, qtde, valorUnitario) " +
                    "values (@idVendaCab, @idProduto, @qtde, @valorUnitario)", Banco.conexao);
                Banco.comando.Parameters.AddWithValue("@idVendaCab", idVendaCab);
                Banco.comando.Parameters.AddWithValue("@idProduto", idProduto);
                Banco.comando.Parameters.AddWithValue("@qtde", qtde);
                Banco.comando.Parameters.AddWithValue("@valorUnitario", valorUnitario);
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
