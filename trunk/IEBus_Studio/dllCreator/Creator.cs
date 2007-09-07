using Microsoft.VisualBasic;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Windows.Forms;
using System.Text;
namespace dllCreator
{
    public class Creator
    {
        private string _Make;
        private string _Model;
        private int _Year;
        private DeviceManager _dm;
        private System.Collections.Generic.List<Event> _events;
        private string CreateCode()
        {
            StringBuilder sBuilder = new StringBuilder();
            sBuilder.AppendLine("Imports System");
            sBuilder.AppendLine("Imports System.Windows.Forms");
            sBuilder.AppendLine("Namespace " + _Make);
            sBuilder.AppendLine("Public Class " + _Model + "_" + _Year);
            sBuilder.AppendLine("Public WithEvents sPort as New System.IO.Ports.SerialPort");
            for (int x = 0; x < Events.Count; x++)
            {
                sBuilder.AppendLine("''' <summary>");
                sBuilder.AppendLine("''' " + Events[x].Description);
                sBuilder.AppendLine("''' </summary>");
                string args = string.Empty;
                for (int y = 0; y < Events[x].Variables.Count; y++)
                {
                    if (Events[x].Variables[y].StartsWith("%"))
                        args += ", ByVal " + Events[x].Variables[y].Remove(0, 1) + " as Integer";
                }
                sBuilder.AppendLine("Public Event " + Events[x].Name + "(ByVal Master as Integer, ByVal Slave as Integer" + args + ")");
            }
            sBuilder.AppendLine("''' <summary>");
            sBuilder.AppendLine("''' Specific devices for this car.");
            sBuilder.AppendLine("''' </summary>");
            sBuilder.AppendLine("Public Enum CarDevices").AppendLine();
            for (int x = 0; x < DeviceManager.Devices.Count; x++)
            {
                sBuilder.AppendLine("''' <summary>");
                sBuilder.AppendLine("''' " + DeviceManager[x].Description);
                sBuilder.AppendLine("''' </summary>");
                sBuilder.AppendLine(DeviceManager[x].Name.Replace(" ", "_") + " = " + DeviceManager[x].Address);
            }
            sBuilder.AppendLine("End Enum");
            sBuilder.AppendLine("Public Sub OpenPort(ByVal PortName as String, ByVal BaudRate as Integer, ByVal DataBits as Integer, ByVal Parity as System.IO.Ports.Parity, ByVal StopBits as System.IO.Ports.StopBits, ByVal Handshake as System.IO.Ports.Handshake)");
            sBuilder.AppendLine("If sPort.IsOpen Then sPort.Close"); 
            sBuilder.AppendLine("Try");
            sBuilder.AppendLine("sPort.PortName = PortName");
            sBuilder.AppendLine("sPort.BaudRate = BaudRate");
            sBuilder.AppendLine("sPort.DataBits = DataBits");
            sBuilder.AppendLine("sPort.Parity = Parity");
            sBuilder.AppendLine("sPort.StopBits = StopBits");
            sBuilder.AppendLine("sPort.Handshake = Handshake");
            sBuilder.AppendLine("sPort.Open()");
            sBuilder.AppendLine("Catch ex as Exception");
            sBuilder.AppendLine("MessageBox.Show(ex.Message)");
            sBuilder.AppendLine("End Try");
            sBuilder.AppendLine("End Sub");
            sBuilder.AppendLine("Public Sub ClosePort()");
            sBuilder.AppendLine("If sPort.IsOpen Then sPort.Close");
            sBuilder.AppendLine("End Sub");
            sBuilder.AppendLine("Public Sub DataReceived(ByVal sender as object, ByVal e as System.IO.Ports.SerialDataReceivedEventArgs) Handles sPort.DataReceived");
            sBuilder.AppendLine("");
            sBuilder.AppendLine("End Sub");
            sBuilder.AppendLine("End Class");
            sBuilder.AppendLine("End Namespace");
            System.Console.WriteLine(sBuilder.ToString());
            return sBuilder.ToString();
        }
        private void CompileCode(string strCode, string OutputFolder)
        {
            VBCodeProvider vbCP = new VBCodeProvider();
            CompilerParameters comParams = new CompilerParameters();
            comParams.OutputAssembly = OutputFolder + "\\" + _Make + "." + _Model + "." + _Year + ".dll";
            comParams.ReferencedAssemblies.Add("System.dll");
            comParams.ReferencedAssemblies.Add("System.Data.dll");
            comParams.ReferencedAssemblies.Add("System.Xml.dll");
            comParams.ReferencedAssemblies.Add("mscorlib.dll");
            comParams.ReferencedAssemblies.Add("System.Windows.Forms.dll");
            comParams.WarningLevel = 3;
            comParams.TreatWarningsAsErrors = false;
            comParams.CompilerOptions = "/target:library /doc /optimize";
            comParams.GenerateExecutable = false;
            comParams.GenerateInMemory = false;

            CompilerResults comResults = vbCP.CompileAssemblyFromSource(comParams, strCode);
            foreach (string strOut in comResults.Output)
            {
                //Console.WriteLine(strOut);
            }

            if (comResults.Errors.Count > 0)
            {
                foreach (CompilerError cErr in comResults.Errors)
                {
                    //Console.WriteLine(cErr.ErrorNumber + ": " + cErr.ErrorText);
                }
                MessageBox.Show("Errors occoured", "Errors", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Creator(string Make, string Model, int Year)
        {
            _Make = Make;
            _Model = Model;
            _Year = Year;
            _dm = new DeviceManager();
            _events = new System.Collections.Generic.List<Event>();
        }
        public DeviceManager DeviceManager
        {
            get { return _dm; }
        }
        public System.Collections.Generic.List<Event> Events
        {
            get { return _events; }
        }
        public void CompileDLL(string OutputFolder)
        {
            string dynamicCode = CreateCode();
            CompileCode(dynamicCode, OutputFolder);
        }
        public void AddEvent(string Name, string Description, int Master, int Slave, string Data)
        {
            Event newEvent = new Event(Name, Description, Master, Slave, Data);
            _events.Add(newEvent);
        }
    }
}