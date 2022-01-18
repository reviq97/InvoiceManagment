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
using WSB_PO.ConvertModelss;
using WSB_PO.Invoices;

namespace WSB_PO
{
    class DbAccess :  IDbAccess
    {
        public delegate void Converter();
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

        public void InsertQuery( string name, decimal price, decimal tax, int quantity, string ean, string unit)
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
        public  void InsertQuery(uint hash, string name, string company, string adress, string city, string postcode, string discount, string nip, string phone, string email, string category)
        {
            DbAccess db = new DbAccess();
            using (var con = new SQLiteConnection(db.LoadConnectionString()))
            {
                try
                {
                    using (SQLiteCommand command = new SQLiteCommand("INSERT INTO Recipient (Id, Name, Company, Address, City, Postcode, Discount, Nip, Phone, Email, Category) " +
                        "VALUES (@Id, @Name, @Company ,@City, @Address, @Postcode, @Discount, @Nip, @Phone, @Email, @Category)", con))
                    {
                        command.Parameters.AddWithValue("@Id", hash);
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Company", company);
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
        public void InsertQuery(uint hasz, string invNumber, string name, string sold, string quantity, string vat, string priceNet, string priceBrutto, string created, string modified, string comment, string add)
        {
            DbAccess db = new DbAccess();
            using (var con = new SQLiteConnection(db.LoadConnectionString()))
            {
                try
                {
                    using (SQLiteCommand command = new SQLiteCommand("INSERT INTO Invoices (HashID, InvNumber, Name, Sold, Quantity, VAT, PriceNetto, PriceBrutto, CreatedOn, ModifiedOn, Comment) " +
                        "VALUES (@HashID,@InvNumber,@Name, @Sold, @Quantity, @VAT, @PriceNetto, @PriceBrutto, @CreatedOn, @ModifiedOn, @Comment)", con))
                    {
                        command.Parameters.AddWithValue("@HashID", hasz);
                        command.Parameters.AddWithValue("@InvNumber", invNumber);
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Sold", sold);
                        command.Parameters.AddWithValue("@Quantity", quantity);
                        command.Parameters.AddWithValue("@VAT", vat);
                        command.Parameters.AddWithValue("@PriceNetto", priceNet);
                        command.Parameters.AddWithValue("@PriceBrutto", priceBrutto);
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
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
        public void UpdateQuery(uint hash, string invNumber, string name, string sold, string quantity, string vat, string priceNet, string priceBrutto, string created, string modified, string comment)
        {
            DbAccess db = new DbAccess();
            using (var con = new SQLiteConnection(db.LoadConnectionString()))
            {
                try
                {
                    using (SQLiteCommand command = new SQLiteCommand("UPDATE Invoices SET InvNumber = @InvNumber , Name = @Name, Sold = @Sold, Quantity = @Quantity ," +
                        " VAT = @VAT, PriceNetto  = @PriceNetto, PriceBrutto = @PriceBrutto, CreatedOn = @CreatedOn, ModifiedOn = @ModifiedOn, Comment = @Comment " +
                        "where HashID = @id", con))
                    {
                        command.Parameters.AddWithValue("@id", hash);
                        command.Parameters.AddWithValue("@InvNumber", invNumber);
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Sold", sold);
                        command.Parameters.AddWithValue("@Quantity", quantity);
                        command.Parameters.AddWithValue("@VAT", vat);
                        command.Parameters.AddWithValue("@PriceNetto", priceNet);
                        command.Parameters.AddWithValue("@PriceBrutto", priceBrutto);
                        command.Parameters.AddWithValue("@CreatedOn", created);
                        command.Parameters.AddWithValue("@ModifiedOn", modified);
                        command.Parameters.AddWithValue("@Comment", comment);

                        con.Open();
                        int result = command.ExecuteNonQuery();

                        // Check Error
                        if (result < 0)
                            Console.WriteLine("Wystąpił błąd podczas przetwarzania bazy.");
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
        public void UpdateQuery(uint hash, string name, string company, string adress, string city, string postcode, string discount, string nip, string phone, string email, string category, string add)
        {
            DbAccess db = new DbAccess();
            using (var con = new SQLiteConnection(db.LoadConnectionString()))
            {
                try
                {
                    using (SQLiteCommand command = new SQLiteCommand("UPDATE Recipient SET  Name = @Name , Company = @Company, " +
                        "Address = @Address, City = @City, Postcode = @Postcode, Discount = @Discount, Nip = @Nip, Phone = @Phone, Email = @Email, Category = @Category " +
                        "where Id= @Id", con))
                    {
                        command.Parameters.AddWithValue("@Id", hash);
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Company", company);
                        command.Parameters.AddWithValue("@City", adress);
                        command.Parameters.AddWithValue("@Address", city);
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
        
        
    }
        
}


