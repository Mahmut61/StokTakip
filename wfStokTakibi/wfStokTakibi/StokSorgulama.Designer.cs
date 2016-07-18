namespace wfStokTakibi
{
    partial class StokSorgulama
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
            this.dgvUrunler = new System.Windows.Forms.DataGridView();
            this.rbKritikSeviye = new System.Windows.Forms.RadioButton();
            this.rbTumUrunler = new System.Windows.Forms.RadioButton();
            this.cbKategoriler = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUrunler)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvUrunler
            // 
            this.dgvUrunler.AllowUserToAddRows = false;
            this.dgvUrunler.AllowUserToDeleteRows = false;
            this.dgvUrunler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUrunler.Location = new System.Drawing.Point(33, 164);
            this.dgvUrunler.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvUrunler.Name = "dgvUrunler";
            this.dgvUrunler.ReadOnly = true;
            this.dgvUrunler.Size = new System.Drawing.Size(758, 323);
            this.dgvUrunler.TabIndex = 0;
            // 
            // rbKritikSeviye
            // 
            this.rbKritikSeviye.AutoSize = true;
            this.rbKritikSeviye.Location = new System.Drawing.Point(240, 57);
            this.rbKritikSeviye.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbKritikSeviye.Name = "rbKritikSeviye";
            this.rbKritikSeviye.Size = new System.Drawing.Size(195, 21);
            this.rbKritikSeviye.TabIndex = 1;
            this.rbKritikSeviye.Text = "Kritik Seviyenin Altındakiler";
            this.rbKritikSeviye.UseVisualStyleBackColor = true;
            // 
            // rbTumUrunler
            // 
            this.rbTumUrunler.AutoSize = true;
            this.rbTumUrunler.Checked = true;
            this.rbTumUrunler.Location = new System.Drawing.Point(240, 98);
            this.rbTumUrunler.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbTumUrunler.Name = "rbTumUrunler";
            this.rbTumUrunler.Size = new System.Drawing.Size(105, 21);
            this.rbTumUrunler.TabIndex = 2;
            this.rbTumUrunler.TabStop = true;
            this.rbTumUrunler.Text = "Tüm Ürünler";
            this.rbTumUrunler.UseVisualStyleBackColor = true;
            // 
            // cbKategoriler
            // 
            this.cbKategoriler.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKategoriler.FormattingEnabled = true;
            this.cbKategoriler.Location = new System.Drawing.Point(631, 84);
            this.cbKategoriler.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbKategoriler.Name = "cbKategoriler";
            this.cbKategoriler.Size = new System.Drawing.Size(160, 24);
            this.cbKategoriler.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(643, 61);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Kategori Seçiniz";
            // 
            // StokSorgulama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 548);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbKategoriler);
            this.Controls.Add(this.rbTumUrunler);
            this.Controls.Add(this.rbKritikSeviye);
            this.Controls.Add(this.dgvUrunler);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "StokSorgulama";
            this.Text = "StokSorgulama";
            this.Load += new System.EventHandler(this.StokSorgulama_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUrunler)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUrunler;
        private System.Windows.Forms.RadioButton rbKritikSeviye;
        private System.Windows.Forms.RadioButton rbTumUrunler;
        private System.Windows.Forms.ComboBox cbKategoriler;
        private System.Windows.Forms.Label label1;
    }
}