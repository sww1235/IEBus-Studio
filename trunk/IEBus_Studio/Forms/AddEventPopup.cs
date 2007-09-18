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
            controlCombo.SelectedIndex = 15;
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
                this.Width = 135 + masterErrorLabel.Width + 10;
                if (this.Width < 265) this.Width = 265;
                return;
            }
            else
            {
                masterErrorLabel.Text = "";
            }

            // if the slave address string doesnt start with 0x
            if (slaveAddressStr.Substring(0, 2) != "0x")
            {
                // Display an error
                slaveErrorLabel.Text = "Address must be a hex string starting with 0x";
                this.Width = 135 + slaveErrorLabel.Width + 10;
                if (this.Width < 265) this.Width = 265;
                return;
            }
            else
            {
                slaveErrorLabel.Text = "";
            }


            // if the master address string is too long
            if (masterAddressStr.Length > 8)
            {
                // Display an error
                masterErrorLabel.Text = "Address too long, maximum length is 3 bytes.";
                this.Width = 135 + masterErrorLabel.Width + 10;
                if (this.Width < 265) this.Width = 265;
                return;
            }
            else
            {
                masterErrorLabel.Text = "";
            }

            // if the slave address string is too long
            if (slaveAddressStr.Length > 8)
            {
                // Display an error
                slaveErrorLabel.Text = "Address too long, maximum length is 3 bytes.";
                this.Width = 135 + slaveErrorLabel.Width + 10;
                if (this.Width < 265) this.Width = 265;
                return;
            }
            else
            {
                slaveErrorLabel.Text = "";
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
                this.Width = 135 + masterErrorLabel.Width + 10;
                if (this.Width < 265) this.Width = 265;
                return;
            }

            // if the conversion of master address from string to integer was a success, remove an error messages
            masterErrorLabel.Text = "";

            // try to convert the slave address string to an integer
            try
            {
                slave_address = Convert.ToInt32(slaveAddressStr.Substring(2, slaveAddressStr.Length - 2), 16);
            }
            catch (Exception exc)
            {
                // if it fails, display an error stating that its an invalid hex string
                slaveErrorLabel.Text = "Address must be a valid hex string starting with 0x";
                this.Width = 135 + slaveErrorLabel.Width + 10;
                if (this.Width < 265) this.Width = 265;
                return;
            }

            // if the conversion of slave address from string to integer was a success, remove an error messages
            slaveErrorLabel.Text = "";

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

            // get the control
            ControlByte control = (ControlByte)System.Enum.Parse(typeof(ControlByte), (string)controlCombo.SelectedItem);

            // get the broadcast bit
            int broadcast = 1;
            if (!broadcastCheckbox.Checked)
                broadcast = 0;

            // create the event and add it to the event list
            Event ev = new Event("Unkown", "Describe me.", broadcast, master_address, slave_address, control, "");
            _eventManager.addEvent(ev);

            this.Hide();
            _mainForm.Enabled = true;
            _mainForm.Focus();
            _mainForm.displayDeviceList();
            _mainForm.displayEventList();
        }
    }
}