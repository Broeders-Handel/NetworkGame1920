Imports System.ComponentModel
Imports System.Net.Sockets
Imports System.IO
Public Class TCPControllerClient
    Private _TCPClient As TcpClient
    Private _TCPClientStream As NetworkStream
    Private _username As String

    Public Property Username As String
        Get
            Return _username
        End Get
        Set(ByVal value As String)
            _username = value
        End Set
    End Property

    Public Property TCPClient() As TcpClient
        Get
            Return _TCPClient
        End Get
        Set(ByVal value As TcpClient)
            _TCPClient = value
        End Set
    End Property
    Public ReadOnly Property TCPClientStream() As NetworkStream
        Get
            Return TCPClient.GetStream()
        End Get

    End Property
    Public Sub Connect()
        Try
            TCPClient = New TcpClient("127.0.0.1", 64553)
            _TCPClientStream = TCPClient.GetStream()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Function NewLine() As String
        Return Environment.NewLine
    End Function
    Public Sub sendToServer(Message As String)

        If Message Like "//*" Then
            Throw New Exception("De // Command is niet toegelaten")
        Else
                Dim sendbytes() As Byte = System.Text.Encoding.ASCII.GetBytes(Message)
                TCPClient.Client.Send(sendbytes)
        End If
    End Sub
    Public Function ReceiveText() As String
        Dim Output As String = ""
        If _TCPClientStream.DataAvailable = True Then
            Dim rcvbytes(_TCPClient.ReceiveBufferSize) As Byte
            _TCPClientStream.Read(rcvbytes, 0, CInt(_TCPClient.ReceiveBufferSize))
            Output &= _username & " => " & System.Text.Encoding.ASCII.GetString(rcvbytes) & NewLine()
        End If

        Return Output
    End Function
    Private Enum ClientStatus
        Connected
        Disconnected
    End Enum
End Class
