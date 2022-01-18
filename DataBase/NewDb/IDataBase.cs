using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSB_PO.Interfaces.NewDb;

namespace WSB_PO.Interfaces
{
    interface IDataBase<T> : IDbConn
    {
        void Create();
        DataTable Get();
        void Delete(T value);
        void Update(T value);
        void Insert(T value);

        IEnumerable<T> Search();
        T FindById(int it);
    }
}
