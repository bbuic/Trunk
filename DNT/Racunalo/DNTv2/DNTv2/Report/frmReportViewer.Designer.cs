namespace DNTv2.Report
{
    partial class frmReportViewer
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DNTbazaDataSet = new DNTv2.Report.DNTbazaDataSet();
            this.DNTTransakcijeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DNTTransakcijeTableAdapter = new DNTv2.Report.DNTbazaDataSetTableAdapters.DNTTransakcijeTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DNTbazaDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DNTTransakcijeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Transakcije";
            reportDataSource1.Value = this.DNTTransakcijeBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "DNTv2.Report.Transakcije.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(284, 262);
            this.reportViewer1.TabIndex = 0;
            // 
            // DNTbazaDataSet
            // 
            this.DNTbazaDataSet.DataSetName = "DNTbazaDataSet";
            this.DNTbazaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DNTTransakcijeBindingSource
            // 
            this.DNTTransakcijeBindingSource.DataMember = "DNTTransakcije";
            this.DNTTransakcijeBindingSource.DataSource = this.DNTbazaDataSet;
            // 
            // DNTTransakcijeTableAdapter
            // 
            this.DNTTransakcijeTableAdapter.ClearBeforeFill = true;
            // 
            // frmReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmReportViewer";
            this.Text = "frmReportViewer";
            this.Load += new System.EventHandler(this.frmReportViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DNTbazaDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DNTTransakcijeBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource DNTTransakcijeBindingSource;
        private DNTbazaDataSet DNTbazaDataSet;
        private DNTbazaDataSetTableAdapters.DNTTransakcijeTableAdapter DNTTransakcijeTableAdapter;
    }
}