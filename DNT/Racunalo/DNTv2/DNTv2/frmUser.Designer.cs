namespace DNTv2
{
    partial class frmUser
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUser));
            this.dgvKorisnici = new System.Windows.Forms.DataGridView();
            this.GRB_KORISNICI_DNT = new System.Windows.Forms.GroupBox();
            this.btnNovi = new System.Windows.Forms.Button();
            this.btnObrisi = new System.Windows.Forms.Button();
            this.btnZapamti = new System.Windows.Forms.Button();
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.Label9 = new System.Windows.Forms.Label();
            this.LBL_KUCNI_BROJ = new System.Windows.Forms.Label();
            this.txtKucniBroj = new System.Windows.Forms.TextBox();
            this.txtGrad = new System.Windows.Forms.TextBox();
            this.txtUlica = new System.Windows.Forms.TextBox();
            this.txtTelefon = new System.Windows.Forms.TextBox();
            this.txtPrezime = new System.Windows.Forms.TextBox();
            this.txtIme = new System.Windows.Forms.TextBox();
            this.LBL_GRAD_MJESTO = new System.Windows.Forms.Label();
            this.LBL_TELEFON = new System.Windows.Forms.Label();
            this.LBL_ADRESA = new System.Windows.Forms.Label();
            this.LBL_PREZIME = new System.Windows.Forms.Label();
            this.LBL_IME = new System.Windows.Forms.Label();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.Label1 = new System.Windows.Forms.Label();
            this.dtpDatumKartice = new System.Windows.Forms.DateTimePicker();
            this.LBL_DATUM_UPISA = new System.Windows.Forms.Label();
            this.LBL_BROJ_UGOVORA = new System.Windows.Forms.Label();
            this.txtBrojUgovora = new System.Windows.Forms.TextBox();
            this.txtBrojKartice = new System.Windows.Forms.TextBox();
            this.LBL_BROJ_KARTICE = new System.Windows.Forms.Label();
            this.dgvKartice = new System.Windows.Forms.DataGridView();
            this.txtImeFilter = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPovratak = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblBrojKorisnika = new System.Windows.Forms.Label();
            this.chAktivnost = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKorisnici)).BeginInit();
            this.GRB_KORISNICI_DNT.SuspendLayout();
            this.TabControl1.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.TabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKartice)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvKorisnici
            // 
            this.dgvKorisnici.AllowUserToAddRows = false;
            this.dgvKorisnici.AllowUserToDeleteRows = false;
            this.dgvKorisnici.AllowUserToResizeRows = false;
            this.dgvKorisnici.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvKorisnici.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKorisnici.Location = new System.Drawing.Point(2, 31);
            this.dgvKorisnici.MultiSelect = false;
            this.dgvKorisnici.Name = "dgvKorisnici";
            this.dgvKorisnici.ReadOnly = true;
            this.dgvKorisnici.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKorisnici.Size = new System.Drawing.Size(778, 215);
            this.dgvKorisnici.TabIndex = 39;
            // 
            // GRB_KORISNICI_DNT
            // 
            this.GRB_KORISNICI_DNT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.GRB_KORISNICI_DNT.Controls.Add(this.btnNovi);
            this.GRB_KORISNICI_DNT.Controls.Add(this.btnObrisi);
            this.GRB_KORISNICI_DNT.Controls.Add(this.btnZapamti);
            this.GRB_KORISNICI_DNT.Controls.Add(this.TabControl1);
            this.GRB_KORISNICI_DNT.Location = new System.Drawing.Point(2, 252);
            this.GRB_KORISNICI_DNT.Name = "GRB_KORISNICI_DNT";
            this.GRB_KORISNICI_DNT.Size = new System.Drawing.Size(556, 307);
            this.GRB_KORISNICI_DNT.TabIndex = 40;
            this.GRB_KORISNICI_DNT.TabStop = false;
            // 
            // btnNovi
            // 
            this.btnNovi.Image = global::DNTv2.Properties.Resources.Actions_user_group_new_icon;
            this.btnNovi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNovi.Location = new System.Drawing.Point(439, 211);
            this.btnNovi.Name = "btnNovi";
            this.btnNovi.Size = new System.Drawing.Size(104, 26);
            this.btnNovi.TabIndex = 63;
            this.btnNovi.Text = "Dodaj";
            this.btnNovi.UseVisualStyleBackColor = true;
            // 
            // btnObrisi
            // 
            this.btnObrisi.BackColor = System.Drawing.SystemColors.Control;
            this.btnObrisi.Image = global::DNTv2.Properties.Resources.Actions_user_group_delete_icon;
            this.btnObrisi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnObrisi.Location = new System.Drawing.Point(439, 242);
            this.btnObrisi.Name = "btnObrisi";
            this.btnObrisi.Size = new System.Drawing.Size(104, 26);
            this.btnObrisi.TabIndex = 62;
            this.btnObrisi.Text = "Obriši";
            this.btnObrisi.UseVisualStyleBackColor = false;
            // 
            // btnZapamti
            // 
            this.btnZapamti.Image = global::DNTv2.Properties.Resources.Save_icon;
            this.btnZapamti.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnZapamti.Location = new System.Drawing.Point(439, 271);
            this.btnZapamti.Name = "btnZapamti";
            this.btnZapamti.Size = new System.Drawing.Size(104, 26);
            this.btnZapamti.TabIndex = 40;
            this.btnZapamti.Text = "Zapamti";
            this.btnZapamti.UseVisualStyleBackColor = true;
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
            this.TabPage1.Controls.Add(this.txtKucniBroj);
            this.TabPage1.Controls.Add(this.txtGrad);
            this.TabPage1.Controls.Add(this.txtUlica);
            this.TabPage1.Controls.Add(this.txtTelefon);
            this.TabPage1.Controls.Add(this.txtPrezime);
            this.TabPage1.Controls.Add(this.txtIme);
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
            this.TabPage1.Text = "Korisnici";
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
            // txtKucniBroj
            // 
            this.txtKucniBroj.Location = new System.Drawing.Point(281, 95);
            this.txtKucniBroj.MaxLength = 50;
            this.txtKucniBroj.Name = "txtKucniBroj";
            this.txtKucniBroj.Size = new System.Drawing.Size(41, 20);
            this.txtKucniBroj.TabIndex = 68;
            // 
            // txtGrad
            // 
            this.txtGrad.Location = new System.Drawing.Point(101, 122);
            this.txtGrad.MaxLength = 50;
            this.txtGrad.Name = "txtGrad";
            this.txtGrad.Size = new System.Drawing.Size(143, 20);
            this.txtGrad.TabIndex = 69;
            // 
            // txtUlica
            // 
            this.txtUlica.Location = new System.Drawing.Point(101, 95);
            this.txtUlica.MaxLength = 50;
            this.txtUlica.Name = "txtUlica";
            this.txtUlica.Size = new System.Drawing.Size(174, 20);
            this.txtUlica.TabIndex = 66;
            // 
            // txtTelefon
            // 
            this.txtTelefon.Location = new System.Drawing.Point(102, 148);
            this.txtTelefon.MaxLength = 50;
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.Size = new System.Drawing.Size(142, 20);
            this.txtTelefon.TabIndex = 76;
            // 
            // txtPrezime
            // 
            this.txtPrezime.Location = new System.Drawing.Point(101, 69);
            this.txtPrezime.MaxLength = 50;
            this.txtPrezime.Name = "txtPrezime";
            this.txtPrezime.Size = new System.Drawing.Size(275, 20);
            this.txtPrezime.TabIndex = 64;
            // 
            // txtIme
            // 
            this.txtIme.Location = new System.Drawing.Point(101, 43);
            this.txtIme.MaxLength = 50;
            this.txtIme.Name = "txtIme";
            this.txtIme.Size = new System.Drawing.Size(275, 20);
            this.txtIme.TabIndex = 62;
            // 
            // LBL_GRAD_MJESTO
            // 
            this.LBL_GRAD_MJESTO.AutoSize = true;
            this.LBL_GRAD_MJESTO.Location = new System.Drawing.Point(64, 122);
            this.LBL_GRAD_MJESTO.Name = "LBL_GRAD_MJESTO";
            this.LBL_GRAD_MJESTO.Size = new System.Drawing.Size(30, 13);
            this.LBL_GRAD_MJESTO.TabIndex = 70;
            this.LBL_GRAD_MJESTO.Text = "Grad";
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
            this.TabPage2.Controls.Add(this.chAktivnost);
            this.TabPage2.Controls.Add(this.Label1);
            this.TabPage2.Controls.Add(this.dtpDatumKartice);
            this.TabPage2.Controls.Add(this.LBL_DATUM_UPISA);
            this.TabPage2.Controls.Add(this.LBL_BROJ_UGOVORA);
            this.TabPage2.Controls.Add(this.txtBrojUgovora);
            this.TabPage2.Controls.Add(this.txtBrojKartice);
            this.TabPage2.Controls.Add(this.LBL_BROJ_KARTICE);
            this.TabPage2.Controls.Add(this.dgvKartice);
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
            // dtpDatumKartice
            // 
            this.dtpDatumKartice.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDatumKartice.Location = new System.Drawing.Point(84, 226);
            this.dtpDatumKartice.Name = "dtpDatumKartice";
            this.dtpDatumKartice.Size = new System.Drawing.Size(84, 20);
            this.dtpDatumKartice.TabIndex = 87;
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
            // txtBrojUgovora
            // 
            this.txtBrojUgovora.Location = new System.Drawing.Point(280, 199);
            this.txtBrojUgovora.MaxLength = 255;
            this.txtBrojUgovora.Name = "txtBrojUgovora";
            this.txtBrojUgovora.Size = new System.Drawing.Size(100, 20);
            this.txtBrojUgovora.TabIndex = 85;
            // 
            // txtBrojKartice
            // 
            this.txtBrojKartice.Location = new System.Drawing.Point(84, 199);
            this.txtBrojKartice.MaxLength = 5;
            this.txtBrojKartice.Name = "txtBrojKartice";
            this.txtBrojKartice.Size = new System.Drawing.Size(84, 20);
            this.txtBrojKartice.TabIndex = 82;
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
            // dgvKartice
            // 
            this.dgvKartice.AllowUserToAddRows = false;
            this.dgvKartice.AllowUserToDeleteRows = false;
            this.dgvKartice.AllowUserToResizeColumns = false;
            this.dgvKartice.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKartice.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvKartice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvKartice.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvKartice.Location = new System.Drawing.Point(6, 7);
            this.dgvKartice.MultiSelect = false;
            this.dgvKartice.Name = "dgvKartice";
            this.dgvKartice.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKartice.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvKartice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKartice.Size = new System.Drawing.Size(398, 174);
            this.dgvKartice.TabIndex = 0;
            // 
            // txtImeFilter
            // 
            this.txtImeFilter.Location = new System.Drawing.Point(32, 5);
            this.txtImeFilter.Name = "txtImeFilter";
            this.txtImeFilter.Size = new System.Drawing.Size(164, 20);
            this.txtImeFilter.TabIndex = 41;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 65;
            this.label2.Text = "Ime:";
            // 
            // btnPovratak
            // 
            this.btnPovratak.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPovratak.Image = ((System.Drawing.Image)(resources.GetObject("btnPovratak.Image")));
            this.btnPovratak.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPovratak.Location = new System.Drawing.Point(564, 524);
            this.btnPovratak.Name = "btnPovratak";
            this.btnPovratak.Size = new System.Drawing.Size(104, 26);
            this.btnPovratak.TabIndex = 67;
            this.btnPovratak.Text = "Povratak";
            this.btnPovratak.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(277, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 68;
            this.label3.Text = "Broj korisnika:";
            // 
            // lblBrojKorisnika
            // 
            this.lblBrojKorisnika.AutoSize = true;
            this.lblBrojKorisnika.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblBrojKorisnika.Location = new System.Drawing.Point(348, 9);
            this.lblBrojKorisnika.Name = "lblBrojKorisnika";
            this.lblBrojKorisnika.Size = new System.Drawing.Size(80, 13);
            this.lblBrojKorisnika.TabIndex = 69;
            this.lblBrojKorisnika.Text = "brojKorisnika";
            // 
            // chAktivnost
            // 
            this.chAktivnost.AutoSize = true;
            this.chAktivnost.Location = new System.Drawing.Point(280, 228);
            this.chAktivnost.Name = "chAktivnost";
            this.chAktivnost.Size = new System.Drawing.Size(70, 17);
            this.chAktivnost.TabIndex = 90;
            this.chAktivnost.Text = "Aktivnost";
            this.chAktivnost.UseVisualStyleBackColor = true;
            // 
            // frmUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.lblBrojKorisnika);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnPovratak);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtImeFilter);
            this.Controls.Add(this.GRB_KORISNICI_DNT);
            this.Controls.Add(this.dgvKorisnici);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Korisnici dnevno-noćnog trezora";
            ((System.ComponentModel.ISupportInitialize)(this.dgvKorisnici)).EndInit();
            this.GRB_KORISNICI_DNT.ResumeLayout(false);
            this.TabControl1.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            this.TabPage2.ResumeLayout(false);
            this.TabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKartice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.DataGridView dgvKorisnici;
        internal System.Windows.Forms.GroupBox GRB_KORISNICI_DNT;
        internal System.Windows.Forms.Button btnNovi;
        internal System.Windows.Forms.Button btnObrisi;
        internal System.Windows.Forms.Button btnZapamti;
        internal System.Windows.Forms.TabControl TabControl1;
        internal System.Windows.Forms.TabPage TabPage1;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.Label LBL_KUCNI_BROJ;
        internal System.Windows.Forms.TextBox txtKucniBroj;
        internal System.Windows.Forms.TextBox txtGrad;
        internal System.Windows.Forms.TextBox txtUlica;
        internal System.Windows.Forms.TextBox txtTelefon;
        internal System.Windows.Forms.TextBox txtPrezime;
        internal System.Windows.Forms.TextBox txtIme;
        internal System.Windows.Forms.Label LBL_GRAD_MJESTO;
        internal System.Windows.Forms.Label LBL_TELEFON;
        internal System.Windows.Forms.Label LBL_ADRESA;
        internal System.Windows.Forms.Label LBL_PREZIME;
        internal System.Windows.Forms.Label LBL_IME;
        internal System.Windows.Forms.TabPage TabPage2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.DateTimePicker dtpDatumKartice;
        internal System.Windows.Forms.Label LBL_DATUM_UPISA;
        internal System.Windows.Forms.Label LBL_BROJ_UGOVORA;
        internal System.Windows.Forms.TextBox txtBrojUgovora;
        internal System.Windows.Forms.TextBox txtBrojKartice;
        internal System.Windows.Forms.Label LBL_BROJ_KARTICE;
        internal System.Windows.Forms.DataGridView dgvKartice;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Button btnPovratak;
        internal System.Windows.Forms.TextBox txtImeFilter;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label lblBrojKorisnika;
        public System.Windows.Forms.CheckBox chAktivnost;
    }
}