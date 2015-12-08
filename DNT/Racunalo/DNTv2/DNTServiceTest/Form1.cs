using System;
using System.Windows.Forms;
using DNTServiceProcessor;

namespace DNTServiceTest
{
    public partial class Form1 : Form
    {
        private Processor _processor;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _processor = new Processor();
            _processor.Start();
            MessageBox.Show("Servis pokrenut");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _processor.Stop();
            MessageBox.Show("Servis zaustavljen");
        }
    }
}
