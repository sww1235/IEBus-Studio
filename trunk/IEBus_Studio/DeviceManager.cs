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
                xml += "        <address>" + HexStringConverter.ToHexString(device.Address) + "</address>\r\n";
                xml += "    </device>\r\n";
            }
            xml += "</devices>\r\n";
            return xml;
        }

        private bool compare_address(byte[] ar1, byte[] ar2)
        {
            if (ar1.Length != ar2.Length) return false;

            for (int i = 0; i < ar2.Length; i++)
            {
                if (ar1[i] != ar2[i])
                    return false;
            }

            return true;
        }

        public string GetDeviceName(byte[] address)
        {
            foreach (Device device in devices)
            {
                if (compare_address(device.Address, address))
                    return device.Name;
            }

            return null;
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
