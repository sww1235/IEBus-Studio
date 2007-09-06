using System;
using System.Collections.Generic;
using System.Text;

namespace IEBus_Studio
{
    class Device
    {
        private byte[] _address;
        private string _name;
        private string _description;

        public Device()
        {
            _address = new byte[3];
            _name = string.Empty;
            _description = string.Empty;
        }
        public Device(byte[] address, string name, string description)
        {
            _address = address;
            _name = name;
            _description = description;
        }
        public byte[] Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }
    }
}
