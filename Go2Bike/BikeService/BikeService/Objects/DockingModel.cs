using System;
using BikeService.DataBase;

namespace BikeService.Objects
{
    public class DockingModel: Docking
    {
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
