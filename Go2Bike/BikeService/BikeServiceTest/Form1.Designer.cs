namespace BikeServiceTest
{
    partial class Form1
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
            this.dgvReciveCommands = new System.Windows.Forms.DataGridView();
            this.dgvDokinzi = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvSendCommands = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnSendHello = new System.Windows.Forms.Button();
            this.dgvEvents = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBikeTag = new System.Windows.Forms.Button();
            this.btnRfidKartica = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRefresh = new System.Windows.Forms.Label();
            this.Dogadaji = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReciveCommands)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDokinzi)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSendCommands)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvents)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.Dogadaji.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvReciveCommands
            // 
            this.dgvReciveCommands.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReciveCommands.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReciveCommands.Location = new System.Drawing.Point(3, 16);
            this.dgvReciveCommands.Name = "dgvReciveCommands";
            this.dgvReciveCommands.Size = new System.Drawing.Size(273, 220);
            this.dgvReciveCommands.TabIndex = 1;
            // 
            // dgvDokinzi
            // 
            this.dgvDokinzi.AllowUserToAddRows = false;
            this.dgvDokinzi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDokinzi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDokinzi.Location = new System.Drawing.Point(3, 16);
            this.dgvDokinzi.Name = "dgvDokinzi";
            this.dgvDokinzi.Size = new System.Drawing.Size(700, 120);
            this.dgvDokinzi.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.dgvReciveCommands);
            this.groupBox1.Location = new System.Drawing.Point(280, 171);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(279, 239);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Recive commands";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.dgvSendCommands);
            this.groupBox2.Location = new System.Drawing.Point(15, 171);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(259, 239);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Send commands";
            // 
            // dgvSendCommands
            // 
            this.dgvSendCommands.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSendCommands.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSendCommands.Location = new System.Drawing.Point(3, 16);
            this.dgvSendCommands.Name = "dgvSendCommands";
            this.dgvSendCommands.Size = new System.Drawing.Size(253, 220);
            this.dgvSendCommands.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dgvDokinzi);
            this.groupBox3.Location = new System.Drawing.Point(12, 26);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(706, 139);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Dockings";
            // 
            // btnSendHello
            // 
            this.btnSendHello.Location = new System.Drawing.Point(6, 47);
            this.btnSendHello.Name = "btnSendHello";
            this.btnSendHello.Size = new System.Drawing.Size(128, 23);
            this.btnSendHello.TabIndex = 6;
            this.btnSendHello.Text = "Hello";
            this.btnSendHello.UseVisualStyleBackColor = true;
            this.btnSendHello.Click += new System.EventHandler(this.btnHello_Click);
            // 
            // dgvEvents
            // 
            this.dgvEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEvents.Location = new System.Drawing.Point(3, 16);
            this.dgvEvents.Name = "dgvEvents";
            this.dgvEvents.Size = new System.Drawing.Size(273, 386);
            this.dgvEvents.TabIndex = 7;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox4.Controls.Add(this.numericUpDown1);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.btnBikeTag);
            this.groupBox4.Controls.Add(this.btnRfidKartica);
            this.groupBox4.Controls.Add(this.btnSendHello);
            this.groupBox4.Location = new System.Drawing.Point(15, 416);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(140, 163);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Doking -> pilon";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(62, 20);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(72, 20);
            this.numericUpDown1.TabIndex = 15;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Dock ID:";
            // 
            // btnBikeTag
            // 
            this.btnBikeTag.Location = new System.Drawing.Point(6, 105);
            this.btnBikeTag.Name = "btnBikeTag";
            this.btnBikeTag.Size = new System.Drawing.Size(128, 23);
            this.btnBikeTag.TabIndex = 8;
            this.btnBikeTag.Text = "BIKE Tag";
            this.btnBikeTag.UseVisualStyleBackColor = true;
            this.btnBikeTag.Click += new System.EventHandler(this.btnBikeTag_Click);
            // 
            // btnRfidKartica
            // 
            this.btnRfidKartica.Location = new System.Drawing.Point(6, 76);
            this.btnRfidKartica.Name = "btnRfidKartica";
            this.btnRfidKartica.Size = new System.Drawing.Size(128, 23);
            this.btnRfidKartica.TabIndex = 7;
            this.btnRfidKartica.Text = "RFID kartica";
            this.btnRfidKartica.UseVisualStyleBackColor = true;
            this.btnRfidKartica.Click += new System.EventHandler(this.btnRfidKartica_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Datum zadnjeg refresha:";
            // 
            // lblRefresh
            // 
            this.lblRefresh.AutoSize = true;
            this.lblRefresh.Location = new System.Drawing.Point(140, 9);
            this.lblRefresh.Name = "lblRefresh";
            this.lblRefresh.Size = new System.Drawing.Size(35, 13);
            this.lblRefresh.TabIndex = 12;
            this.lblRefresh.Text = "label2";
            // 
            // Dogadaji
            // 
            this.Dogadaji.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Dogadaji.Controls.Add(this.dgvEvents);
            this.Dogadaji.Location = new System.Drawing.Point(565, 171);
            this.Dogadaji.Name = "Dogadaji";
            this.Dogadaji.Size = new System.Drawing.Size(279, 405);
            this.Dogadaji.TabIndex = 13;
            this.Dogadaji.TabStop = false;
            this.Dogadaji.Text = "Events";
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.button3);
            this.groupBox6.Controls.Add(this.btnReset);
            this.groupBox6.Controls.Add(this.button2);
            this.groupBox6.Controls.Add(this.button1);
            this.groupBox6.Location = new System.Drawing.Point(724, 26);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(120, 139);
            this.groupBox6.TabIndex = 14;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Server -> pilon";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 105);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(106, 23);
            this.button3.TabIndex = 15;
            this.button3.Text = "Reset all";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.ServerPilonHandler);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(6, 79);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(106, 23);
            this.btnReset.TabIndex = 10;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.ServerPilonHandler);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(5, 50);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Block";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.ServerPilonHandler);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(5, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Unlock";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ServerPilonHandler);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 591);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.Dogadaji);
            this.Controls.Add(this.lblRefresh);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvReciveCommands)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDokinzi)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSendCommands)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvents)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.Dogadaji.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvReciveCommands;
        private System.Windows.Forms.DataGridView dgvDokinzi;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvSendCommands;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnSendHello;
        private System.Windows.Forms.DataGridView dgvEvents;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRefresh;
        private System.Windows.Forms.Button btnBikeTag;
        private System.Windows.Forms.Button btnRfidKartica;
        private System.Windows.Forms.GroupBox Dogadaji;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}

