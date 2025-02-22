﻿using BibliotecaPOOeBD2.Data;
using BibliotecaPOOeBD2.Interface;
using BibliotecaPOOeBD2.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
                string sql = "UPDATE livros SET titulo = @titulo, autor = @autor, editora = @editora, anoPublicacao = @anoPublicacao," +
                    "isbn =  @isbn, genero = @genero, edicao = @edicao, idioma = @idioma)";

                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());
                comando.Parameters.AddWithValue("@titulo", livros.titulo);
                comando.Parameters.AddWithValue("@autor", livros.autor);
                comando.Parameters.AddWithValue("@editora", livros.editora);
                comando.Parameters.AddWithValue("@titulo", livros.titulo);
                comando.Parameters.AddWithValue("@anoPublicacao", livros.anoPublicacao);
                comando.Parameters.AddWithValue("@isbn", livros.isbn);
                comando.Parameters.AddWithValue("@genero", livros.genero);
                comando.Parameters.AddWithValue("@edicao", livros.edicao);
                comando.Parameters.AddWithValue("@idioma", livros.idioma);

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao Atualizar! " + ex.Message);
            }
        }

        public List<Livro> ListarTodos()
        {
            try
            {
                List<Livro> livros = new List<Livro>();
                string sql = "SELECT * FROM livros ORDER BY Titulo";

                using (MySqlConnection conexao = Conexao.Conectar())
                using (MySqlCommand command = new MySqlCommand(sql, conexao))
                {
                  
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Livro livro = new Livro
                            {
                                idLivro = reader.IsDBNull(reader.GetOrdinal("idLivro")) ? 0 : reader.GetInt32("idLivro"),
                                titulo = reader.IsDBNull(reader.GetOrdinal("titulo")) ? "" : reader.GetString("titulo"),
                                autor = reader.IsDBNull(reader.GetOrdinal("autor")) ? "" : reader.GetString("autor"),
                                editora = reader.IsDBNull(reader.GetOrdinal("editora")) ? "" : reader.GetString("editora"),
                                anoPublicacao = reader.IsDBNull(reader.GetOrdinal("anoPublicacao")) ? DateTime.MinValue : reader.GetDateTime("anoPublicacao"),
                                isbn = reader.IsDBNull(reader.GetOrdinal("isbn")) ? "" : reader.GetString("isbn"),
                                genero = reader.IsDBNull(reader.GetOrdinal("genero")) ? "" : reader.GetString("genero"),
                                edicao = reader.IsDBNull(reader.GetOrdinal("edicao")) ? "" : reader.GetString("edicao"),
                                idioma = reader.IsDBNull(reader.GetOrdinal("idioma")) ? "" : reader.GetString("idioma")
                            };

                            livros.Add(livro);
                        }
                    }
                }

                return livros;

            }
            catch (Exception ex)
            {

                throw new Exception ("Erro ao atualizar!" + ex.Message);
            }
           
        }
    }
}
