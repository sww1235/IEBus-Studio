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
        private EventManager _eventManager;
        private Event _event;
        private Form _mainForm;

        public AddEventPopup(EventManager eventManager, Event theEvent, Form callerForm)
        {
            InitializeComponent();
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

            this.Hide();
            _mainForm.Enabled = true;
        }

        private void cancelDiscoveredEvent_Click(object sender, EventArgs e)
        {
            this.Hide();
            _mainForm.Enabled = true;
        }
    }
}