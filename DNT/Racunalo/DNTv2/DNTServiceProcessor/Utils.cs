using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;

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

        internal static void Log(Exception e)
        {
            string log = "Greska: " + e.Message + Environment.NewLine + "  StacTrace: " + e.StackTrace +
                         (e.InnerException != null ? "Inner exception: " + e.InnerException.Message : "") +
                         Environment.NewLine + " Datum: " + DateTime.Now;
            try
            {
                using (StreamWriter file = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "Log.txt", true))
                {
                    file.WriteLine("");
                    file.WriteLine("");
                    file.WriteLine(log);
                }
            }
            catch (Exception)
            {
                if (!EventLog.SourceExists("DNTService"))
                    EventLog.CreateEventSource("DNTService", "DNT");

                using (EventLog eventLog = new EventLog("DNT"))
                {
                    eventLog.Source = "DNTService";
                    eventLog.WriteEntry(log, EventLogEntryType.Error, 101, 1);
                }
            }
        }
    }
}
