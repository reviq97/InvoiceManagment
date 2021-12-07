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
        Products prod;
        public FormAddProd()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbx_Tax_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
        private List<Products> ConvertDataTableToList()
        {
            List<Products> stuf = new List<Products>();
            DataTable data = new DataTable();
            data = DbAccess.GetProducts();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                Products tmp = new Products();
                tmp.Product = data.Rows[i]["Name"].ToString();
                tmp.Check= data.Rows[i]["Price"].ToString();
                tmp.Quantity = data.Rows[i]["Quantity"].ToString();
                stuf.Add(tmp);
            }
            return stuf;
        }

        private void FormAddProd_Load(object sender, EventArgs e)
        {

            
            dataGridView1.DataSource = DbAccess.GetProducts("SELECT Name, Quantity, Price " +
                "FROM Product");
            dataGridView1.ReadOnly = true;
            textBoxPrice.ReadOnly = true;
            

            List<Products> st = ConvertDataTableToList();

            foreach (var item in st)
            {
                comboBox1.Items.Add(item.Product);
            }

        }

        private void textBox5_Click(object sender, EventArgs e)
        {
            double price, tax, quantity, brutto;

            price = double.Parse(textBoxPrice.Text, CultureInfo.GetCultureInfo("en-EN"));
            quantity = double.Parse(comboBox2.Text, CultureInfo.GetCultureInfo("en-EN"));
            tax = double.Parse(cbx_Tax.Text.Remove(cbx_Tax.Text.Length - 1), CultureInfo.GetCultureInfo("pl-PL"));
            string description = textBoxDesc.Text;

            brutto = ((price * quantity) * (1 + (tax / 100)))/100;
            textBox5.Text = brutto.ToString("F2");

            prod = new Products(quantity.ToString(), brutto.ToString()
                , cbx_Tax.Text.ToString(),comboBox1.Text, description, textBoxPrice.Text.ToString() );
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Products> st = ConvertDataTableToList();

            var find = st.Find(c => c.Product.Contains(comboBox1.Text));
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

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new FormInvoice(ref prod);
            form.Show();
            this.Close();
           
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0)
            {

            }
        }
    }
}
