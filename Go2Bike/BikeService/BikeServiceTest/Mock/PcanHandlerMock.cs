﻿using BikeService.Objects;
using BikeService.Objects.ObjectHandlers;

namespace BikeServiceTest.Mock
{
    public class PcanHandlerMock: IPcanHandler
    {
        public event PcanHandler.ReadHandler HandleCanMessage;

        public void PosaljiPoruku(TPCANMsg canMsg)
        {
            HandleCanMessage?.Invoke(canMsg, new TPCANTimestamp());
        }

        public bool InitCan()
        {
            return true;
        }
        
        public bool Write(TPCANMsg canMsg)
        {
            return true;
        }
    }
}
