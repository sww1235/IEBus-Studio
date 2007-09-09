using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace IEBus_Studio
{
    public class EventManager
    {
        protected ArrayList events;

        public EventManager()
        {
            events = new ArrayList();
        }

        public ArrayList Events
        {
            get { return events; }
            set { events = value; }
        }

        public void addEvent(Event ev)
        {
            events.Add(ev);
        }

        public string ouputAsXML()
        {
            string xml = "<events>\r\n";
            for (int i = 0; i < events.Count; i++)
            {
                Event ev = (Event)events[i];

                xml += "    <event>\r\n";
                xml += "        <name>"           + ev.Name         + "</name>\r\n";
                xml += "        <description>"    + ev.Description  + "</description>\r\n";
                xml += "        <broadcast>"      + ev.Broadcast    + "</broadcast>\r\n";
                xml += "        <master_address>" + ev.Master       + "</master_address>\r\n";
                xml += "        <slave_address>"  + ev.Slave        + "</slave_address>\r\n";
                xml += "        <control>"        + ev.Control      + "</control>\r\n";
                xml += "        <datasize>"       + ev.Size         + "</datasize>\r\n";
                foreach (string var in ev.Variables)
                    xml += "        <data>" + var + "</data>\r\n";
                xml += "    </event>\r\n";
            }
            xml += "</events>\r\n";
            return xml;
        }

        public ArrayList GetDeviceEvents(int master_address)
        {
            ArrayList deviceEvents = new ArrayList();
            
            foreach(Event ev in events)
            {
                if (ev.Master == master_address)
                    deviceEvents.Add(ev);
            }

            return deviceEvents;
        }
    }
}
