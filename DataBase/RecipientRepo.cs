using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WSB_PO.Interfaces;
using WSB_PO.Invoices;

namespace WSB_PO.DataBase
{
    class RecipientRepo : IRecipient<Recipient>
    {
        public string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
        
        public DataTable Get()
        {
            DataTable productsTable = new DataTable();
            using (var con = new SQLiteConnection(LoadConnectionString()))
            {
                try
                {
                    con.Open();

                    string query =
                        @"
                        SELECT *
                        FROM Product
                                    ";

                    var adapter = new SQLiteDataAdapter(query, con);
                    adapter.Fill(productsTable);

                    return productsTable;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Nie można połączyć się z bazą.", "Błąd");
                    return new DataTable();
                }
            }
        }

        public void Delete(Recipient value)
        {
            using (var con = new SQLiteConnection(LoadConnectionString()))
            {
                try
                {
                    con.Open();

                    string query =
                        @"
                        SELECT *
                        FROM Product
                                    ";

                    var adapter = new SQLiteDataAdapter(query, con);

                }
                catch (Exception e)
                {
                    MessageBox.Show("Nie można połączyć się z bazą.", "Błąd");
                }
            }
        }

        public Recipient FindById(int it)
        {
            throw new NotImplementedException();
        }

        public void Insert(Recipient value)
        {
            throw new NotImplementedException();
        }

        public List<Recipient> recipientsList()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Recipient> Search()
        {
            throw new NotImplementedException();
        }

        public void Update(Recipient value)
        {
            throw new NotImplementedException();
        }

        DataTable IDataBase<Recipient>.Get()
        {
            throw new NotImplementedException();
        }

        public void Create()
        {
            throw new NotImplementedException();
        }
    }
}
