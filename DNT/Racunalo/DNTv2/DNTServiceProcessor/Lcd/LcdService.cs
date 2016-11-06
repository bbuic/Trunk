using System;
using System.IO.Ports;
using System.Threading;

namespace DNTServiceProcessor.Lcd
{
    public class LcdService:ILcdService
    {
        private readonly bool _koristiLcd;
        private SerialPort _serialPortLcd;
        private Timer _timerLcd;
        private readonly int _timerDueTime;
        private readonly string _uvodnaPoruka;
        private short _uvodnaPorukaPozicija;
        private Timer _timerWait;

        public LcdService()
        {
            try
            {
                _koristiLcd = Convert.ToBoolean(Utils.ReadSetting("Lcd"));
                if (_koristiLcd)
                {
                    _uvodnaPoruka = Utils.ReadSetting("LcdUvodnaPoruka");
                    try
                    {
                        _timerDueTime = Convert.ToInt32(Utils.ReadSetting("LcdTimerDueTime"));
                    }
                    catch (Exception)
                    {
                        _timerDueTime = 250;
                    }
                    _serialPortLcd = new SerialPort(Utils.ReadSetting("LcdPort"), Convert.ToInt32(Utils.ReadSetting("LcdBaudRate")));
                    _serialPortLcd.Open();

                    _timerWait = new Timer(delegate { UvodnaPoruka(null); });
                }
            }
            catch (Exception e)
            {
                Utils.Log(e);
                _koristiLcd = false;
            }
        }

        public void UvodnaPoruka(int? delay)
        {
            if (!_koristiLcd)
                return;

            try
            {
                if (delay.HasValue)
                {                    
                    _timerWait.Change(delay.Value, Timeout.Infinite);  
                    return;
                }
                
                _uvodnaPorukaPozicija = 0;

                if (_timerLcd == null)
                {
                    _timerLcd = new Timer(delegate
                    {
                        if (_uvodnaPorukaPozicija == 0)
                        {
                            EraseLcd();
                            _serialPortLcd.Write(new byte[] {27, 18}, 0, 2); //VerticalModeLcd
                            KursorPozicija(1, 2);
                        }

                        _serialPortLcd.Write(new[] {_uvodnaPoruka[_uvodnaPorukaPozicija]}, 0, 1);
                        _uvodnaPorukaPozicija += 1;
                        if (_uvodnaPorukaPozicija >= _uvodnaPoruka.Length)
                            _uvodnaPorukaPozicija = 0;
                    });
                }                
                _timerLcd.Change(0, _timerDueTime);
            }
            catch (Exception e)
            {
                Utils.Log(e);
            }          
        }

        public void IspisiPoruku(string poruka)
        {
            if (!_koristiLcd)
                return;

            try
            {
                _timerWait.Change(Timeout.Infinite, Timeout.Infinite); 

                if (_timerLcd != null)            
                    _timerLcd.Change(Timeout.Infinite, Timeout.Infinite);

                EraseLcd();
                KursorPozicija(1, 1);
            
                _serialPortLcd.Write(poruka);
            }
            catch (Exception e)
            {
                Utils.Log(e);
            }
        }

        public void Dispose()
        {
            if (!_koristiLcd)
                return;

            if (_timerLcd != null)
            {
                _timerLcd.Change(Timeout.Infinite, Timeout.Infinite);
                _timerLcd.Dispose();
                _timerLcd = null;
            }

            if (_timerWait != null)
            {
                _timerWait.Change(Timeout.Infinite, Timeout.Infinite);
                _timerWait.Dispose();
                _timerWait = null;
            }

            if (_serialPortLcd != null)
            {
                if (_serialPortLcd.IsOpen)
                    _serialPortLcd.Close();
                _serialPortLcd.Dispose();
                _serialPortLcd = null;
            }
        }

        private void EraseLcd()
        {
            _serialPortLcd.Write(new byte[] { 12 }, 0, 1);//Erase                        
        }

        private void KursorPozicija(byte stupac, byte red)
        {
            _serialPortLcd.Write(new byte[] {27, 108, stupac, red}, 0, 4); //KursorPozicija (1,1)
        }
    }
}
