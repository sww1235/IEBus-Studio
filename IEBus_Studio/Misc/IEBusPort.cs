using System;
using System.Collections.Generic;
using System.Text;

namespace IEBus_Studio.Misc
{
    class IEBusPort : System.IO.Ports.SerialPort
    {
        public delegate void EventReceivedHandler(IEBus_Studio.Event nEvent);
        public event EventReceivedHandler EventReceived;

        public delegate void TextReceivedHandler(string Text);
        public event TextReceivedHandler TextReceived;

        private string leftOverText = string.Empty;

        public IEBusPort()
            : base()
        {
            this.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(IEBusPort_DataReceived);
        }
        public IEBusPort(System.ComponentModel.IContainer Container)
            : base(Container)
        {
            this.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(IEBusPort_DataReceived);
        }
        public bool Connect(string PortName)
        {
            if (this.IsOpen) { this.Close(); }
            try
            {
                this.PortName = PortName;
                this.BaudRate = 9600;
                this.DataBits = 8;
                this.Parity = System.IO.Ports.Parity.None;
                this.StopBits = System.IO.Ports.StopBits.One;
                this.Handshake = System.IO.Ports.Handshake.None;
                this.Open();
                return true;
            }
            catch { return false; }
        }
        public void Disconnect()
        {
            if (this.IsOpen) { this.Close(); }
        }
        void IEBusPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string text = base.ReadExisting();
            TextReceived(text);
            text = leftOverText + text;
            if (text.IndexOf('~') > -1)
            {
                while (text.IndexOf('~', text.IndexOf('~') + 1) > text.IndexOf('~'))
                {
                    if (text.Contains("~"))
                    {
                        int wrkStart = text.IndexOf('~') + 1;
                        int wrkEnd = text.IndexOf('~', wrkStart);
                        string wrkMessage = text.Substring(wrkStart, wrkEnd - wrkStart);
                        if (wrkEnd < text.Length)
                            text = text.Substring(wrkEnd);

                        if (!wrkMessage.Contains("*"))
                        {
                            IEBus_Studio.Event newEvent = new IEBus_Studio.Event();
                            newEvent.Name = "Undefined";
                            newEvent.Description = "Undefined";
                            newEvent.Broadcast = Convert.ToInt32(wrkMessage.Substring(0, 2), 16);
                            newEvent.Master = Convert.ToInt32(wrkMessage.Substring(2, 4), 16);
                            newEvent.Slave = Convert.ToInt32(wrkMessage.Substring(6, 4), 16);
                            newEvent.Control = (IEBus_Studio.ControlByte)Convert.ToInt32(wrkMessage.Substring(10, 2), 16);
                            int dSize = Convert.ToInt32(wrkMessage.Substring(12, 2), 16);
                            List<string> vars = new List<string>();
                            for (int x = 0; x < dSize; x++)
                            {
                                vars.Add(wrkMessage.Substring(14 + (x * 2), 2));
                            }
                            newEvent.Variables = vars;
                            EventReceived(newEvent);
                        }
                    }
                }
            }
            leftOverText = text;
        }
        public void Write(IEBus_Studio.Event nEvent)
        {
            this.Write("~");
            this.Write(BitConverter.GetBytes(nEvent.Broadcast), 0, 1);
            this.Write(BitConverter.GetBytes(nEvent.Master), 0, 2);
            this.Write(BitConverter.GetBytes(nEvent.Slave), 0, 2);
            this.Write(BitConverter.GetBytes((int)nEvent.Control), 0, 1);
            this.Write(BitConverter.GetBytes(nEvent.Variables.Count), 0, 1);
            foreach (string var in nEvent.Variables)
            {
                this.Write(new byte[] { System.Convert.ToByte(var, 16) }, 0, 1);
            }
            this.Write("^");
        }
        public void Write(IEBus_Studio.Event nEvent, List<string> Values)
        {
            this.Write("~");
            this.Write(BitConverter.GetBytes(nEvent.Broadcast), 0, 1);
            this.Write(BitConverter.GetBytes(nEvent.Master), 0, 2);
            this.Write(BitConverter.GetBytes(nEvent.Slave), 0, 2);
            this.Write(BitConverter.GetBytes((int)nEvent.Control), 0, 1);
            this.Write(BitConverter.GetBytes(nEvent.Variables.Count), 0, 1);

            int replaceIndex = 0;
            foreach (string var in nEvent.Variables)
            {
                if (var.Contains("%"))
                {
                    int replaceValue = Convert.ToInt32(Values[replaceIndex]);
                    this.Write(BitConverter.GetBytes(replaceValue), 0, 1);
                    replaceIndex++;
                }
                else
                    this.Write(new byte[] { System.Convert.ToByte(var, 16) }, 0, 1);

            }
            this.Write("^");
        }
    }

}
