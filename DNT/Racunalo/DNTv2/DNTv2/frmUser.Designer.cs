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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.GRB_KORISNICI_DNT = new System.Windows.Forms.GroupBox();
            this.btnPovratak = new System.Windows.Forms.Button();
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
            this.txtPrezimeFilter = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.GRB_KORISNICI_DNT.SuspendLayout();
            this.TabControl1.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.TabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKartice)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 31);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(618, 122);
            this.dataGridView1.TabIndex = 39;
            // 
            // GRB_KORISNICI_DNT
            // 
            this.GRB_KORISNICI_DNT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.GRB_KORISNICI_DNT.Controls.Add(this.btnPovratak);
            this.GRB_KORISNICI_DNT.Controls.Add(this.btnNovi);
            this.GRB_KORISNICI_DNT.Controls.Add(this.btnObrisi);
            this.GRB_KORISNICI_DNT.Controls.Add(this.btnZapamti);
            this.GRB_KORISNICI_DNT.Controls.Add(this.TabControl1);
            this.GRB_KORISNICI_DNT.Location = new System.Drawing.Point(12, 177);
            this.GRB_KORISNICI_DNT.Name = "GRB_KORISNICI_DNT";
            this.GRB_KORISNICI_DNT.Size = new System.Drawing.Size(574, 307);
            this.GRB_KORISNICI_DNT.TabIndex = 40;
            this.GRB_KORISNICI_DNT.TabStop = false;
            this.GRB_KORISNICI_DNT.Text = "Korinici dnevno-noćnog trezora";
            // 
            // btnPovratak
            // 
            this.btnPovratak.Location = new System.Drawing.Point(462, 261);
            this.btnPovratak.Name = "btnPovratak";
            this.btnPovratak.Size = new System.Drawing.Size(78, 23);
            this.btnPovratak.TabIndex = 64;
            this.btnPovratak.Text = "Povratak";
            this.btnPovratak.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPovratak.UseVisualStyleBackColor = true;
            // 
            // btnNovi
            // 
            this.btnNovi.Location = new System.Drawing.Point(462, 172);
            this.btnNovi.Name = "btnNovi";
            this.btnNovi.Size = new System.Drawing.Size(78, 23);
            this.btnNovi.TabIndex = 63;
            this.btnNovi.Text = "Novi";
            this.btnNovi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNovi.UseVisualStyleBackColor = true;
            // 
            // btnObrisi
            // 
            this.btnObrisi.BackColor = System.Drawing.Color.White;
            this.btnObrisi.Location = new System.Drawing.Point(462, 203);
            this.btnObrisi.Name = "btnObrisi";
            this.btnObrisi.Size = new System.Drawing.Size(78, 23);
            this.btnObrisi.TabIndex = 62;
            this.btnObrisi.Text = "Obriši";
            this.btnObrisi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnObrisi.UseVisualStyleBackColor = false;
            // 
            // btnZapamti
            // 
            this.btnZapamti.Location = new System.Drawing.Point(462, 232);
            this.btnZapamti.Name = "btnZapamti";
            this.btnZapamti.Size = new System.Drawing.Size(78, 23);
            this.btnZapamti.TabIndex = 40;
            this.btnZapamti.Text = "Zapamti";
            this.btnZapamti.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            // txtKucniBroj
            // 
            this.txtKucniBroj.Location = new System.Drawing.Point(281, 95);
            this.txtKucniBroj.Name = "txtKucniBroj";
            this.txtKucniBroj.Size = new System.Drawing.Size(41, 20);
            this.txtKucniBroj.TabIndex = 68;
            // 
            // txtGrad
            // 
            this.txtGrad.Location = new System.Drawing.Point(101, 122);
            this.txtGrad.Name = "txtGrad";
            this.txtGrad.Size = new System.Drawing.Size(143, 20);
            this.txtGrad.TabIndex = 69;
            // 
            // txtUlica
            // 
            this.txtUlica.Location = new System.Drawing.Point(101, 95);
            this.txtUlica.Name = "txtUlica";
            this.txtUlica.Size = new System.Drawing.Size(174, 20);
            this.txtUlica.TabIndex = 66;
            // 
            // txtTelefon
            // 
            this.txtTelefon.Location = new System.Drawing.Point(102, 148);
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.Size = new System.Drawing.Size(142, 20);
            this.txtTelefon.TabIndex = 76;
            // 
            // txtPrezime
            // 
            this.txtPrezime.Location = new System.Drawing.Point(101, 69);
            this.txtPrezime.Name = "txtPrezime";
            this.txtPrezime.Size = new System.Drawing.Size(275, 20);
            this.txtPrezime.TabIndex = 64;
            // 
            // txtIme
            // 
            this.txtIme.Location = new System.Drawing.Point(101, 43);
            this.txtIme.Name = "txtIme";
            this.txtIme.Size = new System.Drawing.Size(275, 20);
            this.txtIme.TabIndex = 62;
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKartice.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvKartice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvKartice.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvKartice.Location = new System.Drawing.Point(6, 7);
            this.dgvKartice.Name = "dgvKartice";
            this.dgvKartice.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKartice.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvKartice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKartice.Size = new System.Drawing.Size(398, 174);
            this.dgvKartice.TabIndex = 0;
            // 
            // txtImeFilter
            // 
            this.txtImeFilter.Location = new System.Drawing.Point(33, 5);
            this.txtImeFilter.Name = "txtImeFilter";
            this.txtImeFilter.Size = new System.Drawing.Size(113, 20);
            this.txtImeFilter.TabIndex = 41;
            // 
            // txtPrezimeFilter
            // 
            this.txtPrezimeFilter.Location = new System.Drawing.Point(193, 5);
            this.txtPrezimeFilter.Name = "txtPrezimeFilter";
            this.txtPrezimeFilter.Size = new System.Drawing.Size(113, 20);
            this.txtPrezimeFilter.TabIndex = 42;
            // 
            // frmUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 517);
            this.ControlBox = false;
            this.Controls.Add(this.txtPrezimeFilter);
            this.Controls.Add(this.txtImeFilter);
            this.Controls.Add(this.GRB_KORISNICI_DNT);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmUser";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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

        internal System.Windows.Forms.DataGridView dataGridView1;
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
        internal System.Windows.Forms.Button btnPovratak;
        private System.Windows.Forms.TextBox txtImeFilter;
        private System.Windows.Forms.TextBox txtPrezimeFilter;
    }
}