using System;
using System.Collections.Generic;
using System.Text;

namespace dllCreator
{
    public class Event
    {
        private string _name;
        private string _description;
        private int _master;
        private int _slave;
        private System.Collections.Generic.List<string> _variables;
        public Event(string Name, string Description, int Master, int Slave, string Data)
        {
            _variables = new System.Collections.Generic.List<string>();
            _name = Name;
            _description = Description;
            _master = Master;
            _slave = Slave;
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
    }
}
