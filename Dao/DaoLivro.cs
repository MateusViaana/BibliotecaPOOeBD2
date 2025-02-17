using BibliotecaPOOeBD2.Data;
using BibliotecaPOOeBD2.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibliotecaPOOeBD2.Dao
{
    internal class DaoLivro
    {
        public void Insert(Livro livros)
        {
            try
            {
        

        string sql = "Insert into livros (titulo, autor, editora, anoPublicacao, isbn, genero, edicao, idioma) values (@titulo, @autor, @editora, @anoPublicacao, @isbn, @genero, @edicao, @idioma)";

                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());

                comando.Parameters.AddWithValue("@titulo", livros.titulo);
                comando.Parameters.AddWithValue("@autor", livros.autor);
                comando.Parameters.AddWithValue("@editora", livros.editora);
                comando.Parameters.AddWithValue("@anoPublicacao", livros.anoPublicacao);
                comando.Parameters.AddWithValue("@isbn", livros.isbn);
                comando.Parameters.AddWithValue("@genero", livros.genero);
                comando.Parameters.AddWithValue("@edicao", livros.edicao);
                comando.Parameters.AddWithValue("@idioma", livros.idioma);
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar! " + ex.Message); 
            }

        }
        public void Delete(Livro livros)
        {
            try
            {
                string sql = "DELETE FROM livros where idLivro = @idLivro";
                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());
                comando.Parameters.AddWithValue("@idLivro", livros.idLivro);
                comando.ExecuteNonQuery();
                MessageBox.Show("Livro excluido com sucesso!");
                Conexao.FecharConexao();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao Excluir! " + ex.Message);
            }
        }
        public void Update(Livro livros)
        {
            try
            {
                string sql = "UPDATE livros SET titulo = @titulo, @autor, @editora, @anoPublicacao, @isbn, " +
                    "@genero, @edicao, @idioma)";

                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());
                comando.Parameters.AddWithValue("@titulo", livros.titulo);
                comando.Parameters.AddWithValue("@autor", livros.autor);
                comando.Parameters.AddWithValue("@editora", livros.editora);
                comando.Parameters.AddWithValue("@titulo", livros.titulo);

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao Atualizar! " + ex.Message);
            }
        }
    }
}
