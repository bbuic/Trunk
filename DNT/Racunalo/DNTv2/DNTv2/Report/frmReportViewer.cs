using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DNTv2.Report
{
    public partial class frmReportViewer : Form
    {
        public frmReportViewer()
        {
            InitializeComponent();
        }

        private void frmReportViewer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DNTbazaDataSet.DNTTransakcije' table. You can move, or remove it, as needed.
            this.DNTTransakcijeTableAdapter.Fill(this.DNTbazaDataSet.DNTTransakcije);

            this.reportViewer1.RefreshReport();
        }
    }
}
