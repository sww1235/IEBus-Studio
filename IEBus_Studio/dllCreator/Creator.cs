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
            sBuilder.AppendLine("Dim leftovertext as string = String.Empty");
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
                sBuilder.AppendLine("Public Event " + Events[x].Name + "(ByVal Master as CarDevice, ByVal Slave as CarDevice" + args + ")");
            }
            sBuilder.AppendLine("''' <summary>");
            sBuilder.AppendLine("''' Specific devices for this car.");
            sBuilder.AppendLine("''' </summary>");
            sBuilder.AppendLine("Public Enum CarDevice").AppendLine();
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
            sBuilder.AppendLine("Public Sub DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles sPort.DataReceived");
            sBuilder.AppendLine("Dim text As String = CType(sender, System.IO.Ports.SerialPort).ReadExisting");
            sBuilder.AppendLine("text = leftovertext + text");
            sBuilder.AppendLine("Do While (text.IndexOf(\"^\"c) > text.IndexOf(\"~\"c))");
            sBuilder.AppendLine("If (text.Contains(\"~\")) Then");
            sBuilder.AppendLine("Dim wrkStart As Integer = text.IndexOf(\"~\"c) + 1");
            sBuilder.AppendLine("Dim wrkEnd As Integer = text.IndexOf(\"^\"c)");
            sBuilder.AppendLine("Dim wrkMessage As String = text.Substring(wrkStart, wrkEnd - wrkStart)");
            sBuilder.AppendLine("Console.WriteLine(wrkMessage)");
            sBuilder.AppendLine("If (wrkEnd < text.Length) Then");
            sBuilder.AppendLine("text = text.Substring(wrkEnd + 1)");
            sBuilder.AppendLine("End If");
            sBuilder.AppendLine("If Not (wrkMessage.Contains(\"*\")) Then");
            sBuilder.AppendLine("Dim rawArray() As String = wrkMessage.Split(\":\"c)");
            sBuilder.AppendLine("Dim MasterDevice As CarDevice = System.Convert.ToInt32(rawArray(1), 16)");
            sBuilder.AppendLine("Dim SlaveDevice As CarDevice = System.Convert.ToInt32(rawArray(2), 16)");
            sBuilder.AppendLine("Dim DataLength As Integer = rawArray(4)");
            sBuilder.AppendLine("Dim RawData(DataLength - 1) As String");
            sBuilder.AppendLine("Array.Copy(rawArray, 5, RawData, 0, DataLength)");

            for (int x = 0; x < Events.Count; x++)
            {
                string valueString = string.Empty;
                string paramsString = string.Empty;
                string indicesString = string.Empty;
                string compareString = string.Empty;
                int argsCount = 0;
                for (int y = 0; y < Events[x].Variables.Count; y++)
                {
                    if (Events[x].Variables[y].StartsWith("%"))
                    {
                        paramsString += ", paramVariables(" + argsCount.ToString() + ")";
                        valueString += "paramVariables(" + argsCount.ToString() + ") = System.Convert.ToInt32(RawData(" + y.ToString() + "), 16)" + System.Environment.NewLine;
                        argsCount++;

                        compareString += "*:";
                        indicesString += y.ToString() + ", ";
                    }
                    else
                    {
                        compareString += Events[x].Variables[y] + ":";
                    }
                }
                compareString = compareString.Substring(0, compareString.Length - 1);
                indicesString = indicesString.Substring(0, indicesString.Length - 2);
                argsCount--;
                sBuilder.AppendLine("If MasterDevice = " + Events[x].Master + " And SlaveDevice = " + Events[x].Slave + " And DataLength = " + Events[x].Variables.Count + " Then");
                sBuilder.AppendLine("If BuildWildcard(RawData, New Integer() {" + indicesString + "}).ToLower() = \"" + compareString + "\".ToLower() Then");
                sBuilder.AppendLine("Array.Copy(rawArray, 5, RawData, 0, DataLength)");
                sBuilder.AppendLine("Dim paramVariables(" + argsCount + ") as Integer");
                sBuilder.AppendLine(valueString);
                sBuilder.AppendLine("RaiseEvent " + Events[x].Name + "(MasterDevice, SlaveDevice" + paramsString + ")");
                sBuilder.AppendLine("End If");
                sBuilder.AppendLine("End If");
            }

            sBuilder.AppendLine("End if");
            sBuilder.AppendLine("End if");
            sBuilder.AppendLine("Loop");
            sBuilder.AppendLine("leftovertext = text");
            sBuilder.AppendLine("End Sub");
            sBuilder.AppendLine("Function BuildWildcard(ByVal rData() As String, ByVal Indices() As Integer) As String");
            sBuilder.AppendLine("Dim DataString As String = String.Empty");
            sBuilder.AppendLine("For x As Integer = 0 To Indices.Length - 1");
            sBuilder.AppendLine("rData(Indices(x)) = \"*\"");
            sBuilder.AppendLine("Next");
            sBuilder.AppendLine("For x As Integer = 0 To rData.Length - 1");
            sBuilder.AppendLine("If x = rData.Length - 1 Then");
            sBuilder.AppendLine("DataString &= rData(x).ToString");
            sBuilder.AppendLine("Else");
            sBuilder.AppendLine("DataString &= rData(x).ToString & \":\"");
            sBuilder.AppendLine("End If");
            sBuilder.AppendLine("Next");
            sBuilder.AppendLine("Return DataString");
            sBuilder.AppendLine("End Function");
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
                System.Console.WriteLine(strOut);
            }

            if (comResults.Errors.Count > 0)
            {
                foreach (CompilerError cErr in comResults.Errors)
                {
                    System.Console.WriteLine(cErr.ErrorNumber + ": " + cErr.ErrorText);
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