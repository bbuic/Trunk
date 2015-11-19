using System;
using System.Data.OleDb;
using System.IO;
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
        private Timer _timerBackUp;        
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

            if (_frmPorukaVrata == null)
            {
                _frmPorukaVrata =
                    new frmPoruka("Vanjska vrata trezora otvorena bez aktivnosti predaje pologa duže od " + Settings.Default.TimerVrataOtvorena +
                                  " sekundi.");
                Invoke(new MethodInvoker(delegate { _frmPorukaVrata.Show(this); }));
            }
        }

        #endregion

        #region BackUp

        private void BackUp()
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(Settings.Default.ConnectionString))
                {
                    if (connection.DataSource != null)
                        File.Copy(connection.DataSource, Settings.Default.BackUpFolder + @"\DNTBaza.mdb", true);
                }
            }
            catch
            {
                // ignored
            }
        }

        #endregion


        public frmMain()
        {
            InitializeComponent();

            if (!SerialPortElektronika. IsOpen)
                SerialPortElektronika.Open();

            try
            {
                _timerBackUp = new Timer(_ => BackUp(), null, TimeSpan.FromMinutes(5), TimeSpan.FromHours(24));
            }
            catch
            {
                // ignored
            }

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

                            if (ObjectFactory.KarticaDataService.PostojiBrojKartice(kartica, true))
                            {
                                SerialPortElektronika.Write(new byte[] { 0x10 }, 0, 1);
                                
                                _transakcija = new Transakcija {Kartica = kartica, DatumOd = DateTime.Now, Trezor = true};
                                ObjectFactory.TransakcijaDataService.UnesiTransakciju(_transakcija);

                                TimerZasunStart();
                                TransakcijaUTijeku = true;                                
                            }
                            break;

                        case 0x21: //vrata otvorena
                            TimerZasunStop();
                            TimerVrataOtvorenaStart();                            
                            break;                            
                        case 0x23: //ubacaj vrecica

                            if(!TransakcijaUTijeku)
                                break;
                            
                            TimerVrataOtvorenaReStart();
                            
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
                            
                            if (_frmPorukaVrata != null)
                                Invoke(new MethodInvoker(delegate { _frmPorukaVrata.Close(); _frmPorukaVrata.Dispose(); _frmPorukaVrata = null; }));
                            break;

                         case 0x24: //blokada na fotoceliji

                            if (_frmPorukaFoto == null)
                            {
                                _frmPorukaFoto =
                                    new frmPoruka("Blokada fotosenzora.");
                                Invoke(new MethodInvoker(delegate { _frmPorukaFoto.Show(this); }));
                            }
                            
                            //TODO: napraviti upis alarma
                            break;

                        case 0x27: //maknula se blokada sa fotocelije
                            if (_frmPorukaFoto != null)
                                Invoke(new MethodInvoker(delegate { _frmPorukaFoto.Close(); _frmPorukaFoto.Dispose(); _frmPorukaFoto = null; }));
                            break;
                    }
                }
                catch (Exception e)
                {
                    Utils.Log(e);
                    try
                    {
                        SerialPortElektronika.Close();
                    }catch{}
                    Application.Restart();
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
    }
}
