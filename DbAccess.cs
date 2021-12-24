using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WSB_PO
    {
        public class DbAccess : IDbAccess
        {
            public string LoadConnectionString(string id = "Default")
            {
                return ConfigurationManager.ConnectionStrings[id].ConnectionString;
            }

            public static string TestDatabase()
            {
                DbAccess db = new DbAccess();
                using (var con = new SQLiteConnection(db.LoadConnectionString()))
                {
                    try
                    {
                        con.Open();
                        return $"Połączono z bazą danych w wersji {con.ServerVersion}";
                    }
                    catch (Exception e)
                    {
                        return ("Nie można połączyć się z bazą.");
                    }
                }
            }
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
            public static DataTable GetProducts()
            {
                DataTable productsTable = new DataTable();
                DbAccess db = new DbAccess();
                using (var con = new SQLiteConnection(db.LoadConnectionString()))
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

            public static void AddProduct(string name, double price, double tax, int quantity, string ean, string unit)
            {
                var polishCulture = new CultureInfo("pl-PL");
                string presentTime = DateTime.Now.ToString(polishCulture);
                DbAccess db = new DbAccess();
                using (var con = new SQLiteConnection(db.LoadConnectionString()))
                {
                    try
                    {
                        using (SQLiteCommand command = new SQLiteCommand("INSERT INTO Product (Name, Ean, Quantity, Tax, Price, PriceWithTax, Unit, CreatedOn, ModifiedOn) VALUES (@Name, @Ean, @Quantity, @Tax, @Price, @PriceWithTax, @Unit, @CreatedOn, @ModifiedOn)", con))
                        {
                            command.Parameters.AddWithValue("@Name", name);
                            command.Parameters.AddWithValue("@Ean", ean);
                            command.Parameters.AddWithValue("@Quantity", quantity);
                            command.Parameters.AddWithValue("@Tax", tax);
                            command.Parameters.AddWithValue("@Price", price);
                            command.Parameters.AddWithValue("@PriceWithTax", price + (price * (tax / 100)));
                            command.Parameters.AddWithValue("@Unit", unit);
                            command.Parameters.AddWithValue("@CreatedOn", presentTime);
                            command.Parameters.AddWithValue("@ModifiedOn", presentTime);

                            con.Open();
                            int result = command.ExecuteNonQuery();

                            // Check Error
                            if (result < 0)
                                Console.WriteLine("Wystąpił błąd podczas insertowania do bazy.");
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Nie można połączyć się z bazą.", "Błąd");
                    }
                }
            }

            public static void RemoveProduct(int id)
            {
                DbAccess db = new DbAccess();
                using (var con = new SQLiteConnection(db.LoadConnectionString()))
                {
                    try
                    {
                        using (SQLiteCommand command = new SQLiteCommand("DELETE FROM product WHERE Id = @id", con))
                        {
                            command.Parameters.AddWithValue("@id", id);

                            con.Open();
                            int result = command.ExecuteNonQuery();

                            // Check Error
                            if (result < 0)
                                Console.WriteLine("Wystąpił błąd podczas usuwania z bazy.");
                            else
                                MessageBox.Show("Produkt został usunięty z magazynu.", "Operacja zakończona sukcesem");
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Nie można połączyć się z bazą.", "Błąd");
                    }
                }
            }
        }
}


