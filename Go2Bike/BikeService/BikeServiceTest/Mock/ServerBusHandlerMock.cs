using BikeService.Objects;
using BikeService.Objects.ObjectHandlers;

namespace BikeServiceTest.Mock
{
    public class ServerBusHandlerMock: IServerBusHandler
    {
        public event ServerBusPoruka ServerBusMsg;

        public void SendMessage(ServerMessage msg)
        {
            ServerBusMsg?.Invoke(msg);
        }
    }
}
