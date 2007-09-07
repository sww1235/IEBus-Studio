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
        private System.Collections.Generic.KeyValuePair<int, int> _constants;
        private System.Collections.Generic.KeyValuePair<int, string> _variables;
        public Event(string Name, string Description, int Master, int Slave, string Data)
        {
            _name = Name;
            _description = Description;
            _master = Master;
            _slave = Slave;
            string[] strBytes = Data.Split(":");
        }
    }
}
