using System;
using System.Windows.Forms;

namespace WSB_PO
{
    public partial class FormStorage : Form
    {
        public FormStorage()
        {
            InitializeComponent();
        }

        private void FormStorage_Load(object sender, EventArgs e)
        {
            DbAccess db = new DbAccess();
            dgv_Products.DataSource = db.GetProducts();
            dgv_Products.ReadOnly = true;
        }

        private void btn_AddProduct_Click(object sender, EventArgs e)
        {
            DbAccess db = new DbAccess();
            FormAddProduct fap = new FormAddProduct();
            fap.ShowDialog();
            dgv_Products.DataSource = db.GetProducts();
        }

        private void btn_RemoveProduct_Click(object sender, EventArgs e)
        {
            DbAccess db = new DbAccess();
            DialogResult dr = MessageBox.Show("Czy na pewno chcesz usunąć zaznaczony produkt?", "Potwierdzenie",
                MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                for (int i = 0; i < dgv_Products.SelectedRows.Count; i++)
                {
                    int id = Convert.ToInt32(dgv_Products.SelectedRows[i].Cells[0].Value);
                    db.DeleteQuery(id);
                }
                dgv_Products.DataSource = db.GetProducts();
            }
        }

        private void Click_Back(object sender, EventArgs e)
        {
            this.Close();
            var f1 = new Form1();
            f1.Show();
        }

    }
}