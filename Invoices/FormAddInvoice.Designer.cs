
using System;

namespace WSB_PO.Invoices
{
    partial class FormAddInvoice
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            this.FVNumber = new System.Windows.Forms.Label();
            this.invoiceNumber = new System.Windows.Forms.TextBox();
            this.DateProd = new System.Windows.Forms.Label();
            this.DateSale = new System.Windows.Forms.Label();
            this.Location = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.productsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button3 = new System.Windows.Forms.Button();
            this.invoiceLocation = new System.Windows.Forms.TextBox();
            this.invoiceSaleDate = new System.Windows.Forms.TextBox();
            this.invoiceDate = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.invoiceApply = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.invoiceCompany = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.invoiceAdress = new System.Windows.Forms.TextBox();
            this.invoicePostal = new System.Windows.Forms.TextBox();
            this.invoiceNip = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.invoiceLoc = new System.Windows.Forms.TextBox();
            this.invoiceMail = new System.Windows.Forms.TextBox();
            this.invoiceTel = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.invoicePersonal = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.invoiceCat = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.invoiceOff = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ProdName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.describeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // FVNumber
            // 
            this.FVNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FVNumber.Location = new System.Drawing.Point(12, 21);
            this.FVNumber.Name = "FVNumber";
            this.FVNumber.Size = new System.Drawing.Size(78, 23);
            this.FVNumber.TabIndex = 11;
            this.FVNumber.Text = "Faktura NR: ";
            // 
            // invoiceNumber
            // 
            this.invoiceNumber.Location = new System.Drawing.Point(96, 18);
            this.invoiceNumber.Name = "invoiceNumber";
            this.invoiceNumber.Size = new System.Drawing.Size(100, 20);
            this.invoiceNumber.TabIndex = 12;
            this.invoiceNumber.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // DateProd
            // 
            this.DateProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DateProd.Location = new System.Drawing.Point(321, 21);
            this.DateProd.Name = "DateProd";
            this.DateProd.Size = new System.Drawing.Size(129, 23);
            this.DateProd.TabIndex = 14;
            this.DateProd.Text = "Data wystawienia: ";
            // 
            // DateSale
            // 
            this.DateSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DateSale.Location = new System.Drawing.Point(321, 44);
            this.DateSale.Name = "DateSale";
            this.DateSale.Size = new System.Drawing.Size(129, 23);
            this.DateSale.TabIndex = 15;
            this.DateSale.Text = "Data sprzedaży: ";
            // 
            // Location
            // 
            this.Location.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Location.Location = new System.Drawing.Point(321, 67);
            this.Location.Name = "Location";
            this.Location.Size = new System.Drawing.Size(129, 23);
            this.Location.TabIndex = 16;
            this.Location.Text = "Miejsce wystawienia: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(547, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "_________________________________________________________________________________" +
    "_________";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProdName,
            this.priceDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn,
            this.taxDataGridViewTextBoxColumn,
            this.checkDataGridViewTextBoxColumn,
            this.describeDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.productsBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(14, 557);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(633, 185);
            this.dataGridView1.TabIndex = 40;
            // 
            // productsBindingSource
            // 
            this.productsBindingSource.DataSource = typeof(WSB_PO.Invoices.Product);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(687, 707);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 41;
            this.button3.Text = "Powrót";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // invoiceLocation
            // 
            this.invoiceLocation.Location = new System.Drawing.Point(456, 64);
            this.invoiceLocation.Name = "invoiceLocation";
            this.invoiceLocation.Size = new System.Drawing.Size(100, 20);
            this.invoiceLocation.TabIndex = 46;
            // 
            // invoiceSaleDate
            // 
            this.invoiceSaleDate.Location = new System.Drawing.Point(456, 41);
            this.invoiceSaleDate.Name = "invoiceSaleDate";
            this.invoiceSaleDate.Size = new System.Drawing.Size(100, 20);
            this.invoiceSaleDate.TabIndex = 45;
            // 
            // invoiceDate
            // 
            this.invoiceDate.Location = new System.Drawing.Point(456, 18);
            this.invoiceDate.Name = "invoiceDate";
            this.invoiceDate.Size = new System.Drawing.Size(100, 20);
            this.invoiceDate.TabIndex = 44;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(96, 528);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 49;
            this.button2.Text = "Usuń";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.DeleteProductInvoice);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 528);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 48;
            this.button1.Text = "Dodaj";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.AddProductInvoice);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 475);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(547, 13);
            this.label13.TabIndex = 50;
            this.label13.Text = "_________________________________________________________________________________" +
    "_________";
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label14.Location = new System.Drawing.Point(12, 502);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(134, 23);
            this.label14.TabIndex = 51;
            this.label14.Text = "Towary do faktury:";
            // 
            // invoiceApply
            // 
            this.invoiceApply.Location = new System.Drawing.Point(14, 791);
            this.invoiceApply.Name = "invoiceApply";
            this.invoiceApply.Size = new System.Drawing.Size(75, 23);
            this.invoiceApply.TabIndex = 52;
            this.invoiceApply.Text = "Zatwierdź";
            this.invoiceApply.UseVisualStyleBackColor = true;
            this.invoiceApply.Click += new System.EventHandler(this.invoiceApply_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(570, 791);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 53;
            this.button5.Text = "Powrót";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(12, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 23);
            this.label7.TabIndex = 29;
            this.label7.Text = "Działalność:";
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label12.Location = new System.Drawing.Point(12, 164);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 23);
            this.label12.TabIndex = 30;
            this.label12.Text = "Firma: ";
            // 
            // invoiceCompany
            // 
            this.invoiceCompany.Location = new System.Drawing.Point(147, 161);
            this.invoiceCompany.Name = "invoiceCompany";
            this.invoiceCompany.Size = new System.Drawing.Size(100, 20);
            this.invoiceCompany.TabIndex = 31;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label11.Location = new System.Drawing.Point(12, 187);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 23);
            this.label11.TabIndex = 32;
            this.label11.Text = "Adres: ";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.Location = new System.Drawing.Point(12, 210);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 23);
            this.label10.TabIndex = 33;
            this.label10.Text = "Kod Pocztowy: ";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.Location = new System.Drawing.Point(12, 233);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 23);
            this.label9.TabIndex = 34;
            this.label9.Text = "NIP: ";
            // 
            // invoiceAdress
            // 
            this.invoiceAdress.Location = new System.Drawing.Point(147, 184);
            this.invoiceAdress.Name = "invoiceAdress";
            this.invoiceAdress.Size = new System.Drawing.Size(100, 20);
            this.invoiceAdress.TabIndex = 35;
            // 
            // invoicePostal
            // 
            this.invoicePostal.Location = new System.Drawing.Point(147, 207);
            this.invoicePostal.Name = "invoicePostal";
            this.invoicePostal.Size = new System.Drawing.Size(100, 20);
            this.invoicePostal.TabIndex = 36;
            // 
            // invoiceNip
            // 
            this.invoiceNip.Location = new System.Drawing.Point(147, 230);
            this.invoiceNip.Name = "invoiceNip";
            this.invoiceNip.Size = new System.Drawing.Size(100, 20);
            this.invoiceNip.TabIndex = 37;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(12, 256);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 23);
            this.label8.TabIndex = 38;
            this.label8.Text = "Miejscowość: ";
            // 
            // invoiceLoc
            // 
            this.invoiceLoc.Location = new System.Drawing.Point(147, 253);
            this.invoiceLoc.Name = "invoiceLoc";
            this.invoiceLoc.Size = new System.Drawing.Size(100, 20);
            this.invoiceLoc.TabIndex = 39;
            // 
            // invoiceMail
            // 
            this.invoiceMail.Location = new System.Drawing.Point(147, 394);
            this.invoiceMail.Name = "invoiceMail";
            this.invoiceMail.Size = new System.Drawing.Size(100, 20);
            this.invoiceMail.TabIndex = 61;
            // 
            // invoiceTel
            // 
            this.invoiceTel.Location = new System.Drawing.Point(147, 371);
            this.invoiceTel.Name = "invoiceTel";
            this.invoiceTel.Size = new System.Drawing.Size(100, 20);
            this.invoiceTel.TabIndex = 60;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(12, 397);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 26);
            this.label4.TabIndex = 58;
            this.label4.Text = "Email: ";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(12, 371);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 26);
            this.label5.TabIndex = 57;
            this.label5.Text = "Telefon: ";
            // 
            // invoicePersonal
            // 
            this.invoicePersonal.Location = new System.Drawing.Point(147, 348);
            this.invoicePersonal.Name = "invoicePersonal";
            this.invoicePersonal.Size = new System.Drawing.Size(100, 20);
            this.invoicePersonal.TabIndex = 56;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label15.Location = new System.Drawing.Point(12, 348);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(100, 26);
            this.label15.TabIndex = 55;
            this.label15.Text = "Imie i Nazwisko:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 304);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(547, 13);
            this.label1.TabIndex = 65;
            this.label1.Text = "_________________________________________________________________________________" +
    "_________";
            // 
            // invoiceCat
            // 
            this.invoiceCat.Location = new System.Drawing.Point(147, 420);
            this.invoiceCat.Name = "invoiceCat";
            this.invoiceCat.Size = new System.Drawing.Size(100, 20);
            this.invoiceCat.TabIndex = 67;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(12, 420);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 26);
            this.label2.TabIndex = 66;
            this.label2.Text = "Kategoria:";
            // 
            // invoiceOff
            // 
            this.invoiceOff.Location = new System.Drawing.Point(147, 446);
            this.invoiceOff.Name = "invoiceOff";
            this.invoiceOff.Size = new System.Drawing.Size(100, 20);
            this.invoiceOff.TabIndex = 69;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(12, 446);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 26);
            this.label3.TabIndex = 68;
            this.label3.Text = "Obniżka:";
            // 
            // ProdName
            // 
            this.ProdName.DataPropertyName = "ProdName";
            this.ProdName.HeaderText = "Nazwa";
            this.ProdName.Name = "ProdName";
            this.ProdName.ReadOnly = true;
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            this.priceDataGridViewTextBoxColumn.HeaderText = "Cena netto";
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            this.priceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Ilość";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            this.quantityDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // taxDataGridViewTextBoxColumn
            // 
            this.taxDataGridViewTextBoxColumn.DataPropertyName = "Tax";
            this.taxDataGridViewTextBoxColumn.HeaderText = "VAT";
            this.taxDataGridViewTextBoxColumn.Name = "taxDataGridViewTextBoxColumn";
            this.taxDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // checkDataGridViewTextBoxColumn
            // 
            this.checkDataGridViewTextBoxColumn.DataPropertyName = "Check";
            this.checkDataGridViewTextBoxColumn.HeaderText = "Cena brutto";
            this.checkDataGridViewTextBoxColumn.Name = "checkDataGridViewTextBoxColumn";
            this.checkDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // describeDataGridViewTextBoxColumn
            // 
            this.describeDataGridViewTextBoxColumn.DataPropertyName = "Describe";
            this.describeDataGridViewTextBoxColumn.HeaderText = "Uwagi";
            this.describeDataGridViewTextBoxColumn.Name = "describeDataGridViewTextBoxColumn";
            this.describeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // FormAddInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 867);
            this.Controls.Add(this.invoiceOff);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.invoiceCat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.invoiceMail);
            this.Controls.Add(this.invoiceTel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.invoicePersonal);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.invoiceApply);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.invoiceLocation);
            this.Controls.Add(this.invoiceSaleDate);
            this.Controls.Add(this.invoiceDate);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.invoiceLoc);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.invoiceNip);
            this.Controls.Add(this.invoicePostal);
            this.Controls.Add(this.invoiceAdress);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.invoiceCompany);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Location);
            this.Controls.Add(this.DateSale);
            this.Controls.Add(this.DateProd);
            this.Controls.Add(this.invoiceNumber);
            this.Controls.Add(this.FVNumber);
            this.Name = "FormAddInvoice";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label FVNumber;
        private System.Windows.Forms.TextBox invoiceNumber;
        private System.Windows.Forms.Label DateProd;
        private System.Windows.Forms.Label DateSale;
        private System.Windows.Forms.Label Location;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox invoiceLocation;
        private System.Windows.Forms.TextBox invoiceSaleDate;
        private System.Windows.Forms.TextBox invoiceDate;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Names;
        private System.Windows.Forms.DataGridViewTextBoxColumn productDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource productsBindingSource;
        private System.Windows.Forms.Button invoiceApply;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox invoiceCompany;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox invoiceAdress;
        private System.Windows.Forms.TextBox invoicePostal;
        private System.Windows.Forms.TextBox invoiceNip;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox invoiceLoc;
        private System.Windows.Forms.TextBox invoiceMail;
        private System.Windows.Forms.TextBox invoiceTel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox invoicePersonal;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox invoiceCat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox invoiceOff;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProdName;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn taxDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn checkDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn describeDataGridViewTextBoxColumn;
    }
}