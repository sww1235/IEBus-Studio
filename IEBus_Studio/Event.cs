using System;
using System.Collections.Generic;
using System.Text;

namespace IEBus_Studio
{
    public class Event : IComparable
    {
        private string _name;
        private string _description;
        private string _broadcast;
        private int _master;
        private int _slave;
        private string _control;
        private short _size;
        private System.Collections.Generic.List<string> _variables;

        public Event(string Name, string Description, string Broadcast, int Master, int Slave, string Control, short size, string Data)
        {
            _variables = new System.Collections.Generic.List<string>();
            _name = Name;
            _description = Description;
            _broadcast = Broadcast;
            _master = Master;
            _slave = Slave;
            _control = Control;
            _size = size;

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
        public string Broadcast
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
        public string Control
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
        public short Size
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
            if (obj is dllCreator.Event)
            {
                dllCreator.Event temp = (dllCreator.Event)obj;
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
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (this.GetType() != obj.GetType())
                return false;
            Event ev = (Event)obj;

            bool variables_match = this._variables.Count == ev.Variables.Count;

            if (variables_match)
            {
                for (int i = 0; i < this._variables.Count; i++)
                {
                    if (this._variables[i] != ev.Variables[i])
                        variables_match = false;
                }
            return (this._master == ev.Master) &&
                   (this._slave == ev.Slave) &&
                   (this._control == ev.Control) &&
                   (this._broadcast == ev.Broadcast) &&
                   (this._size == ev.Size) &&
                   (variables_match);
            }
            return false;
        }
    }
}
