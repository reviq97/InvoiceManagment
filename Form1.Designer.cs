namespace WSB_PO
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureWarehouse = new System.Windows.Forms.PictureBox();
            this.pictureExchange = new System.Windows.Forms.PictureBox();
            this.labelInvoices = new System.Windows.Forms.Label();
            this.labelWarehouse = new System.Windows.Forms.Label();
            this.labelExchange = new System.Windows.Forms.Label();
            this.pictureInvoices = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize) (this.pictureWarehouse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.pictureExchange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.pictureInvoices)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureWarehouse
            // 
            this.pictureWarehouse.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("pictureWarehouse.BackgroundImage")));
            this.pictureWarehouse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureWarehouse.Location = new System.Drawing.Point(178, 3);
            this.pictureWarehouse.Name = "pictureWarehouse";
            this.pictureWarehouse.Size = new System.Drawing.Size(128, 128);
            this.pictureWarehouse.TabIndex = 1;
            this.pictureWarehouse.TabStop = false;
            this.pictureWarehouse.Click += new System.EventHandler(this.pictureWarehouse_Click);
            // 
            // pictureExchange
            // 
            this.pictureExchange.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("pictureExchange.BackgroundImage")));
            this.pictureExchange.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureExchange.Location = new System.Drawing.Point(353, 3);
            this.pictureExchange.Name = "pictureExchange";
            this.pictureExchange.Size = new System.Drawing.Size(128, 128);
            this.pictureExchange.TabIndex = 2;
            this.pictureExchange.TabStop = false;
            this.pictureExchange.Click += new System.EventHandler(this.pictureExchange_Click);
            // 
            // labelInvoices
            // 
            this.labelInvoices.AutoSize = true;
            this.labelInvoices.Font = new System.Drawing.Font("Bahnschrift SemiBold Condensed", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.labelInvoices.Location = new System.Drawing.Point(37, 134);
            this.labelInvoices.Name = "labelInvoices";
            this.labelInvoices.Size = new System.Drawing.Size(59, 23);
            this.labelInvoices.TabIndex = 3;
            this.labelInvoices.Text = "Faktury";
            // 
            // labelWarehouse
            // 
            this.labelWarehouse.AutoSize = true;
            this.labelWarehouse.Font = new System.Drawing.Font("Bahnschrift SemiBold Condensed", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.labelWarehouse.Location = new System.Drawing.Point(214, 134);
            this.labelWarehouse.Name = "labelWarehouse";
            this.labelWarehouse.Size = new System.Drawing.Size(67, 23);
            this.labelWarehouse.TabIndex = 4;
            this.labelWarehouse.Text = "Magazyn";
            // 
            // labelExchange
            // 
            this.labelExchange.AutoSize = true;
            this.labelExchange.Font = new System.Drawing.Font("Bahnschrift SemiBold Condensed", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.labelExchange.Location = new System.Drawing.Point(353, 134);
            this.labelExchange.Name = "labelExchange";
            this.labelExchange.Size = new System.Drawing.Size(134, 23);
            this.labelExchange.TabIndex = 5;
            this.labelExchange.Text = "Wydania i przyjęcia";
            // 
            // pictureInvoices
            // 
            this.pictureInvoices.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("pictureInvoices.BackgroundImage")));
            this.pictureInvoices.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureInvoices.Location = new System.Drawing.Point(3, 3);
            this.pictureInvoices.Name = "pictureInvoices";
            this.pictureInvoices.Size = new System.Drawing.Size(128, 128);
            this.pictureInvoices.TabIndex = 6;
            this.pictureInvoices.TabStop = false;
            this.pictureInvoices.Click += new System.EventHandler(this.pictureInvoices_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.pictureInvoices);
            this.panel1.Controls.Add(this.pictureWarehouse);
            this.panel1.Controls.Add(this.labelExchange);
            this.panel1.Controls.Add(this.pictureExchange);
            this.panel1.Controls.Add(this.labelWarehouse);
            this.panel1.Controls.Add(this.labelInvoices);
            this.panel1.Location = new System.Drawing.Point(153, 139);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(485, 158);
            this.panel1.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inwentaryzacja + Faktury 2021 | MNM-Dev";
            ((System.ComponentModel.ISupportInitialize) (this.pictureWarehouse)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.pictureExchange)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.pictureInvoices)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.PictureBox pictureWarehouse;
        private System.Windows.Forms.PictureBox pictureExchange;
        private System.Windows.Forms.Label labelInvoices;
        private System.Windows.Forms.Label labelWarehouse;
        private System.Windows.Forms.Label labelExchange;
        private System.Windows.Forms.PictureBox pictureInvoices;
        private System.Windows.Forms.Panel panel1;
    }
}

