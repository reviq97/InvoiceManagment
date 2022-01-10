using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSB_PO.Interfaces
{
    public interface IDataBase<T>
    {
        T Create();
        void Delete(T value);
        void Update(T value);
        void Insert(T value);

        IEnumerable<T> Search();
        T FindById(int it);
    }
}
