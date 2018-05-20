using System.Diagnostics;

namespace BikeService.DataBase.DataServices
{
    public class EventDataService
    {
        public void Insert(EventType type, EventCategory category, string opis, uint? dockingId = null)
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
