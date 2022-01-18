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
    class InvoiceRepo : IInvoice<Invoice> 
    {

        public string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        public void Create()
        {
            using (var con = new SQLiteConnection(LoadConnectionString()))
            {
                try
                {
                    con.Open();

                    string query =
                        @"
                        SELECT *
                        FROM Invoices
                                    ";

                    var adapter = new SQLiteDataAdapter(query, con);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Nie można połączyć się z bazą.", "Błąd");
                }
            }
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
                        FROM Invoices
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

        public virtual void Delete(Invoice value)
        {

        }

        public Invoice FindById(int it)
        {
            throw new NotImplementedException();
        }

        public void Insert(Invoice value)
        {
            throw new NotImplementedException();
        }

        public List<Invoice> invoiceList()
        {
            return new List<Invoice>();
        }

        
        public IEnumerable<Invoice> Search()
        {
            throw new NotImplementedException();
        }

        public void Update(Invoice value)
        {
            throw new NotImplementedException();
        }

    }
}
