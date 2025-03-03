using BibliotecaPOOeBD2.Dao;
using BibliotecaPOOeBD2.Models;
using MySqlX.XDevAPI.Common;
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
                txtID.Clear();
                txtIDbiblioteca.Clear();
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
                    l1.setISBN(txtISBN.Text);

                    l1.anoPublicacao = DateTime.Parse(txtAnoPublicacao.Text);
                    l1.fk_idBiblioteca = 2;  //professor por favor para funcionar tem que colocar o
                                             //id da fk_biblioteca de acordo com que está no mysql. 
                                             // nos meus testes o id da fk ficou esse 2, mas quando voce testar no seu e ficar fk id 1 
                                             //tem que alterar aqui, se nao fizer isto nao funciona.                
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
                    txtIDbiblioteca.Clear();
                    txtTitulo.Focus();
                    txtIDbiblioteca.Visible = true;
                    labelidBiblioteca.Visible = true;
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
                string titulo = txtPesquisa.Text;
               DaoLivro l = new DaoLivro();
                var filtro = l.ListarSelecionar(titulo);
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

        private void txtIDbiblioteca_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvTabela_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            txtID.Text = dgvTabela.Rows[rowIndex].Cells[0].Value.ToString();
            txtTitulo.Text = dgvTabela.Rows[rowIndex].Cells[1].Value.ToString();
            txtAutor.Text = dgvTabela.Rows[rowIndex].Cells[2].Value.ToString();
            txtEditora.Text = dgvTabela.Rows[rowIndex].Cells[3].Value.ToString();
            txtAnoPublicacao.Text = dgvTabela.Rows[rowIndex].Cells[4].Value.ToString();
            txtISBN.Text = dgvTabela.Rows[rowIndex].Cells[5].Value.ToString();
            txtGenero.Text = dgvTabela.Rows[rowIndex].Cells[6].Value.ToString();
            txtEdicao.Text = dgvTabela.Rows[rowIndex].Cells[7].Value.ToString();           
            txtIdioma.Text = dgvTabela.Rows[rowIndex].Cells[8].Value.ToString();               
            txtIDbiblioteca.Text = dgvTabela.Rows[rowIndex].Cells[9].Value.ToString();
                      
        }

        private void btAtualizar_Click(object sender, EventArgs e)
        {
          

        }

        private void btAtualizar_Click_1(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Deseja mesmo Atualizar ?", "3º POO/BD2 ADS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Livro l = new Livro();
                    l.idLivro = int.Parse(txtID.Text);
                    l.titulo = txtTitulo.Text;
                    l.autor = txtAutor.Text;
                    l.editora = txtEditora.Text;
                    l.edicao = txtEdicao.Text;
                    l.genero = txtGenero.Text;
                    l.idioma = txtIdioma.Text;

                    l.setISBN(txtISBN.Text);
                    l.anoPublicacao = DateTime.Parse(txtAnoPublicacao.Text);
                   
                    DaoLivro daoLivro = new DaoLivro();
                    daoLivro.Update(l);
                    MessageBox.Show("Cadastro Atualizado com Sucesso!", "POO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAnoPublicacao.Clear();
                    txtAutor.Clear();
                    txtEdicao.Clear();
                    txtEditora.Clear();
                    txtGenero.Clear();
                    txtIdioma.Clear();
                    txtISBN.Clear();
                    txtTitulo.Clear();
                    txtTitulo.Focus();
                    txtIDbiblioteca.Clear();
                    txtTitulo.Focus();
                    string titulo = txtPesquisa.Text;
                    dgvTabela.DataSource = daoLivro.ListarSelecionar(titulo);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao Atualizar! " + ex.Message);
            }


        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            try
            {
             DialogResult result = MessageBox.Show("Deseja mesmo Atualizar ?", "3º POO/BD2 ADS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DaoLivro livro = new DaoLivro();
                    Livro l = new Livro();
                    l.idLivro = int.Parse(txtID.Text);

                    livro.Delete(l);

                    MessageBox.Show("Excluido com Sucesso!", "POO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAnoPublicacao.Clear();
                    txtAutor.Clear();
                    txtEdicao.Clear();
                    txtEditora.Clear();
                    txtGenero.Clear();
                    txtIdioma.Clear();
                    txtISBN.Clear();
                    txtTitulo.Clear();
                    txtTitulo.Focus();
                    txtIDbiblioteca.Clear();
                    txtTitulo.Focus();
                    string titulo = txtPesquisa.Text;
                    dgvTabela.DataSource = livro.ListarSelecionar(titulo);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao Excluir! " + ex.Message);
            }
        }
    }
}
