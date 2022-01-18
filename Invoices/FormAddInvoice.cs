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
using WSB_PO.ConvertModelss;
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

        bool edit = false;
        string selected;

        private static List<Product> stuffList = new List<Product>();
        readonly DataTable toGrid = new DataTable();
        public FormAddInvoice()
        {
            InitializeComponent();
            stuffList.Clear();
        }
        public FormAddInvoice(bool editing, string selected)
        {
            InitializeComponent();
            stuffList.Clear();
            edit = editing;
            this.selected = selected;
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

                    if (add.prod != null)
                    {
                        if (stuffList.Count < 6)
                        {
                            if (stuffList.Exists(stuffList => stuffList.ProdName == add.prod.ProdName))
                            {

                                var productToFind = stuffList.Find(p => p.ProdName == add.prod.ProdName);
                                var quantityToAdd = (double.Parse(productToFind.Quantity) + double.Parse(add.prod.Quantity)).ToString();
                                var priceToAdd = ((double.Parse(productToFind.Price) + ((double.Parse(add.prod.Price))))).ToString("F2");
                                var checkToAdd = (double.Parse(priceToAdd) * (1 + (double.Parse(add.prod.Tax) / 100))).ToString("F2");
                                var doubledProduct = new Product(quantityToAdd, checkToAdd, add.prod.Tax, add.prod.ProdName, add.prod.Desc, priceToAdd);

                                var toRemove = stuffList.FindIndex(p => p.ProdName == add.prod.ProdName);
                                stuffList.RemoveAt(toRemove);
                                stuffList.Add(doubledProduct);
                            }
                            else
                            {
                                var products = new Product(add.prod.Quantity, add.prod.Check, add.prod.Tax, add.prod.ProdName,
                                                                add.prod.Desc, add.prod.Price);
                                stuffList.Add(products);
                            }

                            dataGridView1.DataSource = typeof(List<Product>);
                            dataGridView1.DataSource = stuffList;
                        }
                        else
                        {
                            dataGridView1.DataSource = typeof(List<Product>);
                            dataGridView1.DataSource = stuffList;
                        }
                    }
                }
                catch (Exception w)
                {

                    MessageBox.Show(w.Message);
                }
            }

        }

        public void DeleteProductInvoice(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Czy na pewno chcesz usunąć zaznaczony produkt?", "Potwierdzenie",
                MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    if (stuffList.Count != 0)
                    {
                        var id = dataGridView1.CurrentRow.Index;
                        stuffList.RemoveAt(id);
                    }
                    else
                    {
                        MessageBox.Show("Nie możesz usunąć pustej listy!");
                    }

                    dataGridView1.DataSource = typeof(List<Product>);
                    dataGridView1.DataSource = stuffList; //binding
                }
            }
            catch (Exception z)
            {
                MessageBox.Show(z.Message);
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
                    invoiceRecLoc.Text ,invoiceLocation.Text ,invoiceMail.Text ,invoiceNip.Text, invoiceOff.Text, //6-10
                    invoicePersonal.Text ,invoicePostal.Text, invoiceSaleDate.Text, invoiceTel.Text     //11-14
                };
                bool check = Array.Exists<string>(info, p => string.IsNullOrEmpty(p));
                try
                {
                    if (check) throw new Exception("Wypełnij wszystkie pola");
                    else
                    {
                        Recipient recipient = new Recipient(invoicePersonal.Text, invoiceCompany.Text,
                        invoiceAdress.Text, invoiceRecLoc.Text, invoicePostal.Text, invoiceOff.Text, invoiceNip.Text,
                        invoiceTel.Text, invoiceMail.Text, invoiceCat.Text);


                        var dbQuery = new DbAccess();

                        uint hash = (uint)recipient.GetHashCode() / 1000;
                        _inv = new Invoice(info[0], hash, DateTime.Now.ToString(), stuffList, recipient);

                        if (edit == true)
                        {
                            dbQuery.UpdateQuery(uint.Parse(selected), info[10], info[3], info[1], info[5], info[11], invoiceOff.Text, info[8], info[13], info[7], info[2]);
                            dbQuery.UpdateQuery(uint.Parse(selected), invoicePersonal.Text, invoiceCompany.Text, invoiceAdress.Text, invoiceRecLoc.Text, invoicePostal.Text, invoiceOff.Text
                                , invoiceNip.Text, invoiceTel.Text, invoiceMail.Text, invoiceCat.Text, "");

                            for (int i = 0; i < stuffList.Count; i++)
                            {
                                var sold = stuffList[i].ProdName.ToString();
                                var qSubtract = stuffList[i].Quantity.ToString();
                                var tmp = dbQuery.Query($@"Select Quantity From Product where Name = '{sold}'");
                                var quantityGlobal = tmp.Rows[0]["Quantity"].ToString();
                                var math = (int.Parse(quantityGlobal) - int.Parse(qSubtract)).ToString();

                                dbQuery.UpdateQuery(math, sold);


                                //dodwanie produktow do bazy z id faktury
                                dbQuery.UpdateQuery(uint.Parse(selected), invoiceNumber.Text, info[3], sold, qSubtract, stuffList[i].Tax, stuffList[i].Price, stuffList[i].Check
                                    , DateTime.Now.ToString(), DateTime.Now.ToString(), "");
                            }
                        }
                        else
                        {
                            dbQuery.InsertQuery(hash, info[10], info[3], info[1], info[5], info[11], invoiceOff.Text, info[8], info[13], info[7], info[2]);
                            //aktualizujemy stan w bazie danych
                            for (int i = 0; i < stuffList.Count; i++)
                            {
                                var sold = stuffList[i].ProdName.ToString();
                                var qSubtract = stuffList[i].Quantity.ToString();
                                var tmp = dbQuery.Query($@"Select Quantity From Product where Name = '{sold}'");
                                var quantityGlobal = tmp.Rows[0]["Quantity"].ToString();
                                var math = (int.Parse(quantityGlobal) - int.Parse(qSubtract)).ToString();

                                dbQuery.UpdateQuery(math, sold);

                                var describe = stuffList[i].Desc.ToString();

                                //dodwanie produktow do bazy z id faktury
                                dbQuery.InsertQuery(hash, invoiceNumber.Text, info[3], sold, qSubtract, stuffList[i].Tax, stuffList[i].Price, stuffList[i].Check, DateTime.Now.ToString(), DateTime.Now.ToString(), describe, "");
                            }
                        }
                        edit = false;
                        this.Dispose();
                            this.Close();

                    }
                }
                catch (Exception msg)
                {
                    MessageBox.Show(msg.Message);
                }
            }


        }
        public void ViewerForm(Dictionary<uint, Invoice> find, uint selector)
        {
            bool[] info = new bool[]
                {
                    invoiceNumber.ReadOnly = true , invoiceAdress.ReadOnly = true, invoiceCat.ReadOnly = true, invoiceCompany.ReadOnly = true, invoiceDate.ReadOnly = true, //0-5
                    invoiceRecLoc.ReadOnly = true ,invoiceLocation.ReadOnly = true ,invoiceMail.ReadOnly = true ,invoiceNip.ReadOnly = true, invoiceOff.ReadOnly = true, //6-10
                    invoicePersonal.ReadOnly = true ,invoicePostal.ReadOnly = true, invoiceSaleDate.ReadOnly = true, invoiceTel.ReadOnly = true,button1.Enabled = false, button2.Enabled = false     //11-14
                };
            invoiceApply.Enabled = false;
            
            find.TryGetValue(selector, out _inv);

            invoiceNumber.Text = _inv.InvoiceId;
            invoiceAdress.Text = _inv.Recipient.Adress;
            invoiceCat.Text = _inv.Recipient.Category;
            invoiceCompany.Text = _inv.Recipient.Company;
            invoiceDate.Text = _inv.Date;
            invoiceRecLoc.Text = _inv.Recipient.City;
            invoiceLocation.Text = _inv.Recipient.City;
            invoiceMail.Text = _inv.Recipient.Mail;
            invoiceNip.Text = _inv.Recipient.Nip;
            invoiceOff.Text = _inv.Recipient.Discount;
            invoicePersonal.Text = _inv.Recipient.NameAndSur;
            invoicePostal.Text = _inv.Recipient.Postcode;
            invoiceSaleDate.Text = _inv.Date;
            invoiceTel.Text = _inv.Recipient.Phone;

            stuffList = _inv.Stuff;
            dataGridView1.DataSource = typeof(List<Product>);
            dataGridView1.DataSource = stuffList;

        }
        public void EditFormAddInvoice(string selected)
        {
            var cnvRec = new ConvertingRecipient();
            var cnvInv = new ConvertingInvoices();
            var cnvProd = new ConvertingProd();
            List<Recipient> editRecipient = cnvRec.ConvertDataToList($"Select * from Recipient where id={selected}");
            List<Invoice> inv = cnvInv.ConvertDataToList($"Select * from Invoices where HashID={selected}", $"Select * from Recipient where Id={selected}");
            List<Product> prod = new List<Product>();
            DbAccess db = new DbAccess();
            for (int i = 0; i < inv.Count; i++)
            {

                var sold = inv[i].Stuff[i].ProdName.ToString();
                var aToAdd = inv[i].Stuff[i].Quantity.ToString();
                var tmp = db.Query($@"Select Quantity From Product where Name = '{sold}'");
                var quantityGlobal = tmp.Rows[0]["Quantity"].ToString();
                var math = (int.Parse(quantityGlobal) + int.Parse(aToAdd)).ToString();

                db.UpdateQuery(math, sold);
                prod.Add(inv[i].Stuff[i]); 

            }

            invoiceDate.Text = string.Join(invoiceSaleDate.Text, inv.Select(s => s.Date));
            invoiceNumber.Text = string.Join(invoiceNumber.Text, inv.Select(s => s.InvoiceId));
            invoiceAdress.Text = string.Join(invoiceAdress.Text, editRecipient.Select(s => s.City));
            invoiceCat.Text = string.Join(invoiceCat.Text, editRecipient.Select(s => s.Category));
            invoiceCompany.Text = string.Join(invoiceCompany.Text, editRecipient.Select(s => s.Company));
            invoiceDate.Text = string.Join(invoiceDate.Text, inv.Select(s => s.Date));
            invoiceRecLoc.Text = string.Join(invoiceRecLoc.Text, editRecipient.Select(s => s.Adress));
            invoiceMail.Text = string.Join(invoiceMail.Text, editRecipient.Select(s => s.Mail));
            invoiceNip.Text = string.Join(invoiceNip.Text, editRecipient.Select(s => s.Nip));
            invoiceOff.Text = string.Join(invoiceOff.Text, editRecipient.Select(s => s.Discount));
            invoicePersonal.Text = string.Join(invoicePersonal.Text, editRecipient.Select(s => s.NameAndSur));
            invoicePostal.Text = string.Join(invoicePostal.Text, editRecipient.Select(s => s.Postcode));
            invoiceSaleDate.Text = string.Join(invoiceSaleDate.Text, inv.Select(s => s.Date));
            invoiceTel.Text = string.Join(invoiceTel.Text, editRecipient.Select(s => s.Phone));

            dataGridView1.DataSource = typeof(List<Product>);
            dataGridView1.DataSource = prod;
            stuffList.Clear();
            stuffList = prod;


        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void FormAddInvoice_Load(object sender, EventArgs e)
        {
            invoiceDate.ReadOnly = true;
            invoiceDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
        
    }
}
