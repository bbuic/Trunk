namespace DNTv2
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.SerialPortElektronika = new System.IO.Ports.SerialPort(this.components);
            this.Panel1 = new System.Windows.Forms.Panel();
            this.GRB_INFORMACIJE = new System.Windows.Forms.GroupBox();
            this.Label35 = new System.Windows.Forms.Label();
            this.lblDatumPraznjenjaTrezora = new System.Windows.Forms.Label();
            this.lbBrojVrecica = new System.Windows.Forms.Label();
            this.Label14 = new System.Windows.Forms.Label();
            this.GRB_TRANSAKCIJE = new System.Windows.Forms.GroupBox();
            this.lblPretragaTransakcija = new System.Windows.Forms.LinkLabel();
            this.lblAdministracijaKorisnika = new System.Windows.Forms.LinkLabel();
            this.lblPraznjenjeTrezora = new System.Windows.Forms.LinkLabel();
            this.gbPretragaTransakcija = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.DTP_ZAVRSNI_DATUM = new System.Windows.Forms.DateTimePicker();
            this.DTP_POCETNI_DATUM = new System.Windows.Forms.DateTimePicker();
            this.dgvTransakcije = new System.Windows.Forms.DataGridView();
            this.SerialPortLcd = new System.IO.Ports.SerialPort(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.BTN_PRETRAZI_UZ_UVIJET = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.PictureBox2 = new System.Windows.Forms.PictureBox();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.Panel1.SuspendLayout();
            this.GRB_INFORMACIJE.SuspendLayout();
            this.GRB_TRANSAKCIJE.SuspendLayout();
            this.gbPretragaTransakcija.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransakcije)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Panel1.Controls.Add(this.GRB_INFORMACIJE);
            this.Panel1.Controls.Add(this.GRB_TRANSAKCIJE);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(197, 439);
            this.Panel1.TabIndex = 2;
            // 
            // GRB_INFORMACIJE
            // 
            this.GRB_INFORMACIJE.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GRB_INFORMACIJE.BackColor = System.Drawing.SystemColors.Window;
            this.GRB_INFORMACIJE.Controls.Add(this.Label35);
            this.GRB_INFORMACIJE.Controls.Add(this.lblDatumPraznjenjaTrezora);
            this.GRB_INFORMACIJE.Controls.Add(this.lbBrojVrecica);
            this.GRB_INFORMACIJE.Controls.Add(this.Label14);
            this.GRB_INFORMACIJE.Location = new System.Drawing.Point(12, 158);
            this.GRB_INFORMACIJE.Name = "GRB_INFORMACIJE";
            this.GRB_INFORMACIJE.Size = new System.Drawing.Size(174, 161);
            this.GRB_INFORMACIJE.TabIndex = 2;
            this.GRB_INFORMACIJE.TabStop = false;
            // 
            // Label35
            // 
            this.Label35.AutoSize = true;
            this.Label35.Location = new System.Drawing.Point(22, 91);
            this.Label35.Name = "Label35";
            this.Label35.Size = new System.Drawing.Size(126, 13);
            this.Label35.TabIndex = 5;
            this.Label35.Text = "Zadnje pražnjenje trezora";
            // 
            // lblDatumPraznjenjaTrezora
            // 
            this.lblDatumPraznjenjaTrezora.AutoSize = true;
            this.lblDatumPraznjenjaTrezora.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblDatumPraznjenjaTrezora.Location = new System.Drawing.Point(25, 112);
            this.lblDatumPraznjenjaTrezora.Name = "lblDatumPraznjenjaTrezora";
            this.lblDatumPraznjenjaTrezora.Size = new System.Drawing.Size(119, 17);
            this.lblDatumPraznjenjaTrezora.TabIndex = 4;
            this.lblDatumPraznjenjaTrezora.Text = "Datum pražnjenja";
            this.lblDatumPraznjenjaTrezora.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbBrojVrecica
            // 
            this.lbBrojVrecica.AutoSize = true;
            this.lbBrojVrecica.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbBrojVrecica.Location = new System.Drawing.Point(53, 41);
            this.lbBrojVrecica.Name = "lbBrojVrecica";
            this.lbBrojVrecica.Size = new System.Drawing.Size(57, 39);
            this.lbBrojVrecica.TabIndex = 1;
            this.lbBrojVrecica.Text = "00";
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Location = new System.Drawing.Point(37, 16);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(107, 13);
            this.Label14.TabIndex = 0;
            this.Label14.Text = "Broj vrečica u trezoru";
            // 
            // GRB_TRANSAKCIJE
            // 
            this.GRB_TRANSAKCIJE.BackColor = System.Drawing.SystemColors.Window;
            this.GRB_TRANSAKCIJE.Controls.Add(this.pictureBox3);
            this.GRB_TRANSAKCIJE.Controls.Add(this.lblPretragaTransakcija);
            this.GRB_TRANSAKCIJE.Controls.Add(this.PictureBox2);
            this.GRB_TRANSAKCIJE.Controls.Add(this.lblAdministracijaKorisnika);
            this.GRB_TRANSAKCIJE.Controls.Add(this.PictureBox1);
            this.GRB_TRANSAKCIJE.Controls.Add(this.lblPraznjenjeTrezora);
            this.GRB_TRANSAKCIJE.Location = new System.Drawing.Point(12, 18);
            this.GRB_TRANSAKCIJE.Name = "GRB_TRANSAKCIJE";
            this.GRB_TRANSAKCIJE.Size = new System.Drawing.Size(174, 110);
            this.GRB_TRANSAKCIJE.TabIndex = 0;
            this.GRB_TRANSAKCIJE.TabStop = false;
            // 
            // lblPretragaTransakcija
            // 
            this.lblPretragaTransakcija.AutoSize = true;
            this.lblPretragaTransakcija.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblPretragaTransakcija.Location = new System.Drawing.Point(38, 80);
            this.lblPretragaTransakcija.Name = "lblPretragaTransakcija";
            this.lblPretragaTransakcija.Size = new System.Drawing.Size(111, 15);
            this.lblPretragaTransakcija.TabIndex = 5;
            this.lblPretragaTransakcija.TabStop = true;
            this.lblPretragaTransakcija.Text = "Pretrazi transakcije";
            // 
            // lblAdministracijaKorisnika
            // 
            this.lblAdministracijaKorisnika.AutoSize = true;
            this.lblAdministracijaKorisnika.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblAdministracijaKorisnika.Location = new System.Drawing.Point(38, 53);
            this.lblAdministracijaKorisnika.Name = "lblAdministracijaKorisnika";
            this.lblAdministracijaKorisnika.Size = new System.Drawing.Size(136, 15);
            this.lblAdministracijaKorisnika.TabIndex = 2;
            this.lblAdministracijaKorisnika.TabStop = true;
            this.lblAdministracijaKorisnika.Text = "Administracija korisnika\r\n";
            // 
            // lblPraznjenjeTrezora
            // 
            this.lblPraznjenjeTrezora.AutoSize = true;
            this.lblPraznjenjeTrezora.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblPraznjenjeTrezora.Location = new System.Drawing.Point(38, 22);
            this.lblPraznjenjeTrezora.Name = "lblPraznjenjeTrezora";
            this.lblPraznjenjeTrezora.Size = new System.Drawing.Size(107, 15);
            this.lblPraznjenjeTrezora.TabIndex = 0;
            this.lblPraznjenjeTrezora.TabStop = true;
            this.lblPraznjenjeTrezora.Text = "Pražnjenje trezora";
            // 
            // gbPretragaTransakcija
            // 
            this.gbPretragaTransakcija.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPretragaTransakcija.Controls.Add(this.button1);
            this.gbPretragaTransakcija.Controls.Add(this.label3);
            this.gbPretragaTransakcija.Controls.Add(this.label2);
            this.gbPretragaTransakcija.Controls.Add(this.label1);
            this.gbPretragaTransakcija.Controls.Add(this.comboBox1);
            this.gbPretragaTransakcija.Controls.Add(this.DTP_ZAVRSNI_DATUM);
            this.gbPretragaTransakcija.Controls.Add(this.DTP_POCETNI_DATUM);
            this.gbPretragaTransakcija.Controls.Add(this.BTN_PRETRAZI_UZ_UVIJET);
            this.gbPretragaTransakcija.Controls.Add(this.btnPrint);
            this.gbPretragaTransakcija.Location = new System.Drawing.Point(203, 321);
            this.gbPretragaTransakcija.Name = "gbPretragaTransakcija";
            this.gbPretragaTransakcija.Size = new System.Drawing.Size(658, 118);
            this.gbPretragaTransakcija.TabIndex = 37;
            this.gbPretragaTransakcija.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 48;
            this.label3.Text = "Korisnik";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(235, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 47;
            this.label2.Text = "do";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 46;
            this.label1.Text = "Dolazak od";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(88, 70);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(141, 21);
            this.comboBox1.TabIndex = 45;
            // 
            // DTP_ZAVRSNI_DATUM
            // 
            this.DTP_ZAVRSNI_DATUM.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            this.DTP_ZAVRSNI_DATUM.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DTP_ZAVRSNI_DATUM.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTP_ZAVRSNI_DATUM.Location = new System.Drawing.Point(260, 41);
            this.DTP_ZAVRSNI_DATUM.Name = "DTP_ZAVRSNI_DATUM";
            this.DTP_ZAVRSNI_DATUM.ShowUpDown = true;
            this.DTP_ZAVRSNI_DATUM.Size = new System.Drawing.Size(142, 21);
            this.DTP_ZAVRSNI_DATUM.TabIndex = 28;
            // 
            // DTP_POCETNI_DATUM
            // 
            this.DTP_POCETNI_DATUM.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            this.DTP_POCETNI_DATUM.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DTP_POCETNI_DATUM.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTP_POCETNI_DATUM.Location = new System.Drawing.Point(88, 41);
            this.DTP_POCETNI_DATUM.Name = "DTP_POCETNI_DATUM";
            this.DTP_POCETNI_DATUM.ShowUpDown = true;
            this.DTP_POCETNI_DATUM.Size = new System.Drawing.Size(141, 21);
            this.DTP_POCETNI_DATUM.TabIndex = 27;
            // 
            // dgvTransakcije
            // 
            this.dgvTransakcije.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTransakcije.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransakcije.Location = new System.Drawing.Point(203, 5);
            this.dgvTransakcije.Name = "dgvTransakcije";
            this.dgvTransakcije.Size = new System.Drawing.Size(658, 315);
            this.dgvTransakcije.TabIndex = 38;
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.Location = new System.Drawing.Point(546, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 23);
            this.button1.TabIndex = 49;
            this.button1.Text = "PRETRAŽI";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // BTN_PRETRAZI_UZ_UVIJET
            // 
            this.BTN_PRETRAZI_UZ_UVIJET.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BTN_PRETRAZI_UZ_UVIJET.BackgroundImage")));
            this.BTN_PRETRAZI_UZ_UVIJET.Location = new System.Drawing.Point(408, 39);
            this.BTN_PRETRAZI_UZ_UVIJET.Name = "BTN_PRETRAZI_UZ_UVIJET";
            this.BTN_PRETRAZI_UZ_UVIJET.Size = new System.Drawing.Size(104, 23);
            this.BTN_PRETRAZI_UZ_UVIJET.TabIndex = 39;
            this.BTN_PRETRAZI_UZ_UVIJET.Text = "PRETRAŽI";
            this.BTN_PRETRAZI_UZ_UVIJET.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(395, 75);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(163, 33);
            this.btnPrint.TabIndex = 43;
            this.btnPrint.UseVisualStyleBackColor = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(5, 47);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(27, 26);
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // PictureBox2
            // 
            this.PictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox2.Image")));
            this.PictureBox2.Location = new System.Drawing.Point(6, 78);
            this.PictureBox2.Name = "PictureBox2";
            this.PictureBox2.Size = new System.Drawing.Size(26, 26);
            this.PictureBox2.TabIndex = 4;
            this.PictureBox2.TabStop = false;
            // 
            // PictureBox1
            // 
            this.PictureBox1.Location = new System.Drawing.Point(6, 16);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(27, 26);
            this.PictureBox1.TabIndex = 3;
            this.PictureBox1.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 439);
            this.ControlBox = false;
            this.Controls.Add(this.dgvTransakcije);
            this.Controls.Add(this.gbPretragaTransakcija);
            this.Controls.Add(this.Panel1);
            this.Name = "frmMain";
            this.Text = "DNEVNO-NOĆNI TREZOR";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Panel1.ResumeLayout(false);
            this.GRB_INFORMACIJE.ResumeLayout(false);
            this.GRB_INFORMACIJE.PerformLayout();
            this.GRB_TRANSAKCIJE.ResumeLayout(false);
            this.GRB_TRANSAKCIJE.PerformLayout();
            this.gbPretragaTransakcija.ResumeLayout(false);
            this.gbPretragaTransakcija.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransakcije)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort SerialPortElektronika;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.LinkLabel lblAdministracijaKorisnika;
        internal System.Windows.Forms.GroupBox GRB_INFORMACIJE;
        internal System.Windows.Forms.Label Label35;
        internal System.Windows.Forms.Label lblDatumPraznjenjaTrezora;
        internal System.Windows.Forms.Label lbBrojVrecica;
        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.GroupBox GRB_TRANSAKCIJE;
        internal System.Windows.Forms.PictureBox PictureBox2;
        internal System.Windows.Forms.PictureBox PictureBox1;
        internal System.Windows.Forms.LinkLabel lblPraznjenjeTrezora;
        internal System.Windows.Forms.GroupBox gbPretragaTransakcija;
        internal System.Windows.Forms.Button BTN_PRETRAZI_UZ_UVIJET;
        internal System.Windows.Forms.Button btnPrint;
        internal System.Windows.Forms.DateTimePicker DTP_ZAVRSNI_DATUM;
        internal System.Windows.Forms.DateTimePicker DTP_POCETNI_DATUM;
        private System.IO.Ports.SerialPort SerialPortLcd;
        internal System.Windows.Forms.DataGridView dgvTransakcije;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.LinkLabel lblPretragaTransakcija;
        internal System.Windows.Forms.PictureBox pictureBox3;
        internal System.Windows.Forms.Button button1;
    }
}

