namespace IEBus_Studio
{
    public class Device
    {
        private int _address;
        private string _name;
        private string _description;
        public Device()
        {
            _address = -1;
            _name = string.Empty;
            _description = string.Empty;
        }
        public Device(int address, string name, string description)
        {
            _address = address;
            _name = name;
            _description = description;
        }
        public int Address
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