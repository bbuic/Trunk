using System;
using System.Windows.Forms;

namespace BikeService.Objects.ObjectHandlers
{
    using TPCANHandle = UInt16;

    public class PcanHandler
    {
        private readonly TPCANHandle[] m_HandlesArray = {                
                PCANBasic.PCAN_USBBUS1,
                PCANBasic.PCAN_USBBUS2,
                PCANBasic.PCAN_USBBUS3,
                PCANBasic.PCAN_USBBUS4,
                PCANBasic.PCAN_USBBUS5,
                PCANBasic.PCAN_USBBUS6,
                PCANBasic.PCAN_USBBUS7,
                PCANBasic.PCAN_USBBUS8,
                PCANBasic.PCAN_USBBUS9,
                PCANBasic.PCAN_USBBUS10,
                PCANBasic.PCAN_USBBUS11,
                PCANBasic.PCAN_USBBUS12,
                PCANBasic.PCAN_USBBUS13,
                PCANBasic.PCAN_USBBUS14,
                PCANBasic.PCAN_USBBUS15,
                PCANBasic.PCAN_USBBUS16,
                PCANBasic.PCAN_PCCBUS1,
                PCANBasic.PCAN_PCCBUS2,                
            };


        public void Init()
        {
            UInt32 iBuffer;
            TPCANStatus stsResult;
            
            foreach (var handle in m_HandlesArray)
            {
                stsResult = PCANBasic.GetValue(handle, TPCANParameter.PCAN_CHANNEL_CONDITION, out iBuffer, sizeof(UInt32));
                if (stsResult == TPCANStatus.PCAN_ERROR_OK && (iBuffer & PCANBasic.PCAN_CHANNEL_AVAILABLE) == PCANBasic.PCAN_CHANNEL_AVAILABLE)
                {                                        
                    stsResult = PCANBasic.Initialize(
                        handle,
                        TPCANBaudrate.PCAN_BAUD_50K,
                        m_HwType,
                        Convert.ToUInt32(cbbIO.Text, 16),
                        Convert.ToUInt16(cbbInterrupt.Text));
                }
            }                
            
        }

        public void Read() { }
    }
}
