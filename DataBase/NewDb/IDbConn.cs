using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSB_PO.Interfaces.NewDb
{
    interface IDbConn
    {
        string LoadConnectionString(string id = "Default");
    }
}
