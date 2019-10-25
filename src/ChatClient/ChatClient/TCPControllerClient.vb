Imports System.ComponentModel
Imports System.Net.Sockets
Imports System.IO
Public Class TCPControllerClient
    Private _TCPClient As TcpClient
    Private _TCPClientStream As NetworkStream
    Dim RX As StreamReader
    Dim TX As StreamWriter

    Public Property TCPClient() As TcpClient
        Get
            Return _TCPClient
        End Get
        Set(ByVal value As TcpClient)
            _TCPClient = value
        End Set
    End Property
    Public Property TCPClientStream() As NetworkStream
        Get
            Return _TCPClientStream
        End Get
        Set(ByVal value As NetworkStream)
            _TCPClientStream = value
        End Set
    End Property
    Public Sub Connect()
        Try
            TCPClient = New TcpClient("127.0.0.1", 64553)
            _TCPClientStream = TCPClient.GetStream()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub sendToServer(Message As String)
        Dim sendbytes() As Byte = System.Text.Encoding.ASCII.GetBytes(Message)
        TCPClient.Client.Send(sendbytes)
    End Sub
    Public Function ReceiveText() As String
        Dim Output As String = ""
        If _TCPClientStream.DataAvailable = True Then
            Dim rcvbytes(_TCPClient.ReceiveBufferSize) As Byte
            _TCPClientStream.Read(rcvbytes, 0, CInt(_TCPClient.ReceiveBufferSize))
            Output &= _TCPClient.Client.RemoteEndPoint.ToString & " => " & System.Text.Encoding.ASCII.GetString(rcvbytes) & Environment.NewLine
        End If
        Return Output
    End Function
    Private Enum ClientStatus
        Connected
        Disconnected
    End Enum
End Class
