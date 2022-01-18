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
    class ProductRepo : IProduct<Product>
    {

        public string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
        public void Create()
        {
            throw new NotImplementedException();
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

        public void Delete(Product value)
        {
            throw new NotImplementedException();
        }

        public Product FindById(int it)
        {
            throw new NotImplementedException();
        }

        public void Insert(Product value)
        {
            throw new NotImplementedException();
        }

        public List<Product> productList()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> Search()
        {
            throw new NotImplementedException();
        }

        public void Update(Product value)
        {
            throw new NotImplementedException();
        }

        DataTable IDataBase<Product>.Get()
        {
            throw new NotImplementedException();
        }

        
    }
}
