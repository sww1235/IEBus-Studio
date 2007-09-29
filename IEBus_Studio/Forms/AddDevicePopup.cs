using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IEBus_Studio
{
    public partial class AddDevicePopup : Form
    {
        private DeviceManager _deviceManager;
        private Form1 _mainForm;

        public AddDevicePopup(DeviceManager deviceManager, Form1 mainForm)
        {
            InitializeComponent();
            _deviceManager = deviceManager;
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
            // Get the address as a string
            string addressStr = deviceAddress.Text;

            // if the address string doesnt start with 0x
            if (addressStr.Substring(0, 2) != "0x")
            {
                // Display an error
                errorLabel.Text = "Address must be a hex string starting with 0x";
                this.Width = errorLabel.Width + 10;
                if (this.Width < 195) this.Width = 195;
                return;
            }

            // if the address string is too long
            if (addressStr.Length > 8)
            {
                // Display an error
                errorLabel.Text = "Address too long, maximum length is 3 bytes.";
                this.Width = errorLabel.Width + 10;
                if (this.Width < 195) this.Width = 195;
                return;
            }

            int address = -1;

            // try to convert the address string to an integer
            try
            {
                address = Convert.ToInt32(addressStr.Substring(2, addressStr.Length - 2), 16);
            }
            catch (Exception exc)
            {
                // if it fails, display an error stating that its an invalid hex string
                errorLabel.Text = "Address must be a valid hex string starting with 0x";
                this.Width = errorLabel.Width + 10;
                if (this.Width < 195) this.Width = 195;
                return;
            }
            
            // if the device has already been defined, display an error
            if (_mainForm.DeviceManager.isDeviceDefined(address))
            {
                errorLabel.Text = "This device is already defined.";
                this.Width = errorLabel.Width + 10;
                if (this.Width < 195) this.Width = 195;
                return;
            }

            // add the device to the device list
            _deviceManager.AddDevice(address, addressStr, "Describe me.");
            
            this.Hide();
            _mainForm.Enabled = true;
            _mainForm.Focus();
            _mainForm.displayDeviceList();
        }

        void AddDevicePopup_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Hide();
            _mainForm.Enabled = true;
            _mainForm.Focus();
        }

    }
}