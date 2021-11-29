using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WSB_PO.Invoices
{
    public partial class FormAddInvoice : Form
    {
        public FormAddInvoice()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string FV = textBox1.Text;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dgv_Products_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormAddInvoice_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DbAccess.GetInvoiceData(
                        @"
                    SELECT Id, Name, Quantity, Sold, Price, PriceWithTax 
                    FROM Product
                    ");
            dataGridView1.ReadOnly = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            FormInvoices fi = new FormInvoices();
            fi.Show();
            //lala
            //lala
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            

        }
    }
}
