using System;

namespace DNTv2
{
    public sealed class Utils
    {
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
