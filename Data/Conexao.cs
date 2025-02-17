
using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace BibliotecaPOOeBD2.Data
{
    internal class Conexao
    {
        static MySqlConnection _conexao;

        
        public static MySqlConnection Conectar()
        {
            try
            {
                
                string strconexao = "server=localhost; uid=root; pwd=mateus; database=biblioteca";

                _conexao = new MySqlConnection(strconexao);
                _conexao.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao acesso o banco de dados" + ex.Message);
            }
            return _conexao;
        }
        public static void FecharConexao()
        {
            _conexao.Close();
        }
    }
}
