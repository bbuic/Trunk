using System;
using System.ComponentModel;
using BikeService.DataBase;
using BikeService.EventHandlers;

namespace BikeService.Objects
{
    public class DockingModel: Docking
    {
        public BindingList<AbstractEventHandler> SendCommands = new BindingList<AbstractEventHandler>();
        public BindingList<AbstractEventHandler> ReciveCommands = new BindingList<AbstractEventHandler>();

        public bool IsInit { get; set; }

        public bool IsLocked
        {
            get
            {
                if (!IsInit)
                    throw new Exception("Doking nije inicjaliziran.");

                return Tag.HasValue && SwitchState == SwitchState.Zatvoreno;
            }
        }
    }
}
