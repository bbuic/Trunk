using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BikeServiceTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            uint ID = 0x41F;

            string binary = Convert.ToString(ID, 2);

            binary = binary.Remove(0, 1);  //Remove the exact bit, 3rd in this case
            string newValue = Convert.ToInt32(binary, 2).ToString("X");
        }
    }
}
