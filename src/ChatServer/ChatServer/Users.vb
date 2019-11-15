Imports System.Net.Sockets
Public Class Users
    Private _username As String
    Private _client As socket
    Public Property Username As String
        Get
            Return _username
        End Get
        Set(ByVal value As String)
            _username = value
        End Set
    End Property
    Public Property Client As Socket
        Get
            Return _client
        End Get
        Set(value As Socket)
            _client = value
        End Set
    End Property
    Public Sub write(message)
        Client.Send(message)
    End Sub
    Public Overrides Function ToString() As String
        Return " => " & Username
    End Function
End Class
