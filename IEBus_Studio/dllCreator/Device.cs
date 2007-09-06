Public Class Device
    Private _address() As Byte
    Private _name As String
    Private _description As String

    Public Sub New()
        ReDim _address(2)
        _name = String.Empty
        _description = String.Empty
    End Sub
    Public Sub New(ByVal address() As Byte, ByVal name As String, ByVal description As String)
        _address = address
        _name = name
        _description = description
    End Sub

    Public Property Address() As Byte()
        Get
            Return _address
        End Get
        Set(ByVal value As Byte())
            _address = value
        End Set
    End Property
    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property
    Public Property Description() As String
        Get
            Return _description
        End Get
        Set(ByVal value As String)
            _description = value
        End Set
    End Property
End Class
