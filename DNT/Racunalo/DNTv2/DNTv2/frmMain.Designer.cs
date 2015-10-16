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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.LIBL_ODABIR_UZ_UVIJET_TRANSAKCIJE = new System.Windows.Forms.LinkLabel();
            this.LIBL_PRINT = new System.Windows.Forms.LinkLabel();
            this.GRB_KORISNICI_DNT = new System.Windows.Forms.GroupBox();
            this.BTN_RESET_KORISNIK = new System.Windows.Forms.Button();
            this.BTN_PROMJENI_KORISNIKA = new System.Windows.Forms.Button();
            this.BTN_BRISANJE_KARTICE = new System.Windows.Forms.Button();
            this.BTN_UNOS_KARTICE = new System.Windows.Forms.Button();
            this.BTN_IZLAZ_KORISNICI = new System.Windows.Forms.Button();
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.Label9 = new System.Windows.Forms.Label();
            this.LBL_KUCNI_BROJ = new System.Windows.Forms.Label();
            this.TXT_KUCNI_BROJ = new System.Windows.Forms.TextBox();
            this.TXT_GRAD_MJESTO = new System.Windows.Forms.TextBox();
            this.TXT_ULICA = new System.Windows.Forms.TextBox();
            this.TXT_TELEFON = new System.Windows.Forms.TextBox();
            this.TXT_PREZIME = new System.Windows.Forms.TextBox();
            this.TXT_IME = new System.Windows.Forms.TextBox();
            this.LBL_GRAD_MJESTO = new System.Windows.Forms.Label();
            this.LBL_TELEFON = new System.Windows.Forms.Label();
            this.LBL_ADRESA = new System.Windows.Forms.Label();
            this.LBL_PREZIME = new System.Windows.Forms.Label();
            this.LBL_IME = new System.Windows.Forms.Label();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.Label1 = new System.Windows.Forms.Label();
            this.DATUM1 = new System.Windows.Forms.DateTimePicker();
            this.LBL_DATUM_UPISA = new System.Windows.Forms.Label();
            this.LBL_BROJ_UGOVORA = new System.Windows.Forms.Label();
            this.TXT_BROJ_UGOVORA = new System.Windows.Forms.TextBox();
            this.TXT_BROJ_KARTICE = new System.Windows.Forms.TextBox();
            this.LBL_BROJ_KARTICE = new System.Windows.Forms.Label();
            this.DGV_KARTICE = new System.Windows.Forms.DataGridView();
            this.broj_kartice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ugovor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GRB_ODABIR_UZ_UVIJET = new System.Windows.Forms.GroupBox();
            this.BTN_PRETRAZI_UZ_UVIJET = new System.Windows.Forms.Button();
            this.BTN_PRINTER = new System.Windows.Forms.Button();
            this.BTN_IZLAZ_STATISTIKA = new System.Windows.Forms.Button();
            this.GRB_ZAVRSNO_VRIJEME = new System.Windows.Forms.GroupBox();
            this.DTP_ZAVRSNI_DATUM = new System.Windows.Forms.DateTimePicker();
            this.GRB_POCETNO_VRIJEME = new System.Windows.Forms.GroupBox();
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
            this.GRB_KORISNICI_DNT.SuspendLayout();
            this.TabControl1.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.TabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_KARTICE)).BeginInit();
            this.GRB_ODABIR_UZ_UVIJET.SuspendLayout();
            this.GRB_ZAVRSNO_VRIJEME.SuspendLayout();
            this.GRB_POCETNO_VRIJEME.SuspendLayout();
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
            this.GRB_TRANSAKCIJE.Controls.Add(this.LIBL_ODABIR_UZ_UVIJET_TRANSAKCIJE);
            this.GRB_TRANSAKCIJE.Controls.Add(this.LIBL_PRINT);
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
            // LIBL_ODABIR_UZ_UVIJET_TRANSAKCIJE
            // 
            this.LIBL_ODABIR_UZ_UVIJET_TRANSAKCIJE.AutoSize = true;
            this.LIBL_ODABIR_UZ_UVIJET_TRANSAKCIJE.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LIBL_ODABIR_UZ_UVIJET_TRANSAKCIJE.Location = new System.Drawing.Point(26, 58);
            this.LIBL_ODABIR_UZ_UVIJET_TRANSAKCIJE.Name = "LIBL_ODABIR_UZ_UVIJET_TRANSAKCIJE";
            this.LIBL_ODABIR_UZ_UVIJET_TRANSAKCIJE.Size = new System.Drawing.Size(147, 17);
            this.LIBL_ODABIR_UZ_UVIJET_TRANSAKCIJE.TabIndex = 2;
            this.LIBL_ODABIR_UZ_UVIJET_TRANSAKCIJE.TabStop = true;
            this.LIBL_ODABIR_UZ_UVIJET_TRANSAKCIJE.Text = "Pretraživanje uz uvijet";
            // 
            // LIBL_PRINT
            // 
            this.LIBL_PRINT.AutoSize = true;
            this.LIBL_PRINT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LIBL_PRINT.Location = new System.Drawing.Point(26, 28);
            this.LIBL_PRINT.Name = "LIBL_PRINT";
            this.LIBL_PRINT.Size = new System.Drawing.Size(124, 17);
            this.LIBL_PRINT.TabIndex = 0;
            this.LIBL_PRINT.TabStop = true;
            this.LIBL_PRINT.Text = "Pražnjenje trezora";
            // 
            // GRB_KORISNICI_DNT
            // 
            this.GRB_KORISNICI_DNT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.GRB_KORISNICI_DNT.Controls.Add(this.BTN_RESET_KORISNIK);
            this.GRB_KORISNICI_DNT.Controls.Add(this.BTN_PROMJENI_KORISNIKA);
            this.GRB_KORISNICI_DNT.Controls.Add(this.BTN_BRISANJE_KARTICE);
            this.GRB_KORISNICI_DNT.Controls.Add(this.BTN_UNOS_KARTICE);
            this.GRB_KORISNICI_DNT.Controls.Add(this.BTN_IZLAZ_KORISNICI);
            this.GRB_KORISNICI_DNT.Controls.Add(this.TabControl1);
            this.GRB_KORISNICI_DNT.Location = new System.Drawing.Point(225, 223);
            this.GRB_KORISNICI_DNT.Name = "GRB_KORISNICI_DNT";
            this.GRB_KORISNICI_DNT.Size = new System.Drawing.Size(574, 307);
            this.GRB_KORISNICI_DNT.TabIndex = 36;
            this.GRB_KORISNICI_DNT.TabStop = false;
            this.GRB_KORISNICI_DNT.Text = "Korinici dnevno-noćnog trezora";
            this.GRB_KORISNICI_DNT.Visible = false;
            // 
            // BTN_RESET_KORISNIK
            // 
            this.BTN_RESET_KORISNIK.Location = new System.Drawing.Point(462, 260);
            this.BTN_RESET_KORISNIK.Name = "BTN_RESET_KORISNIK";
            this.BTN_RESET_KORISNIK.Size = new System.Drawing.Size(78, 23);
            this.BTN_RESET_KORISNIK.TabIndex = 64;
            this.BTN_RESET_KORISNIK.Text = "RESET";
            this.BTN_RESET_KORISNIK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTN_RESET_KORISNIK.UseVisualStyleBackColor = true;
            // 
            // BTN_PROMJENI_KORISNIKA
            // 
            this.BTN_PROMJENI_KORISNIKA.Location = new System.Drawing.Point(462, 172);
            this.BTN_PROMJENI_KORISNIKA.Name = "BTN_PROMJENI_KORISNIKA";
            this.BTN_PROMJENI_KORISNIKA.Size = new System.Drawing.Size(78, 23);
            this.BTN_PROMJENI_KORISNIKA.TabIndex = 63;
            this.BTN_PROMJENI_KORISNIKA.Text = "PROMJENI";
            this.BTN_PROMJENI_KORISNIKA.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTN_PROMJENI_KORISNIKA.UseVisualStyleBackColor = true;
            // 
            // BTN_BRISANJE_KARTICE
            // 
            this.BTN_BRISANJE_KARTICE.BackColor = System.Drawing.Color.White;
            this.BTN_BRISANJE_KARTICE.Location = new System.Drawing.Point(462, 203);
            this.BTN_BRISANJE_KARTICE.Name = "BTN_BRISANJE_KARTICE";
            this.BTN_BRISANJE_KARTICE.Size = new System.Drawing.Size(78, 23);
            this.BTN_BRISANJE_KARTICE.TabIndex = 62;
            this.BTN_BRISANJE_KARTICE.Text = "OBRIŠI";
            this.BTN_BRISANJE_KARTICE.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTN_BRISANJE_KARTICE.UseVisualStyleBackColor = false;
            // 
            // BTN_UNOS_KARTICE
            // 
            this.BTN_UNOS_KARTICE.Location = new System.Drawing.Point(462, 232);
            this.BTN_UNOS_KARTICE.Name = "BTN_UNOS_KARTICE";
            this.BTN_UNOS_KARTICE.Size = new System.Drawing.Size(78, 23);
            this.BTN_UNOS_KARTICE.TabIndex = 40;
            this.BTN_UNOS_KARTICE.Text = "ZAPAMTI";
            this.BTN_UNOS_KARTICE.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTN_UNOS_KARTICE.UseVisualStyleBackColor = true;
            // 
            // BTN_IZLAZ_KORISNICI
            // 
            this.BTN_IZLAZ_KORISNICI.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BTN_IZLAZ_KORISNICI.BackgroundImage")));
            this.BTN_IZLAZ_KORISNICI.Location = new System.Drawing.Point(445, 41);
            this.BTN_IZLAZ_KORISNICI.Name = "BTN_IZLAZ_KORISNICI";
            this.BTN_IZLAZ_KORISNICI.Size = new System.Drawing.Size(106, 23);
            this.BTN_IZLAZ_KORISNICI.TabIndex = 18;
            this.BTN_IZLAZ_KORISNICI.Text = "Odjava";
            this.BTN_IZLAZ_KORISNICI.UseVisualStyleBackColor = true;
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.TabPage1);
            this.TabControl1.Controls.Add(this.TabPage2);
            this.TabControl1.Location = new System.Drawing.Point(15, 19);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(418, 278);
            this.TabControl1.TabIndex = 37;
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.Label9);
            this.TabPage1.Controls.Add(this.LBL_KUCNI_BROJ);
            this.TabPage1.Controls.Add(this.TXT_KUCNI_BROJ);
            this.TabPage1.Controls.Add(this.TXT_GRAD_MJESTO);
            this.TabPage1.Controls.Add(this.TXT_ULICA);
            this.TabPage1.Controls.Add(this.TXT_TELEFON);
            this.TabPage1.Controls.Add(this.TXT_PREZIME);
            this.TabPage1.Controls.Add(this.TXT_IME);
            this.TabPage1.Controls.Add(this.LBL_GRAD_MJESTO);
            this.TabPage1.Controls.Add(this.LBL_TELEFON);
            this.TabPage1.Controls.Add(this.LBL_ADRESA);
            this.TabPage1.Controls.Add(this.LBL_PREZIME);
            this.TabPage1.Controls.Add(this.LBL_IME);
            this.TabPage1.Location = new System.Drawing.Point(4, 22);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(410, 252);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Korisnici DNT-a";
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.BackColor = System.Drawing.SystemColors.Window;
            this.Label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Label9.ForeColor = System.Drawing.Color.Red;
            this.Label9.Location = new System.Drawing.Point(382, 46);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(15, 20);
            this.Label9.TabIndex = 80;
            this.Label9.Text = "*";
            // 
            // LBL_KUCNI_BROJ
            // 
            this.LBL_KUCNI_BROJ.AutoSize = true;
            this.LBL_KUCNI_BROJ.Location = new System.Drawing.Point(324, 98);
            this.LBL_KUCNI_BROJ.Name = "LBL_KUCNI_BROJ";
            this.LBL_KUCNI_BROJ.Size = new System.Drawing.Size(54, 13);
            this.LBL_KUCNI_BROJ.TabIndex = 79;
            this.LBL_KUCNI_BROJ.Text = "Kućni broj";
            // 
            // TXT_KUCNI_BROJ
            // 
            this.TXT_KUCNI_BROJ.Location = new System.Drawing.Point(281, 95);
            this.TXT_KUCNI_BROJ.Name = "TXT_KUCNI_BROJ";
            this.TXT_KUCNI_BROJ.Size = new System.Drawing.Size(41, 20);
            this.TXT_KUCNI_BROJ.TabIndex = 68;
            // 
            // TXT_GRAD_MJESTO
            // 
            this.TXT_GRAD_MJESTO.Location = new System.Drawing.Point(101, 122);
            this.TXT_GRAD_MJESTO.Name = "TXT_GRAD_MJESTO";
            this.TXT_GRAD_MJESTO.Size = new System.Drawing.Size(143, 20);
            this.TXT_GRAD_MJESTO.TabIndex = 69;
            // 
            // TXT_ULICA
            // 
            this.TXT_ULICA.Location = new System.Drawing.Point(101, 95);
            this.TXT_ULICA.Name = "TXT_ULICA";
            this.TXT_ULICA.Size = new System.Drawing.Size(174, 20);
            this.TXT_ULICA.TabIndex = 66;
            // 
            // TXT_TELEFON
            // 
            this.TXT_TELEFON.Location = new System.Drawing.Point(102, 148);
            this.TXT_TELEFON.Name = "TXT_TELEFON";
            this.TXT_TELEFON.Size = new System.Drawing.Size(142, 20);
            this.TXT_TELEFON.TabIndex = 76;
            // 
            // TXT_PREZIME
            // 
            this.TXT_PREZIME.Location = new System.Drawing.Point(101, 69);
            this.TXT_PREZIME.Name = "TXT_PREZIME";
            this.TXT_PREZIME.Size = new System.Drawing.Size(275, 20);
            this.TXT_PREZIME.TabIndex = 64;
            // 
            // TXT_IME
            // 
            this.TXT_IME.Location = new System.Drawing.Point(101, 43);
            this.TXT_IME.Name = "TXT_IME";
            this.TXT_IME.Size = new System.Drawing.Size(275, 20);
            this.TXT_IME.TabIndex = 62;
            // 
            // LBL_GRAD_MJESTO
            // 
            this.LBL_GRAD_MJESTO.AutoSize = true;
            this.LBL_GRAD_MJESTO.Location = new System.Drawing.Point(28, 122);
            this.LBL_GRAD_MJESTO.Name = "LBL_GRAD_MJESTO";
            this.LBL_GRAD_MJESTO.Size = new System.Drawing.Size(67, 13);
            this.LBL_GRAD_MJESTO.TabIndex = 70;
            this.LBL_GRAD_MJESTO.Text = "Grad(Mjesto)";
            // 
            // LBL_TELEFON
            // 
            this.LBL_TELEFON.AutoSize = true;
            this.LBL_TELEFON.Location = new System.Drawing.Point(53, 151);
            this.LBL_TELEFON.Name = "LBL_TELEFON";
            this.LBL_TELEFON.Size = new System.Drawing.Size(43, 13);
            this.LBL_TELEFON.TabIndex = 78;
            this.LBL_TELEFON.Text = "Telefon";
            // 
            // LBL_ADRESA
            // 
            this.LBL_ADRESA.AutoSize = true;
            this.LBL_ADRESA.Location = new System.Drawing.Point(63, 95);
            this.LBL_ADRESA.Name = "LBL_ADRESA";
            this.LBL_ADRESA.Size = new System.Drawing.Size(31, 13);
            this.LBL_ADRESA.TabIndex = 67;
            this.LBL_ADRESA.Text = "Ulica";
            // 
            // LBL_PREZIME
            // 
            this.LBL_PREZIME.AutoSize = true;
            this.LBL_PREZIME.Location = new System.Drawing.Point(9, 72);
            this.LBL_PREZIME.Name = "LBL_PREZIME";
            this.LBL_PREZIME.Size = new System.Drawing.Size(86, 13);
            this.LBL_PREZIME.TabIndex = 65;
            this.LBL_PREZIME.Text = "Prezime (Naziv2)";
            // 
            // LBL_IME
            // 
            this.LBL_IME.AutoSize = true;
            this.LBL_IME.Location = new System.Drawing.Point(29, 46);
            this.LBL_IME.Name = "LBL_IME";
            this.LBL_IME.Size = new System.Drawing.Size(66, 13);
            this.LBL_IME.TabIndex = 63;
            this.LBL_IME.Text = "Ime (Naziv1)";
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.Label1);
            this.TabPage2.Controls.Add(this.DATUM1);
            this.TabPage2.Controls.Add(this.LBL_DATUM_UPISA);
            this.TabPage2.Controls.Add(this.LBL_BROJ_UGOVORA);
            this.TabPage2.Controls.Add(this.TXT_BROJ_UGOVORA);
            this.TabPage2.Controls.Add(this.TXT_BROJ_KARTICE);
            this.TabPage2.Controls.Add(this.LBL_BROJ_KARTICE);
            this.TabPage2.Controls.Add(this.DGV_KARTICE);
            this.TabPage2.Location = new System.Drawing.Point(4, 22);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(410, 252);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Kartice";
            this.TabPage2.UseVisualStyleBackColor = true;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.SystemColors.Window;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Label1.ForeColor = System.Drawing.Color.Red;
            this.Label1.Location = new System.Drawing.Point(174, 199);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(15, 20);
            this.Label1.TabIndex = 89;
            this.Label1.Text = "*";
            // 
            // DATUM1
            // 
            this.DATUM1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DATUM1.Location = new System.Drawing.Point(84, 226);
            this.DATUM1.Name = "DATUM1";
            this.DATUM1.Size = new System.Drawing.Size(84, 20);
            this.DATUM1.TabIndex = 87;
            // 
            // LBL_DATUM_UPISA
            // 
            this.LBL_DATUM_UPISA.AutoSize = true;
            this.LBL_DATUM_UPISA.Location = new System.Drawing.Point(40, 230);
            this.LBL_DATUM_UPISA.Name = "LBL_DATUM_UPISA";
            this.LBL_DATUM_UPISA.Size = new System.Drawing.Size(38, 13);
            this.LBL_DATUM_UPISA.TabIndex = 88;
            this.LBL_DATUM_UPISA.Text = "Datum";
            // 
            // LBL_BROJ_UGOVORA
            // 
            this.LBL_BROJ_UGOVORA.AutoSize = true;
            this.LBL_BROJ_UGOVORA.Location = new System.Drawing.Point(232, 202);
            this.LBL_BROJ_UGOVORA.Name = "LBL_BROJ_UGOVORA";
            this.LBL_BROJ_UGOVORA.Size = new System.Drawing.Size(42, 13);
            this.LBL_BROJ_UGOVORA.TabIndex = 86;
            this.LBL_BROJ_UGOVORA.Text = "Ugovor";
            // 
            // TXT_BROJ_UGOVORA
            // 
            this.TXT_BROJ_UGOVORA.Location = new System.Drawing.Point(280, 199);
            this.TXT_BROJ_UGOVORA.Name = "TXT_BROJ_UGOVORA";
            this.TXT_BROJ_UGOVORA.Size = new System.Drawing.Size(100, 20);
            this.TXT_BROJ_UGOVORA.TabIndex = 85;
            // 
            // TXT_BROJ_KARTICE
            // 
            this.TXT_BROJ_KARTICE.Location = new System.Drawing.Point(84, 199);
            this.TXT_BROJ_KARTICE.MaxLength = 5;
            this.TXT_BROJ_KARTICE.Name = "TXT_BROJ_KARTICE";
            this.TXT_BROJ_KARTICE.Size = new System.Drawing.Size(84, 20);
            this.TXT_BROJ_KARTICE.TabIndex = 82;
            // 
            // LBL_BROJ_KARTICE
            // 
            this.LBL_BROJ_KARTICE.AutoSize = true;
            this.LBL_BROJ_KARTICE.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LBL_BROJ_KARTICE.Location = new System.Drawing.Point(18, 202);
            this.LBL_BROJ_KARTICE.Name = "LBL_BROJ_KARTICE";
            this.LBL_BROJ_KARTICE.Size = new System.Drawing.Size(60, 13);
            this.LBL_BROJ_KARTICE.TabIndex = 83;
            this.LBL_BROJ_KARTICE.Text = "Broj kartice";
            // 
            // DGV_KARTICE
            // 
            this.DGV_KARTICE.AllowUserToAddRows = false;
            this.DGV_KARTICE.AllowUserToDeleteRows = false;
            this.DGV_KARTICE.AllowUserToResizeColumns = false;
            this.DGV_KARTICE.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_KARTICE.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV_KARTICE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_KARTICE.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.broj_kartice,
            this.ugovor,
            this.datum});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_KARTICE.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGV_KARTICE.Location = new System.Drawing.Point(6, 7);
            this.DGV_KARTICE.Name = "DGV_KARTICE";
            this.DGV_KARTICE.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_KARTICE.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DGV_KARTICE.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_KARTICE.Size = new System.Drawing.Size(398, 174);
            this.DGV_KARTICE.TabIndex = 0;
            // 
            // broj_kartice
            // 
            this.broj_kartice.DataPropertyName = "Broj";
            this.broj_kartice.HeaderText = "Broj kartice";
            this.broj_kartice.Name = "broj_kartice";
            this.broj_kartice.ReadOnly = true;
            // 
            // ugovor
            // 
            this.ugovor.DataPropertyName = "Ugovor";
            this.ugovor.HeaderText = "Ugovor";
            this.ugovor.Name = "ugovor";
            this.ugovor.ReadOnly = true;
            // 
            // datum
            // 
            this.datum.DataPropertyName = "Datum";
            this.datum.HeaderText = "Datum";
            this.datum.Name = "datum";
            this.datum.ReadOnly = true;
            // 
            // GRB_ODABIR_UZ_UVIJET
            // 
            this.GRB_ODABIR_UZ_UVIJET.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GRB_ODABIR_UZ_UVIJET.Controls.Add(this.BTN_PRETRAZI_UZ_UVIJET);
            this.GRB_ODABIR_UZ_UVIJET.Controls.Add(this.BTN_PRINTER);
            this.GRB_ODABIR_UZ_UVIJET.Controls.Add(this.BTN_IZLAZ_STATISTIKA);
            this.GRB_ODABIR_UZ_UVIJET.Controls.Add(this.GRB_ZAVRSNO_VRIJEME);
            this.GRB_ODABIR_UZ_UVIJET.Controls.Add(this.GRB_POCETNO_VRIJEME);
            this.GRB_ODABIR_UZ_UVIJET.Location = new System.Drawing.Point(215, 376);
            this.GRB_ODABIR_UZ_UVIJET.Name = "GRB_ODABIR_UZ_UVIJET";
            this.GRB_ODABIR_UZ_UVIJET.Size = new System.Drawing.Size(640, 154);
            this.GRB_ODABIR_UZ_UVIJET.TabIndex = 37;
            this.GRB_ODABIR_UZ_UVIJET.TabStop = false;
            this.GRB_ODABIR_UZ_UVIJET.Text = "Pretraživanje uz uvijet";
            this.GRB_ODABIR_UZ_UVIJET.Visible = false;
            // 
            // BTN_PRETRAZI_UZ_UVIJET
            // 
            this.BTN_PRETRAZI_UZ_UVIJET.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BTN_PRETRAZI_UZ_UVIJET.BackgroundImage")));
            this.BTN_PRETRAZI_UZ_UVIJET.Location = new System.Drawing.Point(162, 116);
            this.BTN_PRETRAZI_UZ_UVIJET.Name = "BTN_PRETRAZI_UZ_UVIJET";
            this.BTN_PRETRAZI_UZ_UVIJET.Size = new System.Drawing.Size(114, 23);
            this.BTN_PRETRAZI_UZ_UVIJET.TabIndex = 39;
            this.BTN_PRETRAZI_UZ_UVIJET.Text = "PRETRAŽI";
            this.BTN_PRETRAZI_UZ_UVIJET.UseVisualStyleBackColor = true;
            // 
            // BTN_PRINTER
            // 
            this.BTN_PRINTER.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BTN_PRINTER.BackgroundImage")));
            this.BTN_PRINTER.Location = new System.Drawing.Point(222, 25);
            this.BTN_PRINTER.Name = "BTN_PRINTER";
            this.BTN_PRINTER.Size = new System.Drawing.Size(54, 59);
            this.BTN_PRINTER.TabIndex = 43;
            this.BTN_PRINTER.UseVisualStyleBackColor = true;
            this.BTN_PRINTER.Visible = false;
            // 
            // BTN_IZLAZ_STATISTIKA
            // 
            this.BTN_IZLAZ_STATISTIKA.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BTN_IZLAZ_STATISTIKA.BackgroundImage")));
            this.BTN_IZLAZ_STATISTIKA.Location = new System.Drawing.Point(13, 25);
            this.BTN_IZLAZ_STATISTIKA.Name = "BTN_IZLAZ_STATISTIKA";
            this.BTN_IZLAZ_STATISTIKA.Size = new System.Drawing.Size(106, 23);
            this.BTN_IZLAZ_STATISTIKA.TabIndex = 45;
            this.BTN_IZLAZ_STATISTIKA.Text = "Natrag";
            this.BTN_IZLAZ_STATISTIKA.UseVisualStyleBackColor = true;
            // 
            // GRB_ZAVRSNO_VRIJEME
            // 
            this.GRB_ZAVRSNO_VRIJEME.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.GRB_ZAVRSNO_VRIJEME.Controls.Add(this.DTP_ZAVRSNI_DATUM);
            this.GRB_ZAVRSNO_VRIJEME.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.GRB_ZAVRSNO_VRIJEME.Location = new System.Drawing.Point(310, 83);
            this.GRB_ZAVRSNO_VRIJEME.Name = "GRB_ZAVRSNO_VRIJEME";
            this.GRB_ZAVRSNO_VRIJEME.Size = new System.Drawing.Size(230, 61);
            this.GRB_ZAVRSNO_VRIJEME.TabIndex = 41;
            this.GRB_ZAVRSNO_VRIJEME.TabStop = false;
            this.GRB_ZAVRSNO_VRIJEME.Text = "Završno vrijeme dolaska";
            // 
            // DTP_ZAVRSNI_DATUM
            // 
            this.DTP_ZAVRSNI_DATUM.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            this.DTP_ZAVRSNI_DATUM.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DTP_ZAVRSNI_DATUM.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTP_ZAVRSNI_DATUM.Location = new System.Drawing.Point(16, 25);
            this.DTP_ZAVRSNI_DATUM.Name = "DTP_ZAVRSNI_DATUM";
            this.DTP_ZAVRSNI_DATUM.ShowUpDown = true;
            this.DTP_ZAVRSNI_DATUM.Size = new System.Drawing.Size(197, 29);
            this.DTP_ZAVRSNI_DATUM.TabIndex = 28;
            // 
            // GRB_POCETNO_VRIJEME
            // 
            this.GRB_POCETNO_VRIJEME.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.GRB_POCETNO_VRIJEME.Controls.Add(this.DTP_POCETNI_DATUM);
            this.GRB_POCETNO_VRIJEME.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.GRB_POCETNO_VRIJEME.Location = new System.Drawing.Point(310, 14);
            this.GRB_POCETNO_VRIJEME.Name = "GRB_POCETNO_VRIJEME";
            this.GRB_POCETNO_VRIJEME.Size = new System.Drawing.Size(230, 60);
            this.GRB_POCETNO_VRIJEME.TabIndex = 40;
            this.GRB_POCETNO_VRIJEME.TabStop = false;
            this.GRB_POCETNO_VRIJEME.Text = "Poèetno vrijeme dolaska";
            // 
            // DTP_POCETNI_DATUM
            // 
            this.DTP_POCETNI_DATUM.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            this.DTP_POCETNI_DATUM.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DTP_POCETNI_DATUM.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTP_POCETNI_DATUM.Location = new System.Drawing.Point(16, 22);
            this.DTP_POCETNI_DATUM.Name = "DTP_POCETNI_DATUM";
            this.DTP_POCETNI_DATUM.ShowUpDown = true;
            this.DTP_POCETNI_DATUM.Size = new System.Drawing.Size(197, 29);
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
            this.Controls.Add(this.GRB_KORISNICI_DNT);
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
            this.GRB_KORISNICI_DNT.ResumeLayout(false);
            this.TabControl1.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            this.TabPage2.ResumeLayout(false);
            this.TabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_KARTICE)).EndInit();
            this.GRB_ODABIR_UZ_UVIJET.ResumeLayout(false);
            this.GRB_ZAVRSNO_VRIJEME.ResumeLayout(false);
            this.GRB_POCETNO_VRIJEME.ResumeLayout(false);
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
        internal System.Windows.Forms.LinkLabel LIBL_ODABIR_UZ_UVIJET_TRANSAKCIJE;
        internal System.Windows.Forms.LinkLabel LIBL_PRINT;
        internal System.Windows.Forms.GroupBox GRB_KORISNICI_DNT;
        internal System.Windows.Forms.Button BTN_RESET_KORISNIK;
        internal System.Windows.Forms.Button BTN_PROMJENI_KORISNIKA;
        internal System.Windows.Forms.Button BTN_BRISANJE_KARTICE;
        internal System.Windows.Forms.Button BTN_UNOS_KARTICE;
        internal System.Windows.Forms.Button BTN_IZLAZ_KORISNICI;
        internal System.Windows.Forms.TabControl TabControl1;
        internal System.Windows.Forms.TabPage TabPage1;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.Label LBL_KUCNI_BROJ;
        internal System.Windows.Forms.TextBox TXT_KUCNI_BROJ;
        internal System.Windows.Forms.TextBox TXT_GRAD_MJESTO;
        internal System.Windows.Forms.TextBox TXT_ULICA;
        internal System.Windows.Forms.TextBox TXT_TELEFON;
        internal System.Windows.Forms.TextBox TXT_PREZIME;
        internal System.Windows.Forms.TextBox TXT_IME;
        internal System.Windows.Forms.Label LBL_GRAD_MJESTO;
        internal System.Windows.Forms.Label LBL_TELEFON;
        internal System.Windows.Forms.Label LBL_ADRESA;
        internal System.Windows.Forms.Label LBL_PREZIME;
        internal System.Windows.Forms.Label LBL_IME;
        internal System.Windows.Forms.TabPage TabPage2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.DateTimePicker DATUM1;
        internal System.Windows.Forms.Label LBL_DATUM_UPISA;
        internal System.Windows.Forms.Label LBL_BROJ_UGOVORA;
        internal System.Windows.Forms.TextBox TXT_BROJ_UGOVORA;
        internal System.Windows.Forms.TextBox TXT_BROJ_KARTICE;
        internal System.Windows.Forms.Label LBL_BROJ_KARTICE;
        internal System.Windows.Forms.DataGridView DGV_KARTICE;
        internal System.Windows.Forms.DataGridViewTextBoxColumn broj_kartice;
        internal System.Windows.Forms.DataGridViewTextBoxColumn ugovor;
        internal System.Windows.Forms.DataGridViewTextBoxColumn datum;
        internal System.Windows.Forms.GroupBox GRB_ODABIR_UZ_UVIJET;
        internal System.Windows.Forms.Button BTN_PRETRAZI_UZ_UVIJET;
        internal System.Windows.Forms.Button BTN_PRINTER;
        internal System.Windows.Forms.Button BTN_IZLAZ_STATISTIKA;
        internal System.Windows.Forms.GroupBox GRB_ZAVRSNO_VRIJEME;
        internal System.Windows.Forms.DateTimePicker DTP_ZAVRSNI_DATUM;
        internal System.Windows.Forms.GroupBox GRB_POCETNO_VRIJEME;
        internal System.Windows.Forms.DateTimePicker DTP_POCETNI_DATUM;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.IO.Ports.SerialPort SerialPortLcd;
    }
}

