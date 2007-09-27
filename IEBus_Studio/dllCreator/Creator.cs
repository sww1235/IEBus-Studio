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
        private System.Collections.Generic.List<IEBus_Studio.Event> _events;
        private string CreateCode()
        {
            _events.Sort();
            StringBuilder sBuilder = new StringBuilder();
            sBuilder.AppendLine("Imports System");
            sBuilder.AppendLine("Imports System.Windows.Forms");
            sBuilder.AppendLine("Imports System.Collections");
            sBuilder.AppendLine("Imports Microsoft.VisualBasic");
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
                sBuilder.AppendLine("Public Event " + Events[x].Name.Replace(' ', '_') + "(ByVal Master as CarDevice, ByVal Slave as CarDevice" + args + ")");
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
            sBuilder.AppendLine("Dim currentMessageArray() As String = wrkMessage.Split(\":\"c)");
            sBuilder.AppendLine("Dim MasterDevice As CarDevice = System.Convert.ToInt32(currentMessageArray(1), 16)");
            sBuilder.AppendLine("Dim SlaveDevice As CarDevice = System.Convert.ToInt32(currentMessageArray(2), 16)");
            sBuilder.AppendLine("Dim ControlByte As Integer = currentMessageArray(3)");
            sBuilder.AppendLine("Dim Broadcast As Integer = currentMessageArray(1)");
            sBuilder.AppendLine("Dim DataLength As Integer = currentMessageArray(4)");
            sBuilder.AppendLine("Dim RawData(DataLength - 1) As String");
            sBuilder.AppendLine("Array.Copy(currentMessageArray, 5, RawData, 0, DataLength)");

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
                if (indicesString != string.Empty)
                    indicesString = indicesString.Substring(0, indicesString.Length - 2);
                argsCount--;
                if (x == 0)
                    sBuilder.AppendLine("If MasterDevice = " + Events[x].Master + " And SlaveDevice = " + Events[x].Slave + " And DataLength = " + Events[x].Variables.Count + " And ControlByte = " + (int)Events[x].Control + " And Broadcast = " + Events[x].Broadcast + " Then");
                else
                    sBuilder.AppendLine("ElseIf MasterDevice = " + Events[x].Master + " And SlaveDevice = " + Events[x].Slave + " And DataLength = " + Events[x].Variables.Count + " And ControlByte = " + (int)Events[x].Control + " And Broadcast = " + Events[x].Broadcast + " Then");
                sBuilder.AppendLine("If BuildWildcard(RawData, New Integer() {" + indicesString + "}).ToLower() = \"" + compareString + "\".ToLower() Then");
                sBuilder.AppendLine("Array.Copy(currentMessageArray, 5, RawData, 0, DataLength)");
                if (valueString != string.Empty)
                {
                    sBuilder.AppendLine("Dim paramVariables(" + argsCount + ") as Integer");
                    sBuilder.AppendLine(valueString);
                }
                sBuilder.AppendLine("RaiseEvent " + Events[x].Name.Replace(' ', '_') + "(MasterDevice, SlaveDevice" + paramsString + ")");
                sBuilder.AppendLine("End If");
            }
            sBuilder.AppendLine("End If");

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

            for (int x = 0; x < Events.Count; x++)
            {
                sBuilder.AppendLine("''' <summary>");
                sBuilder.AppendLine("''' Emulates " + Events[x].Description);
                sBuilder.AppendLine("''' </summary>");
                string args = string.Empty;
                string param = string.Empty;
                string varString = string.Empty;
                int count = 0;
                varString += Events[x].Broadcast.ToString("X1") + ":";
                varString += Events[x].Master.ToString("X1") + ":";
                varString += Events[x].Slave.ToString("X1") + ":";
                int cByte = (int)System.Enum.Parse(typeof(IEBus_Studio.ControlByte), Events[x].Control.ToString());
                varString += cByte.ToString("X1") + ":";
                varString += Events[x].Size.ToString("X1") + ":";
                for (int y = 0; y < Events[x].Variables.Count; y++)
                {
                    if (Events[x].Variables[y].StartsWith("%"))
                    {
                        if (Events[x].Variables[y].ToLower().Contains("checksum"))
                        {
                            string[] checksumSection = Events[x].ChecksumCalc.Split(' ');
                            string parsedChecksumCalc = string.Empty;
                            for (int k = 0; k < checksumSection.Length; k++)
                            {
                                if (!checksumSection[k].StartsWith("%"))
                                    checksumSection[k] = "\"" + checksumSection[k] + "\"";
                                else
                                    checksumSection[k] = checksumSection[k] + ".ToString()";
                                parsedChecksumCalc += checksumSection[k] + " & ";
                            }
                            parsedChecksumCalc = parsedChecksumCalc.Substring(0, parsedChecksumCalc.Length - 3);
                            param += "mCalc.evaluate(" + parsedChecksumCalc.Replace("%", "").Replace("0x", "&H") + "), ";
                        }
                        else
                            param += Events[x].Variables[y].Remove(0, 1) + ", ";

                        args += "ByVal " + Events[x].Variables[y].Remove(0, 1) + " as Integer, ";
                        varString += "{" + count.ToString() + "}:";
                        count++;
                    }
                    else
                    {
                        varString += Events[x].Variables[y] + ":";
                    }
                }
                varString = varString.Substring(0, varString.Length - 1);
                param = param.Substring(0, param.Length - 2);
                args = args.Substring(0, args.Length - 2);
                sBuilder.AppendLine("Public Sub Send_" + Events[x].Name.Replace(' ', '_') + "(" + args + ")");
                sBuilder.AppendLine("Dim mCalc as new mcCalc()");
                sBuilder.AppendLine("Dim vString as string = String.Format(\"" + varString + "\", New String(){" + param + "})");
                sBuilder.AppendLine("Dim sString() as string = vString.Split(\":\"c)");
                sBuilder.AppendLine("sPort.Write(\"~\")");
                sBuilder.AppendLine("For sStringx as integer = 0 to sString.Length -1");
                sBuilder.AppendLine("If sStringx = 1 or sStringx = 2 Then");
                sBuilder.AppendLine("sPort.Write(BitConverter.GetBytes(System.Convert.ToInt16(sString(sStringx), 16)), 0, 2)");
                sBuilder.AppendLine("Else");
                sBuilder.AppendLine("sPort.Write(BitConverter.GetBytes(System.Convert.ToByte(sString(sStringx), 16)), 0, 1)");
                sBuilder.AppendLine("End If");
                sBuilder.AppendLine("Next");
                sBuilder.AppendLine("sPort.Write(\"^\")");
                sBuilder.AppendLine("End Sub");
            }

            sBuilder.AppendLine("End Class");
            #region "Calc Code"
            sBuilder.AppendLine("Public Class mcCalc");
            sBuilder.AppendLine("    Private Class mcSymbol");
            sBuilder.AppendLine("        Implements IComparer");
            sBuilder.AppendLine("        Public Token As String");
            sBuilder.AppendLine("        Public Cls As mcCalc.TOKENCLASS");
            sBuilder.AppendLine("        Public PrecedenceLevel As PRECEDENCE");
            sBuilder.AppendLine("        Public tag As String");
            sBuilder.AppendLine("        Public Delegate Function compare_function(ByVal x As Object, ByVal y As Object) As Integer");
            sBuilder.AppendLine("        Public Overridable Overloads Function compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare");
            sBuilder.AppendLine("            Dim asym, bsym As mcSymbol");
            sBuilder.AppendLine("            asym = CType(x, mcSymbol)");
            sBuilder.AppendLine("            bsym = CType(y, mcSymbol)");
            sBuilder.AppendLine("            If asym.Token > bsym.Token Then Return 1");
            sBuilder.AppendLine("            If asym.Token < bsym.Token Then Return -1");
            sBuilder.AppendLine("            If asym.PrecedenceLevel = -1 Or bsym.PrecedenceLevel = -1 Then Return 0");
            sBuilder.AppendLine("            If asym.PrecedenceLevel > bsym.PrecedenceLevel Then Return 1");
            sBuilder.AppendLine("            If asym.PrecedenceLevel < bsym.PrecedenceLevel Then Return -1");
            sBuilder.AppendLine("            Return 0");
            sBuilder.AppendLine("        End Function");
            sBuilder.AppendLine("        Public Sub New()");
            sBuilder.AppendLine("        End Sub");
            sBuilder.AppendLine("    End Class");
            sBuilder.AppendLine("    Private Enum PRECEDENCE");
            sBuilder.AppendLine("        NONE = 0");
            sBuilder.AppendLine("        LEVEL0 = 1");
            sBuilder.AppendLine("        LEVEL1 = 2");
            sBuilder.AppendLine("        LEVEL2 = 3");
            sBuilder.AppendLine("        LEVEL3 = 4");
            sBuilder.AppendLine("        LEVEL4 = 5");
            sBuilder.AppendLine("        LEVEL5 = 6");
            sBuilder.AppendLine("    End Enum");
            sBuilder.AppendLine("    Private Enum TOKENCLASS");
            sBuilder.AppendLine("        KEYWORD = 1");
            sBuilder.AppendLine("        IDENTIFIER = 2");
            sBuilder.AppendLine("        NUMBER = 3");
            sBuilder.AppendLine("        [OPERATOR] = 4");
            sBuilder.AppendLine("        PUNCTUATION = 5");
            sBuilder.AppendLine("    End Enum");
            sBuilder.AppendLine("    Private m_tokens As Collection");
            sBuilder.AppendLine("    Private m_State(,) As Integer");
            sBuilder.AppendLine("    Private m_KeyWords() As String");
            sBuilder.AppendLine("    Private m_colstring As String");
            sBuilder.AppendLine("    Private Const ALPHA As String = \"_ABCDEFGHIJKLMNOPQRSTUVWXYZ\"");
            sBuilder.AppendLine("    Private Const DIGITS As String = \"#0123456789\"");
            sBuilder.AppendLine("    Private m_funcs() As String = {\"sin\", \"cos\", \"tan\", \"arcsin\", \"arccos\", \"arctan\", \"sqrt\", \"max\", \"min\", \"floor\", \"ceiling\", \"log\", \"log10\", \"ln\", \"round\", \"abs\", \"neg\", \"pos\"}");
            sBuilder.AppendLine("    Private m_operators As ArrayList");
            sBuilder.AppendLine("    Private m_stack As New Stack()");
            sBuilder.AppendLine("    Private Sub init_operators()");
            sBuilder.AppendLine("        Dim op As mcSymbol");
            sBuilder.AppendLine("        m_operators = New ArrayList()");
            sBuilder.AppendLine("        op = New mcSymbol()");
            sBuilder.AppendLine("        op.Token = \"-\"");
            sBuilder.AppendLine("        op.Cls = TOKENCLASS.OPERATOR");
            sBuilder.AppendLine("        op.PrecedenceLevel = PRECEDENCE.LEVEL1");
            sBuilder.AppendLine("        m_operators.Add(op)");
            sBuilder.AppendLine("        op = New mcSymbol()");
            sBuilder.AppendLine("        op.Token = \"+\"");
            sBuilder.AppendLine("        op.Cls = TOKENCLASS.OPERATOR");
            sBuilder.AppendLine("        op.PrecedenceLevel = PRECEDENCE.LEVEL1");
            sBuilder.AppendLine("        m_operators.Add(op)");
            sBuilder.AppendLine("        op = New mcSymbol()");
            sBuilder.AppendLine("        op.Token = \"*\"");
            sBuilder.AppendLine("        op.Cls = TOKENCLASS.OPERATOR");
            sBuilder.AppendLine("        op.PrecedenceLevel = PRECEDENCE.LEVEL2");
            sBuilder.AppendLine("        m_operators.Add(op)");
            sBuilder.AppendLine("        op = New mcSymbol()");
            sBuilder.AppendLine("        op.Token = \"/\"");
            sBuilder.AppendLine("        op.Cls = TOKENCLASS.OPERATOR");
            sBuilder.AppendLine("        op.PrecedenceLevel = PRECEDENCE.LEVEL2");
            sBuilder.AppendLine("        m_operators.Add(op)");
            sBuilder.AppendLine("        op = New mcSymbol()");
            sBuilder.AppendLine("        op.Token = \"\\\"");
            sBuilder.AppendLine("        op.Cls = TOKENCLASS.OPERATOR");
            sBuilder.AppendLine("        op.PrecedenceLevel = PRECEDENCE.LEVEL2");
            sBuilder.AppendLine("        m_operators.Add(op)");
            sBuilder.AppendLine("        op = New mcSymbol()");
            sBuilder.AppendLine("        op.Token = \"%\"");
            sBuilder.AppendLine("        op.Cls = TOKENCLASS.OPERATOR");
            sBuilder.AppendLine("        op.PrecedenceLevel = PRECEDENCE.LEVEL2");
            sBuilder.AppendLine("        m_operators.Add(op)");
            sBuilder.AppendLine("        op = New mcSymbol()");
            sBuilder.AppendLine("        op.Token = \"^\"");
            sBuilder.AppendLine("        op.Cls = TOKENCLASS.OPERATOR");
            sBuilder.AppendLine("        op.PrecedenceLevel = PRECEDENCE.LEVEL3");
            sBuilder.AppendLine("        m_operators.Add(op)");
            sBuilder.AppendLine("        op = New mcSymbol()");
            sBuilder.AppendLine("        op.Token = \"!\"");
            sBuilder.AppendLine("        op.Cls = TOKENCLASS.OPERATOR");
            sBuilder.AppendLine("        op.PrecedenceLevel = PRECEDENCE.LEVEL5");
            sBuilder.AppendLine("        m_operators.Add(op)");
            sBuilder.AppendLine("        op = New mcSymbol()");
            sBuilder.AppendLine("        op.Token = \"&\"");
            sBuilder.AppendLine("        op.Cls = TOKENCLASS.OPERATOR");
            sBuilder.AppendLine("        op.PrecedenceLevel = PRECEDENCE.LEVEL5");
            sBuilder.AppendLine("        m_operators.Add(op)");
            sBuilder.AppendLine("        op = New mcSymbol()");
            sBuilder.AppendLine("        op.Token = \"-\"");
            sBuilder.AppendLine("        op.Cls = TOKENCLASS.OPERATOR");
            sBuilder.AppendLine("        op.PrecedenceLevel = PRECEDENCE.LEVEL4");
            sBuilder.AppendLine("        m_operators.Add(op)");
            sBuilder.AppendLine("        op = New mcSymbol()");
            sBuilder.AppendLine("        op.Token = \"+\"");
            sBuilder.AppendLine("        op.Cls = TOKENCLASS.OPERATOR");
            sBuilder.AppendLine("        op.PrecedenceLevel = PRECEDENCE.LEVEL4");
            sBuilder.AppendLine("        m_operators.Add(op)");
            sBuilder.AppendLine("        op = New mcSymbol()");
            sBuilder.AppendLine("        op.Token = \"(\"");
            sBuilder.AppendLine("        op.Cls = TOKENCLASS.OPERATOR");
            sBuilder.AppendLine("        op.PrecedenceLevel = PRECEDENCE.LEVEL5");
            sBuilder.AppendLine("        m_operators.Add(op)");
            sBuilder.AppendLine("        op = New mcSymbol()");
            sBuilder.AppendLine("        op.Token = \")\"");
            sBuilder.AppendLine("        op.Cls = TOKENCLASS.OPERATOR");
            sBuilder.AppendLine("        op.PrecedenceLevel = PRECEDENCE.LEVEL0");
            sBuilder.AppendLine("        m_operators.Add(op)");
            sBuilder.AppendLine("        m_operators.Sort(op)");
            sBuilder.AppendLine("    End Sub");
            sBuilder.AppendLine("    Public Function evaluate(ByVal expression As String) As Double");
            sBuilder.AppendLine("        Dim symbols As New Queue()");
            sBuilder.AppendLine("        Try");
            sBuilder.AppendLine("            If IsNumeric(expression) Then Return CType(expression, Double)");
            sBuilder.AppendLine("            calc_scan(expression, symbols)");
            sBuilder.AppendLine("            Return level0(symbols)");
            sBuilder.AppendLine("        Catch");
            sBuilder.AppendLine("            Return 0");
            sBuilder.AppendLine("        End Try");
            sBuilder.AppendLine("    End Function");
            sBuilder.AppendLine("    Private Function calc_op(ByVal op As mcSymbol, ByVal operand1 As Double, Optional ByVal operand2 As Double = Nothing) As Double");
            sBuilder.AppendLine("        Select Case op.Token.ToLower");
            sBuilder.AppendLine("            Case \"&\" ' sample to show addition of custom operator");
            sBuilder.AppendLine("                Return 5");
            sBuilder.AppendLine("            Case \"^\"");
            sBuilder.AppendLine("                Return (operand1 ^ operand2)");
            sBuilder.AppendLine("            Case \"+\"");
            sBuilder.AppendLine("                Select Case op.PrecedenceLevel");
            sBuilder.AppendLine("                    Case PRECEDENCE.LEVEL1");
            sBuilder.AppendLine("                        Return (operand2 + operand1)");
            sBuilder.AppendLine("                    Case PRECEDENCE.LEVEL4");
            sBuilder.AppendLine("                        Return operand1");
            sBuilder.AppendLine("                End Select");
            sBuilder.AppendLine("            Case \"-\"");
            sBuilder.AppendLine("                Select Case op.PrecedenceLevel");
            sBuilder.AppendLine("                    Case PRECEDENCE.LEVEL1");
            sBuilder.AppendLine("                        Return (operand1 - operand2)");
            sBuilder.AppendLine("                    Case PRECEDENCE.LEVEL4");
            sBuilder.AppendLine("                        Return -1 * operand1");
            sBuilder.AppendLine("                End Select");
            sBuilder.AppendLine("            Case \"*\"");
            sBuilder.AppendLine("                Return (operand2 * operand1)");
            sBuilder.AppendLine("            Case \"/\"");
            sBuilder.AppendLine("                Return (operand1 / operand2)");
            sBuilder.AppendLine("            Case \"\\\"");
            sBuilder.AppendLine("                Return (CLng(operand1) \\ CLng(operand2))");
            sBuilder.AppendLine("            Case \"%\"");
            sBuilder.AppendLine("                Return (operand1 Mod operand2)");
            sBuilder.AppendLine("            Case \"!\"");
            sBuilder.AppendLine("                Dim i As Integer");
            sBuilder.AppendLine("                Dim res As Double = 1");
            sBuilder.AppendLine("                If operand1 > 1 Then");
            sBuilder.AppendLine("                    For i = CInt(operand1) To 1 Step -1");
            sBuilder.AppendLine("                        res = res * i");
            sBuilder.AppendLine("                    Next");
            sBuilder.AppendLine("                End If");
            sBuilder.AppendLine("                Return (res)");
            sBuilder.AppendLine("        End Select");
            sBuilder.AppendLine("    End Function");
            sBuilder.AppendLine("    Private Function calc_function(ByVal func As String, ByVal args As Collection) As Double");
            sBuilder.AppendLine("        Select Case func.ToLower");
            sBuilder.AppendLine("            Case \"cos\"");
            sBuilder.AppendLine("                Return (Math.Cos(CDbl(args(1))))");
            sBuilder.AppendLine("            Case \"sin\"");
            sBuilder.AppendLine("                Return (Math.Sin(CDbl(args(1))))");
            sBuilder.AppendLine("            Case \"tan\"");
            sBuilder.AppendLine("                Return (Math.Tan(CDbl(args(1))))");
            sBuilder.AppendLine("            Case \"floor\"");
            sBuilder.AppendLine("                Return (Math.Floor(CDbl(args(1))))");
            sBuilder.AppendLine("            Case \"ceiling\"");
            sBuilder.AppendLine("                Return (Math.Ceiling(CDbl(args(1))))");
            sBuilder.AppendLine("            Case \"max\"");
            sBuilder.AppendLine("                Return (Math.Max(CDbl(args(1)), CDbl(args(2))))");
            sBuilder.AppendLine("            Case \"min\"");
            sBuilder.AppendLine("                Return (Math.Min(CDbl(args(1)), CDbl(args(2))))");
            sBuilder.AppendLine("            Case \"arcsin\"");
            sBuilder.AppendLine("                Return (Math.Asin(CDbl(args(1))))");
            sBuilder.AppendLine("            Case \"arccos\"");
            sBuilder.AppendLine("                Return (Math.Acos(CDbl(args(1))))");
            sBuilder.AppendLine("            Case \"arctan\"");
            sBuilder.AppendLine("                Return (Math.Atan(CDbl(args(1))))");
            sBuilder.AppendLine("            Case \"sqrt\"");
            sBuilder.AppendLine("                Return (Math.Sqrt(CDbl(args(1))))");
            sBuilder.AppendLine("            Case \"log\"");
            sBuilder.AppendLine("                Return (Math.Log10(CDbl(args(1))))");
            sBuilder.AppendLine("            Case \"log10\"");
            sBuilder.AppendLine("                Return (Math.Log10(CDbl(args(1))))");
            sBuilder.AppendLine("            Case \"abs\"");
            sBuilder.AppendLine("                Return (Math.Abs(CDbl(args(1))))");
            sBuilder.AppendLine("            Case \"round\"");
            sBuilder.AppendLine("                Return (Math.Round(CDbl(args(1))))");
            sBuilder.AppendLine("            Case \"ln\"");
            sBuilder.AppendLine("                Return (Math.Log(CDbl(args(1))))");
            sBuilder.AppendLine("            Case \"neg\"");
            sBuilder.AppendLine("                Return (-1 * CDbl(args(1)))");
            sBuilder.AppendLine("            Case \"pos\"");
            sBuilder.AppendLine("                Return (+1 * CDbl(args(1)))");
            sBuilder.AppendLine("        End Select");
            sBuilder.AppendLine("    End Function");
            sBuilder.AppendLine("    Private Function identifier(ByVal token As String) As Double");
            sBuilder.AppendLine("        Select Case token.ToLower");
            sBuilder.AppendLine("            Case \"e\"");
            sBuilder.AppendLine("                Return Math.E");
            sBuilder.AppendLine("            Case \"pi\"");
            sBuilder.AppendLine("                Return Math.PI");
            sBuilder.AppendLine("            Case Else");
            sBuilder.AppendLine("                ' look in symbol table....?");
            sBuilder.AppendLine("        End Select");
            sBuilder.AppendLine("    End Function");
            sBuilder.AppendLine("    Private Function is_operator(ByVal token As String, Optional ByVal level As PRECEDENCE = CType(-1, PRECEDENCE), Optional ByRef [operator] As mcSymbol = Nothing) As Boolean");
            sBuilder.AppendLine("        Try");
            sBuilder.AppendLine("            Dim op As New mcSymbol()");
            sBuilder.AppendLine("            op.Token = token");
            sBuilder.AppendLine("            op.PrecedenceLevel = level");
            sBuilder.AppendLine("            op.tag = \"test\"");
            sBuilder.AppendLine("            Dim ir As Integer = m_operators.BinarySearch(op, op)");
            sBuilder.AppendLine("            If ir > -1 Then");
            sBuilder.AppendLine("                [operator] = CType(m_operators(ir), mcSymbol)");
            sBuilder.AppendLine("                Return True");
            sBuilder.AppendLine("            End If");
            sBuilder.AppendLine("            Return False");
            sBuilder.AppendLine("        Catch");
            sBuilder.AppendLine("            Return False");
            sBuilder.AppendLine("        End Try");
            sBuilder.AppendLine("    End Function");
            sBuilder.AppendLine("    Private Function is_function(ByVal token As String) As Boolean");
            sBuilder.AppendLine("        Try");
            sBuilder.AppendLine("            Dim lr As Integer = Array.BinarySearch(m_funcs, token.ToLower)");
            sBuilder.AppendLine("            Return (lr > -1)");
            sBuilder.AppendLine("        Catch");
            sBuilder.AppendLine("            Return False");
            sBuilder.AppendLine("        End Try");
            sBuilder.AppendLine("    End Function");
            sBuilder.AppendLine("    Public Function calc_scan(ByVal line As String, ByVal symbols As Queue) As Boolean");
            sBuilder.AppendLine("        Dim sp As Integer  ' start position marker");
            sBuilder.AppendLine("        Dim cp As Integer  ' current position marker");
            sBuilder.AppendLine("        Dim col As Integer ' input column");
            sBuilder.AppendLine("        Dim lex_state As Integer");
            sBuilder.AppendLine("        Dim cc As Char");
            sBuilder.AppendLine("        line = line & \" \" ' add a space as an end marker");
            sBuilder.AppendLine("        sp = 0");
            sBuilder.AppendLine("        cp = 0");
            sBuilder.AppendLine("        lex_state = 1");
            sBuilder.AppendLine("        Do While cp <= line.Length - 1");
            sBuilder.AppendLine("            cc = line.Chars(cp)");
            sBuilder.AppendLine("            ' if cc is not found then IndexOf returns -1 giving col = 2.");
            sBuilder.AppendLine("            col = m_colstring.IndexOf(cc) + 3");
            sBuilder.AppendLine("            ' set the input column ");
            sBuilder.AppendLine("            Select Case col");
            sBuilder.AppendLine("                Case 2 ' cc wasn't found in the column string");
            sBuilder.AppendLine("                    If ALPHA.IndexOf(Char.ToUpper(cc)) > 0 Then      ' letter column?");
            sBuilder.AppendLine("                        col = 1");
            sBuilder.AppendLine("                    ElseIf DIGITS.IndexOf(Char.ToUpper(cc)) > 0 Then ' number column?");
            sBuilder.AppendLine("                        col = 2");
            sBuilder.AppendLine("                    Else ' everything else is assigned to the punctuation column");
            sBuilder.AppendLine("                        col = 6");
            sBuilder.AppendLine("                    End If");
            sBuilder.AppendLine("                Case Is > 5 ' cc was found and is > 5 so must be in operator column");
            sBuilder.AppendLine("                    col = 7");
            sBuilder.AppendLine("                    ' case else ' cc was found - col contains the correct column");
            sBuilder.AppendLine("            End Select");
            sBuilder.AppendLine("            ' find the new state based on current state and column (determined by input)");
            sBuilder.AppendLine("            lex_state = m_State(lex_state - 1, col - 1)");
            sBuilder.AppendLine("            Select Case lex_state");
            sBuilder.AppendLine("                Case 3 ' function or variable  end state ");
            sBuilder.AppendLine("                    ' TODO variables aren't supported but substitution ");
            sBuilder.AppendLine("                    '      could easily be performed here or after");
            sBuilder.AppendLine("                    '      tokenization");
            sBuilder.AppendLine("                    Dim sym As New mcSymbol()");
            sBuilder.AppendLine("                    sym.Token = line.Substring(sp, cp - sp)");
            sBuilder.AppendLine("                    If is_function(sym.Token) Then");
            sBuilder.AppendLine("                        sym.Cls = TOKENCLASS.KEYWORD");
            sBuilder.AppendLine("                    Else");
            sBuilder.AppendLine("                        sym.Cls = TOKENCLASS.IDENTIFIER");
            sBuilder.AppendLine("                    End If");
            sBuilder.AppendLine("                    symbols.Enqueue(sym)");
            sBuilder.AppendLine("                    lex_state = 1");
            sBuilder.AppendLine("                    cp = cp - 1");
            sBuilder.AppendLine("                Case 5 ' number end state");
            sBuilder.AppendLine("                    Dim sym As New mcSymbol()");
            sBuilder.AppendLine("                    sym.Token = line.Substring(sp, cp - sp)");
            sBuilder.AppendLine("                    sym.Cls = TOKENCLASS.NUMBER");
            sBuilder.AppendLine("                    symbols.Enqueue(sym)");
            sBuilder.AppendLine("                    lex_state = 1");
            sBuilder.AppendLine("                    cp = cp - 1");
            sBuilder.AppendLine("                Case 6 ' punctuation end state");
            sBuilder.AppendLine("                    Dim sym As New mcSymbol()");
            sBuilder.AppendLine("                    sym.Token = line.Substring(sp, cp - sp + 1)");
            sBuilder.AppendLine("                    sym.Cls = TOKENCLASS.PUNCTUATION");
            sBuilder.AppendLine("                    symbols.Enqueue(sym)");
            sBuilder.AppendLine("                    lex_state = 1");
            sBuilder.AppendLine("                Case 7 ' operator end state");
            sBuilder.AppendLine("                    Dim sym As New mcSymbol()");
            sBuilder.AppendLine("                    sym.Token = line.Substring(sp, cp - sp + 1)");
            sBuilder.AppendLine("                    sym.Cls = TOKENCLASS.OPERATOR");
            sBuilder.AppendLine("                    symbols.Enqueue(sym)");
            sBuilder.AppendLine("                    lex_state = 1");
            sBuilder.AppendLine("            End Select");
            sBuilder.AppendLine("            cp += 1");
            sBuilder.AppendLine("            If lex_state = 1 Then sp = cp");
            sBuilder.AppendLine("        Loop");
            sBuilder.AppendLine("        Return True");
            sBuilder.AppendLine("    End Function");
            sBuilder.AppendLine("    Private Sub init()");
            sBuilder.AppendLine("        Dim op As mcSymbol");
            sBuilder.AppendLine("        Dim state(,) As Integer = {{2, 4, 1, 1, 4, 6, 7}, _");
            sBuilder.AppendLine("                                   {2, 3, 3, 3, 3, 3, 3}, _");
            sBuilder.AppendLine("                                   {1, 1, 1, 1, 1, 1, 1}, _");
            sBuilder.AppendLine("                                   {2, 4, 5, 5, 4, 5, 5}, _");
            sBuilder.AppendLine("                                   {1, 1, 1, 1, 1, 1, 1}, _");
            sBuilder.AppendLine("                                   {1, 1, 1, 1, 1, 1, 1}, _");
            sBuilder.AppendLine("                                   {1, 1, 1, 1, 1, 1, 1}}");
            sBuilder.AppendLine("        init_operators()");
            sBuilder.AppendLine("        m_State = state");
            sBuilder.AppendLine("        m_colstring = Chr(9) & \" \" & \".()\"");
            sBuilder.AppendLine("        For Each op In m_operators");
            sBuilder.AppendLine("            m_colstring = m_colstring & op.Token");
            sBuilder.AppendLine("        Next");
            sBuilder.AppendLine("        Array.Sort(m_funcs)");
            sBuilder.AppendLine("        m_tokens = New Collection()");
            sBuilder.AppendLine("    End Sub");
            sBuilder.AppendLine("    Public Sub New()");
            sBuilder.AppendLine("        init()");
            sBuilder.AppendLine("    End Sub");
            sBuilder.AppendLine("    Private Function level0(ByRef tokens As Queue) As Double");
            sBuilder.AppendLine("        Return level1(tokens)");
            sBuilder.AppendLine("    End Function");
            sBuilder.AppendLine("    Private Function level1_prime(ByRef tokens As Queue, ByVal result As Double) As Double");
            sBuilder.AppendLine("        Dim symbol, [operator] As mcSymbol");
            sBuilder.AppendLine("       [operator] = new mcSymbol()");

            sBuilder.AppendLine("        If tokens.Count > 0 Then");
            sBuilder.AppendLine("            symbol = CType(tokens.Peek, mcSymbol)");
            sBuilder.AppendLine("        Else");
            sBuilder.AppendLine("            Return result");
            sBuilder.AppendLine("        End If");
            sBuilder.AppendLine("        ' binary level1 precedence operators....+, -");
            sBuilder.AppendLine("        If is_operator(symbol.Token, PRECEDENCE.LEVEL1, [operator]) Then");
            sBuilder.AppendLine("            tokens.Dequeue()");
            sBuilder.AppendLine("            result = calc_op([operator], result, level2(tokens))");
            sBuilder.AppendLine("            result = level1_prime(tokens, result)");
            sBuilder.AppendLine("        End If");
            sBuilder.AppendLine("        Return result");
            sBuilder.AppendLine("    End Function");
            sBuilder.AppendLine("    Private Function level1(ByRef tokens As Queue) As Double");
            sBuilder.AppendLine("        Return level1_prime(tokens, level2(tokens))");
            sBuilder.AppendLine("    End Function");
            sBuilder.AppendLine("    Private Function level2(ByRef tokens As Queue) As Double");
            sBuilder.AppendLine("        Return level2_prime(tokens, level3(tokens))");
            sBuilder.AppendLine("    End Function");
            sBuilder.AppendLine("    Private Function level2_prime(ByRef tokens As Queue, ByVal result As Double) As Double");
            sBuilder.AppendLine("        Dim symbol, [operator] As mcSymbol");

            sBuilder.AppendLine("       [operator] = new mcSymbol()");


            sBuilder.AppendLine("        If tokens.Count > 0 Then");
            sBuilder.AppendLine("            symbol = CType(tokens.Peek, mcSymbol)");
            sBuilder.AppendLine("        Else");
            sBuilder.AppendLine("            Return result");
            sBuilder.AppendLine("        End If");
            sBuilder.AppendLine("        If is_operator(symbol.Token, PRECEDENCE.LEVEL2, [operator]) Then");
            sBuilder.AppendLine("            tokens.Dequeue()");
            sBuilder.AppendLine("            result = calc_op([operator], result, level3(tokens))");
            sBuilder.AppendLine("            result = level2_prime(tokens, result)");
            sBuilder.AppendLine("        End If");
            sBuilder.AppendLine("        Return result");
            sBuilder.AppendLine("    End Function");
            sBuilder.AppendLine("    Private Function level3(ByRef tokens As Queue) As Double");
            sBuilder.AppendLine("        Return level3_prime(tokens, level4(tokens))");
            sBuilder.AppendLine("    End Function");
            sBuilder.AppendLine("    Private Function level3_prime(ByRef tokens As Queue, ByVal result As Double) As Double");
            sBuilder.AppendLine("        Dim symbol, [operator] As mcSymbol");
            sBuilder.AppendLine("       [operator] = new mcSymbol()");

            sBuilder.AppendLine("        If tokens.Count > 0 Then");
            sBuilder.AppendLine("            symbol = CType(tokens.Peek, mcSymbol)");
            sBuilder.AppendLine("        Else");
            sBuilder.AppendLine("            Return result");
            sBuilder.AppendLine("        End If");
            sBuilder.AppendLine("        ' binary level3 precedence operators....^");
            sBuilder.AppendLine("        If is_operator(symbol.Token, PRECEDENCE.LEVEL3, [operator]) Then");
            sBuilder.AppendLine("            tokens.Dequeue()");
            sBuilder.AppendLine("            result = calc_op([operator], result, level4(tokens))");
            sBuilder.AppendLine("            result = level3_prime(tokens, result)");
            sBuilder.AppendLine("        End If");
            sBuilder.AppendLine("        Return result");
            sBuilder.AppendLine("    End Function");
            sBuilder.AppendLine("    Private Function level4(ByRef tokens As Queue) As Double");
            sBuilder.AppendLine("        Return level4_prime(tokens)");
            sBuilder.AppendLine("    End Function");
            sBuilder.AppendLine("    Private Function level4_prime(ByRef tokens As Queue) As Double");
            sBuilder.AppendLine("        Dim symbol, [operator] As mcSymbol");
            sBuilder.AppendLine("       [operator] = new mcSymbol()");

            sBuilder.AppendLine("        If tokens.Count > 0 Then");
            sBuilder.AppendLine("            symbol = CType(tokens.Peek, mcSymbol)");
            sBuilder.AppendLine("        Else");
            sBuilder.AppendLine("            Throw New System.Exception(\"Invalid expression.\")");
            sBuilder.AppendLine("        End If");
            sBuilder.AppendLine("        ' unary level4 precedence right associative  operators.... +, -");
            sBuilder.AppendLine("        If is_operator(symbol.Token, PRECEDENCE.LEVEL4, [operator]) Then");
            sBuilder.AppendLine("            tokens.Dequeue()");
            sBuilder.AppendLine("            Return calc_op([operator], level5(tokens))");
            sBuilder.AppendLine("        Else");
            sBuilder.AppendLine("            Return level5(tokens)");
            sBuilder.AppendLine("        End If");
            sBuilder.AppendLine("    End Function");
            sBuilder.AppendLine("    Private Function level5(ByVal tokens As Queue) As Double");
            sBuilder.AppendLine("        Return level5_prime(tokens, level6(tokens))");
            sBuilder.AppendLine("    End Function");
            sBuilder.AppendLine("    Private Function level5_prime(ByVal tokens As Queue, ByVal result As Double) As Double");
            sBuilder.AppendLine("        Dim symbol, [operator] As mcSymbol");
            sBuilder.AppendLine("       [operator] = new mcSymbol()");

            sBuilder.AppendLine("        If tokens.Count > 0 Then");
            sBuilder.AppendLine("            symbol = CType(tokens.Peek, mcSymbol)");
            sBuilder.AppendLine("        Else");
            sBuilder.AppendLine("            Return result");
            sBuilder.AppendLine("        End If");
            sBuilder.AppendLine("        ' unary level5 precedence left associative operators.... !");
            sBuilder.AppendLine("        If is_operator(symbol.Token, PRECEDENCE.LEVEL5, [operator]) Then");
            sBuilder.AppendLine("            tokens.Dequeue()");
            sBuilder.AppendLine("            Return calc_op([operator], result)");
            sBuilder.AppendLine("        Else");
            sBuilder.AppendLine("            Return result");
            sBuilder.AppendLine("        End If");
            sBuilder.AppendLine("    End Function");
            sBuilder.AppendLine("    Private Function level6(ByRef tokens As Queue) As Double");
            sBuilder.AppendLine("        Dim symbol As mcSymbol");
            sBuilder.AppendLine("        If tokens.Count > 0 Then");
            sBuilder.AppendLine("            symbol = CType(tokens.Peek, mcSymbol)");
            sBuilder.AppendLine("        Else");
            sBuilder.AppendLine("            Throw New System.Exception(\"Invalid expression.\")");
            sBuilder.AppendLine("            Return 0");
            sBuilder.AppendLine("        End If");
            sBuilder.AppendLine("        Dim val As Double");
            sBuilder.AppendLine("        ' constants, identifiers, keywords, -> expressions");
            sBuilder.AppendLine("        If symbol.Token = \"(\" Then ' opening paren of new expression");
            sBuilder.AppendLine("            tokens.Dequeue()");
            sBuilder.AppendLine("            val = level0(tokens)");
            sBuilder.AppendLine("            symbol = CType(tokens.Dequeue, mcSymbol)");
            sBuilder.AppendLine("            ' closing paren");
            sBuilder.AppendLine("            If symbol.Token <> \")\" Then Throw New System.Exception(\"Invalid expression.\")");
            sBuilder.AppendLine("            Return val");
            sBuilder.AppendLine("        Else");
            sBuilder.AppendLine("            Select Case symbol.Cls");
            sBuilder.AppendLine("                Case TOKENCLASS.IDENTIFIER");
            sBuilder.AppendLine("                    tokens.Dequeue()");
            sBuilder.AppendLine("                    Return identifier(symbol.Token)");
            sBuilder.AppendLine("                Case TOKENCLASS.KEYWORD");
            sBuilder.AppendLine("                    tokens.Dequeue()");
            sBuilder.AppendLine("                    Return calc_function(symbol.Token, arguments(tokens))");
            sBuilder.AppendLine("                Case TOKENCLASS.NUMBER");
            sBuilder.AppendLine("                    tokens.Dequeue()");
            sBuilder.AppendLine("                    m_stack.Push(CDbl(symbol.Token))");
            sBuilder.AppendLine("                    Return CDbl(symbol.Token)");
            sBuilder.AppendLine("                Case Else");
            sBuilder.AppendLine("                    Throw New System.Exception(\"Invalid expression.\")");
            sBuilder.AppendLine("            End Select");
            sBuilder.AppendLine("        End If");
            sBuilder.AppendLine("    End Function");
            sBuilder.AppendLine("    Private Function arguments(ByVal tokens As Queue) As Collection");
            sBuilder.AppendLine("        Dim symbol As mcSymbol");
            sBuilder.AppendLine("        Dim args As New Collection()");
            sBuilder.AppendLine("        If tokens.Count > 0 Then");
            sBuilder.AppendLine("            symbol = CType(tokens.Peek, mcSymbol)");
            sBuilder.AppendLine("        Else");
            sBuilder.AppendLine("            Throw New System.Exception(\"Invalid expression.\")");
            sBuilder.AppendLine("            Return Nothing");
            sBuilder.AppendLine("        End If");
            //sBuilder.AppendLine("        Dim val As Double");
            sBuilder.AppendLine("        If symbol.Token = \"(\" Then");
            sBuilder.AppendLine("            tokens.Dequeue()");
            sBuilder.AppendLine("            args.Add(level0(tokens))");
            sBuilder.AppendLine("            symbol = CType(tokens.Dequeue, mcSymbol)");
            sBuilder.AppendLine("            Do While symbol.Token <> \")\"");
            sBuilder.AppendLine("                If symbol.Token = \",\" Then");
            sBuilder.AppendLine("                    args.Add(level0(tokens))");
            sBuilder.AppendLine("                Else");
            sBuilder.AppendLine("                    Throw New System.Exception(\"Invalid expression.\")");
            sBuilder.AppendLine("                    Return Nothing");
            sBuilder.AppendLine("                End If");
            sBuilder.AppendLine("                symbol = CType(tokens.Dequeue, mcSymbol)");
            sBuilder.AppendLine("            Loop");
            sBuilder.AppendLine("            Return args");
            sBuilder.AppendLine("        Else");
            sBuilder.AppendLine("            Throw New System.Exception(\"Invalid expression.\")");
            sBuilder.AppendLine("            Return Nothing");
            sBuilder.AppendLine("        End If");
            sBuilder.AppendLine("    End Function");
            sBuilder.AppendLine("End Class");
            #endregion
            sBuilder.AppendLine("End Namespace");
            System.Console.WriteLine(sBuilder.ToString());
            return sBuilder.ToString();
        }
        private void CompileCode(string strCode, string OutputFile)
        {
            VBCodeProvider vbCP = new VBCodeProvider();
            CompilerParameters comParams = new CompilerParameters();
            comParams.OutputAssembly = OutputFile;
            comParams.ReferencedAssemblies.Add("System.dll");
            comParams.ReferencedAssemblies.Add("System.Data.dll");
            comParams.ReferencedAssemblies.Add("System.Design.dll");
            comParams.ReferencedAssemblies.Add("System.Xml.dll");
            comParams.ReferencedAssemblies.Add("mscorlib.dll");
            comParams.ReferencedAssemblies.Add("System.Windows.Forms.dll");
            comParams.ReferencedAssemblies.Add("Microsoft.VisualBasic.dll");
            comParams.WarningLevel = 6;
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
            _events = new System.Collections.Generic.List<IEBus_Studio.Event>();
        }
        public DeviceManager DeviceManager
        {
            get { return _dm; }
        }
        public string PrefferedFilename
        {
            get { return _Make + "." + _Model + "." + _Year + ".dll"; }
        }
        public System.Collections.Generic.List<IEBus_Studio.Event> Events
        {
            get { return _events; }
        }
        public void CompileDLL(string OutputFolder)
        {
            string dynamicCode = CreateCode();
            CompileCode(dynamicCode, OutputFolder);
        }
        public void AddEvent(string Name, string Description, int Broadcast, int Master, int Slave, IEBus_Studio.ControlByte Control, string Data, string checksumCalc)
        {
            IEBus_Studio.Event newEvent = new IEBus_Studio.Event(Name, Description, Broadcast, Master, Slave, Control, Data, checksumCalc);
            _events.Add(newEvent);
        }
        public void AddEvent(IEBus_Studio.Event ev)
        {
            _events.Add(ev);
        }
    }
}