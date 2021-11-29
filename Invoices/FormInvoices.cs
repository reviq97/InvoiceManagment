using System;
using System.Data;
using System.Windows.Forms;
using WSB_PO.Invoices;

namespace WSB_PO
{
    public partial class FormInvoices : Form
    {
        public static DataTable data = new DataTable();
        public FormInvoices()
        {
            InitializeComponent();
        }

        private int temp = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            temp++;
            listBox1.Items.Add(temp);
            listBox1.SelectedIndex = listBox1.Items.Count-1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
            listBox1.SelectedIndex = listBox1.Items.Count-1;
        }

        private void FormInvoices_Load(object sender, EventArgs e)
        {

        }

        private void button3_Back(object sender, EventArgs e)
        {
            this.Close();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            var gen = new FormAddInvoice();
            gen.Show();
        }
    }
}