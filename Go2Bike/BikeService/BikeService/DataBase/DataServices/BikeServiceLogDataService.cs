using System.Diagnostics;

namespace BikeService.DataBase.DataServices
{
    public class BikeServiceLogDataService
    {
        public void Write(LogType type, string log)
        {
            var stackTrace = new StackTrace();
            var name = stackTrace.GetFrame(1).GetMethod();
            if (name.DeclaringType != null)
            {
                var name1 = name.DeclaringType.FullName; //klasa
            }
            var name2 = name.Name;//metoda
        }
    }
}
