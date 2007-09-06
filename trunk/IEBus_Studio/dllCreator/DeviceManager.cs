using System.Collections;
public class DeviceManager
{
    private ArrayList _devices;
    public void DeviceManager()
    {
        _devices = new ArrayList();
    }
    public Device this[string Name]
    {
        get
        {
            foreach (Device dev in _devices)
            {
                if (dev.Name == Name)
                    return dev;
            }
            return null;
        }
        set
        {
            foreach (Device dev in _devices)
            {
                if (dev.Name == Name)
                    dev = value;
            }
        }
    }
    public Device this[int Index]
    {
        get
        {
            if (_devices.Count > Index)
                return _devices(Index);
            else
                return null;
        }
        set
        {
            if (_devices.Count > Index)
                _devices(Index) = value;
        }
    }
    public ArrayList Devices
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
    public void AddDevice(Device Device)
    {
        _devices.Add(Device);
    }
    public void AddDevice(int Address, string Name, string Description)
    {
        _devices.Add(new Device(Address, Name, Description));
    }
    public void RemoveDevice(Device Device)
    {
        if (_devices.Contains(Device))
            _devices.Remove(Device);
    }
}
