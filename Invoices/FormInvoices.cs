using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using WSB_PO.ConvertModelss;
using WSB_PO.Invoices;
using WSB_PO.Xml;

namespace WSB_PO
{
    public partial class FormInvoices : Form
    {
        public static DataTable data = new DataTable();
        private static readonly List<Invoices.Invoice> listInvoices = new List<Invoices.Invoice>();
        Dictionary<uint, Invoice> findDict = new Dictionary<uint, Invoice>();

        readonly DbAccess db = new DbAccess();

        public FormInvoices()
        {
            InitializeComponent();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (var fainvoice = new FormAddInvoice())
            {
                try
                {
                    fainvoice.ShowDialog();

                    if (fainvoice.Inv.Stuff != null)
                    {
                        listInvoices.Add(new Invoices.Invoice(fainvoice.Inv.InvoiceId, fainvoice.Inv.Hash,
                       DateTime.Now.ToString(), fainvoice.Inv.Stuff, fainvoice.Inv.Recipient));
                        var db = new DbAccess();
                    }
                    var rec = new ConvertingRecipient();
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message);
                }

            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //W przypadku usuniêcia, faktura musi zostaæ usuniêta równie¿ w bazie danych
            listBox1.Items.Remove(listBox1.SelectedItem);
            listBox1.SelectedIndex = listBox1.Items.Count-1;
        }

        private void FormInvoices_Load(object sender, EventArgs e)
        {
            var rec = new ConvertingRecipient();
            List<Recipient> recList = rec.ConvertDataToList(); 
            foreach (var item in recList)
            {
                listBox1.Items.Add(item.Id);
            }
            
        }
        
        private void button3_Back(object sender, EventArgs e)
        {
            this.Close();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.SelectedItem != null)
                {
                    DialogResult dr = MessageBox.Show("Czy na pewno chcesz wejœæ? Stan magazynu zostanie powiêkszony o iloœæ produktów na fakturze", "Potwierdzenie",
               MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        var selected = listBox1.SelectedItem.ToString();
                        bool editing = true;
                        //pobieramy informacje z bazy danych do listy, lista otwiera showDialog,
                        using (var editInvoice = new FormAddInvoice(editing, selected))
                        {
                            editInvoice.EditFormAddInvoice(selected);
                            editInvoice.ShowDialog();
                            MessageBox.Show("Pomyœlnie dokonano korekty faktury");
                        }
                    }
                }
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.Message);
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.SelectedItem != null)
                {
                    uint selector = uint.Parse(listBox1.SelectedItem.ToString());
                    List<Invoice> tmp = new List<Invoice>();
                    ConvertingInvoices cnv = new ConvertingInvoices();
                    tmp = cnv.ConvertDataToList($"Select * from Invoices Where HashId = {selector}", $"SELECT * from Recipient Where id = {selector}");
                    foreach (var item in tmp)
                    {
                        if (!findDict.ContainsKey(selector))
                        {
                            findDict.Add(item.Hash, item);
                        }
                    }
                    using (var viewerForm = new FormAddInvoice())
                    {
                        viewerForm.ViewerForm(findDict, selector);
                        viewerForm.ShowDialog();
                    }
                }
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.Message);
            }
            
                
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.SelectedItem != null)
                {
                    var selected = listBox1.SelectedItem.ToString();
                    ConvertingInvoices cnv = new ConvertingInvoices();
                    List<Invoice> tmp = cnv.ConvertDataToList($"Select * from Invoices Where HashId = {selected}", $"SELECT * from Recipient Where id = {selected}");

                    List<ToXmlModel> listXml = new List<ToXmlModel>();
                    List<string> list = new List<string>();

                    foreach (var item in tmp)
                    {
                        ToXmlModel xml = new ToXmlModel();

                        xml.Hash = item.Hash.ToString();
                        xml.InvoiceId = item.InvoiceId.ToString();
                        xml.Recipient.Add(item.Recipient.Mail.ToString());
                        xml.Recipient.Add(item.Recipient.NameAndSur.ToString());
                        xml.Recipient.Add(item.Recipient.Nip.ToString());
                        xml.Recipient.Add(item.Recipient.Phone.ToString());
                        xml.Recipient.Add(item.Recipient.Postcode.ToString());
                        xml.Recipient.Add(item.Recipient.Adress.ToString());
                        xml.Recipient.Add(item.Recipient.Category.ToString());
                        xml.Recipient.Add(item.Recipient.City.ToString());
                        xml.Recipient.Add(item.Recipient.Company.ToString());

                        listXml.Add(xml);
                    }
                    XmlToSerialize xmlToSerialize = new XmlToSerialize();
                    xmlToSerialize.Serialize(listXml);
                }
                
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.Message);
            }
            
           

            

        }

    }
}