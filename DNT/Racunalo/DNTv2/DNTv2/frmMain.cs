using System;
using System.Threading;
using System.Windows.Forms;
using DNTv2.DataModel;
using DNTv2.DataModel.Services;
using DNTv2.Properties;
using Timer = System.Threading.Timer;

namespace DNTv2
{
    public partial class frmMain : Form
    {
        private Timer _timerVrataZasun;
        private Timer _timerVrataOtvorena;
        //private readonly Timer _timerLcd;
        private bool _obradaSerijskogPortaUTijeku;
        private Transakcija _transakcija;
        internal bool TransakcijaUTijeku { get; set; }
        internal TransakcijeModelService TransakcijeModelService { get; set; }
        private frmPoruka _frmPorukaVrata;
        private frmPoruka _frmPorukaFoto;

        #region Timer zasun

        private void ZatvoriZasun()
        {
            TimerZasunStop();
            TransakcijaUTijeku = false;
            _transakcija = null;
            SerialPortElektronika.Write(new byte[] {0x11}, 0, 1);
            //UvodnaPoruka();
        }

        private void TimerZasunStart()
        {
            _timerVrataZasun = new Timer(_ => ZatvoriZasun());
            _timerVrataZasun.Change(Settings.Default.TimerZasun * 1000, Timeout.Infinite);
        }

        private void TimerZasunStop()
        {
            if (_timerVrataZasun != null)
            {
                _timerVrataZasun.Change(Timeout.Infinite, Timeout.Infinite);
                _timerVrataZasun.Dispose();
                _timerVrataZasun = null;
            }
        }

        #endregion

        #region Timer vrata

        private void TimerVrataOtvorenaReStart()
        {
            if (_timerVrataOtvorena != null)
                _timerVrataOtvorena.Change(Settings.Default.TimerVrataOtvorena*1000, Timeout.Infinite);
            else
                TimerVrataOtvorenaStart();
        }

        private void TimerVrataOtvorenaStart()
        {
            if (_timerVrataOtvorena == null)
            {
                _timerVrataOtvorena = new Timer(_ => ZatvoriVrata());
                _timerVrataOtvorena.Change(Settings.Default.TimerVrataOtvorena*1000, Timeout.Infinite);
            }else
                TimerVrataOtvorenaReStart();
        }

        private void TimerVrataOtvorenaStop()
        {
            if (_timerVrataOtvorena != null)
            {
                _timerVrataOtvorena.Change(Timeout.Infinite, Timeout.Infinite);
                _timerVrataOtvorena.Dispose();
                _timerVrataOtvorena = null;
            }
        }

        private void ZatvoriVrata()
        {
            TimerVrataOtvorenaStop();

            SerialPortElektronika.Write(new byte[] { 0x12 }, 0, 1);
            //WriteMessage2Lcd("Molimo da zatvorite vrata...");            

            //TODO: upis alarma u bazu

            _frmPorukaVrata = 
                new frmPoruka("Vanjska vrata trezora su otvorena duže od " + Settings.Default.TimerVrataOtvorena + " sec.");
            Invoke(new MethodInvoker(delegate { _frmPorukaVrata.Show(this); }));                        
        }

        #endregion


