Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Threading
Public Class TCPController
    Public Event MessageRecieved(sender As TCPController, data As String)

    'server config
    Public serverIP As IPAddress = IPAddress.Parse("10.0.9.105")
    Public serverPort As Integer = 64555
    Public server As TcpListener

    Private ComunicatieThread As Thread
    Public IsListening As Boolean = True

    'Client
    Private Client As TcpClient
    Private ClientData As StreamReader

    Public Sub New()
        server = New TcpListener(serverIP, serverPort)
        server.Start()

        ComunicatieThread = New Thread(New ThreadStart(AddressOf Listening))
        ComunicatieThread.Start()

    End Sub
    Private Sub Listening()
        'Create Listener Loop
        Do Until IsListening = False
            'Accept Incoming Connections
            If server.Pending = True Then
                Client = server.AcceptTcpClient
                ClientData = New StreamReader(Client.GetStream)
            End If
            ' Raise event for incoming messages
            Try
                RaiseEvent MessageRecieved(Me, ClientData.ReadLine)
            Catch ex As Exception
            End Try
            'Reduce Cpu Usage
            Thread.Sleep(100)
        Loop
    End Sub



End Class
