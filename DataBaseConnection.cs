using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WSB_PO
{
    class DataBaseConnection : IDbAccess
    {
        public DataTable QueryToProducts(string query)
        {
            var invoiceData = new DataTable();
            using (var con = new SQLiteConnection(LoadConnectionString()))
            {
                try
                {
                    con.Open();
                    var adapter = new SQLiteDataAdapter(query, con);
                    adapter.Fill(invoiceData);

                    return invoiceData;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Nie można połączyć się z bazą.", "Błąd");
                    return new DataTable();
                }
            }
        }

        public string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
