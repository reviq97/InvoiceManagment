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
using WSB_PO.Invoices;

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
        public DataTable Query(string query)
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
                    MessageBox.Show(e.Message);
                    MessageBox.Show("Nie można połączyć się z bazą.", "Błąd");
                    return new DataTable();
                }
            }
        }
        public DataTable GetProducts()
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
        public void ModifyQuery()
        {

        }

        public void InsertQuery( string name, double price, double tax, int quantity, string ean, string unit)
        {
            var polishCulture = new CultureInfo("pl-PL");
            string presentTime = DateTime.Now.ToString(polishCulture);
            DbAccess db = new DbAccess();
            using (var con = new SQLiteConnection(db.LoadConnectionString()))
            {
                try
                {
                    using (SQLiteCommand command = new SQLiteCommand("INSERT INTO Product ( Name, Ean, Quantity, Tax, Price, PriceWithTax, Unit, CreatedOn, ModifiedOn) " +
                        "VALUES (@Name, @Ean, @Quantity, @Tax, @Price, @PriceWithTax, @Unit, @CreatedOn, @ModifiedOn)", con))
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
        public  void InsertQuery(uint hash, string name, string adress, string city, string postcode, string discount, string nip, string phone, string email, string category)
        {
            var polishCulture = new CultureInfo("pl-PL");
            string presentTime = DateTime.Now.ToString(polishCulture);
            DbAccess db = new DbAccess();
            using (var con = new SQLiteConnection(db.LoadConnectionString()))
            {
                try
                {
                    using (SQLiteCommand command = new SQLiteCommand("INSERT INTO Recipient (Id, Name, Address, City, Postcode, Discount, Nip, Phone, Email, Category) " +
                        "VALUES (@Id, @Name, @City, @Address, @Postcode, @Discount, @Nip, @Phone, @Email, @Category)", con))
                    {
                        command.Parameters.AddWithValue("@Id", hash);
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@City", city);
                        command.Parameters.AddWithValue("@Address", adress);
                        command.Parameters.AddWithValue("@Postcode", postcode);
                        command.Parameters.AddWithValue("@Discount", discount);
                        command.Parameters.AddWithValue("@Nip", nip);
                        command.Parameters.AddWithValue("@Phone", phone);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Category", category);
                        

                        con.Open();
                        int result = command.ExecuteNonQuery();

                        if (result < 0)
                            Console.WriteLine("Wystąpił błąd podczas insertowania do bazy.");
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    MessageBox.Show("Nie można połączyć się z bazą.", "Błąd");
                }
            }
        }
        public void InsertQuery(uint hasz, string invNumber, string sold, string quantity, string vat, string priceNet, string created, string modified, string comment)
        {
            var polishCulture = new CultureInfo("pl-PL");
            string presentTime = DateTime.Now.ToString(polishCulture);
            DbAccess db = new DbAccess();
            using (var con = new SQLiteConnection(db.LoadConnectionString()))
            {
                try
                {
                    using (SQLiteCommand command = new SQLiteCommand("INSERT INTO Invoices (HashID, InvNumber, Sold, Quantity, VAT, PriceNetto, CreatedOn, ModifiedOn, Comment) " +
                        "VALUES (@HashID,@InvNumber, @Sold, @Quantity, @VAT, @PriceNetto, @CreatedOn, @ModifiedOn, @Comment)", con))
                    {
                        command.Parameters.AddWithValue("@HashID", hasz);
                        command.Parameters.AddWithValue("@InvNumber", invNumber);
                        command.Parameters.AddWithValue("@Sold", sold);
                        command.Parameters.AddWithValue("@Quantity", quantity);
                        command.Parameters.AddWithValue("@VAT", vat);
                        command.Parameters.AddWithValue("@PriceNetto", priceNet);
                        command.Parameters.AddWithValue("@CreatedOn", created);
                        command.Parameters.AddWithValue("@ModifiedOn", modified);
                        command.Parameters.AddWithValue("@Comment", comment);

                        con.Open();
                        int result = command.ExecuteNonQuery();

                        if (result < 0)
                            Console.WriteLine("Wystąpił błąd podczas insertowania do bazy.");
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    MessageBox.Show("Nie można połączyć się z bazą.", "Błąd");
                }
            }
        }

        public void UpdateQuery(string condition, string product)
        {
            DbAccess db = new DbAccess();
            using (var con = new SQLiteConnection(db.LoadConnectionString()))
            {
                try
                {
                    using (SQLiteCommand command = new SQLiteCommand("UPDATE product SET Quantity = (@condition) where Name = @product" ,con))
                    {
                        command.Parameters.AddWithValue("@condition", condition);
                        command.Parameters.AddWithValue("@product", product);

                        con.Open();
                        int result = command.ExecuteNonQuery();

                        // Check Error
                        if (result < 0)
                            Console.WriteLine("Wystąpił błąd podczas przetwarzania bazy.");
                        else
                            MessageBox.Show("Faktura została dodana do bazy danych", "Operacja zakończona sukcesem");
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Nie można połączyć się z bazą.", "Błąd");
                }
            }
        }
        public void DeleteQuery(int id)
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
        public List<Product> ConvertDataTableToList()
        {
            DbAccess db = new DbAccess();
            List<Product> stuf = new List<Product>();
            DataTable data = new DataTable();
            data = db.GetProducts();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                Product tmp = new Product();
                tmp.ProdName = data.Rows[i]["Name"].ToString();
                tmp.Check = data.Rows[i]["Price"].ToString();
                tmp.Quantity = data.Rows[i]["Quantity"].ToString();
                stuf.Add(tmp);
            }
            return stuf;
        }
        public List<Recipient> ConvertDataTableToRecList()
        {
            DbAccess db = new DbAccess();
            List<Recipient> stuf = new List<Recipient>();
            DataTable data = new DataTable();

            data = db.Query("SELECT * FROM recipient");

            for (int i = 0; i < data.Rows.Count; i++)
            {

                Recipient tmp = new Recipient(
                    data.Rows[i]["Name"].ToString(),
                    data.Rows[i]["Address"].ToString(),
                    data.Rows[i]["City"].ToString(),
                    data.Rows[i]["Postcode"].ToString(),
                    0,
                    data.Rows[i]["Nip"].ToString(),
                    data.Rows[i]["Phone"].ToString(),
                    data.Rows[i]["Email"].ToString(),
                    data.Rows[i]["Category"].ToString()
                    );
                
                stuf.Add(tmp);

            }
            return stuf;
        }
    }
}


