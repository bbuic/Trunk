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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.grbInfo = new System.Windows.Forms.GroupBox();
            this.Label35 = new System.Windows.Forms.Label();
            this.lblDatumPraznjenjaTrezora = new System.Windows.Forms.Label();
            this.lbBrojVrecica = new System.Windows.Forms.Label();
            this.Label14 = new System.Windows.Forms.Label();
            this.grbMainIzbornik = new System.Windows.Forms.GroupBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lblPretragaTransakcija = new System.Windows.Forms.LinkLabel();
            this.PictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblAdministracijaKorisnika = new System.Windows.Forms.LinkLabel();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblPraznjenjeTrezora = new System.Windows.Forms.LinkLabel();
            this.gbPretragaTransakcija = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPovratakIzPretrazivanja = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDatumDo = new System.Windows.Forms.DateTimePicker();
            this.dtpDatumOd = new System.Windows.Forms.DateTimePicker();
            this.btnPretrazi = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.dgvTransakcije = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvDogadaj = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.Panel1.SuspendLayout();
            this.grbInfo.SuspendLayout();
            this.grbMainIzbornik.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.gbPretragaTransakcija.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransakcije)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDogadaj)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Panel1.Controls.Add(this.grbInfo);
            this.Panel1.Controls.Add(this.grbMainIzbornik);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(197, 447);
            this.Panel1.TabIndex = 2;
            // 
            // grbInfo
            // 
            this.grbInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grbInfo.BackColor = System.Drawing.SystemColors.Window;
            this.grbInfo.Controls.Add(this.Label35);
            this.grbInfo.Controls.Add(this.lblDatumPraznjenjaTrezora);
            this.grbInfo.Controls.Add(this.lbBrojVrecica);
            this.grbInfo.Controls.Add(this.Label14);
            this.grbInfo.Location = new System.Drawing.Point(12, 176);
            this.grbInfo.Name = "grbInfo";
            this.grbInfo.Size = new System.Drawing.Size(174, 161);
            this.grbInfo.TabIndex = 2;
            this.grbInfo.TabStop = false;
            // 
            // Label35
            // 
            this.Label35.AutoSize = true;
            this.Label35.Location = new System.Drawing.Point(22, 96);
            this.Label35.Name = "Label35";
            this.Label35.Size = new System.Drawing.Size(126, 13);
            this.Label35.TabIndex = 5;
            this.Label35.Text = "Zadnje pražnjenje trezora";
            // 
            // lblDatumPraznjenjaTrezora
            // 
            this.lblDatumPraznjenjaTrezora.AutoSize = true;
            this.lblDatumPraznjenjaTrezora.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblDatumPraznjenjaTrezora.Location = new System.Drawing.Point(25, 117);
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
            this.lbBrojVrecica.Location = new System.Drawing.Point(59, 39);
            this.lbBrojVrecica.Name = "lbBrojVrecica";
            this.lbBrojVrecica.Size = new System.Drawing.Size(57, 39);
            this.lbBrojVrecica.TabIndex = 1;
            this.lbBrojVrecica.Text = "00";
            // 
            // Label14
            // 
            this.Label14.Location = new System.Drawing.Point(34, 16);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(107, 13);
            this.Label14.TabIndex = 0;
            this.Label14.Text = "Broj pologa u trezoru";
            // 
            // grbMainIzbornik
            // 
            this.grbMainIzbornik.BackColor = System.Drawing.SystemColors.Window;
            this.grbMainIzbornik.Controls.Add(this.pictureBox4);
            this.grbMainIzbornik.Controls.Add(this.linkLabel1);
            this.grbMainIzbornik.Controls.Add(this.pictureBox3);
            this.grbMainIzbornik.Controls.Add(this.lblPretragaTransakcija);
            this.grbMainIzbornik.Controls.Add(this.PictureBox2);
            this.grbMainIzbornik.Controls.Add(this.lblAdministracijaKorisnika);
            this.grbMainIzbornik.Controls.Add(this.PictureBox1);
            this.grbMainIzbornik.Controls.Add(this.lblPraznjenjeTrezora);
            this.grbMainIzbornik.Location = new System.Drawing.Point(12, 18);
            this.grbMainIzbornik.Name = "grbMainIzbornik";
            this.grbMainIzbornik.Size = new System.Drawing.Size(174, 142);
            this.grbMainIzbornik.TabIndex = 0;
            this.grbMainIzbornik.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DNTv2.Properties.Resources.Button_Refresh_icon1;
            this.pictureBox4.Location = new System.Drawing.Point(5, 107);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(27, 26);
            this.pictureBox4.TabIndex = 8;
            this.pictureBox4.TabStop = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.linkLabel1.Location = new System.Drawing.Point(37, 113);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(85, 15);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Učitaj podatke";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DNTv2.Properties.Resources.User_Group_icon;
            this.pictureBox3.Location = new System.Drawing.Point(4, 76);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(27, 26);
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // lblPretragaTransakcija
            // 
            this.lblPretragaTransakcija.AutoSize = true;
            this.lblPretragaTransakcija.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblPretragaTransakcija.Location = new System.Drawing.Point(38, 51);
            this.lblPretragaTransakcija.Name = "lblPretragaTransakcija";
            this.lblPretragaTransakcija.Size = new System.Drawing.Size(116, 15);
            this.lblPretragaTransakcija.TabIndex = 5;
            this.lblPretragaTransakcija.TabStop = true;
            this.lblPretragaTransakcija.Text = "Pretraga transakcija";
            // 
            // PictureBox2
            // 
            this.PictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox2.Image")));
            this.PictureBox2.Location = new System.Drawing.Point(6, 46);
            this.PictureBox2.Name = "PictureBox2";
            this.PictureBox2.Size = new System.Drawing.Size(26, 26);
            this.PictureBox2.TabIndex = 4;
            this.PictureBox2.TabStop = false;
            // 
            // lblAdministracijaKorisnika
            // 
            this.lblAdministracijaKorisnika.AutoSize = true;
            this.lblAdministracijaKorisnika.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblAdministracijaKorisnika.Location = new System.Drawing.Point(37, 82);
            this.lblAdministracijaKorisnika.Name = "lblAdministracijaKorisnika";
            this.lblAdministracijaKorisnika.Size = new System.Drawing.Size(136, 15);
            this.lblAdministracijaKorisnika.TabIndex = 2;
            this.lblAdministracijaKorisnika.TabStop = true;
            this.lblAdministracijaKorisnika.Text = "Administracija korisnika\r\n";
            // 
            // PictureBox1
            // 
            this.PictureBox1.Image = global::DNTv2.Properties.Resources.Safe_icon;
            this.PictureBox1.Location = new System.Drawing.Point(6, 16);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(27, 26);
            this.PictureBox1.TabIndex = 3;
            this.PictureBox1.TabStop = false;
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
            this.gbPretragaTransakcija.Controls.Add(this.label2);
            this.gbPretragaTransakcija.Controls.Add(this.btnPovratakIzPretrazivanja);
            this.gbPretragaTransakcija.Controls.Add(this.label1);
            this.gbPretragaTransakcija.Controls.Add(this.dtpDatumDo);
            this.gbPretragaTransakcija.Controls.Add(this.dtpDatumOd);
            this.gbPretragaTransakcija.Controls.Add(this.btnPretrazi);
            this.gbPretragaTransakcija.Controls.Add(this.btnPrint);
            this.gbPretragaTransakcija.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbPretragaTransakcija.Location = new System.Drawing.Point(0, 236);
            this.gbPretragaTransakcija.Name = "gbPretragaTransakcija";
            this.gbPretragaTransakcija.Size = new System.Drawing.Size(636, 83);
            this.gbPretragaTransakcija.TabIndex = 37;
            this.gbPretragaTransakcija.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(181, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 50;
            this.label2.Text = "do";
            // 
            // btnPovratakIzPretrazivanja
            // 
            this.btnPovratakIzPretrazivanja.Image = ((System.Drawing.Image)(resources.GetObject("btnPovratakIzPretrazivanja.Image")));
            this.btnPovratakIzPretrazivanja.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPovratakIzPretrazivanja.Location = new System.Drawing.Point(472, 18);
            this.btnPovratakIzPretrazivanja.Name = "btnPovratakIzPretrazivanja";
            this.btnPovratakIzPretrazivanja.Size = new System.Drawing.Size(104, 26);
            this.btnPovratakIzPretrazivanja.TabIndex = 49;
            this.btnPovratakIzPretrazivanja.Text = "Povratak";
            this.btnPovratakIzPretrazivanja.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 46;
            this.label1.Text = "Od";
            // 
            // dtpDatumDo
            // 
            this.dtpDatumDo.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            this.dtpDatumDo.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dtpDatumDo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDatumDo.Location = new System.Drawing.Point(203, 20);
            this.dtpDatumDo.Name = "dtpDatumDo";
            this.dtpDatumDo.ShowUpDown = true;
            this.dtpDatumDo.Size = new System.Drawing.Size(142, 23);
            this.dtpDatumDo.TabIndex = 28;
            // 
            // dtpDatumOd
            // 
            this.dtpDatumOd.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            this.dtpDatumOd.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dtpDatumOd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDatumOd.Location = new System.Drawing.Point(35, 20);
            this.dtpDatumOd.Name = "dtpDatumOd";
            this.dtpDatumOd.ShowUpDown = true;
            this.dtpDatumOd.Size = new System.Drawing.Size(141, 23);
            this.dtpDatumOd.TabIndex = 27;
            // 
            // btnPretrazi
            // 
            this.btnPretrazi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPretrazi.Location = new System.Drawing.Point(362, 18);
            this.btnPretrazi.Name = "btnPretrazi";
            this.btnPretrazi.Size = new System.Drawing.Size(104, 26);
            this.btnPretrazi.TabIndex = 39;
            this.btnPretrazi.Text = "Traži";
            this.btnPretrazi.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(362, 47);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(104, 26);
            this.btnPrint.TabIndex = 43;
            this.btnPrint.Text = "Ispiši";
            this.btnPrint.UseVisualStyleBackColor = false;
            // 
            // dgvTransakcije
            // 
            this.dgvTransakcije.AllowUserToAddRows = false;
            this.dgvTransakcije.AllowUserToDeleteRows = false;
            this.dgvTransakcije.AllowUserToResizeRows = false;
            this.dgvTransakcije.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransakcije.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvTransakcije.Location = new System.Drawing.Point(0, 0);
            this.dgvTransakcije.Name = "dgvTransakcije";
            this.dgvTransakcije.ReadOnly = true;
            this.dgvTransakcije.Size = new System.Drawing.Size(636, 217);
            this.dgvTransakcije.TabIndex = 38;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.dgvTransakcije);
            this.panel2.Controls.Add(this.gbPretragaTransakcija);
            this.panel2.Location = new System.Drawing.Point(197, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(636, 319);
            this.panel2.TabIndex = 38;
            // 
            // dgvDogadaj
            // 
            this.dgvDogadaj.AllowUserToAddRows = false;
            this.dgvDogadaj.AllowUserToDeleteRows = false;
            this.dgvDogadaj.AllowUserToResizeRows = false;
            this.dgvDogadaj.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDogadaj.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvDogadaj.Location = new System.Drawing.Point(0, 23);
            this.dgvDogadaj.Name = "dgvDogadaj";
            this.dgvDogadaj.ReadOnly = true;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent;
            this.dgvDogadaj.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDogadaj.Size = new System.Drawing.Size(636, 99);
            this.dgvDogadaj.TabIndex = 39;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.dgvDogadaj);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(197, 325);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(636, 122);
            this.panel3.TabIndex = 39;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 40;
            this.label3.Text = "Događaji uređaja";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 447);
            this.ControlBox = false;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.Panel1);
            this.Name = "frmMain";
            this.Text = "   DNEVNO-NOĆNI TREZOR";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Panel1.ResumeLayout(false);
            this.grbInfo.ResumeLayout(false);
            this.grbInfo.PerformLayout();
            this.grbMainIzbornik.ResumeLayout(false);
            this.grbMainIzbornik.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.gbPretragaTransakcija.ResumeLayout(false);
            this.gbPretragaTransakcija.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransakcije)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDogadaj)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.LinkLabel lblAdministracijaKorisnika;
        internal System.Windows.Forms.GroupBox grbInfo;
        internal System.Windows.Forms.Label Label35;
        internal System.Windows.Forms.Label lblDatumPraznjenjaTrezora;
        internal System.Windows.Forms.Label lbBrojVrecica;
        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.GroupBox grbMainIzbornik;
        internal System.Windows.Forms.PictureBox PictureBox2;
        internal System.Windows.Forms.PictureBox PictureBox1;
        internal System.Windows.Forms.LinkLabel lblPraznjenjeTrezora;
        internal System.Windows.Forms.GroupBox gbPretragaTransakcija;
        internal System.Windows.Forms.Button btnPretrazi;
        internal System.Windows.Forms.Button btnPrint;
        internal System.Windows.Forms.DateTimePicker dtpDatumDo;
        internal System.Windows.Forms.DateTimePicker dtpDatumOd;
        internal System.Windows.Forms.DataGridView dgvTransakcije;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.LinkLabel lblPretragaTransakcija;
        internal System.Windows.Forms.PictureBox pictureBox3;
        internal System.Windows.Forms.Button btnPovratakIzPretrazivanja;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.DataGridView dgvDogadaj;
        internal System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.PictureBox pictureBox4;
        internal System.Windows.Forms.LinkLabel linkLabel1;
    }
}

