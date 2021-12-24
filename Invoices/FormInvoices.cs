using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using WSB_PO.Invoices;

namespace WSB_PO
{
    public partial class FormInvoices : Form
    {
        public static DataTable data = new DataTable();
        private static List<Invoices.Invoice> listInvoices = new List<Invoices.Invoice>();
        public FormInvoices()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //przy zatwierdzaniu faktury nalezy zwolnic stan w bazie danych (napisac kod)
            using (var fainvoice = new FormAddInvoice())
            {
                fainvoice.ShowDialog();

                //potrzebny if, w przypadku gdy ktoœ wciœnie X musi po prostu zamknac okno i reszte miec w dupie
                listInvoices.Add(new Invoices.Invoice(fainvoice.Inv.InvoiceId,fainvoice.Inv.RecipientId,
                DateTime.Now,fainvoice.Inv.Stuff, fainvoice.Inv.Recipient));
                int size = listInvoices.Count;
                listBox1.Items.Add(listInvoices[size-1].InvoiceId);
            }
            
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
            //edycja
        }
    }
}