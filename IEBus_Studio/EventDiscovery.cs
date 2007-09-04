using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace IEBus_Studio
{
    class DiscoveredEvent
    {
        private Event theEvent;
        private int numberOfInstances;

        public DiscoveredEvent(Event theEvent)
        {
            this.theEvent = theEvent;
            numberOfInstances = 0;
        }

        public Event TheEvent
        {
            get { return theEvent; }
            set { theEvent = value; }
        }

        public int NumberOfInstances
        {
            get { return numberOfInstances; }
            set { numberOfInstances = value; }
        }

        public void addInstance()
        {
            numberOfInstances++;
        }
    }

    class EventDiscovery
    {
        private ArrayList discoveredEvents;
        private long timeLeft;
        private Timer timer;
        private Form formToLock;
        private Label timeLeftLabel;

        public EventDiscovery()
        {
            discoveredEvents = new ArrayList();
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

        public long TimeLeft
        {
            get { return timeLeft; }
            set { timeLeft = value; }
        }

        public void Start(Form form, Label label)
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
            for (int i = 0; i < discoveredEvents.Count; i++)
            {
                DiscoveredEvent discoveredEvent = (DiscoveredEvent)discoveredEvents[i];

                // If the event has already happened since discovery begain
                if (discoveredEvent.Equals(theEvent))
                {
                    // increment the number of instances found for that evnet
                    discoveredEvent.addInstance();

                    // if the discovered event is the first one in the list
                    // and it has been found more than the event above it
                    if (i != 0 && discoveredEvent.NumberOfInstances > ((DiscoveredEvent)discoveredEvents[i - 1]).NumberOfInstances)
                    {
                        // move the the discovered event higher up in the list
                        DiscoveredEvent temp = (DiscoveredEvent)discoveredEvents[i];
                        discoveredEvents[i] = discoveredEvents[i - 1];
                        discoveredEvents[i - 1] = temp;
                    }
                }
                else
                {
                    // This is the first time the event has happend 
                    // during discovery so add it to the list
                    discoveredEvents.Add(theEvent);
                }
            }
        }
    }
}
