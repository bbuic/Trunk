using System;
using System.Text;
using System.Threading;
using BikeService.Properties;
using TPCANHandle = System.UInt16;
using TPCANTimestampFD = System.UInt64;

namespace BikeService.Objects.ObjectHandlers
{
    public class PcanHandler
    {
        private TPCANHandle _handle;
        private Thread _mReadThread;

        public delegate void ReadHandler(TPCANMsg theMsg, TPCANTimestamp itsTimeStamp);
        public event ReadHandler CanRead;
        
        public bool Init()
        {
            try
            {
                ObjectFactory.LogDataService.Write(LogLocation.CanInit, LogType.Info, "Pokrenuta inicjalizacija CANa.");

                TPCANStatus stsResult;
                foreach (var handle in PCANBasic.UsbHandlesArray)
                {
                    ObjectFactory.LogDataService.Write(LogLocation.CanInit, LogType.Info, "Pretraga uređaja PCAN-USB broj: " + handle);

                    UInt32 iBuffer;
                    stsResult = PCANBasic.GetValue(handle, TPCANParameter.PCAN_CHANNEL_CONDITION, out iBuffer, sizeof(UInt32));
                    if (stsResult == TPCANStatus.PCAN_ERROR_OK && (iBuffer & PCANBasic.PCAN_CHANNEL_AVAILABLE) == PCANBasic.PCAN_CHANNEL_AVAILABLE)
                    {
                        _handle = handle;
                        ObjectFactory.LogDataService.Write(LogLocation.CanInit, LogType.Info, "Postoji uređaj PCAN-USB broj: " + handle);
                        break;
                    }             
                }

                if (_handle <= 0)
                    throw new Exception("Ne postoji uređaj PCAN-USB");

                uint ioPort = Convert.ToUInt32(Settings.Default.IOPort, 16);
                ushort interrupt = Convert.ToUInt16(Settings.Default.Interrupt);

                ObjectFactory.LogDataService.Write(LogLocation.CanInit, LogType.Info,
                                                   string.Format("Inicjalizacija CAN, parametri({0}, {1}, {2}, {3}, {4})",
                                                                 _handle, Settings.Default.TPCANBaudrate, Settings.Default.TPCANType, ioPort, interrupt));

                stsResult = PCANBasic.Initialize(_handle, Settings.Default.TPCANBaudrate, Settings.Default.TPCANType, ioPort, interrupt);

                if (stsResult != TPCANStatus.PCAN_ERROR_OK)
                {
                    if (stsResult != TPCANStatus.PCAN_ERROR_CAUTION)
                        throw new Exception(GetFormatedError(stsResult));

                    ObjectFactory.LogDataService.Write(LogLocation.CanInit, LogType.Info, 
                        "Greška u procesu inicjalizacije CANa. Razlog: The bitrate being used is different than the given one");
                    stsResult = TPCANStatus.PCAN_ERROR_OK;
                }
                else
                {
                    _mReadThread = new Thread(CanReadThreadFunc) { IsBackground = true };
                    _mReadThread.Start();

                    ObjectFactory.LogDataService.Write(LogLocation.CanInit, LogType.Info, "Uspješno inicjaliziran uređaj PCAN-USB broj: " + _handle);
                }
                
                return stsResult == TPCANStatus.PCAN_ERROR_OK;
            }
            catch (Exception e)
            {
                ObjectFactory.LogDataService.Write(LogLocation.CanInit, LogType.Error, 
                    string.Format("Greška u procesu inicjalizacije PCAN-USB uređaja. Razlog: {0}, StackTrace: {1}", e.Message, e.StackTrace));
                return false;
            }
        }

 
        private void CanReadThreadFunc()
        {
            var mReceiveEvent = new AutoResetEvent(false);
            uint iBuffer = Convert.ToUInt32(mReceiveEvent.SafeWaitHandle.DangerousGetHandle().ToInt32());            
            var stsResult = PCANBasic.SetValue(_handle, TPCANParameter.PCAN_RECEIVE_EVENT, ref iBuffer, sizeof(UInt32));

            if (stsResult != TPCANStatus.PCAN_ERROR_OK)
            {
                ObjectFactory.LogDataService.Write(LogLocation.CanRead, LogType.Error, 
                    "Greška u procesu inicjalizacije čitanja CANa(PCAN_RECEIVE_EVENT). Razlog: " + GetFormatedError(stsResult));                
                return;
            }
            
            while (true)
            {                
                if (mReceiveEvent.WaitOne(50))
                {
                    do
                    {
                        stsResult = ReadMessage();
                        if (stsResult == TPCANStatus.PCAN_ERROR_ILLOPERATION)
                        {
                            ObjectFactory.LogDataService.Write(LogLocation.CanRead, LogType.Error, "Greška u procesu čitanja CANa. Razlog: PCAN_ERROR_ILLOPERATION");
                            break;
                        }
                    } while (!Convert.ToBoolean(stsResult & TPCANStatus.PCAN_ERROR_QRCVEMPTY));
                }
            }
        }
        
