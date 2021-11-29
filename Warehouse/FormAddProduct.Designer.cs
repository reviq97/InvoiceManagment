using System;
using System.ComponentModel;

namespace WSB_PO
{
    partial class FormAddProduct
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbx_Name = new System.Windows.Forms.TextBox();
            this.tbx_Quantity = new System.Windows.Forms.TextBox();
            this.tbx_Unit = new System.Windows.Forms.TextBox();
            this.mtb_Netto = new System.Windows.Forms.MaskedTextBox();
            this.mtb_Brutto = new System.Windows.Forms.MaskedTextBox();
            this.mtb_EAN = new System.Windows.Forms.MaskedTextBox();
            this.cbx_Tax = new System.Windows.Forms.ComboBox();
            this.btn_AddProductToDB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(33, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nazwa produktu";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(33, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Kod EAN";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(33, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "VAT";
            // 
            // radioButton1
            // 
            this.radioButton1.Checked = true;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.radioButton1.Location = new System.Drawing.Point(18, 78);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(104, 24);
            this.radioButton1.TabIndex = 5;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Cena netto";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.Location = new System.Drawing.Point(18, 138);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(104, 24);
            this.radioButton2.TabIndex = 6;
            this.radioButton2.Text = "Cena brutto";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(33, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "Ilość";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(33, 202);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 9;
            this.label6.Text = "Jednostka";
            // 
            // tbx_Name
            // 
            this.tbx_Name.Location = new System.Drawing.Point(139, 19);
            this.tbx_Name.Name = "tbx_Name";
            this.tbx_Name.Size = new System.Drawing.Size(165, 20);
            this.tbx_Name.TabIndex = 10;
            // 
            // tbx_Quantity
            // 
            this.tbx_Quantity.Location = new System.Drawing.Point(139, 169);
            this.tbx_Quantity.Name = "tbx_Quantity";
            this.tbx_Quantity.Size = new System.Drawing.Size(85, 20);
            this.tbx_Quantity.TabIndex = 15;
            // 
            // tbx_Unit
            // 
            this.tbx_Unit.Location = new System.Drawing.Point(139, 199);
            this.tbx_Unit.Name = "tbx_Unit";
            this.tbx_Unit.Size = new System.Drawing.Size(85, 20);
            this.tbx_Unit.TabIndex = 17;
            // 
            // mtb_Netto
            // 
            this.mtb_Netto.Location = new System.Drawing.Point(139, 79);
            this.mtb_Netto.Mask = "9999 zł 99 gr";
            this.mtb_Netto.Name = "mtb_Netto";
            this.mtb_Netto.Size = new System.Drawing.Size(85, 20);
            this.mtb_Netto.TabIndex = 18;
            this.mtb_Netto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mtb_Netto.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.mtb_Netto_MaskInputRejected);
            this.mtb_Netto.Leave += new System.EventHandler(this.mtb_Netto_Leave);
            // 
            // mtb_Brutto
            // 
            this.mtb_Brutto.Enabled = false;
            this.mtb_Brutto.Location = new System.Drawing.Point(139, 139);
            this.mtb_Brutto.Mask = "9999 zł 99 gr";
            this.mtb_Brutto.Name = "mtb_Brutto";
            this.mtb_Brutto.Size = new System.Drawing.Size(85, 20);
            this.mtb_Brutto.TabIndex = 19;
            this.mtb_Brutto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mtb_Brutto.Leave += new System.EventHandler(this.mtb_Brutto_Leave);
            // 
            // mtb_EAN
            // 
            this.mtb_EAN.Location = new System.Drawing.Point(139, 49);
            this.mtb_EAN.Mask = "9999999999999";
            this.mtb_EAN.Name = "mtb_EAN";
            this.mtb_EAN.Size = new System.Drawing.Size(85, 20);
            this.mtb_EAN.TabIndex = 20;
            // 
            // cbx_Tax
            // 
            this.cbx_Tax.FormattingEnabled = true;
            this.cbx_Tax.Items.AddRange(new object[] {
            "0%",
            "5%",
            "8%",
            "23%"});
            this.cbx_Tax.Location = new System.Drawing.Point(139, 109);
            this.cbx_Tax.Name = "cbx_Tax";
            this.cbx_Tax.Size = new System.Drawing.Size(85, 21);
            this.cbx_Tax.TabIndex = 21;
            this.cbx_Tax.Text = "23%";
            this.cbx_Tax.SelectedIndexChanged += new System.EventHandler(this.cbx_Tax_SelectedIndexChanged);
            // 
            // btn_AddProductToDB
            // 
            this.btn_AddProductToDB.Location = new System.Drawing.Point(33, 237);
            this.btn_AddProductToDB.Name = "btn_AddProductToDB";
            this.btn_AddProductToDB.Size = new System.Drawing.Size(271, 23);
            this.btn_AddProductToDB.TabIndex = 22;
            this.btn_AddProductToDB.Text = "Dodaj produkt";
            this.btn_AddProductToDB.UseVisualStyleBackColor = true;
            this.btn_AddProductToDB.Click += new System.EventHandler(this.btn_AddProductToDB_Click);
            // 
            // FormAddProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 281);
            this.Controls.Add(this.btn_AddProductToDB);
            this.Controls.Add(this.cbx_Tax);
            this.Controls.Add(this.mtb_EAN);
            this.Controls.Add(this.mtb_Brutto);
            this.Controls.Add(this.mtb_Netto);
            this.Controls.Add(this.tbx_Unit);
            this.Controls.Add(this.tbx_Quantity);
            this.Controls.Add(this.tbx_Name);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormAddProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dodawanie produktu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button btn_AddProductToDB;

        private System.Windows.Forms.ComboBox cbx_Tax;

        private System.Windows.Forms.MaskedTextBox mtb_Netto;
        private System.Windows.Forms.MaskedTextBox mtb_Brutto;

        private System.Windows.Forms.MaskedTextBox mtb_EAN;

        private System.Windows.Forms.TextBox tbx_Quantity;
        private System.Windows.Forms.TextBox tbx_Unit;

        private System.Windows.Forms.TextBox tbx_Name;

        private System.Windows.Forms.Label label6;

        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.RadioButton radioButton2;

        private System.Windows.Forms.RadioButton radioButton1;

        private System.Windows.Forms.Label label4;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

        #endregion
    }
}