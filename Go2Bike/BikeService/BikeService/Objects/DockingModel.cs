using System.ComponentModel;
using BikeService.DataBase;
using BikeService.EventHandlers;

namespace BikeService.Objects
{
    public class DockingModel: Docking
    {
        public BindingList<CanMessage> SendCommands = new BindingList<CanMessage>();
        public BindingList<CanMessage> ReciveCommands = new BindingList<CanMessage>();

        public bool IsInit { get; set; }

        public bool IsLocked => Tag.HasValue && SwitchState == SwitchState.Zatvoreno;
    }
}
