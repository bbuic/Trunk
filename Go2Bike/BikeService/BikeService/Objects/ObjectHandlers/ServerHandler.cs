using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace BikeService.Objects.ObjectHandlers
{
    public class ServerHandler
    {
        public string GetNalaz(int id)
        {
            try
            {
                var uri = string.Format("http://localhost/IN2.BISWebService/Pylon2Cloud/ValidateBike?tagId={1}", id, type);
                return ExecuteGet<string>(uri, userId, 10);
            }
            catch (WebException e1)
            {
                HttpWebResponse response = e1.Response as HttpWebResponse;
                if (response != null)
                    throw new Exception("Greška u procesu izvršavanja metode GetNalaz. Razlog: " + response.StatusDescription);
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Greška u procesu izvršavanja metode GetNalaz. Razlog: " + e.Message);
            }
        }

        public T ExecuteGet<T>(string uri, short userId, int timeoutInSeconds)
        {
            HttpWebRequest webReq = (HttpWebRequest)HttpWebRequest.Create(uri);
            webReq.Timeout = 1000 * timeoutInSeconds;
            webReq.Headers.Add("UserId", userId.ToString());
            webReq.Method = "GET";
            webReq.ContentType = "application/json";
            webReq.ContentLength = 0;

            using (WebResponse response = (HttpWebResponse)webReq.GetResponse())
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
