using System;
using System.Data.OleDb;
using System.Threading;
using System.Windows.Forms;
using DNTv2.DataModel;
using Timer = System.Windows.Forms.Timer;

namespace DNTv2
{
    public partial class frmMain : Form
    {
        private readonly Timer _timerVrataZasun;
        private readonly Timer _timerVrataOtvorena;
        //private readonly Timer _timerLcd;
        private bool _obradaSerijskogPorta;
        private Transakcija _transakcija;
        
        public frmMain()
        {
            InitializeComponent();
            
            _timerVrataZasun = new Timer {Interval = Properties.Settings.Default.TimerZasun};
            _timerVrataZasun.Tick += delegate
            {
                _timerVrataZasun.Stop();
                SerialPortElektronika.Write(new byte[] {17}, 0, 1); //Zatvori zasun
                //UvodnaPoruka();
            };

            _timerVrataOtvorena = new Timer {Interval = Properties.Settings.Default.TimerVrataOtvorena};
            _timerVrataOtvorena.Tick += delegate
            {
                _timerVrataOtvorena.Stop();

                new frmPoruka("Vrata otvorena").ShowDialog();

                //TODO: upis alarma
                /*'KONEKCIJA.Open()
                'Dim NAREDBA As New System.Data.OleDb.OleDbCommand("INSERT INTO ALARM" & _
                '"(dolazak_OT, otvoreno) Values ('" & VRIJEME_DOLASKA & "','" & Now & "')", KONEKCIJA)
                'Dim recordsAffected As Int32 = NAREDBA.ExecuteNonQuery()
                'KONEKCIJA.Close()*/

                SerialPortElektronika.Write(new byte[] {0x18}, 0, 1);
                //WriteMessage2Lcd("Molimo da zatvorite vrata...");
            };

            if (!SerialPortElektronika. IsOpen)
                SerialPortElektronika.Open();

            //if(Properties.Settings.Default.KoristiLcd && !SerialPortLcd.IsOpen)
            //{
            //    SerialPortLcd.Open();
            //    _timerLcd = new Timer{Interval = Properties.Settings.Default.TimerLcd};
            //    _timerLcd.Tick += delegate
            //    {
            //        short pozicija = 0;
            //        EraseLcd();
            //        VerticalModeLcd();
            //        KursorPozicija(1,1);

            //        SerialPortLcd.Write(new[]{Properties.Settings.Default.PorukaLcd[pozicija]}, 0, 1);
            //        pozicija += 1;

            //        if (pozicija > Properties.Settings.Default.PorukaLcd.Length) pozicija = 1;
            //    };
            //}
            
            SerialPortElektronika.DataReceived += delegate
            {
                if(_obradaSerijskogPorta)
                    return;

                try
                {
                    _obradaSerijskogPorta = true;

                    switch (SerialPortElektronika.ReadByte())
                    {
                        case 20:

                            string kartica = null;
                            byte[] buffer = new byte[3];
                            buffer[1] = (byte)this.SerialPortElektronika.ReadByte();
                            buffer[0] = (byte)this.SerialPortElektronika.ReadByte();
                            kartica = ((BitConverter.ToInt16(buffer, 0)).ToString()).PadLeft(5, '0');

                            if (ObjectFactory.KarticaDataService.ExistsById(kartica))
                            {
                                SerialPortElektronika.Write(new byte[] { 16 }, 0, 1);
                                
                                _transakcija = new Transakcija {Kartica = kartica, DatumOd = DateTime.Now, Trezor = true};
                                ObjectFactory.TransakcijaDataService.Insert(_transakcija);
                                _timerVrataZasun.Start();
                                //WriteMessage2Lcd("   OTORITE VRATA      Ubacujte vrecice");
                            }
                            break;

                        case 21: //vrata otvorena
                            _timerVrataZasun.Stop();
                            _timerVrataOtvorena.Start();
                            //WriteMessage2Lcd("Dozvoljeno ubacivatiUbaceno vrecica = 0");

                            break;
                            
                        case 23: //ubacaj vrecica

                            _transakcija.BrojVrecica += 1;

                            Utils.ResetTimer(_timerVrataOtvorena);

                            //WriteMessage2Lcd("Dozvoljeno ubacivatiUbaceno vrecica = " + _transakcija.BrojVrecica + "");

                            //OleDbCommand komanda = new OleDbCommand("UPDATE DNTTransakcije Set vrecica = ? WHERE dolazak = ?");
                            //komanda.Parameters.Add("@Vrecice", OleDbType.Integer).Value = BROJ_VRECICA;
                            //komanda.Parameters.Add("@Dolazak", OleDbType.Date).Value = VRIJEME_DOLASKA;
                            //UPDATE_NAREDBA(komanda);

                            
                            ////POKAŽI U LABELI BROJ VREČICA
                            //LABELA_VRECICE_TREZOR();

                            break;

                        case 22: //vrata zatorena
                            _timerVrataOtvorena.Stop();

                            _transakcija.DatumDo = DateTime.Now;
                            ObjectFactory.TransakcijaDataService.Update(_transakcija);
                            
                            //WriteMessage2Lcd("HVALA NA POVJERENJU!");
                            //Thread.Sleep(3000);
                            //UvodnaPoruka();
                            
                            _transakcija = null;

                            //FRM_PORUKA_VRATA1.Close();
                            break;

                         case 24: //blokada na fotoceliji

                            //FRM_PORUKA_FOTO1.Show();
                            //WriteMessage2Lcd("TREZOR NE RADI      Dodite kasnije");

                            //TODO: napraviti upis alarma
                            //KONEKCIJA.Open()
                            //Dim NAREDBA As New System.Data.OleDbCommand("INSERT INTO ALARM" & _
                            //"(dolazak_ZA,zapunjeno) Values ('" & VRIJEME_DOLASKA & "','" & Now & "')", KONEKCIJA)
                            //Dim recordsAffected As Int32 = NAREDBA.ExecuteNonQuery()
                            //KONEKCIJA.Close()
                            break;

                        case 27: //maknula se blokada sa fotocelije
                            //FRM_PORUKA_FOTO1.Close();
                            break;
                    }
                }
                finally
                {
                    _obradaSerijskogPorta = false;
                }
            };
        }

        #region LCD

        //private void KursorPozicija(byte stupac, byte red)
        //{
        //    SerialPortLcd.Write(new byte[] {27, 108, stupac, red}, 0, 4);
        //}

        //private void EraseLcd()
        //{
        //    SerialPortLcd.Write(new byte[] {12}, 0, 1);
        //}

        //private void VerticalModeLcd()
        //{
        //    SerialPortLcd.Write(new byte[] {27, 18}, 0, 2);
        //}

        //private void UvodnaPoruka()
        //{
        //    _timerLcd.Start();
        //}

        //private void WriteMessage2Lcd(string poruka)
        //{
        //    _timerLcd.Stop();
        //    EraseLcd();
        //    KursorPozicija(1, 1);
        //    SerialPortLcd.Write(poruka);
        //}

        #endregion

    }
}
