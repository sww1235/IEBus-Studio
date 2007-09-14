using System;
using System.Collections.Generic;
using System.Text;

namespace IEBus_Studio
{
    public class Event : IComparable
    {
        private string _name;
        private string _description;
        private int _broadcast;
        private int _master;
        private int _slave;
        private IEBus_Studio.ControlByte _control;
        private System.Collections.Generic.List<string> _variables;
        public Event()
        {
            _variables = new System.Collections.Generic.List<string>();
        }
        public Event(string Name, string Description, int Broadcast, int Master, int Slave, IEBus_Studio.ControlByte Control,  string Data)
        {
            _variables = new System.Collections.Generic.List<string>();
            _name = Name;
            _description = Description;
            _broadcast = Broadcast;
            _master = Master;
            _slave = Slave;
            _control = Control;

            if (Data != "" && Data != null)
            {
                string[] strBytes = Data.Split(':');
                for (int x = 0; x < strBytes.Length; x++)
                {
                    _variables.Add(strBytes[x]);
                }
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
        public int Broadcast
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
        public IEBus_Studio.ControlByte Control
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
        public int Size
        {
            get
            {
                return _variables.Count;
            }
        }
        public int DynamicVariableCount
        {
            get
            {
                int vCount = 0;
                for (int x = 0; x < _variables.Count; x++)
                {
                    if (_variables[x].Contains("%"))
                        vCount++;
                }
                return vCount;
            }
        }
        public int CompareTo(object obj)
        {
            if (obj is Event)
            {
                Event temp = (Event)obj;
                int CompareResult = 0;

                int C1 = this.Variables.Count;
                int C2 = temp.Variables.Count;

                if (C1 > C2)
                    CompareResult = 1;
                else if (C1 == C2)
                    CompareResult = 0;
                else
                    CompareResult = -1;

                C1 = this.DynamicVariableCount;
                C2 = temp.DynamicVariableCount;

                if (CompareResult == 0)
                {
                    if (C1 > C2)
                        CompareResult = 1;
                    else if (C1 == C2)
                        CompareResult = 0;
                    else
                        CompareResult = -1;
                }

                // If the Matches are equal, sort based on the Pattern.
                if (CompareResult == 0)
                {
                    for (int x = 0; x < _variables.Count; x++)
                    {
                        CompareResult = System.String.Compare(
                            this.Variables[x],
                            temp.Variables[x]);
                        if (CompareResult != 0)
                            break;
                    }
                }
                return CompareResult;
            }
            throw new ArgumentException("object is not an Event");
        }
    }
}
