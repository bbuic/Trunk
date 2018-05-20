using System;

namespace BikeService.DataBase
{
    public class Docking
    {
        public uint Id { get; set; }
        
        public int? Tag { get; set; }

        public DateTime? DatumUkljucivanja { get; set; }

        public int InternalState { get; set; }
        public int StatusMikraca2 { get; set; }

        public SwitchState SwitchState { get; set; }

        public int MotorCurrent05A { get; set; }
        public int MotorCurrent1A { get; set; }

        public StanjeSignalizacije StanjeSignalizacije { get; set; }
    }
}
