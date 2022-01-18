using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSB_PO
{
    class DbCommands : IDbAccess
    {

        public string LoadConnectionString(string id = "Default")
        {
            throw new NotImplementedException();
        }

        public virtual DataTable GetProducts()
        {
            throw new NotImplementedException();
        }

        public virtual void InsertQuery(string name, decimal price, decimal tax, int quantity, string ean, string unit)
        {

        }
        public virtual void DeleteQuery(int id)
        {

        }
        public virtual void UpdateQuery(string condition, string name)
        {
            throw new NotImplementedException();
        }


        public void ModifyQuery()
        {
            throw new NotImplementedException();
        }

        public DataTable Query(string query)
        {
            throw new NotImplementedException();
        }

        
    }
}
