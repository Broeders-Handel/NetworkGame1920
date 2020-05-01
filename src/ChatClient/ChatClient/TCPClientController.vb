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
    Public Sub DisconnectUser()
        Write("", False, True)
        TCPClient = New TcpClient
    End Sub

    Enum ConnectResponse
        NoUsername
        DuplicateUsername
        CorrectUsername
    End Enum
    Public Function Connect(IpAdress As String) As ConnectResponse
        Try
            If Username = "" Then
                Return ConnectResponse.NoUsername
            Else
                TCPClient = New TcpClient(IpAdress, 64553)
                'Luister naar antwoord server, als niet ok => DuplicateUsername
                Write(Username, True)

                Return ConnectResponse.CorrectUsername
            End If
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Return False
        End Try
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
End Class

