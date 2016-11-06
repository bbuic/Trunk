using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.IO.Ports;
using System.Threading;
using DNTDataAccess;
using DNTServiceProcessor.Lcd;
using DNTv2.DataModel;

namespace DNTServiceProcessor
{
    public class Processor
    {
        private SerialPort _serialPortElektronika;
        private Timer _timerVrataZasun;
        private Timer _timerVrataOtvorena;
        private Timer _timerFoto;
        private static Timer _timerBackUp;
        private static Timer _timerSerialPort;        
        private Transakcija _transakcija;
        internal bool TransakcijaUTijeku { get; set; }
        private readonly Queue<byte> _queue = new Queue<byte>();
        private ILcdService _lcdService;

        #region Timer zasun

        private void ZatvoriZasun()
        {
            TimerZasunStop();
            TransakcijaUTijeku = false;
            _transakcija = null;
            _serialPortElektronika.Write(new byte[] { 0x11 }, 0, 1);

            _lcdService.UvodnaPoruka();
        }

        private void TimerZasunStart()
        {
            _timerVrataZasun = new Timer(_ => ZatvoriZasun());
            _timerVrataZasun.Change(int.Parse( Utils.ReadSetting("TimerZasun")) * 1000, Timeout.Infinite);
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
                _timerVrataOtvorena.Change(int.Parse(Utils.ReadSetting("TimerVrataOtvorena")) * 1000, Timeout.Infinite);
            else
                TimerVrataOtvorenaStart();
        }

        private void TimerVrataOtvorenaStart()
        {
            if (_timerVrataOtvorena == null)
            {
                _timerVrataOtvorena = new Timer(_ => ZatvoriVrata());
                _timerVrataOtvorena.Change(int.Parse(Utils.ReadSetting("TimerVrataOtvorena")) * 1000, Timeout.Infinite);
            }
            else
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
            
            ObjectFactory.DogadajDataService.OtvoriDogadaj(DogadajTip.Vrata, _transakcija != null ? _transakcija.Kartica : null);

            _lcdService.IspisiPoruku("Molimo da zatvorite vrata...");
        }

        #endregion

        #region BackUp

