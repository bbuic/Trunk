using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DNTv2.DataModel;

namespace DNTv2.Report
{
    public partial class frmReportViewer : Form
    {
        public frmReportViewer()
        {
            InitializeComponent();
        }

        public frmReportViewer(IList<TransakcijeModel> models)
        {            
            InitializeComponent();
            
            TransakcijeModelBindingSource.DataSource = models;            
        }

        private void frmReportViewer_Load(object sender, EventArgs e)
        {
            reportViewer1.RefreshReport();            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            reportViewer1.PrintDialog();
        }
    }
}
