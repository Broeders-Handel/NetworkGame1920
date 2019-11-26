Imports System.IO
Imports System.Net.Sockets
Public Class Users
    Private _username As String
    Private _client As TcpClient
    Public Property Username As String
        Get
            Return _username
        End Get
        Set(ByVal value As String)
            _username = value
        End Set
    End Property
    Public Property Client As TcpClient
        Get
            Return _client
        End Get
        Set(value As TcpClient)
            _client = value
        End Set
    End Property
    Public Sub write(message)
        Dim strWrit As StreamWriter = New StreamWriter(Client.GetStream)
        strWrit.Write(message)
    End Sub
    'bij het luisteren => gooi event wanneer iets ontvangen
    Public Overrides Function ToString() As String
        Return " => " & Username
    End Function
End Class
