using System;
using System.Collections.Generic;
using System.Text;

namespace IEBus_Studio
{
    public class Event
    {
        private string _name;
        private string _description;
        private char _broadcast;
        private int _master;
        private int _slave;
        private char _control;
        private ushort _size;
        private System.Collections.Generic.List<string> _variables;

        public Event(string Name, string Description, char Broadcast, int Master, int Slave, char Control, ushort size, string Data)
        {
            _variables = new System.Collections.Generic.List<string>();
            _name = Name;
            _description = Description;
            _broadcast = Broadcast;
            _master = Master;
            _slave = Slave;
            _control = Control;
            _size = 0;

            string[] strBytes = Data.Split(':');
            for (int x = 0; x < strBytes.Length; x++)
            {
                    _variables.Add(strBytes[x]);
            }
        }
        public System.Collections.Generic.List<string> Variables
        {
            get { return _variables;}
        }
        public int Master
        {
            get
            {
                return _master;
            }
            set
            {
                _master = value;
            }
        }
        public int Slave
        {
            get
            {
                return _slave;
            }
            set
            {
                _slave = value;
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
        public char Broadcast
        {
            get
            {
                return _broadcast;
            }
            set
            {
                _broadcast = value;
            }
        }
        public char Control
        {
            get
            {
                return _control;
            }
            set
            {
                _control = value;
            }
        }
        public ushort Size
        {
            get
            {
                return _size;
            }
            set
            {
                _size = value;
            }
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (this.GetType() != obj.GetType())
                return false;
            Event ev = (Event)obj;

            return (this._master == ev.Master) &&
                   (this._slave == ev.Slave) &&
                   (this._control == ev.Control) &&
                   (this._broadcast == ev.Broadcast) &&
                   (this._size == ev.Slave) &&
                   (this.Variables.Equals(ev.Variables));
                    
        }
    }
}
