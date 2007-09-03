using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace IEBus_Studio
{
    class DeviceManager
    {
        protected ArrayList devices;

        public DeviceManager()
        {
            devices = new ArrayList();
        }

        public ArrayList Devices
        {
            get { return devices; }
            set { devices = value; }
        }

        public void addDevice(Device device)
        {
            devices.Add(device);
        }

        public string ouputAsXML()
        {
            string xml = "<devices>\r\n";
            for (int i = 0; i < devices.Count; i++)
            {
                Device device = (Device)devices[i];

                xml += "    <device>\r\n";
                xml += "        <name>" + device.Name + "</name>\r\n";
                xml += "        <description>" + device.Description + "</description>\r\n";
                xml += "        <address>" + device.AddressString + "</address>\r\n";
                xml += "    </device>\r\n";
            }
            xml += "</devices>\r\n";
            return xml;
        }

        static public ArrayList ScanDevices()
        {
            //TODO: send command to COM to scan devices
            //TODO: get response
            ArrayList devicesFound = new ArrayList();
            return devicesFound;
        }
    }
}
