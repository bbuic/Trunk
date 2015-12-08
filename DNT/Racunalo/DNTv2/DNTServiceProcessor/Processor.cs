﻿using System;
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
        private static Timer _timerBackUp;
        private Timer _timerZvucniSignal;
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
            //UvodnaPoruka();
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

        #region Timer zvučni signal

        private void ZvucniSignal()
        {
            Console.Beep(1000, 500);
        }

        private void TimerZvucniSignalStart()
        {
            if (_timerZvucniSignal == null)
            {
                _timerZvucniSignal = new Timer(_ => ZvucniSignal());
                _timerZvucniSignal.Change(0, 2000);
            }
        }

        private void TimerZvucniSignalStop()
        {
            if (_timerZvucniSignal != null)
            {
                _timerZvucniSignal.Change(Timeout.Infinite, Timeout.Infinite);
                _timerZvucniSignal.Dispose();
                _timerZvucniSignal = null;
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
            TimerZvucniSignalStop();
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
            TimerZvucniSignalStop();
        }

        private void ZatvoriVrata()
        {
            TimerVrataOtvorenaStop();

            SerialPortElektronika.Write(new byte[] { 0x12 }, 0, 1);

            ObjectFactory.DogadajDataService.OtvoriDogadaj(DogadajTip.Vrata);

            TimerZvucniSignalStart();
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
            if (SerialPortElektronika == null)
            {
                SerialPortElektronika = new SerialPort(Utils.ReadSetting("PortElektronika"), 19200);
                SerialPortElektronika.Open();
            }

            try
            {
                string s = Utils.ReadSetting("BackUpFolder");
                if(!string.IsNullOrEmpty(s) && Directory.Exists(s))
                    _timerBackUp = new Timer(BackUp, null, TimeSpan.FromMinutes(1), TimeSpan.FromHours(24));
            }
            catch (Exception e)
            {
                Utils.Log(e);
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

                        case 0x23: //ubacaj vrecica

                            if (!TransakcijaUTijeku)
                                break;

                            TimerVrataOtvorenaReStart();

                            _transakcija.BrojVrecica += 1;
                            ObjectFactory.TransakcijaDataService.PromjeniTransakciju(_transakcija);

                            ObjectFactory.DogadajDataService.ZatvoriDogadaj(DogadajTip.Vrata);
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

                        case 0x24: //blokada na fotoceliji
                            ObjectFactory.DogadajDataService.OtvoriDogadaj(DogadajTip.Foto);
                            break;

                        case 0x27: //maknula se blokada sa fotocelije
                           ObjectFactory.DogadajDataService.ZatvoriDogadaj(DogadajTip.Foto);
                            break;
                    }
                }
                catch (Exception e)
                {
                    Utils.Log(e);
                    try
                    {
                        SerialPortElektronika.Close();
                    }
                    catch { }
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
            if (SerialPortElektronika.BytesToRead > 0)
                SerialPortElektronika.DiscardInBuffer();
            SerialPortElektronika.Close();
            SerialPortElektronika.Dispose();
            SerialPortElektronika = null;
        }
    }
}