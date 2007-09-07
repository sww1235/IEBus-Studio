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
        private EventManager eventManager;

        public AddEventPopup(EventManager eventManager)
        {
            InitializeComponent();
            this.eventManager = eventManager;
        }

        private void addDiscoveredEvent_Click(object sender, EventArgs e)
        {
            
        }

        private void cancelDiscoveredEvent_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Dispose();
        }
    }
}