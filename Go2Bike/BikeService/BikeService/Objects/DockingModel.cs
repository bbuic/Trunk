using BikeService.DataBase;

namespace BikeService.Objects
{
    public class DockingModel: Docking
    {        
        public bool IsInit { get; set; }

        public bool IsLocked => Tag.HasValue && SwitchState == SwitchState.Zatvoreno;
    }
}
