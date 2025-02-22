﻿using BibliotecaPOOeBD2.Dao;
using BibliotecaPOOeBD2.Models;
using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibliotecaPOOeBD2.Formularios
{
    public partial class CadastrarUsuario : Form
    {
        public CadastrarUsuario()
        {
            InitializeComponent();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                txtAnoPublicacao.Clear();
                txtAutor.Clear();
                txtEdicao.Clear();
                txtEditora.Clear();
                txtGenero.Clear();
                txtIdioma.Clear();
                txtISBN.Clear();
                txtTitulo.Clear();
                txtTitulo.Focus();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao cancelar!" + ex.Message);
            }
           
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Livro l1 = new Livro();
                {
                    l1.titulo = txtTitulo.Text;
                    l1.autor = txtAutor.Text;
                    l1.editora = txtEditora.Text;
                    l1.edicao = txtEdicao.Text;
                    l1.genero = txtGenero.Text;
                    l1.idioma = txtIdioma.Text;
                    l1.isbn = txtISBN.Text;
                    l1.anoPublicacao = DateTime.Parse(txtAnoPublicacao.Text);
                    DaoLivro l2 = new DaoLivro();
                    l2.Insert(l1);
                    l2.ListarTodos();
                    MessageBox.Show("Cadastro realizado com Sucesso!", "POO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAnoPublicacao.Clear();
                    txtAutor.Clear();
                    txtEdicao.Clear();
                    txtEditora.Clear();
                    txtGenero.Clear();
                    txtIdioma.Clear();
                    txtISBN.Clear();
                    txtTitulo.Clear();
                    txtTitulo.Focus();
                }
               
                
            }
            catch (Exception ex )
            {

               MessageBox.Show ("Erro ao realizar o cadastro!" +ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
               DaoLivro l = new DaoLivro();
                var filtro = l.ListarTodos();
               dgvTabela.DataSource = filtro.OrderBy(p => p.titulo).ToList();

              
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao pesquisar! " + ex.Message);
            }
           
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
