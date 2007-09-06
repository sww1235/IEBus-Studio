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
        public Creator(string Make, string Model, int Year)
        {
            _Make = Make;
            _Model = Model;
            _Year = Year;
            _dm = new DeviceManager();
        }
        public DeviceManager DeviceManager
        {
            get { return _dm; }
        }
        public void CompileDLL(string OutputFolder)
        {
            string dynamicCode = CreateCode();
            CompileCode(dynamicCode, OutputFolder);
        }
        private string CreateCode()
        {
            StringBuilder sBuilder = new StringBuilder();
            sBuilder.AppendLine("Imports System");
            sBuilder.AppendLine("Imports System.Windows.Forms");
            sBuilder.AppendLine("Namespace " + _Make);
            sBuilder.AppendLine("Public Class " + _Model + "_" + _Year);
            sBuilder.AppendLine("''' <summary>");
            sBuilder.AppendLine("''' Specific devices for this car.");
            sBuilder.AppendLine("''' </summary>");
            sBuilder.AppendLine("Public Enum CarDevices").AppendLine();
            for (int x=0; x < DeviceManager.Devices.Count; x++)
            {
                sBuilder.AppendLine("''' <summary>");
                sBuilder.AppendLine("''' " + DeviceManager[x].Description);
                sBuilder.AppendLine("''' </summary>");
                sBuilder.AppendLine(DeviceManager[x].Name.Replace(" ", "_") + " = " + DeviceManager[x].Address);
            }
            sBuilder.AppendLine("End Enum");
            sBuilder.AppendLine("''' <summary>");
            sBuilder.AppendLine("''' this is sample method");
            sBuilder.AppendLine("''' </summary>");
            sBuilder.AppendLine("Sub Run");
            sBuilder.AppendLine("MessageBox.Show(\"dfsdf\")");
            sBuilder.AppendLine("End Sub");
            sBuilder.AppendLine("End Class");
            sBuilder.AppendLine("End Namespace");
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
    }
}