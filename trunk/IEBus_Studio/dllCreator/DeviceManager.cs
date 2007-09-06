
Public Class DeviceManager
    Private _devices As ArrayList
    Public Sub New()
        _devices = New ArrayList()
    End Sub

    Default Public Property Device(ByVal Name As String) As Device
        Get
            For Each dev As Device In _devices
                If dev.Name = Name Then
                    Return dev
                End If
            Next
            Return Nothing
        End Get
        Set(ByVal value As Device)
            For Each dev As Device In _devices
                If dev.Name = Name Then
                    dev = value
                End If
            Next
        End Set
    End Property
    Default Public Property Device(ByVal Index As Integer) As Device
        Get
            If _devices.Count > Index Then
                Return _devices(Index)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal value As Device)
            If _devices.Count > Index Then
                _devices(Index) = value
            End If
        End Set
    End Property
    Public Property Devices() As ArrayList
        Get
            Return _devices
        End Get
        Set(ByVal value As ArrayList)
            _devices = value
        End Set
    End Property

    Public Sub AddDevice(ByVal Device As Device)
        _devices.Add(Device)
    End Sub
    Public Sub AddDevice(ByVal Address() As Byte, ByVal Name As String, ByVal Description As String)
        _devices.Add(New Device(Address, Name, Description))
    End Sub
    Public Sub RemoveDevice(ByVal Device As Device)
        If _devices.Contains(Device) Then
            _devices.Remove(Device)
        End If
    End Sub
End Class