        private TPCANStatus ReadMessage()
        {
            TPCANMsg canMsg;
            TPCANTimestamp canTimeStamp;
            var stsResult = PCANBasic.Read(_handle, out canMsg, out canTimeStamp);
            if (stsResult != TPCANStatus.PCAN_ERROR_QRCVEMPTY)
            {
                if (CanRead != null)
                    CanRead(canMsg, canTimeStamp);                
            }
            else
                ObjectFactory.LogDataService.Write(LogLocation.CanRead, LogType.Info, "Greška u procesu čitanja CANa. Razlog: PCAN_ERROR_QRCVEMPTY");            
            return stsResult;
        }

        public void Release()
        {
            ObjectFactory.LogDataService.Write(LogLocation.CanRelease, LogType.Info, "Pokrenut release CANa.");
            if (_handle > 0)
            {
                PCANBasic.Uninitialize(_handle);
                ObjectFactory.LogDataService.Write(LogLocation.CanRelease, LogType.Info, "Završen release CANa. Handle: " + _handle);
            }
            else
                ObjectFactory.LogDataService.Write(LogLocation.CanRelease, LogType.Info, "Nije moguće pokrenuti release jer nema handlera.");
        }

        public void Write(string idUredaja, TPCANMessageType msgtype, byte len, byte[] data)
        {
            try
            {
                var canMsg = new TPCANMsg
                    {
                        DATA = new byte[8],
                        ID = Convert.ToUInt32(idUredaja, 16),
                        LEN = Convert.ToByte(len),
                        MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD
                    };
                for (var i = 0; i < data.Length; i++)
                    canMsg.DATA[i] = data[i];            

                var stsResult = PCANBasic.Write(_handle, ref canMsg);

                if (stsResult == TPCANStatus.PCAN_ERROR_OK)
                    ObjectFactory.LogDataService.Write(LogLocation.CanWrite, LogType.Info, "Uspješno poslana poruka.");
                else
                    throw new Exception(GetFormatedError(stsResult));
            }
            catch (Exception e)
            {
                ObjectFactory.LogDataService.Write(LogLocation.CanWrite, LogType.Error,
                    string.Format("Greška u procesu slanja komande. Razlog: {0}, StackTrace: {1}", e.Message, e.StackTrace));
            }
        }


        private string GetFormatedError(TPCANStatus error)
        {
            // Creates a buffer big enough for a error-text
            //
            var strTemp = new StringBuilder(256);
            // Gets the text using the GetErrorText API function
            // If the function success, the translated error is returned. If it fails,
            // a text describing the current error is returned.
            //
            if (PCANBasic.GetErrorText(error, 0, strTemp) != TPCANStatus.PCAN_ERROR_OK)
                return string.Format("An error occurred. Error-code's text ({0:X}) couldn't be retrieved", error);
            return strTemp.ToString();
        }
    }
}
