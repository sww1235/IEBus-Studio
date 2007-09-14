using System.Collections;
using System.IO;
using System.Xml.Serialization;
using System;
[Serializable]
    public class DeviceManager
    {
        private System.Collections.Generic.List<IEBus_Studio.Device> _devices;
        public DeviceManager()
        {
            _devices = new System.Collections.Generic.List<IEBus_Studio.Device>();
        }
        public IEBus_Studio.Device this[string Name]
        {
            get
            {
                foreach (IEBus_Studio.Device dev in _devices)
                {
                    if (dev.Name == Name)
                        return dev;
                }
                return null;
            }
            set
            {
                foreach (IEBus_Studio.Device dev in _devices)
                {
                    if (dev.Name == Name)
                        _devices[_devices.IndexOf(dev)] = value;
                }
            }
        }
        public IEBus_Studio.Device this[int Index]
        {
            get
            {
                if (_devices.Count > Index)
                    return _devices[Index];
                else
                    return null;
            }
            set
            {
                if (_devices.Count > Index)
                    _devices[Index] = value;
            }
        }
        public System.Collections.Generic.List<IEBus_Studio.Device> Devices
        {
            get
            {
                return _devices;
            }
            set
            {
                _devices = value;
            }
        }
        public void AddDevice(IEBus_Studio.Device Device)
        {
            _devices.Add(Device);
        }
        public void AddDevice(int Address, string Name, string Description)
        {
            _devices.Add(new IEBus_Studio.Device(Address, Name, Description));
        }
        public void RemoveDevice(IEBus_Studio.Device Device)
        {
            if (_devices.Contains(Device))
                _devices.Remove(Device);
        }
        public string GetDeviceName(int address)
        {
            foreach (IEBus_Studio.Device device in _devices)
            {
                if (device.Address == address)
                    return device.Name;
            }

            return string.Empty;
        }
        public IEBus_Studio.Device GetDeviceByName(string name)
        {
            foreach (IEBus_Studio.Device device in _devices)
            {
                if (device.Name == name)
                    return device;
            }

            return null;
        }
        public IEBus_Studio.Device GetDeviceByAddress(int address)
        {
            foreach (IEBus_Studio.Device device in _devices)
            {
                if (device.Address == address)
                    return device;
            }

            return null;
        }
    }
