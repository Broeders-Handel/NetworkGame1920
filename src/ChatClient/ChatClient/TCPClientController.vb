Imports System.ComponentModel
Imports System.Net.Sockets
Imports System.IO
Imports System.Net

Public Class TCPClientController
    Private _TCPClient As TcpClient
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
    Public Function Connect(IpAdress As String) As Boolean
        Try
            If Username = "" Then
                Return False
            Else
                TCPClient = New TcpClient(IpAdress, 64553)
                Write(Username, True)
                Return True
            End If
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Return False
        End Try
    End Function
    Public Enum COM_COMMAND
        DISCONNECT
        CONNECT
        MESSAGE
        USERNAME
    End Enum
    Private Function getCommand(message As String)
        Dim IndexSlash As Integer = message.IndexOf("//", 2)
        Dim command As String = message.Substring(0, IndexSlash + 2)
        Return command
    End Function

    Public Function HandleMessageWithCommand(message As String) As String
        Dim command As String = getCommand(message)
        If command = "//DISC//" Then
            DisconnectUser()
            Return "<< DISCONNECTED FROM SERVER >>"
        ElseIf command = "//MS//" Then
            Return message
        ElseIf command = "//CONNECTED//" Then
            Return "<< CONNECTED TO SERVER >>"
        End If
    End Function
    Public Sub Write(Message As String, Optional isUsername As Boolean = False, Optional IsDisconnect As Boolean = False)
        Try
            If isUsername = True And IsDisconnect = False Then
                Message = "//UN//" & Message
            ElseIf isUsername = False And IsDisconnect = False Then
                Message = "//MS//" & Message
            ElseIf isUsername = False And IsDisconnect = True Then
                Message = "//DISC//" & Message
            End If
            Dim strWrit As StreamWriter = New StreamWriter(TCPClientStream)
            strWrit.WriteLine(Message)
            strWrit.Flush()
        Catch ex As Exception
            MessageBox.Show("Je bent niet meer verbonden")
        End Try
    End Sub
    Public Sub DisconnectUser()
        Write("", False, True)
        TCPClient = New TcpClient
    End Sub
End Class

