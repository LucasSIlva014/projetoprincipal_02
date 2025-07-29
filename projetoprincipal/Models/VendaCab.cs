using System;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using Org.BouncyCastle.Bcpg;

namespace projetoprincipal.Models
{
    public class VendaCab
    {

        public int Id { get; set; }

        public int idCliente { get; set; }

        public DateTime data { get; set; }

        public double total { get; set; }




        public int incluir()
        {
            try
            {

                Banco.conexao.Open();
                Banco.comando = new MySqlCommand(
                    "INSERT INTO  vendacab (idCliente, data, total) " +
                    "VALUES (@idCliente, @data, @total)", Banco.conexao);
                Banco.comando.Parameters.AddWithValue("@idCliente", idCliente);
                Banco.comando.Parameters.AddWithValue("@data", data);
                Banco.comando.Parameters.AddWithValue("@total", total);
                Banco.comando.ExecuteNonQuery();
                Banco.conexao.Close();
                return (int)Banco.comando.LastInsertedId;

            }

            catch (Exception e)
            {

                {
                    MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }
            }


        }




    }
}
