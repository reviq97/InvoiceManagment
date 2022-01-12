using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WSB_PO.Invoices
{
    public partial class FormAddProd : Form
    {
        private Product _prod;

        public Product prod
        {
            get
            {
                return _prod;
            }

            private set { _prod = value; }
        }
       

        public FormAddProd()
        {
            InitializeComponent();
        }

        private List<Product> ConvertDataTableToList()
        {
            DbAccess db = new DbAccess();
            List<Product> stuf = new List<Product>();
            var data = db.GetProducts();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                Product tmp = new Product
                {
                    ProdName = data.Rows[i]["Name"].ToString(),
                    Check = data.Rows[i]["Price"].ToString(),
                    Quantity = data.Rows[i]["Quantity"].ToString()
                };
                stuf.Add(tmp);
            }
            return stuf;
        }

        private void FormAddProd_Load(object sender, EventArgs e)
        {
            DbAccess db = new DbAccess();
            
            dataGridView1.DataSource = db.Query("SELECT Name, Quantity, Price " +
                "FROM Product");
            dataGridView1.ReadOnly = true;
            textBoxPrice.ReadOnly = true;
            

            List<Product> st = ConvertDataTableToList();

            foreach (var item in st)
            {
                comboBox1.Items.Add(item.ProdName);
            }

        }

        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Product> st = ConvertDataTableToList();

            var find = st.Find(c => c.ProdName.Contains(comboBox1.Text));
            textBoxPrice.Text = find.Check;
            for (int i = 0; i < int.Parse(find.Quantity); i++)
            {
                if (i == 0)
                {
                    comboBox2.Items.Clear();
                }
                comboBox2.Items.Add(i+1);
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             if (_prod == null)
            {
                MessageBox.Show("Wypełnij wszystkie pola!");
            }
            else
            {
               Close();
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0)
            {

            }
        }

        private void cbx_Tax_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbx_Tax.Text.Length>0)
            {
                double price, tax, quantity, brutto;
                textBox5.ReadOnly = true;
                try
                {
                    price = double.Parse(textBoxPrice.Text, CultureInfo.GetCultureInfo("en-EN"));
                    quantity = double.Parse(comboBox2.Text, CultureInfo.GetCultureInfo("en-EN"));
                    tax = double.Parse(cbx_Tax.Text.Remove(cbx_Tax.Text.Length - 1), CultureInfo.GetCultureInfo("pl-PL"));
                    string description = textBoxDesc.Text;


                    brutto = (((price / 100) * (1 + (tax / 100))) * quantity);
                    price *= (quantity)/100;

                    textBox5.Text = brutto.ToString("F2");

                    prod = new Product(quantity.ToString(), brutto.ToString("F2")
                        , cbx_Tax.Text.ToString(), comboBox1.Text, description, price.ToString("F2"));
                }
                catch (Exception msg)
                {
                    MessageBox.Show(msg.Message);
                }
            }
        }
    }
}
