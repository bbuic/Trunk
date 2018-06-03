using System;
using System.IO;
using System.Text;
using BikeService.DataBase;
using BikeService.Properties;
using Microsoft.ServiceBus.Messaging;

namespace BikeService.Objects.ObjectHandlers
{
    public delegate void ServerBusPoruka(ServerMessage message);

    public class ServerBusHandler : IServerBusHandler
    {
        public event ServerBusPoruka ServerBusMsg;

        public ServerBusHandler()
        {
            QueueClient queueClient;
            try
            {
                queueClient = QueueClient.CreateFromConnectionString(Settings.Default.ServiceBusConnString, "BojanQueue");
            }
            catch (Exception e)
            {
                throw new Exception($"Greška u procesu inicjalizacije ServiceBus-a uređaja. Razlog: {e.Message}, StackTrace: {e.StackTrace}");
            }

            queueClient.OnMessage(receivedMessage =>
            {
                try
                {
                    string messageBody;
                    using (TextReader reader = new StreamReader(receivedMessage.GetBody<Stream>(), Encoding.UTF8))
                        messageBody = reader.ReadToEnd();
                    ServerBusMsg?.Invoke((ServerMessage) Utils.DeSerialize(messageBody));
                    receivedMessage.Complete();
                }
                catch (Exception e)
                {
                    ObjectFactory.EventDataService.Insert(new Event(EventType.ServerRequest,
                        EventCategory.Error, $"Greška u procesu obrade server requesta. Razlog: {e.Message}"));
                    receivedMessage.Abandon();
                }
            });
        }
    }
}
