using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WSB_PO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void PictureInvoices_Click(object sender, EventArgs e)
        {
            using (FormInvoices fi = new FormInvoices())
            {
                this.Hide();
                fi.ShowDialog();
            }

        }

        private void pictureWarehouse_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormStorage fs = new FormStorage();
            fs.ShowDialog();
        }

        private void pictureExchange_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kliknięto Wydania i przyjęcia", "Wydania i przyjęcia");
        }
    }
}
