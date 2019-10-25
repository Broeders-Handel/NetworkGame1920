Imports System.ComponentModel
Imports System.Net.Sockets
Imports System.IO
Public Class TCPControllerClient
    Dim TCPClient As TcpClient
    Dim TCPClientStream As NetworkStream
    Dim RX As StreamReader
    Dim TX As StreamWriter
    Public Sub Connect()
        Try
            TCPClient = New TcpClient("127.0.0.1", 64553)
            TCPClientStream = TCPClient.GetStream()
        Catch ex As Exception

        End Try
    End Sub
    Private Enum ClientStatus
        Connected
        Disconnected
    End Enum
End Class
