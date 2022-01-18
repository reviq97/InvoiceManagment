using System;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WSB_PO
{
    public partial class FormAddProduct : Form
    {
        public FormAddProduct()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            mtb_Brutto.Enabled = false;
            mtb_Netto.Enabled = true;
            radioButton1.Font = new Font(radioButton1.Font, FontStyle.Bold);
            radioButton2.Font = new Font(radioButton2.Font, FontStyle.Regular);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            mtb_Brutto.Enabled = true;
            mtb_Netto.Enabled = false;
            radioButton1.Font = new Font(radioButton1.Font, FontStyle.Regular);
            radioButton2.Font = new Font(radioButton2.Font, FontStyle.Bold);
        }
        
        private void mtb_Netto_Leave(object sender, EventArgs e)
        {
            try
            {
                string textNetto = Regex.Replace(mtb_Netto.Text, "[^0-9.]", "");
                string cenaNetto = textNetto.Insert(textNetto.Length - 2, ",");
                double doubleNetto = Convert.ToDouble(cenaNetto) ;
                double tax = Convert.ToDouble(cbx_Tax.Text.Remove(cbx_Tax.Text.Length - 1));

                double priceWithTax = doubleNetto + (doubleNetto * (tax / 100));
                string priceWithTaxNumsOnly = Regex.Replace(Math.Round(priceWithTax, 2, MidpointRounding.AwayFromZero).ToString("N2"), "[^0-9.]", "");
                if (priceWithTaxNumsOnly.Length < 6)
                {
                    int placesToAdd = 6 - priceWithTaxNumsOnly.Length;
                    for (int i = 0; i < placesToAdd; i++)
                    {
                        priceWithTaxNumsOnly = priceWithTaxNumsOnly.Insert(0, " ");
                    }
                }
                mtb_Brutto.Text = priceWithTaxNumsOnly;
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.Message);
                
            }
            
        }
        
        private void mtb_Brutto_Leave(object sender, EventArgs e)
        {
            string textBrutto = Regex.Replace(mtb_Brutto.Text, "[^0-9.]", "");
            string cenaBrutto = textBrutto.Insert(textBrutto.Length - 2, ",");
            double doubleBrutto = Convert.ToDouble(cenaBrutto);
            double tax = Convert.ToDouble(cbx_Tax.Text.Remove(cbx_Tax.Text.Length - 1));
            
            double priceWithoutTax = doubleBrutto / (1+(tax/100));
            string priceWithoutTaxNumsOnly = Regex.Replace(Math.Round(priceWithoutTax, 2, MidpointRounding.AwayFromZero).ToString("N2"), "[^0-9.]", "");
            if (priceWithoutTaxNumsOnly.Length < 6)
            {
                int placesToAdd = 6 - priceWithoutTaxNumsOnly.Length;
                for (int i = 0; i < placesToAdd; i++)
                {
                    priceWithoutTaxNumsOnly = priceWithoutTaxNumsOnly.Insert(0, " ");
                }
            }
            mtb_Netto.Text = priceWithoutTaxNumsOnly;
        }

        private void btn_AddProductToDB_Click(object sender, EventArgs e)
        {
            try
            {
                var db = new DbAccess();
                string name = tbx_Name.Text;
                string priceNumsOnly = Regex.Replace(mtb_Netto.Text, "[^0-9.]", "");
                string priceToDoublify = priceNumsOnly.Insert(priceNumsOnly.Length - 2, ",");
                
                decimal tax = Convert.ToDecimal(cbx_Tax.Text.Remove(cbx_Tax.Text.Length - 1));
                
                decimal pricedec = (decimal.Parse(priceNumsOnly));
                string priceDecString = pricedec.ToString().Insert(pricedec.ToString().Length - 2, ",");
                decimal toDec = decimal.Parse(priceDecString);
                int quantity = Int32.Parse(tbx_Quantity.Text);
                string ean = mtb_EAN.Text;
                string unit = tbx_Unit.Text;
                db.InsertQuery(name, toDec, tax, quantity, ean, unit);
                this.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Upewnij się, że wszystko wypełniłeś poprawnie");
            }

        }

        private void mtb_Netto_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void cbx_Tax_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void mtb_EAN_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void FormAddProduct_Load(object sender, EventArgs e)
        {

        }

        private void mtb_Brutto_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}