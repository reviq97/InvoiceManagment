using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WSB_PO.Interfaces;
using WSB_PO.Invoices;

namespace WSB_PO.Invoices
{
    public partial class FormAddInvoice : Form, IModifyForm
    {
        private Invoice _inv;

        public Invoice Inv
        {
            get {
                if (_inv == null)
                {
                    return new Invoice();
                }
                else
                {
                    return _inv;
                }
                 }
            private set { _inv = value; }
        }
        private static List<Product> stuffList = new List<Product>();

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
        public void AddProductInvoice(object sender, EventArgs e)
        {

            using (var add = new FormAddProd())
            {
                try
                {
                    add.ShowDialog();


                    var prod = new Product(add.prod.Quantity, add.prod.Check, add.prod.Tax, add.prod.ProdName,
                        add.prod.Describe, add.prod.Price);

                    stuffList.Add(prod);
                    dataGridView1.DataSource = typeof(List<Product>);
                    dataGridView1.DataSource = stuffList;
                }
                catch (Exception)
                {

                    MessageBox.Show("Wypełnij wszystkie pola!");
                }
            }

        }

        public void DeleteProductInvoice(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Czy na pewno chcesz usunąć zaznaczony produkt?", "Potwierdzenie",
                MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                var id = dataGridView1.CurrentRow.Index;
                stuffList.RemoveAt(id);
                dataGridView1.DataSource = typeof(List<Product>);
                dataGridView1.DataSource = stuffList; //binding
            }
        }

        private void invoiceApply_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Czy na pewno chcesz zatwierdzić fakturę?", "Potwierdzenie",
               MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                string[] info = new string[]
                {
                    invoiceNumber.Text , invoiceAdress.Text, invoiceCat.Text, invoiceCompany.Text, invoiceDate.Text, //0-5
                    invoiceLoc.Text ,invoiceLocation.Text ,invoiceMail.Text ,invoiceNip.Text, invoiceOff.Text, //6-10
                    invoicePersonal.Text ,invoicePostal.Text, invoiceSaleDate.Text, invoiceTel.Text     //11-14
                };
                bool check = Array.Exists<string>(info, p => string.IsNullOrEmpty(p));
                try
                {
                    if (check) throw new Exception("Wypełnij wszystkie pola");
                    else
                    {
                        Recipient recipient = new Recipient(invoiceCompany.Text,
                        invoiceAdress.Text, invoiceLocation.Text, invoicePostal.Text, 0, invoiceNip.Text,
                        invoiceTel.Text, invoiceMail.Text, invoiceCat.Text);

                        _inv = new Invoice(info[0], 0, DateTime.Now, stuffList, recipient);

                        var dbQuery = new DbAccess();

                        uint hash = (uint)recipient.GetHashCode()/1000;

                        dbQuery.InsertQuery(hash, info[3], info[1], info[5], info[11], "", info[8], info[13], info[7],info[2]);
                        // haszkod ustala id dla danego recipienta, uzupelnic discount, category, company

                        //aktualizujemy stan w bazie danych
                        for (int i = 0; i < stuffList.Count; i++)
                        {
                            var name = stuffList[i].ProdName.ToString();
                            var qSubtract = stuffList[i].Quantity.ToString();
                            var tmp = dbQuery.Query($@"Select Quantity From Product where Name = '{name}'");
                            var quantityGlobal = tmp.Rows[0]["Quantity"].ToString();
                            var math = (int.Parse(quantityGlobal) - int.Parse(qSubtract)).ToString();

                            dbQuery.UpdateQuery(math, name);

                            var describe = stuffList[i].Describe.ToString();

                            dbQuery.InsertQuery(hash, name, qSubtract, DateTime.Now.ToString(), DateTime.Now.ToString(), describe);
                        }

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
}
