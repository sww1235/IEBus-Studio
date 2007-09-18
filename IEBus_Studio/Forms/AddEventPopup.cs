using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IEBus_Studio
{
    public partial class AddEventPopup : Form
    {
        private DeviceManager _deviceManager;
        private EventManager _eventManager;
        private Form1 _mainForm;

        public AddEventPopup(DeviceManager deviceManager, EventManager eventManager, Form1 mainForm)
        {
            InitializeComponent();
            _deviceManager = deviceManager;
            _eventManager = eventManager;
            _mainForm = mainForm;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            _mainForm.Enabled = true;
            _mainForm.Focus();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            // Get the address as a strings
            string masterAddressStr = masterAddress.Text;
            string slaveAddressStr = slaveAddress.Text;

            // if the master address string doesnt start with 0x
            if (masterAddressStr.Substring(0, 2) != "0x")
            {
                // Display an error
                masterErrorLabel.Text = "Address must be a hex string starting with 0x";
                this.Width = masterErrorLabel.Width + 10;
                if (this.Width < 195) this.Width = 195;
                return;
            }

            // if the slave address string doesnt start with 0x
            if (slaveAddressStr.Substring(0, 2) != "0x")
            {
                // Display an error
                slaveErrorLabel.Text = "Address must be a hex string starting with 0x";
                this.Width = slaveErrorLabel.Width + 10;
                if (this.Width < 195) this.Width = 195;
                return;
            }


            // if the master address string is too long
            if (masterAddressStr.Length > 8)
            {
                // Display an error
                masterErrorLabel.Text = "Address too long, maximum length is 3 bytes.";
                this.Width = masterErrorLabel.Width + 10;
                if (this.Width < 195) this.Width = 195;
                return;
            }

            // if the slave address string is too long
            if (slaveAddressStr.Length > 8)
            {
                // Display an error
                slaveErrorLabel.Text = "Address too long, maximum length is 3 bytes.";
                this.Width = slaveErrorLabel.Width + 10;
                if (this.Width < 195) this.Width = 195;
                return;
            }

            int master_address = -1;
            int slave_address = -1;

            // try to convert the master address string to an integer
            try
            {
                master_address = Convert.ToInt32(masterAddressStr.Substring(2, masterAddressStr.Length - 2), 16);
            }
            catch (Exception exc)
            {
                // if it fails, display an error stating that its an invalid hex string
                masterErrorLabel.Text = "Address must be a valid hex string starting with 0x";
                this.Width = masterErrorLabel.Width + 10;
                if (this.Width < 195) this.Width = 195;
                return;
            }

            // try to convert the slave address string to an integer
            try
            {
                slave_address = Convert.ToInt32(slaveAddressStr.Substring(2, slaveAddressStr.Length - 2), 16);
            }
            catch (Exception exc)
            {
                // if it fails, display an error stating that its an invalid hex string
                slaveErrorLabel.Text = "Address must be a valid hex string starting with 0x";
                this.Width = slaveErrorLabel.Width + 10;
                if (this.Width < 195) this.Width = 195;
                return;
            }

            // if the master device isn't already defined, create and define it
            if (!_mainForm.isDeviceDefined(master_address))
            {
                Device device = new Device(master_address, _mainForm.parseDeviceAddress(Convert.ToString(master_address,16)), "Describe me.");
                _deviceManager.AddDevice(device);
            }

            // if the master device isn't already defined, create and define it
            if (!_mainForm.isDeviceDefined(slave_address))
            {
                Device device = new Device(slave_address, _mainForm.parseDeviceAddress(Convert.ToString(slave_address, 16)), "Describe me.");
                _deviceManager.AddDevice(device);
            }

            // add the device to the device list
            int broadcast = 1;
            ControlByte control = (ControlByte)0xF;
            Event ev = new Event("Unkown", "Describe me.", broadcast, master_address, slave_address, control, "");
            _eventManager.addEvent(ev);

            this.Hide();
            _mainForm.Enabled = true;
            _mainForm.Focus();
            _mainForm.displayDeviceList();
        }
    }
}