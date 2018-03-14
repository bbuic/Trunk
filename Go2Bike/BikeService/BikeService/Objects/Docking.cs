using System;
using BikeService.Objects.ObjectHandlers;

namespace BikeService.Objects
{
    public class Docking
    {
        private SwitchState _switchState;

        public event EventHandler UserCardRead;
        public event EventHandler TagRead;

        public delegate void SwitchStateChangedParams(SwitchState state);
        public event SwitchStateChangedParams SwitchStateChanged;

        public PcanHandler PcanHandler { get; set; }

        public uint Id { get; set; }        
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

        public void HelloResponse()
        {
            PcanHandler.Write(Id, new[] { Commands.HelloResponse });
            LastHello = DateTime.Now;
        }

        public void ExecuteCommand(byte[] data)
        {
            PcanHandler.Write(Id, data);
        }
    }
}
