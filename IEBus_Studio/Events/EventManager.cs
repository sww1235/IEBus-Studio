using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.IO;
using System.Xml.Serialization;

namespace IEBus_Studio
{
[Serializable]
    public class EventManager
    {
        private System.Collections.Generic.List<IEBus_Studio.Event> _events;

        public EventManager()
        {
            _events = new System.Collections.Generic.List<IEBus_Studio.Event>();
        }

        public System.Collections.Generic.List<IEBus_Studio.Event> Events
        {
            get { return _events; }
            set { _events = value; }
        }

        public void addEvent(Event ev)
        {
            _events.Add(ev);
        }

        public ArrayList GetDeviceEvents(int master_address)
        {
            ArrayList deviceEvents = new ArrayList();
            
            foreach(Event ev in _events)
            {
                if (ev.Master == master_address)
                    deviceEvents.Add(ev);
            }

            return deviceEvents;
        }
    }
}
