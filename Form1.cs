using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BibliotecaPOOeBD2.Data;
using BibliotecaPOOeBD2.Formularios;

namespace BibliotecaPOOeBD2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btCadastrarLivro_Click(object sender, EventArgs e)
        {
            CadastrarUsuario form = new CadastrarUsuario();
            form.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Conexao.Conectar();
        }

        private void livrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastrarUsuario form = new CadastrarUsuario();
            form.ShowDialog();
        }

        private void pesquisarLivrosToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void pesquisarLivrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PesquisarLivro form = new PesquisarLivro();
            form.ShowDialog();
        }
    }
}
