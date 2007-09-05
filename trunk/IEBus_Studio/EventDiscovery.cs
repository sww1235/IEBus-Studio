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
            numberOfInstances = 1;
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

        public override bool Equals(object obj)
        {
            if(obj == null) return false;

            if (this.GetType() != obj.GetType()) return false;

            DiscoveredEvent devent = (DiscoveredEvent)obj;

            return this.TheEvent.Equals(devent.TheEvent);
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

        public ArrayList DiscoveredEvents
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

        public Label TimeLeftLabel
        {
            get { return timeLeftLabel; }
            set { timeLeftLabel = value; }
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
            bool eventAdded = false;

            for (int i = 0; i < discoveredEvents.Count; i++)
            {
                DiscoveredEvent discoveredEvent = (DiscoveredEvent)discoveredEvents[i];

                // If the event has already happened since discovery begain
                if (discoveredEvent.TheEvent.Equals(theEvent))
                {
                    // increment the number of instances found for that evnet
                    discoveredEvent.addInstance();

                    // while the discovered event is not the first one in the list
                    // and it has been found more than the event above it
                    int j = i;
                    while (j != 0 && ((DiscoveredEvent)discoveredEvents[j]).NumberOfInstances > ((DiscoveredEvent)discoveredEvents[j - 1]).NumberOfInstances)
                    {
                        // move the the discovered event higher up in the list
                        DiscoveredEvent temp = (DiscoveredEvent)discoveredEvents[j];
                        discoveredEvents[j] = discoveredEvents[j - 1];
                        discoveredEvents[j - 1] = temp;

                        // and compare this event with the one above that
                        j--;
                    }


                    // set the boolean that the event has been added
                    eventAdded = true;
                }
            }

            // if the event wasn't added because it wasn't 
            // already in the list of discovered events
            if (!eventAdded)
            {
                // add it to the list of discovered events
                discoveredEvents.Add(new DiscoveredEvent(theEvent));
            }


        }
    }
}
