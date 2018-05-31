using System.Diagnostics;

namespace BikeService.DataBase.DataServices
{
    public class EventDataService : IEventDataService
    {
        public void Insert(Event dogadaj)
        {
            //TODO: datetime uzeti
            
            //stack trace
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
