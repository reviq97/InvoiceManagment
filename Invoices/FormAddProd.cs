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
        private Product _tmp;

        public Product tmpProd
        {
            get { return _tmp; }
            private set { _tmp = value; }
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
                (
                    data.Rows[i]["Quantity"].ToString(),
                    data.Rows[i]["Price"].ToString(),
                    data.Rows[i]["Name"].ToString(),
                    data.Rows[i]["Tax"].ToString()

                ); 
                stuf.Add(tmp);
            }
            return stuf;
        }

        private void FormAddProd_Load(object sender, EventArgs e)
        {
            DbAccess db = new DbAccess();
            dataGridView1.DataSource = db.Query("SELECT Name, Quantity, Price, Tax " +
                "FROM Product");
            cbx_Tax.ReadOnly = true;
            dataGridView1.ReadOnly = true;
            textBoxPrice.ReadOnly = true;
            priceBox.ReadOnly = true;

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
            cbx_Tax.Text = find.Tax + "%";
            comboBox2.Items.Clear();
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
            prod = null;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (string.IsNullOrEmpty(cbx_Tax.Text) || string.IsNullOrEmpty(comboBox2.Text) || string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Wypełnij wszystkie pola!");
            }
            else
            {
                Dispose();
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
            try
            {
                NullOrEmptyState();
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.Message);
            }
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            try
            {
                NullOrEmptyState();
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.Message);
            }
        }
        private void NullOrEmptyState()
        {
            if (!string.IsNullOrEmpty(cbx_Tax.Text) && !string.IsNullOrEmpty(comboBox2.Text) && !string.IsNullOrEmpty(textBoxPrice.Text))
            {
                double price = double.Parse(textBoxPrice.Text, CultureInfo.GetCultureInfo("en-EN"))*100;
                double quantity = double.Parse(comboBox2.Text, CultureInfo.GetCultureInfo("en-EN"));
                double tax = double.Parse(cbx_Tax.Text.Remove(cbx_Tax.Text.Length - 1), CultureInfo.GetCultureInfo("pl-PL"));
                string description = textBoxDesc.Text;

                double brutto = (((price / 100) * (1 + (tax / 100))) * quantity);
                price *= (quantity) / 100;

                priceBox.Text = brutto.ToString("F2");

                prod = new Product(quantity.ToString(), brutto.ToString("F2"), tax.ToString("F2"), comboBox1.Text, description, price.ToString("F2"));
            }
        }
    }
}
