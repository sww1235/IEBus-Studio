using System;
using System.Collections.Generic;
using System.Text;

namespace IEBus_Studio
{
    class Event
    {
        string name;
        string description;
        protected bool				broadcast;		// Broadcast bit		[ 1 bit ]
	    protected byte[]			master_address;	// Master Address		[12 bits]
	    protected byte[]		    slave_address;	// Slave Address		[12 bits]
        protected byte         		control;		// Control				[ 4 bits]
        protected ushort            datasize;       // Data byte count		[ 8 bits]
        protected byte[]            data;			// Data					[128 bits]

        public Event()
        {
            name           = "Unkown Name";
            description    = "Unkown Description";
            broadcast      = true;
            master_address = new byte[3];
            slave_address  = new byte[3];
            control        = 0x7F;
            datasize       = 0x00;
            data           = new byte[16];
        }

        public Event(string name, string description, bool broadcast, byte[] master_address, byte[] slave_address, byte control, ushort datasize, byte[] data)
        {
            this.name           = name;
            this.description    = description;
            this.broadcast      = broadcast;
            this.master_address = master_address;
            this.slave_address  = slave_address;
            this.control        = control;
            this.datasize       = datasize;
            this.Data           = data;
        }

        public Event(string name, string description, string broadcast, string master_address, string slave_address, string control, ushort datasize, string data)
        {
            this.name                  = name;
            this.Description           = description;
            this.BroadcastString       = broadcast;
            this.Master_Address_String = master_address;
            this.Slave_Address_String  = slave_address;
            this.ControlString         = control;
            this.datasize              = datasize;
            this.DataString            = data;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Description
        {
            get { return description; }
            set { name = value; }
        }

        public bool Broadcast
        {
            get { return broadcast; }
            set { broadcast = value; }
        }

        public string BroadcastString
        {
            get
            {
                if (!broadcast)
                    return "0";
                return "1";
            }
            set
            {
                if (value == "0")
                    broadcast = false;
                broadcast = true;
            }
        }

        public byte[] Master_Address
        {
            get { return master_address; }
            set { master_address = value; }
        }

        public string Master_Address_String
        {
            get
            {
                return System.BitConverter.ToString(master_address);
            }
            set
            {
                // If invalid address is typed use static address
                if (!Validator.validate_address(value))
                {
                    value = "00-00-00";
                }
                master_address = HexStringConverter.ToByteArray(value);
            }
        }

        public byte[] Slave_Address
        {
            get { return slave_address; }
            set { slave_address = value; }
        }

        public string Slave_Address_String
        {
            get
            {
                return System.BitConverter.ToString(slave_address);
            }
            set
            {
                // If invalid address is typed use static address
                if (!Validator.validate_address(value))
                {
                    value = "00-00-00";
                }
                slave_address = HexStringConverter.ToByteArray(value);
            }
        }

        public byte Control
        {
            get { return control; }
            set { control = value; }
        }

        public string ControlString
        {
            get 
            { 
                return Convert.ToString(control, 16); 
            }
            set
            {
                if (!Validator.validate_control(value))
                {
                    value = "F";
                }
                control = Convert.ToByte(value, 16);
            }
        }

        public ushort DataSize
        {
            get { return datasize; }
            set { datasize = value; }
        }

        public byte[] Data
        {
            get { return data; }
            set {
                // if data is too large
                if (value.Length > 20)
                {
                    // Only take first 20 bytes
                    data = new byte[20];
                    for (int i = 0; i < 20; i++)
                        data[i] = value[i];
                }
                // if data is too small, pad with 00s
                else if (value.Length < 20)
                {
                    data = new byte[20];
                    for (int i = 0; i < 20; i++)
                    {
                        if (i >= value.Length)
                            data[i] = 0x00;
                        else
                            data[i] = value[i];
                    }
                }
                else
                {
                    data = value; 
                }
            }
        }

        public string DataString
        {
            get 
            { 
                return System.BitConverter.ToString(data); 
            }
            set 
            {
                if (!Validator.validate_data(value))
                {
                    value = "00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00";
                }

                // Convert hex string to byte array
                data = HexStringConverter.ToByteArray(value);
            }
        }

        private bool compare_byte_array(byte[] ar1, byte[] ar2)
        {
            if (ar1.Length != ar2.Length) return false;

            for (int i = 0; i < ar1.Length; i++)
            {
                if (ar1[i] != ar2[i])
                    return false;
            }

            return true;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (this.GetType() != obj.GetType()) return false;

            Event ev = (Event)obj;


            // Return true if the fields match (other than name/description):
            return 
                (broadcast == ev.Broadcast) &&
                compare_byte_array(master_address, ev.Master_Address) &&
                compare_byte_array(slave_address, ev.Slave_Address) &&
                (control == ev.Control) &&
                (datasize == ev.DataSize) &&
                compare_byte_array(data, ev.Data);
        }

        
    }
}
