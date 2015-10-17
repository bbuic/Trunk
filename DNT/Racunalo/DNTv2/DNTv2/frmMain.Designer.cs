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
            this.GRB_ADMINISTRACIJA = new System.Windows.Forms.GroupBox();
            this.PictureBox3 = new System.Windows.Forms.PictureBox();
            this.LIBL_KORISNICI_DNT = new System.Windows.Forms.LinkLabel();
            this.GRB_INFORMACIJE = new System.Windows.Forms.GroupBox();
            this.Label35 = new System.Windows.Forms.Label();
            this.LBL_PRAZNJENJE_TREZORA = new System.Windows.Forms.Label();
            this.LBL_BROJ_UBACENIH_VRECICA_NAKON_RESETA = new System.Windows.Forms.Label();
            this.Label14 = new System.Windows.Forms.Label();
            this.GRB_TRANSAKCIJE = new System.Windows.Forms.GroupBox();
            this.PictureBox2 = new System.Windows.Forms.PictureBox();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTraziTrans = new System.Windows.Forms.LinkLabel();
            this.lblPraznjenjeTrezora = new System.Windows.Forms.LinkLabel();
            this.GRB_ODABIR_UZ_UVIJET = new System.Windows.Forms.GroupBox();
            this.BTN_PRETRAZI_UZ_UVIJET = new System.Windows.Forms.Button();
            this.BTN_PRINTER = new System.Windows.Forms.Button();
            this.BTN_IZLAZ_STATISTIKA = new System.Windows.Forms.Button();
            this.DTP_ZAVRSNI_DATUM = new System.Windows.Forms.DateTimePicker();
            this.DTP_POCETNI_DATUM = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.SerialPortLcd = new System.IO.Ports.SerialPort(this.components);
            this.Panel1.SuspendLayout();
            this.GRB_ADMINISTRACIJA.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox3)).BeginInit();
            this.GRB_INFORMACIJE.SuspendLayout();
            this.GRB_TRANSAKCIJE.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.GRB_ODABIR_UZ_UVIJET.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Panel1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Panel1.Controls.Add(this.GRB_ADMINISTRACIJA);
            this.Panel1.Controls.Add(this.GRB_INFORMACIJE);
            this.Panel1.Controls.Add(this.GRB_TRANSAKCIJE);
            this.Panel1.Location = new System.Drawing.Point(12, 12);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(197, 518);
            this.Panel1.TabIndex = 2;
            // 
            // GRB_ADMINISTRACIJA
            // 
            this.GRB_ADMINISTRACIJA.BackColor = System.Drawing.SystemColors.Window;
            this.GRB_ADMINISTRACIJA.Controls.Add(this.PictureBox3);
            this.GRB_ADMINISTRACIJA.Controls.Add(this.LIBL_KORISNICI_DNT);
            this.GRB_ADMINISTRACIJA.Location = new System.Drawing.Point(12, 155);
            this.GRB_ADMINISTRACIJA.Name = "GRB_ADMINISTRACIJA";
            this.GRB_ADMINISTRACIJA.Size = new System.Drawing.Size(174, 94);
            this.GRB_ADMINISTRACIJA.TabIndex = 3;
            this.GRB_ADMINISTRACIJA.TabStop = false;
            this.GRB_ADMINISTRACIJA.Text = "Korisnici D-N trezora";
            // 
            // PictureBox3
            // 
            this.PictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox3.Image")));
            this.PictureBox3.Location = new System.Drawing.Point(2, 29);
            this.PictureBox3.Name = "PictureBox3";
            this.PictureBox3.Size = new System.Drawing.Size(50, 45);
            this.PictureBox3.TabIndex = 4;
            this.PictureBox3.TabStop = false;
            // 
            // LIBL_KORISNICI_DNT
            // 
            this.LIBL_KORISNICI_DNT.AutoSize = true;
            this.LIBL_KORISNICI_DNT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LIBL_KORISNICI_DNT.Location = new System.Drawing.Point(51, 29);
            this.LIBL_KORISNICI_DNT.Name = "LIBL_KORISNICI_DNT";
            this.LIBL_KORISNICI_DNT.Size = new System.Drawing.Size(104, 45);
            this.LIBL_KORISNICI_DNT.TabIndex = 2;
            this.LIBL_KORISNICI_DNT.TabStop = true;
            this.LIBL_KORISNICI_DNT.Text = "Unos korisnika\r\n\r\nBrisanje korisnika\r\n";
            // 
            // GRB_INFORMACIJE
            // 
            this.GRB_INFORMACIJE.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GRB_INFORMACIJE.BackColor = System.Drawing.SystemColors.Window;
            this.GRB_INFORMACIJE.Controls.Add(this.Label35);
            this.GRB_INFORMACIJE.Controls.Add(this.LBL_PRAZNJENJE_TREZORA);
            this.GRB_INFORMACIJE.Controls.Add(this.LBL_BROJ_UBACENIH_VRECICA_NAKON_RESETA);
            this.GRB_INFORMACIJE.Controls.Add(this.Label14);
            this.GRB_INFORMACIJE.Location = new System.Drawing.Point(14, 280);
            this.GRB_INFORMACIJE.Name = "GRB_INFORMACIJE";
            this.GRB_INFORMACIJE.Size = new System.Drawing.Size(172, 148);
            this.GRB_INFORMACIJE.TabIndex = 2;
            this.GRB_INFORMACIJE.TabStop = false;
            this.GRB_INFORMACIJE.Text = "Informacije";
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
            // LBL_PRAZNJENJE_TREZORA
            // 
            this.LBL_PRAZNJENJE_TREZORA.AutoSize = true;
            this.LBL_PRAZNJENJE_TREZORA.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LBL_PRAZNJENJE_TREZORA.Location = new System.Drawing.Point(25, 112);
            this.LBL_PRAZNJENJE_TREZORA.Name = "LBL_PRAZNJENJE_TREZORA";
            this.LBL_PRAZNJENJE_TREZORA.Size = new System.Drawing.Size(119, 17);
            this.LBL_PRAZNJENJE_TREZORA.TabIndex = 4;
            this.LBL_PRAZNJENJE_TREZORA.Text = "Datum pražnjenja";
            this.LBL_PRAZNJENJE_TREZORA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LBL_BROJ_UBACENIH_VRECICA_NAKON_RESETA
            // 
            this.LBL_BROJ_UBACENIH_VRECICA_NAKON_RESETA.AutoSize = true;
            this.LBL_BROJ_UBACENIH_VRECICA_NAKON_RESETA.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LBL_BROJ_UBACENIH_VRECICA_NAKON_RESETA.Location = new System.Drawing.Point(53, 41);
            this.LBL_BROJ_UBACENIH_VRECICA_NAKON_RESETA.Name = "LBL_BROJ_UBACENIH_VRECICA_NAKON_RESETA";
            this.LBL_BROJ_UBACENIH_VRECICA_NAKON_RESETA.Size = new System.Drawing.Size(57, 39);
            this.LBL_BROJ_UBACENIH_VRECICA_NAKON_RESETA.TabIndex = 1;
            this.LBL_BROJ_UBACENIH_VRECICA_NAKON_RESETA.Text = "00";
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Location = new System.Drawing.Point(14, 21);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(147, 13);
            this.Label14.TabIndex = 0;
            this.Label14.Text = "Broj vrečica nakon pražnjenja";
            // 
            // GRB_TRANSAKCIJE
            // 
            this.GRB_TRANSAKCIJE.BackColor = System.Drawing.SystemColors.Window;
            this.GRB_TRANSAKCIJE.Controls.Add(this.PictureBox2);
            this.GRB_TRANSAKCIJE.Controls.Add(this.PictureBox1);
            this.GRB_TRANSAKCIJE.Controls.Add(this.lblTraziTrans);
            this.GRB_TRANSAKCIJE.Controls.Add(this.lblPraznjenjeTrezora);
            this.GRB_TRANSAKCIJE.Location = new System.Drawing.Point(12, 18);
            this.GRB_TRANSAKCIJE.Name = "GRB_TRANSAKCIJE";
            this.GRB_TRANSAKCIJE.Size = new System.Drawing.Size(174, 95);
            this.GRB_TRANSAKCIJE.TabIndex = 0;
            this.GRB_TRANSAKCIJE.TabStop = false;
            this.GRB_TRANSAKCIJE.Text = "Transakcije";
            // 
            // PictureBox2
            // 
            this.PictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox2.Image")));
            this.PictureBox2.Location = new System.Drawing.Point(5, 58);
            this.PictureBox2.Name = "PictureBox2";
            this.PictureBox2.Size = new System.Drawing.Size(19, 21);
            this.PictureBox2.TabIndex = 4;
            this.PictureBox2.TabStop = false;
            // 
            // PictureBox1
            // 
            this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
            this.PictureBox1.Location = new System.Drawing.Point(5, 27);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(19, 21);
            this.PictureBox1.TabIndex = 3;
            this.PictureBox1.TabStop = false;
            // 
            // lblTraziTrans
            // 
            this.lblTraziTrans.AutoSize = true;
            this.lblTraziTrans.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTraziTrans.Location = new System.Drawing.Point(26, 58);
            this.lblTraziTrans.Name = "lblTraziTrans";
            this.lblTraziTrans.Size = new System.Drawing.Size(147, 17);
            this.lblTraziTrans.TabIndex = 2;
            this.lblTraziTrans.TabStop = true;
            this.lblTraziTrans.Text = "Pretraživanje uz uvijet";
            // 
            // lblPraznjenjeTrezora
            // 
            this.lblPraznjenjeTrezora.AutoSize = true;
            this.lblPraznjenjeTrezora.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblPraznjenjeTrezora.Location = new System.Drawing.Point(26, 28);
            this.lblPraznjenjeTrezora.Name = "lblPraznjenjeTrezora";
            this.lblPraznjenjeTrezora.Size = new System.Drawing.Size(124, 17);
            this.lblPraznjenjeTrezora.TabIndex = 0;
            this.lblPraznjenjeTrezora.TabStop = true;
            this.lblPraznjenjeTrezora.Text = "Pražnjenje trezora";
            // 
            // GRB_ODABIR_UZ_UVIJET
            // 
            this.GRB_ODABIR_UZ_UVIJET.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GRB_ODABIR_UZ_UVIJET.Controls.Add(this.DTP_ZAVRSNI_DATUM);
            this.GRB_ODABIR_UZ_UVIJET.Controls.Add(this.DTP_POCETNI_DATUM);
            this.GRB_ODABIR_UZ_UVIJET.Controls.Add(this.BTN_PRETRAZI_UZ_UVIJET);
            this.GRB_ODABIR_UZ_UVIJET.Controls.Add(this.BTN_PRINTER);
            this.GRB_ODABIR_UZ_UVIJET.Controls.Add(this.BTN_IZLAZ_STATISTIKA);
            this.GRB_ODABIR_UZ_UVIJET.Location = new System.Drawing.Point(215, 424);
            this.GRB_ODABIR_UZ_UVIJET.Name = "GRB_ODABIR_UZ_UVIJET";
            this.GRB_ODABIR_UZ_UVIJET.Size = new System.Drawing.Size(640, 106);
            this.GRB_ODABIR_UZ_UVIJET.TabIndex = 37;
            this.GRB_ODABIR_UZ_UVIJET.TabStop = false;
            this.GRB_ODABIR_UZ_UVIJET.Text = "Pretraživanje uz uvijet";
            this.GRB_ODABIR_UZ_UVIJET.Visible = false;
            // 
            // BTN_PRETRAZI_UZ_UVIJET
            // 
            this.BTN_PRETRAZI_UZ_UVIJET.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BTN_PRETRAZI_UZ_UVIJET.BackgroundImage")));
            this.BTN_PRETRAZI_UZ_UVIJET.Location = new System.Drawing.Point(395, 37);
            this.BTN_PRETRAZI_UZ_UVIJET.Name = "BTN_PRETRAZI_UZ_UVIJET";
            this.BTN_PRETRAZI_UZ_UVIJET.Size = new System.Drawing.Size(104, 23);
            this.BTN_PRETRAZI_UZ_UVIJET.TabIndex = 39;
            this.BTN_PRETRAZI_UZ_UVIJET.Text = "PRETRAŽI";
            this.BTN_PRETRAZI_UZ_UVIJET.UseVisualStyleBackColor = true;
            // 
            // BTN_PRINTER
            // 
            this.BTN_PRINTER.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BTN_PRINTER.BackgroundImage")));
            this.BTN_PRINTER.Location = new System.Drawing.Point(398, 66);
            this.BTN_PRINTER.Name = "BTN_PRINTER";
            this.BTN_PRINTER.Size = new System.Drawing.Size(101, 22);
            this.BTN_PRINTER.TabIndex = 43;
            this.BTN_PRINTER.UseVisualStyleBackColor = true;
            this.BTN_PRINTER.Visible = false;
            // 
            // BTN_IZLAZ_STATISTIKA
            // 
            this.BTN_IZLAZ_STATISTIKA.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BTN_IZLAZ_STATISTIKA.BackgroundImage")));
            this.BTN_IZLAZ_STATISTIKA.Location = new System.Drawing.Point(528, 37);
            this.BTN_IZLAZ_STATISTIKA.Name = "BTN_IZLAZ_STATISTIKA";
            this.BTN_IZLAZ_STATISTIKA.Size = new System.Drawing.Size(106, 23);
            this.BTN_IZLAZ_STATISTIKA.TabIndex = 45;
            this.BTN_IZLAZ_STATISTIKA.Text = "Natrag";
            this.BTN_IZLAZ_STATISTIKA.UseVisualStyleBackColor = true;
            // 
            // DTP_ZAVRSNI_DATUM
            // 
            this.DTP_ZAVRSNI_DATUM.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            this.DTP_ZAVRSNI_DATUM.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DTP_ZAVRSNI_DATUM.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTP_ZAVRSNI_DATUM.Location = new System.Drawing.Point(181, 36);
            this.DTP_ZAVRSNI_DATUM.Name = "DTP_ZAVRSNI_DATUM";
            this.DTP_ZAVRSNI_DATUM.ShowUpDown = true;
            this.DTP_ZAVRSNI_DATUM.Size = new System.Drawing.Size(197, 21);
            this.DTP_ZAVRSNI_DATUM.TabIndex = 28;
            // 
            // DTP_POCETNI_DATUM
            // 
            this.DTP_POCETNI_DATUM.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            this.DTP_POCETNI_DATUM.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DTP_POCETNI_DATUM.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTP_POCETNI_DATUM.Location = new System.Drawing.Point(24, 36);
            this.DTP_POCETNI_DATUM.Name = "DTP_POCETNI_DATUM";
            this.DTP_POCETNI_DATUM.ShowUpDown = true;
            this.DTP_POCETNI_DATUM.Size = new System.Drawing.Size(141, 21);
            this.DTP_POCETNI_DATUM.TabIndex = 27;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(226, 14);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(644, 199);
            this.dataGridView1.TabIndex = 38;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 575);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.GRB_ODABIR_UZ_UVIJET);
            this.Controls.Add(this.Panel1);
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.Panel1.ResumeLayout(false);
            this.GRB_ADMINISTRACIJA.ResumeLayout(false);
            this.GRB_ADMINISTRACIJA.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox3)).EndInit();
            this.GRB_INFORMACIJE.ResumeLayout(false);
            this.GRB_INFORMACIJE.PerformLayout();
            this.GRB_TRANSAKCIJE.ResumeLayout(false);
            this.GRB_TRANSAKCIJE.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.GRB_ODABIR_UZ_UVIJET.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort SerialPortElektronika;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.GroupBox GRB_ADMINISTRACIJA;
        internal System.Windows.Forms.PictureBox PictureBox3;
        internal System.Windows.Forms.LinkLabel LIBL_KORISNICI_DNT;
        internal System.Windows.Forms.GroupBox GRB_INFORMACIJE;
        internal System.Windows.Forms.Label Label35;
        internal System.Windows.Forms.Label LBL_PRAZNJENJE_TREZORA;
        internal System.Windows.Forms.Label LBL_BROJ_UBACENIH_VRECICA_NAKON_RESETA;
        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.GroupBox GRB_TRANSAKCIJE;
        internal System.Windows.Forms.PictureBox PictureBox2;
        internal System.Windows.Forms.PictureBox PictureBox1;
        internal System.Windows.Forms.LinkLabel lblTraziTrans;
        internal System.Windows.Forms.LinkLabel lblPraznjenjeTrezora;
        internal System.Windows.Forms.GroupBox GRB_ODABIR_UZ_UVIJET;
        internal System.Windows.Forms.Button BTN_PRETRAZI_UZ_UVIJET;
        internal System.Windows.Forms.Button BTN_PRINTER;
        internal System.Windows.Forms.Button BTN_IZLAZ_STATISTIKA;
        internal System.Windows.Forms.DateTimePicker DTP_ZAVRSNI_DATUM;
        internal System.Windows.Forms.DateTimePicker DTP_POCETNI_DATUM;
        private System.IO.Ports.SerialPort SerialPortLcd;
        internal System.Windows.Forms.DataGridView dataGridView1;
    }
}

