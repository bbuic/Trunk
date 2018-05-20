namespace BikeService.EventHandlers
{
    public class StateEventHandler:AbstractEventHandler
    {
        public StateEventHandler(CanReciveCommands canReciveCommands, int numMsg, byte firstByte, ObradiEventHandler handler, AbstractEventHandler successor = null) : base(canReciveCommands, numMsg, firstByte, handler, successor)
        {
        }
        
        public int InternalState => Messages[0][2];
        public int StatusMikraca2 => Messages[0][8];

        public SwitchState SwitchState => (SwitchState) Utils.GetBit(Messages[1][0], 0);

        public int MotorCurrent05A => Utils.GetBit(Messages[1][2], 0);
        public int MotorCurrent1A => Utils.GetBit(Messages[1][3], 1);

        public StanjeSignalizacije StanjeSignalizacije=> (StanjeSignalizacije) Utils.GetBit(Messages[1][4], 1);

        internal override void Handle()
        {}
    }
}
