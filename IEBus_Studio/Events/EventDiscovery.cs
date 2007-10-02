using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace IEBus_Studio
{
    class EventDiscovery
    {
        private System.Collections.Generic.List<Event> discoveredEvents;
        private long timeLeft;
        private Timer timer;
        private Form formToLock;
        private ToolStripStatusLabel timeLeftLabel;

        public EventDiscovery()
        {
            discoveredEvents = new System.Collections.Generic.List<Event>();
            timeLeft = 0;
            timer = new Timer();
            timer.Tick += new EventHandler(reduceTimeLeft);
            timer.Interval = 1000; // 1 second
        }

        public void reduceTimeLeft(object obj, EventArgs args)
        {
            timeLeft--;
            timeLeftLabel.Text = timeLeft + " seconds left";

            if (timeLeft == 0)
            {
                timer.Stop();
                formToLock.Enabled = true;
                timeLeftLabel.Text = "";
            }
        }

        public System.Collections.Generic.List<Event> DiscoveredEvents
        {
            get { return discoveredEvents; }
            set { discoveredEvents = value; }
        }

        public long TimeLeft
        {
            get { return timeLeft; }
            set { timeLeft = value; }
        }

        public Form FormToLock
        {
            get { return FormToLock; }
            set { formToLock = value; }
        }

        public ToolStripStatusLabel TimeLeftLabel
        {
            get { return timeLeftLabel; }
            set { timeLeftLabel = value; }
        }

        public void Start(Form form, ToolStripStatusLabel label)
        {
            timer.Start();
            formToLock = form;
            timeLeftLabel = label;

            formToLock.Enabled = false;
            timeLeftLabel.Text = timeLeft + " seconds left";
        }

        public bool discoveryingEvents()
        {
            if (timer.Enabled)
                return true;
            return false;
        }

        public void addEvent(Event theEvent)
        {
                discoveredEvents.Add(theEvent);
        }
    }
}
