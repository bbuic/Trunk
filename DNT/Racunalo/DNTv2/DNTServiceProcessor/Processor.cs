using System;
using System.Data.OleDb;
using System.IO;
using System.IO.Ports;
using System.Threading;
using DNTDataAccess;
using DNTv2.DataModel;

namespace DNTServiceProcessor
{
    public class Processor
    {
        private SerialPort SerialPortElektronika;
        private Timer _timerVrataZasun;
        private Timer _timerVrataOtvorena;
        private Timer _timerFoto;
        private static Timer _timerBackUp;
        private bool _obradaSerijskogPortaUTijeku;
        private Transakcija _transakcija;
        internal bool TransakcijaUTijeku { get; set; }

        #region Timer zasun

        private void ZatvoriZasun()
        {
            TimerZasunStop();
            TransakcijaUTijeku = false;
            _transakcija = null;
            SerialPortElektronika.Write(new byte[] { 0x11 }, 0, 1);
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

            SerialPortElektronika.Write(new byte[] { 0x12 }, 0, 1);

            ObjectFactory.DogadajDataService.OtvoriDogadaj(DogadajTip.Vrata, _transakcija != null ? _transakcija.Kartica : null);
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
                if (SerialPortElektronika == null)
                {
                    SerialPortElektronika = new SerialPort(Utils.ReadSetting("PortElektronika"), 19200);
                    SerialPortElektronika.Open();
                }

                string s = Utils.ReadSetting("BackUpFolder");
                if(!string.IsNullOrEmpty(s) && Directory.Exists(s))
                    _timerBackUp = new Timer(BackUp, null, TimeSpan.FromMinutes(1), TimeSpan.FromHours(24));
            }
            catch (Exception e)
            {
                Utils.Log(e);
                throw;
            }

            //HENDLANJE PORUKA ELEKTRONIKE
            SerialPortElektronika.DataReceived += delegate
            {
                if (_obradaSerijskogPortaUTijeku)
                    return;
                try
                {
                    _obradaSerijskogPortaUTijeku = true;

                    switch (SerialPortElektronika.ReadByte())
                    {
                        case 0x20:

                            if (SerialPortElektronika.BytesToRead < 2 || TransakcijaUTijeku)
                                break;

                            byte[] buffer = new byte[2];
                            buffer[1] = (byte)this.SerialPortElektronika.ReadByte();
                            buffer[0] = (byte)this.SerialPortElektronika.ReadByte();
                            var kartica = ((BitConverter.ToInt16(buffer, 0)).ToString()).PadLeft(5, '0');

                            if (ObjectFactory.KarticaDataService.PostojiBrojKartice(kartica, true))
                            {
                                SerialPortElektronika.Write(new byte[] { 0x10 }, 0, 1);

                                _transakcija = new Transakcija { Kartica = kartica, DatumOd = DateTime.Now, Trezor = true };
                                ObjectFactory.TransakcijaDataService.UnesiTransakciju(_transakcija);

                                TimerZasunStart();
                                TransakcijaUTijeku = true;
                            }
                            break;

                        case 0x21: //vrata otvorena

                            if (!TransakcijaUTijeku)
                                break;

                            TimerZasunStop();
                            TimerVrataOtvorenaStart();
                            break;
                            
                        case 0x23: //detekcija objekta na fotosenzoru

                            if (!TransakcijaUTijeku)
                                break;

                            ObjectFactory.DogadajDataService.ZatvoriDogadaj(DogadajTip.Vrata);
                            ObjectFactory.DogadajDataService.ZatvoriDogadaj(DogadajTip.Foto);
                            TimerVrataOtvorenaReStart();
                            
                            _timerFoto = new Timer(delegate
                            {
                                ObjectFactory.DogadajDataService.OtvoriDogadaj(DogadajTip.Foto, _transakcija != null ? _transakcija.Kartica : null);
                            });                            
                            _timerFoto.Change(int.Parse( Utils.ReadSetting("TimerFoto")), Timeout.Infinite);
                            break;

                        case 0x27: //objekt se maknuo sa fotosenzora
                            
                            if (_timerFoto != null)
                            {
                                _timerFoto.Change(Timeout.Infinite, Timeout.Infinite);
                                _timerFoto.Dispose();
                                _timerFoto = null;
                            }

                            if (!TransakcijaUTijeku)
                                break;
                            
                            _transakcija.BrojVrecica += 1;
                            ObjectFactory.TransakcijaDataService.PromjeniTransakciju(_transakcija);

                            ObjectFactory.DogadajDataService.ZatvoriDogadaj(DogadajTip.Vrata);
                            ObjectFactory.DogadajDataService.ZatvoriDogadaj(DogadajTip.Foto);
                            TimerVrataOtvorenaReStart();
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
                            break;
                        
                    }
                }
                catch (Exception e)
                {
                    Utils.Log(e);
                }
                finally
                {
                    if (SerialPortElektronika.BytesToRead > 0)
                        SerialPortElektronika.DiscardInBuffer();

                    _obradaSerijskogPortaUTijeku = false;
                }
            };
        }

        public void Stop()
        {
            try
            {
                if (SerialPortElektronika != null)
                {
                    if (SerialPortElektronika.IsOpen)
                        SerialPortElektronika.Close();
                    SerialPortElektronika.Dispose();
                    SerialPortElektronika = null;
                }
            }
            catch (Exception e)
            {
                Utils.Log(e);
            }
        }
    }
}
