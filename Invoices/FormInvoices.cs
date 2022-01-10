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
        DbAccess db = new DbAccess();
        


        public FormInvoices()
        {
            InitializeComponent();
            //Na samym pocz¹tku musz¹ zostaæ wyœwietlone wszstkie fakutry które ju¿ s¹ w bazie danych
            //Moze lepiej daæ datagridview zamiast listbox
            //gdy starczy czasu zmieñ interfejs DataBase 

            //zabezpieczyæ przycisk X w przypadku gdy ktos wyjdzie, kompozycja lub overriding buttona X
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (var fainvoice = new FormAddInvoice())
            {
                try
                {
                    fainvoice.ShowDialog();

                    //potrzebny if, w przypadku gdy ktoœ wciœnie X musi po prostu zamknac okno i reszte miec w dupie
                    listInvoices.Add(new Invoices.Invoice(fainvoice.Inv.InvoiceId, fainvoice.Inv.RecipientId,
                        DateTime.Now, fainvoice.Inv.Stuff, fainvoice.Inv.Recipient));
                    var db = new DbAccess();

                    int size = listInvoices.Count-1;
                    if (listInvoices.Count == 1)
                    {
                        listBox1.Items.Add(listInvoices[0].InvoiceId);
                    }
                    else
                    {
                        if (listInvoices.Count>1)
                        {
                            listBox1.Items.Add(listInvoices[size].InvoiceId);
                        }
                    }

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
            
        }

        private void button3_Back(object sender, EventArgs e)
        {
            this.Close();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var db = new DbAccess();
            var data = db.Query("Select * from Recipient");
            List<Recipient> editRecipient = db.ConvertDataTableToRecList();

            //pobieramy informacje z bazy danych do listy, lista otwiera showDialog,
            using(var editInvoice = new FormAddInvoice()){
                
                editInvoice.ShowDialog();


            }
            //wkleja wartosci ktore by³y, u¿ytkownik to edytuje, od razu nalezy dodaæ stan jaki jest w magazynie
            //w przypadku gdy nie zmieni siê to po prostu np z 95 + 5 i przy zamknieciu okna -5.
            //Taki mechanizm bêdzie mieæ w przypadku edycji. Ktoœ siê pomyli³ zamiast 1 dal 10. 
            //program najpierw dodaje +1 do ogólnego stanu, nastêpnie przy kliknieciu przycisku
            //zatwierdz odejmuje 10.


        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Dictionary
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Interfejs odpowiedzialny za druk
        }
    }
}