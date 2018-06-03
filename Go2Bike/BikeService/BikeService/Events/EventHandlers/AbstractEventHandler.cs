using System;
using System.Collections.Generic;
using System.Threading;
using BikeService.Objects;

namespace BikeService.Events.EventHandlers
{
    public delegate void ObradiEventHandler(AbstractEvent dogadaj);

    public abstract class AbstractEventHandler
    {
        private readonly ObradiEventHandler _handler;
        private readonly AbstractEventHandler _successor;
        private readonly int _numMsg;        
        private readonly List<TPCANMsg> _list = new List<TPCANMsg>();
        private readonly Timer _timer;      
        private readonly Type _type;

        protected AbstractEventHandler(CanReciveCommands canReciveCommands, int numMsg, ObradiEventHandler handler, AbstractEventHandler successor = null, Type type = null)
        {
            CommandType = canReciveCommands;
            _handler = handler;
            _successor = successor;
            _numMsg = numMsg;
            _type = type;

            if (_timer == null)
                _timer = new Timer(delegate
                {
                    _list.Clear();
                });
        }
        
        public CanReciveCommands CommandType { get; set; }
        
        internal void NewMessage(TPCANMsg msg)
        {
            if (msg.DATA[0].Equals((byte)CommandType))
            {
                msg.ID = Utils.RemoveFirstBit(msg.ID);
                _list.Add(msg);

                if (_list.Count != _numMsg)
                    _timer.Change(Properties.Settings.Default.CleanMessagesTime, Timeout.Infinite);
                else
                {
                    _timer.Change(Timeout.Infinite, Timeout.Infinite);

                    AbstractEvent dogadaj;
                    if (_type != null)
                        dogadaj = (AbstractEvent) Activator.CreateInstance(_type);
                    else
                        dogadaj = new GenericEvent();
                    dogadaj.EventType = CommandType;
                    foreach (var tpcanMsg in _list)
                        dogadaj.List.Add(tpcanMsg);
                    _list.Clear();
                    dogadaj.Handle();

                    _handler(dogadaj);
                    
                }
            }
            else
                _successor?.NewMessage(msg);
        }              
    }
}
