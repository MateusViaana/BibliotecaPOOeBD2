using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BibliotecaPOOeBD2.Models
{
    internal class Livro
    {
        public int idLivro { set; get; }
        public string titulo { set; get; }
        public string autor { set; get; }
        public string editora { set; get; }
        public DateTime anoPublicacao { set; get; }
        public string isbn {  set; get; }
        public string genero { set; get; }
        public string edicao { set; get; }
        public string idioma { set; get; }

        public int fk_idBiblioteca { set; get; }

        public void setISBN(string isbn)
        {
            if (isbn.Length != 13)
            {
                MessageBox.Show("Quantidade de números ISBN deve ser 13!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
           
            else
            {
                this.isbn = isbn;
            }
        }
    }
}
