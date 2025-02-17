using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace BibliotecaPOOeBD2.Models
{
    internal class Livro
    {
        public int idLivro { set; get; }
        public string titulo { set; get; }
        public string autor { set; get; }
        public string editora { set; get; }
        public DateTime anoPublicacao { set; get; }
        public string isbn { set; get; }
        public string genero { set; get; }
        public string edicao { set; get; }
        public string idioma { set; get; }
    }
}
