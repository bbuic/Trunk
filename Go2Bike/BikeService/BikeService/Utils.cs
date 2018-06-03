using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace BikeService
{
    public class Utils
    {
        public static uint AddFirstBit(uint dockId)
        {
            var s = Convert.ToString(dockId, 2).PadLeft(9, '0');
            return Convert.ToUInt32("1" + s, 2);
        }

        public static uint RemoveFirstBit(uint dockId)
        {
            return Convert.ToUInt32(Convert.ToString(dockId, 2).Remove(0, 1), 2);
        }

        public static string Serialize(object o)
        {
            return "";
        }

        public static object DeSerialize(object o)
        {
            return "";
        }

        public static int GetBit(byte b, int bitNumber)
        {
            return b & (1 << bitNumber);
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
