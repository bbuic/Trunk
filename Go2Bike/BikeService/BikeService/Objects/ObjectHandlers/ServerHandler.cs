using System.Collections.Generic;

namespace BikeService.Objects.ObjectHandlers
{
    public class ServerHandler : IServerHandler
    {
        public void SendEvent()
        {
        }

        public void SendPilonStatus(List<DockingModel> list)
        {
            
        }

        public bool ValidateRfidTag(int rfidTagId, uint dockId)
        {
            return true;
        }

        public bool ValidateBikeTag(int bikeTagId, uint dockId)
        {
            //try
            //{
            //    var uri = string.Format("{0}{1}{2}", Properties.Settings.Default.CloudUrl, Properties.Settings.Default.ValidateTag, tagId);
            //    return ExecuteGet<bool>(uri, 10);
            //}
            //catch (WebException e1)
            //{
            //    var response = e1.Response as HttpWebResponse;
            //    if (response != null)
            //        throw new Exception("Greška u procesu izvršavanja metode ValidateBikeTag. Razlog: " + response.StatusDescription);
            //    throw;
            //}
            //catch (Exception e)
            //{
            //    throw new Exception("Greška u procesu izvršavanja metode ValidateBikeTag. Razlog: " + e.Message);
            //}
            return true;
        }

        
    }
}
