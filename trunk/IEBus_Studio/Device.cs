using System;
using System.Collections.Generic;
using System.Text;

namespace IEBus_Studio
{
    class Device
    {
        protected byte[] address;
        protected string name;
        protected string description;

        public Device()
        {
            address = new byte[3];
            name = "Unkown Name";
            description = "Unkown Description";
        }

        public Device(byte[] address, string name, string description)
        {
            this.address = address;
            this.name = name;
            this.description = description;
        }

        public Device(string address, string name, string description)
        {
            this.AddressString = address;
            this.name = name;
            this.description = description;
        }

        public byte[] Address
        {
            get { return address; }
            set { address = value; }
        }

        public string AddressString
        {
            get
            {
               return System.BitConverter.ToString(address);
            }
            set
            {
                // If invalid address is typed use static address
                if (!Validator.validate_address(value))
                {
                    value = "00-00-00";
                }
                address = HexStringConverter.ToByteArray(value);
            }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Description
        {
            get {return description; }
            set { description = value; }
        }
    }
}