        private void BackUp(object o)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(Utils.ReadSetting("ConnectionString")))
                {
                    if (connection.DataSource != null)
                        File.Copy(connection.DataSource, Utils.ReadSetting("BackUpFolder") + @"\DNTBaza.mdb", true);
                }
            }
            catch (Exception e)
            {
                Utils.Log(e);
            }
        }

        #endregion


        public void Start()
        {
            try
            {
                if (_serialPortElektronika == null)
                {
                    _serialPortElektronika = new SerialPort(Utils.ReadSetting("PortElektronika"), 19200){ReceivedBytesThreshold = 1};                    
                    _serialPortElektronika.Open();
                }

                string s = Utils.ReadSetting("BackUpFolder");
                if(!string.IsNullOrEmpty(s) && Directory.Exists(s))
                    _timerBackUp = new Timer(BackUp, null, TimeSpan.FromMinutes(1), TimeSpan.FromHours(24));

                _lcdService = new LcdService();
                _lcdService.UvodnaPoruka();
            }
            catch (Exception e)
            {
                Utils.Log(e);
                throw;
            }

            if (_timerSerialPort == null)
                _timerSerialPort = new Timer(_ => ObradiPodatkeSerijskogPorta());
            
            _serialPortElektronika.DataReceived += delegate
            {
                _timerSerialPort.Change(100, Timeout.Infinite);

                while (_serialPortElektronika.BytesToRead > 0)
                    _queue.Enqueue((byte) _serialPortElektronika.ReadByte());
            };
        }

        private void ObradiPodatkeSerijskogPorta()
        {
            while (_queue.Count > 0)            
            {
                try
                {
                    switch (_queue.Dequeue())
                    {
                        case 0x20: //bezkontaktna kartica

                            if (_queue.Count < 2 || TransakcijaUTijeku)
                            {
                                _queue.Clear();
                                break;
                            }

                            byte[] buffer = new byte[2];
                            buffer[1] = _queue.Dequeue();
                            buffer[0] = _queue.Dequeue();
                            var kartica = ((BitConverter.ToInt16(buffer, 0)).ToString()).PadLeft(5, '0');

                            if (ObjectFactory.KarticaDataService.PostojiBrojKartice(kartica, true))
                            {
                                _serialPortElektronika.Write(new byte[] {0x10}, 0, 1);

                                _transakcija = new Transakcija
                                {
                                    Kartica = kartica,
                                    DatumOd = DateTime.Now,
                                    Trezor = true
                                };
                                ObjectFactory.TransakcijaDataService.UnesiTransakciju(_transakcija);

                                TimerZasunStart();
                                TransakcijaUTijeku = true;

                                _lcdService.IspisiPoruku("   OTORITE VRATA      Ubacujte vrecice");
                            }
                            break;

                        case 0x21: //vrata otvorena

                            if (!TransakcijaUTijeku)
                                break;

                            TimerZasunStop();
                            TimerVrataOtvorenaStart();

                            _lcdService.IspisiPoruku("Dozvoljeno ubacivatiUbaceno vrecica = 0");
                            break;

                        case 0x23: //detekcija objekta na fotosenzoru

                            if (!TransakcijaUTijeku)
                                break;
                            
                            TimerVrataOtvorenaReStart();

                            if (_timerFoto == null)
                            {
                                _timerFoto = 
                                    new Timer(delegate{ ObjectFactory.DogadajDataService.OtvoriDogadaj(DogadajTip.Foto, _transakcija != null ? _transakcija.Kartica : null);});
                            }
                            _timerFoto.Change(int.Parse(Utils.ReadSetting("TimerFoto")), Timeout.Infinite);
                            break;

                        case 0x27: //objekt se maknuo sa fotosenzora

                            if (_timerFoto != null)
                            {
                                _timerFoto.Change(Timeout.Infinite, Timeout.Infinite);
                                _timerFoto.Dispose();
                                _timerFoto = null;
                            }
                            
                            ObjectFactory.DogadajDataService.ZatvoriDogadaj(DogadajTip.Vrata);
                            ObjectFactory.DogadajDataService.ZatvoriDogadaj(DogadajTip.Foto);

                            if (!TransakcijaUTijeku)
                                break;

                            TimerVrataOtvorenaReStart();

                            _transakcija.BrojVrecica += 1;
                            ObjectFactory.TransakcijaDataService.PromjeniTransakciju(_transakcija);

                            _lcdService.IspisiPoruku("Dozvoljeno ubacivatiUbaceno vrecica = " + _transakcija.BrojVrecica);
                            break;

                        case 0x22: //vrata zatorena

                            if (!TransakcijaUTijeku)
                                break;

                            TimerVrataOtvorenaStop();

                            TransakcijaUTijeku = false;

                            _transakcija.DatumDo = DateTime.Now;
                            ObjectFactory.TransakcijaDataService.PromjeniTransakciju(_transakcija);
                            _transakcija = null;

                            ObjectFactory.DogadajDataService.ZatvoriDogadaj(DogadajTip.Vrata);

                            _lcdService.IspisiPoruku("HVALA NA POVJERENJU!");
                            int i;
                            try
                            {
                                i = Convert.ToInt32(Utils.ReadSetting("TimerTransakcijaEnd"));
                            }
                            catch (Exception)
                            {
                                i = 2000;
                            }
                            _lcdService.UvodnaPoruka(i);                          
                            break;

                        default:
                            _queue.Dequeue();
                            break;
                    }
                }
                catch (Exception e)
                {
                    Utils.Log(e);
                }                
            }            
        }

        public void Stop()
        {
            try
            {
                if (_serialPortElektronika != null)
                {
                    if (_serialPortElektronika.IsOpen)
                        _serialPortElektronika.Close();
                    _serialPortElektronika.Dispose();
                    _serialPortElektronika = null;
                }

                _lcdService.Dispose();
            }
            catch (Exception e)
            {
                Utils.Log(e);
            }
        }
    }
}
