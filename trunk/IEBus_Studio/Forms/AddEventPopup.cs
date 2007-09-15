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
        private Event _event;
        private Form1 _mainForm;

        public AddEventPopup(DeviceManager deviceManager, EventManager eventManager, Event theEvent, Form1 callerForm)
        {
            InitializeComponent();
            _deviceManager = deviceManager;
            _eventManager = eventManager;           
            _event = theEvent;
            _mainForm = callerForm;
        }

        private void addDiscoveredEvent_Click(object sender, EventArgs e)
        {
            // Set the events name and description
            _event.Name = eventName.Text;
            _event.Description = eventDescription.Text;

            _eventManager.addEvent(_event);

            // Create the master device of the event doesnt already exists
            if (!_mainForm.isDeviceDefined(_event.Master))
            {
                Device device = new Device(_event.Master, _mainForm.parseDeviceAddress(Convert.ToString(_event.Master, 16)), "");
                _deviceManager.AddDevice(device);
            }

            // Create the slave device of the event doesnt already exists
            if (!_mainForm.isDeviceDefined(_event.Slave))
            {
                Device device = new Device(_event.Slave, _mainForm.parseDeviceAddress(Convert.ToString(_event.Slave, 16)), "");
                _deviceManager.AddDevice(device);
            }

            this.Hide();
            _mainForm.Enabled = true;
            _mainForm.Focus();
        }

        private void cancelDiscoveredEvent_Click(object sender, EventArgs e)
        {
            this.Hide();
            _mainForm.Enabled = true;
        }

        void AddEventPopup_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Hide();
            _mainForm.Enabled = true;
        }

    }
}