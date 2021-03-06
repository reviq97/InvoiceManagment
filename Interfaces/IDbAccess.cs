using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSB_PO
{
    public interface IDbAccess
    {
        DataTable Query(string query);
        string LoadConnectionString(string id = "Default");
        DataTable GetProducts();
        void ModifyQuery();
        void InsertQuery(string name, decimal price, decimal tax, int quantity, string ean, string unit);
        void UpdateQuery(string condition, string name);
        void DeleteQuery(int id);
    }
}
