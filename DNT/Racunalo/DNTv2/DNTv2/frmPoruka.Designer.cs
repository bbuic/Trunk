namespace DNTv2
{
    partial class frmPoruka
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPoruka));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnPovratakIzPretrazivanja = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(54, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DNTv2.Properties.Resources.Folders_OS_Info_Metro_icon;
            this.pictureBox1.Location = new System.Drawing.Point(15, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(33, 35);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btnPovratakIzPretrazivanja
            // 
            this.btnPovratakIzPretrazivanja.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPovratakIzPretrazivanja.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnPovratakIzPretrazivanja.Image = ((System.Drawing.Image)(resources.GetObject("btnPovratakIzPretrazivanja.Image")));
            this.btnPovratakIzPretrazivanja.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPovratakIzPretrazivanja.Location = new System.Drawing.Point(248, 58);
            this.btnPovratakIzPretrazivanja.Name = "btnPovratakIzPretrazivanja";
            this.btnPovratakIzPretrazivanja.Size = new System.Drawing.Size(67, 26);
            this.btnPovratakIzPretrazivanja.TabIndex = 50;
            this.btnPovratakIzPretrazivanja.Text = "Zatvori";
            this.btnPovratakIzPretrazivanja.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPovratakIzPretrazivanja.UseVisualStyleBackColor = true;
            this.btnPovratakIzPretrazivanja.Click += new System.EventHandler(this.btnPovratakIzPretrazivanja_Click);
            // 
            // frmPoruka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 88);
            this.Controls.Add(this.btnPovratakIzPretrazivanja);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmPoruka";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Poruka";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        internal System.Windows.Forms.Button btnPovratakIzPretrazivanja;
    }
}