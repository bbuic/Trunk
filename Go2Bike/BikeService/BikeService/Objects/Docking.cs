using System;

namespace BikeService.Objects
{
    public class Docking
    {
        private SwitchState _switchState;

        public event EventHandler UserCardRead;
        public event EventHandler TagRead;

        public delegate void SwitchStateChangedParams(SwitchState state);
        public event SwitchStateChangedParams SwitchStateChanged;

        public uint Id { get; set; }
        public Firmware Firmware { get; set; }
        public DateTime? LastHello { get; set; }
        
        public byte? RequestCommand { get; set; }
        public byte? ResponseCommand { get; set; }

        public SwitchState SwitchState
        {
            get { return _switchState; }
            set
            {
                if(_switchState != value)
                {
                    _switchState = value;
                    if (SwitchStateChanged != null) 
                        SwitchStateChanged.Invoke(value);
                }
            }
        }
    }
}
