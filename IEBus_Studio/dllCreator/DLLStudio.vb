Imports Microsoft.VisualBasic
Imports System.CodeDom
Imports System.CodeDom.Compiler
Imports system.Windows.Forms
Public Class DLLStudio
    Private _Make As String
    Private _Model As String
    Private _dm As DeviceManager
    Public Sub New(ByVal Make As String, ByVal Model As String)
        _Make = Make
        _Model = Model
        _dm = New DeviceManager
    End Sub
    Public ReadOnly Property DeviceManager() As DeviceManager
        Get
            Return _dm
        End Get
    End Property
    Public Sub CompileDLL(ByVal OutputFolder As String)
        Dim dynamicCode As String = CreateCode()
        CompileCode(dynamicCode, OutputFolder)
    End Sub
    Private Function CreateCode() As String
        Dim sBuilder As New System.Text.StringBuilder
        sBuilder.AppendLine("Imports System")
        sBuilder.AppendLine("Imports System.Windows.Forms")
        sBuilder.AppendLine("Namespace " & _Make)
        sBuilder.AppendLine("Public Class " & _Model)
        sBuilder.AppendLine("''' <summary>")
        sBuilder.AppendLine("''' Specific devices for this car.")
        sBuilder.AppendLine("''' </summary>")
        sBuilder.AppendLine("Public Enum CarDevices").AppendLine()
        For x As Integer = 0 To DeviceManager.Devices.Count - 1
            sBuilder.AppendLine("''' <summary>")
            sBuilder.AppendLine("''' " & DeviceManager(x).Description)
            sBuilder.AppendLine("''' </summary>")
            sBuilder.AppendLine(DeviceManager(x).Name.Replace(" ", "_") & " = " & BitConverter.ToString(DeviceManager(x).Address, 0, 3))
        Next
        sBuilder.AppendLine("End Enum")

        sBuilder.AppendLine("''' <summary>")
        sBuilder.AppendLine("''' this is sample method")
        sBuilder.AppendLine("''' </summary>")
        sBuilder.AppendLine("Sub Run")
        sBuilder.AppendLine("MessageBox.Show(""dfsdf"")")
        sBuilder.AppendLine("End Sub")
        sBuilder.AppendLine("End Class")
        sBuilder.AppendLine("End Namespace")
        Return sBuilder.ToString
    End Function
    Private Sub CompileCode(ByVal strCode As String, ByVal OutputFolder As String)
        Dim vbCP As New VBCodeProvider
        Dim comParams As New CompilerParameters
        comParams.OutputAssembly = OutputFolder & "\" & _Make & "." & _Model & ".dll"
        comParams.ReferencedAssemblies.Add("System.dll")
        comParams.ReferencedAssemblies.Add("System.Data.dll")
        comParams.ReferencedAssemblies.Add("System.Xml.dll")
        comParams.ReferencedAssemblies.Add("mscorlib.dll")
        comParams.ReferencedAssemblies.Add("System.Windows.Forms.dll")
        comParams.WarningLevel = 3
        comParams.TreatWarningsAsErrors = False
        comParams.CompilerOptions = "/target:library /doc /optimize"
        comParams.GenerateExecutable = False
        comParams.GenerateInMemory = False

        Dim comResults As CompilerResults = vbCP.CompileAssemblyFromSource(comParams, strCode)
        For Each strOut As String In comResults.Output
            Console.WriteLine(strOut)
        Next

        If comResults.Errors.Count > 0 Then
            For Each cErr As CompilerError In comResults.Errors
                Console.WriteLine(cErr.ErrorNumber + ": " + cErr.ErrorText)
            Next
            MessageBox.Show("Errors occoured", "Errors", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class
