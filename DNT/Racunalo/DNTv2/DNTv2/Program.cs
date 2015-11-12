using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DNTv2.DataModel.Converters;
using DNTv2.DataModel.Services;

namespace DNTv2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new TransakcijaModel2Gui().Convert2Form());
                //Application.Run(new KorisnikModel2Gui().Convert2Form());
            }
            catch (Exception e)
            {
                Utils.Log(e);

                MessageBox.Show(@"Došlo je do nepredviđene greške, kontaktirajte adminitratora. " +
                    @"Vrijeme greške: " + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") +
                    @", Opis greške: " + e.Message, 
                    "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
