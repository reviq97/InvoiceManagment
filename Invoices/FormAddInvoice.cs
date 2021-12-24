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
    public partial class FormAddInvoice : Form
    {
        private Invoice _inv;

        public Invoice Inv
        {
            get { return _inv; }
            private set { _inv = value; }
        }
        private static List<Products> stuffList = new List<Products>();

        DataTable toGrid = new DataTable();
        public FormAddInvoice()
        {
            InitializeComponent();
            stuffList.Clear();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string FV = invoiceNumber.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }
        private void AddProductInvoice(object sender, EventArgs e)
        {

            using (var add = new FormAddProd())
            {
                add.ShowDialog();

                var prod = new Products(add.prod.Quantity, add.prod.Check, add.prod.Tax, add.prod.Product,
                        add.prod.Describe, add.prod.Price);

                stuffList.Add(prod);
                dataGridView1.DataSource = typeof(List<Products>);
                dataGridView1.DataSource = stuffList;  
            }

        }

        private void DeleteProductInvoice(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Czy na pewno chcesz usunąć zaznaczony produkt?", "Potwierdzenie",
                MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                var id = dataGridView1.CurrentRow.Index;
                stuffList.RemoveAt(id);
                dataGridView1.DataSource = typeof(List<Products>);
                dataGridView1.DataSource = stuffList; //binding
            }
        }

        private void invoiceApply_Click(object sender, EventArgs e)
        {
            string [] text = new string[]
            {
                invoiceNumber.Text,invoiceAdress.Text,invoiceCat.Text,invoiceCompany.Text,invoiceDate.Text,
                invoiceLoc.Text,invoiceLocation.Text,invoiceMail.Text,invoiceNip.Text,invoiceOff.Text,
                invoicePersonal.Text,invoicePostal.Text,invoiceSaleDate.Text,invoiceTel.Text
            };
            bool check = Array.Exists<string>(text, p => string.IsNullOrEmpty(p));
            try
            {
                if (check) throw new Exception("Wypełnij wszystkie pola");
                else
                {
                    //stworzyc database ktory ma recipientow
                        Recipient recipient = new Recipient(invoiceCompany.Text, invoicePersonal.Text,
                        invoiceAdress.Text, invoiceLocation.Text, invoicePostal.Text, 0, invoiceNip.Text,
                        invoiceTel.Text, invoiceMail.Text, invoiceCat.Text);


                    _inv = new Invoice(text[0], 0, DateTime.Now,stuffList,recipient);
                    
                    this.Close();
                }
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.Message);
            }
            
        }
    }
}
