using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSB_PO
{
    interface IDbAccess
    {
        DataTable QueryToProducts(string query);
        string LoadConnectionString(string id = "Default");
    }
}
