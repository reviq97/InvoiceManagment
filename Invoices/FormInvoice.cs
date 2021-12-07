using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WSB_PO.Invoices;

namespace WSB_PO.Invoices
{
    public partial class FormInvoice : Form
    {
        public static List<Products> stuffList = new List<Products>();
        DataTable toGrid = new DataTable();
        public FormInvoice()
        {
            InitializeComponent();
        }
        public FormInvoice(ref Products stuff)
        {
            InitializeComponent();
            stuffList.Add(stuff);
            dataGridView1.DataSource = stuffList;
        }
        
        private void label1_Click(object sender, EventArgs e)
        {

        }
        
        private void dataToGridView()
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string FV = invoiceNumber.Text;
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
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddProductInvoice(object sender, EventArgs e)
        {
            var addProd = new FormAddProd();
            this.Close();
            addProd.Show();

        }

        private void DeleteProductInvoice(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Czy na pewno chcesz usunąć zaznaczony produkt?", "Potwierdzenie",
                MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                var id = dataGridView1.CurrentRow.Index;
                stuffList.Add(new Products("","","","","",""));
                stuffList.RemoveAt(id);
                dataGridView1.DataSource = stuffList;
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void productsBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void invoiceCompany_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label7_Click_2(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
