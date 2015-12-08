using System;
using System.Configuration;

namespace DNTServiceProcessor
{
    public sealed class Utils
    {
        public static string ReadSetting(string key)
        {
            try
            {
                return ConfigurationManager.AppSettings[key];
            }
            catch (Exception e)
            {
                throw new Exception("Greška prilikom čitanja konfiguracije. Opis greške: " + e.Message);
            }
        } 

        public static void Log(Exception e)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"Log.txt", true))
            {
                file.WriteLine("");
                file.WriteLine("");
                file.WriteLine("Greska: " + e.Message + "  StacTrace: " + e.StackTrace + 
                    (e.InnerException != null ? "Inner exception: " + e.InnerException.Message : ""));
            }
        }
    }
}
