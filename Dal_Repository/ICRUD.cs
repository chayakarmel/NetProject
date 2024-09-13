using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal_Repository
{
    internal interface ICRUD<T>
    {
        T Get(int id);
        List<T> GetAll(Func<T,bool>? condition= null);
        bool Add(T item);
        bool Update(T item);

        bool Delete(int id);

    }
}