        public frmMain()
        {
            InitializeComponent();

            if (!SerialPortElektronika. IsOpen)
                SerialPortElektronika.Open();

            #region LCD

            //if (Properties.Settings.Default.KoristiLcd && !SerialPortLcd.IsOpen)
            //{
            //    SerialPortLcd.Open();
            //    _timerLcd = new Timer { Interval = Properties.Settings.Default.TimerLcd };
            //    _timerLcd.Tick += delegate
            //    {
            //        short pozicija = 0;
            //        EraseLcd();
            //        VerticalModeLcd();
            //        KursorPozicija(1, 1);

            //        SerialPortLcd.Write(new[] { Properties.Settings.Default.PorukaLcd[pozicija] }, 0, 1);
            //        pozicija += 1;

            //        if (pozicija > Properties.Settings.Default.PorukaLcd.Length) pozicija = 1;
            //    };
            //}

            #endregion
            
            //HENDLANJE PORUKA ELEKTRONIKE
            SerialPortElektronika.DataReceived += delegate
            {
                if(_obradaSerijskogPortaUTijeku)
                    return;
                try
                {
                    _obradaSerijskogPortaUTijeku = true;

                    switch (SerialPortElektronika.ReadByte())
                    {
                        case 0x20:

                            if(SerialPortElektronika.BytesToRead < 2 || TransakcijaUTijeku)
                                break;

                            byte[] buffer = new byte[2];
                            buffer[1] = (byte)this.SerialPortElektronika.ReadByte();
                            buffer[0] = (byte)this.SerialPortElektronika.ReadByte();
                            var kartica = ((BitConverter.ToInt16(buffer, 0)).ToString()).PadLeft(5, '0');

                            if (ObjectFactory.KarticaDataService.PostojiBrojKartice(kartica))
                            {
                                SerialPortElektronika.Write(new byte[] { 0x10 }, 0, 1);
                                
                                _transakcija = new Transakcija {Kartica = kartica, DatumOd = DateTime.Now, Trezor = true};
                                ObjectFactory.TransakcijaDataService.UnesiTransakciju(_transakcija);

                                TimerZasunStart();
                                TransakcijaUTijeku = true;
                                //WriteMessage2Lcd("   OTORITE VRATA      Ubacujte vrecice");
                            }
                            break;

                        case 0x21: //vrata otvorena
                            TimerZasunStop();
                            TimerVrataOtvorenaStart();
                            //WriteMessage2Lcd("Dozvoljeno ubacivatiUbaceno vrecica = 0");
                            break;                            
                        case 0x23: //ubacaj vrecica

                            if(!TransakcijaUTijeku)
                                break;
                            
                            TimerVrataOtvorenaReStart();

                            //WriteMessage2Lcd("Dozvoljeno ubacivatiUbaceno vrecica = " + _transakcija.vrecica + "");

                            _transakcija.BrojVrecica += 1;
                            ObjectFactory.TransakcijaDataService.PromjeniTransakciju(_transakcija);

                            if (_frmPorukaVrata != null)
                                Invoke(new MethodInvoker(delegate { _frmPorukaVrata.Close(); _frmPorukaVrata.Dispose(); _frmPorukaVrata = null; }));
                            break;

                        case 0x22: //vrata zatorena

                            TimerVrataOtvorenaStop();

                            TransakcijaUTijeku = false;

                            _transakcija.DatumDo = DateTime.Now;
                            ObjectFactory.TransakcijaDataService.PromjeniTransakciju(_transakcija);
                            _transakcija = null;

                            //WriteMessage2Lcd("HVALA NA POVJERENJU!");
                            //Thread.Sleep(3000);
                            //UvodnaPoruka();

                            if (_frmPorukaVrata != null)
                                Invoke(new MethodInvoker(delegate { _frmPorukaVrata.Close(); _frmPorukaVrata.Dispose(); _frmPorukaVrata = null; }));
                            break;

                         case 0x24: //blokada na fotoceliji

                            _frmPorukaFoto = 
                                new frmPoruka("Blokada fotosenzora.");
                            Invoke(new MethodInvoker(delegate { _frmPorukaFoto.Show(this); })); 

                            //WriteMessage2Lcd("TREZOR NE RADI      Dodite kasnije");

                            //TODO: napraviti upis alarma
                            break;

                        case 0x27: //maknula se blokada sa fotocelije
                            if (_frmPorukaFoto != null)
                                Invoke(new MethodInvoker(delegate { _frmPorukaFoto.Close(); _frmPorukaFoto.Dispose(); _frmPorukaFoto = null; }));
                            break;
                    }
                }
                finally
                {
                    if (SerialPortElektronika.BytesToRead > 0)
                        SerialPortElektronika.DiscardInBuffer();

                    this.Invoke(new MethodInvoker(delegate { TransakcijeModelService.Refresh(); }));
                
                    _obradaSerijskogPortaUTijeku = false;
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
