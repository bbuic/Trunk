using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace BikeService.Objects.ObjectHandlers
{
    public class ServerHandler
    {
        public void OpenBike(int bikeTagId, uint dockId)
        {
        }

        public void CloseBike(int bikeTagId, uint dockId)
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

        private T ExecuteGet<T>(string uri, int timeoutInSeconds)
        {
            var webReq = (HttpWebRequest)WebRequest.Create(uri);
            webReq.Timeout = 1000 * timeoutInSeconds;
            webReq.Headers.Add("PilonId", Properties.Settings.Default.PilonId.ToString());
            webReq.Headers.Add("ApiKey ", Properties.Settings.Default.ApiKey);
            webReq.Method = "GET";
            webReq.ContentType = "application/json";
            webReq.ContentLength = 0;

            using (var response = webReq.GetResponse())
            {
                string jsonresponse = null;
                using (var inputStream = response.GetResponseStream())
                    if (inputStream != null)
                        using (var reader = new StreamReader(inputStream))
                            jsonresponse = reader.ReadToEnd();
                response.Close();

                return JsonConvert.DeserializeObject<T>(jsonresponse);
            }
        }
    }
}
