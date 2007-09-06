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
                string hexString = "";
                foreach (byte abyte in address)
                {
                    string temp = Convert.ToString(abyte);
                    if (temp.Length == 1) temp = "0" + temp;
                    hexString += temp;
                }

                while (hexString.Length != 0 && hexString[0] == '0') hexString = hexString.Substring(1, hexString.Length - 1);
                if (hexString.Length == 0) hexString = "0";

                return hexString;
               //return System.BitConverter.ToString(address);
            }
            set
            {
                // If invalid address is typed use static address
                if (!Validator.validate_address(value))
                {
                    value = "000000";
                }
                address = HexStringConverter.ToByteArray(value, false);
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
