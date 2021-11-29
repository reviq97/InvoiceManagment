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
    public partial class FormAddProd : Form
    {
        public FormAddProd()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbx_Tax_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FormAddProd_Load(object sender, EventArgs e)
        {
            var data = DbAccess.GetProducts("SELECT Name, Quantity, Price " +
                "FROM Product");
            dataGridView1.DataSource = DbAccess.GetProducts("SELECT Name, Quantity, Price " +
                "FROM Product");
            dataGridView1.ReadOnly = true;

            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*try
            {
                var select = dataGridView1.SelectedRows[0].DataBoundItem;
                textBoxName.Text = select.ToString().;
                textBoxQuantity.Text = select.ToString();
                textBoxPrice.Text = select.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Coś poszło nie tak");
            }*/
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
