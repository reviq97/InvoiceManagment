using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSB_PO.Invoices;

namespace WSB_PO.Interfaces
{
    interface IProduct<T> : IDataBase<T>
    {
        List<T> productList();

    }
}
