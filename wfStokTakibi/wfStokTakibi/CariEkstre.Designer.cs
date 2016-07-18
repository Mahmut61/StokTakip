namespace wfStokTakibi
{
    partial class CariEkstre
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
            this.rbTumFirmalar = new System.Windows.Forms.RadioButton();
            this.rbSaticilar = new System.Windows.Forms.RadioButton();
            this.rbAlicilar = new System.Windows.Forms.RadioButton();
            this.txtCariNo = new System.Windows.Forms.TextBox();
            this.btnFirmaBul = new System.Windows.Forms.Button();
            this.txtFirma = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.dtpIlkTarih = new System.Windows.Forms.DateTimePicker();
            this.dtpSonTarih = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvCariler = new System.Windows.Forms.DataGridView();
            this.dgvHareketler = new System.Windows.Forms.DataGridView();
            this.txtBakiye = new System.Windows.Forms.TextBox();
            this.txtToplamCikan = new System.Windows.Forms.TextBox();
            this.txtToplamGiren = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCariler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHareketler)).BeginInit();
            this.SuspendLayout();
            // 
            // rbTumFirmalar
            // 
            this.rbTumFirmalar.AutoSize = true;
            this.rbTumFirmalar.Location = new System.Drawing.Point(264, 92);
            this.rbTumFirmalar.Margin = new System.Windows.Forms.Padding(4);
            this.rbTumFirmalar.Name = "rbTumFirmalar";
            this.rbTumFirmalar.Size = new System.Drawing.Size(109, 21);
            this.rbTumFirmalar.TabIndex = 27;
            this.rbTumFirmalar.TabStop = true;
            this.rbTumFirmalar.Text = "Tüm Firmalar";
            this.rbTumFirmalar.UseVisualStyleBackColor = true;
            this.rbTumFirmalar.CheckedChanged += new System.EventHandler(this.rbTumFirmalar_CheckedChanged);
            // 
            // rbSaticilar
            // 
            this.rbSaticilar.AutoSize = true;
            this.rbSaticilar.Location = new System.Drawing.Point(143, 92);
            this.rbSaticilar.Margin = new System.Windows.Forms.Padding(4);
            this.rbSaticilar.Name = "rbSaticilar";
            this.rbSaticilar.Size = new System.Drawing.Size(76, 21);
            this.rbSaticilar.TabIndex = 26;
            this.rbSaticilar.TabStop = true;
            this.rbSaticilar.Text = "Satıcılar";
            this.rbSaticilar.UseVisualStyleBackColor = true;
            this.rbSaticilar.CheckedChanged += new System.EventHandler(this.rbSaticilar_CheckedChanged);
            // 
            // rbAlicilar
            // 
            this.rbAlicilar.AutoSize = true;
            this.rbAlicilar.Location = new System.Drawing.Point(29, 92);
            this.rbAlicilar.Margin = new System.Windows.Forms.Padding(4);
            this.rbAlicilar.Name = "rbAlicilar";
            this.rbAlicilar.Size = new System.Drawing.Size(67, 21);
            this.rbAlicilar.TabIndex = 25;
            this.rbAlicilar.TabStop = true;
            this.rbAlicilar.Text = "Alıcılar";
            this.rbAlicilar.UseVisualStyleBackColor = true;
            this.rbAlicilar.CheckedChanged += new System.EventHandler(this.rbAlicilar_CheckedChanged);
            // 
            // txtCariNo
            // 
            this.txtCariNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtCariNo.Location = new System.Drawing.Point(14, 41);
            this.txtCariNo.Name = "txtCariNo";
            this.txtCariNo.ReadOnly = true;
            this.txtCariNo.Size = new System.Drawing.Size(1, 23);
            this.txtCariNo.TabIndex = 31;
            // 
            // btnFirmaBul
            // 
            this.btnFirmaBul.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnFirmaBul.Location = new System.Drawing.Point(224, 41);
            this.btnFirmaBul.Name = "btnFirmaBul";
            this.btnFirmaBul.Size = new System.Drawing.Size(39, 23);
            this.btnFirmaBul.TabIndex = 30;
            this.btnFirmaBul.Text = "...";
            this.btnFirmaBul.UseVisualStyleBackColor = true;
            this.btnFirmaBul.Click += new System.EventHandler(this.btnFirmaBul_Click);
            // 
            // txtFirma
            // 
            this.txtFirma.Location = new System.Drawing.Point(104, 41);
            this.txtFirma.Name = "txtFirma";
            this.txtFirma.ReadOnly = true;
            this.txtFirma.Size = new System.Drawing.Size(120, 23);
            this.txtFirma.TabIndex = 29;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(27, 41);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(43, 17);
            this.label13.TabIndex = 28;
            this.label13.Text = "Firma";
            // 
            // dtpIlkTarih
            // 
            this.dtpIlkTarih.Location = new System.Drawing.Point(478, 56);
            this.dtpIlkTarih.Name = "dtpIlkTarih";
            this.dtpIlkTarih.Size = new System.Drawing.Size(130, 23);
            this.dtpIlkTarih.TabIndex = 32;
            this.dtpIlkTarih.ValueChanged += new System.EventHandler(this.dtpIlkTarih_ValueChanged);
            // 
            // dtpSonTarih
            // 
            this.dtpSonTarih.Location = new System.Drawing.Point(691, 56);
            this.dtpSonTarih.Name = "dtpSonTarih";
            this.dtpSonTarih.Size = new System.Drawing.Size(130, 23);
            this.dtpSonTarih.TabIndex = 33;
            this.dtpSonTarih.ValueChanged += new System.EventHandler(this.dtpSonTarih_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(508, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 17);
            this.label1.TabIndex = 34;
            this.label1.Text = "İlk Tarih";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(720, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 17);
            this.label2.TabIndex = 35;
            this.label2.Text = "Son Tarih";
            // 
            // dgvCariler
            // 
            this.dgvCariler.AllowUserToAddRows = false;
            this.dgvCariler.AllowUserToDeleteRows = false;
            this.dgvCariler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCariler.Location = new System.Drawing.Point(30, 157);
            this.dgvCariler.Name = "dgvCariler";
            this.dgvCariler.ReadOnly = true;
            this.dgvCariler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCariler.Size = new System.Drawing.Size(333, 282);
            this.dgvCariler.TabIndex = 36;
            this.dgvCariler.DoubleClick += new System.EventHandler(this.dgvCariler_DoubleClick);
            // 
            // dgvHareketler
            // 
            this.dgvHareketler.AllowUserToAddRows = false;
            this.dgvHareketler.AllowUserToDeleteRows = false;
            this.dgvHareketler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHareketler.Location = new System.Drawing.Point(369, 157);
            this.dgvHareketler.Name = "dgvHareketler";
            this.dgvHareketler.ReadOnly = true;
            this.dgvHareketler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHareketler.Size = new System.Drawing.Size(527, 282);
            this.dgvHareketler.TabIndex = 37;
            // 
            // txtBakiye
            // 
            this.txtBakiye.Location = new System.Drawing.Point(822, 445);
            this.txtBakiye.Name = "txtBakiye";
            this.txtBakiye.ReadOnly = true;
            this.txtBakiye.Size = new System.Drawing.Size(80, 23);
            this.txtBakiye.TabIndex = 40;
            this.txtBakiye.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtToplamCikan
            // 
            this.txtToplamCikan.Location = new System.Drawing.Point(741, 445);
            this.txtToplamCikan.Name = "txtToplamCikan";
            this.txtToplamCikan.ReadOnly = true;
            this.txtToplamCikan.Size = new System.Drawing.Size(80, 23);
            this.txtToplamCikan.TabIndex = 39;
            this.txtToplamCikan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtToplamGiren
            // 
            this.txtToplamGiren.Location = new System.Drawing.Point(660, 445);
            this.txtToplamGiren.Name = "txtToplamGiren";
            this.txtToplamGiren.ReadOnly = true;
            this.txtToplamGiren.Size = new System.Drawing.Size(80, 23);
            this.txtToplamGiren.TabIndex = 38;
            this.txtToplamGiren.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CariEkstre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(927, 507);
            this.Controls.Add(this.txtBakiye);
            this.Controls.Add(this.txtToplamCikan);
            this.Controls.Add(this.txtToplamGiren);
            this.Controls.Add(this.dgvHareketler);
            this.Controls.Add(this.dgvCariler);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpSonTarih);
            this.Controls.Add(this.dtpIlkTarih);
            this.Controls.Add(this.txtCariNo);
            this.Controls.Add(this.btnFirmaBul);
            this.Controls.Add(this.txtFirma);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.rbTumFirmalar);
            this.Controls.Add(this.rbSaticilar);
            this.Controls.Add(this.rbAlicilar);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CariEkstre";
            this.Text = "CariEkstre";
            this.Load += new System.EventHandler(this.CariEkstre_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCariler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHareketler)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbTumFirmalar;
        private System.Windows.Forms.RadioButton rbSaticilar;
        private System.Windows.Forms.RadioButton rbAlicilar;
        private System.Windows.Forms.TextBox txtCariNo;
        private System.Windows.Forms.Button btnFirmaBul;
        private System.Windows.Forms.TextBox txtFirma;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtpIlkTarih;
        private System.Windows.Forms.DateTimePicker dtpSonTarih;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvCariler;
        private System.Windows.Forms.DataGridView dgvHareketler;
        private System.Windows.Forms.TextBox txtBakiye;
        private System.Windows.Forms.TextBox txtToplamCikan;
        private System.Windows.Forms.TextBox txtToplamGiren;
    }
}