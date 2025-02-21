using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaPOOeBD2.Interface
{
    public interface IDAO<T>
    {
        void Insert(T item);

        void Update(T item);

        void Delete(int id);
       
    }
}
