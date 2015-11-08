using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DNTv2
{
    public partial class frmPoruka : Form
    {
        public frmPoruka()
        {
            InitializeComponent();
        }

        public frmPoruka(string poruka)
        {
            InitializeComponent();
            label1.Text = poruka;
        }

        private void btnPovratakIzPretrazivanja_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
