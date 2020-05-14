Imports System.ComponentModel
Imports System.Net.Sockets
Imports System.IO
Imports System.Net
Imports System.Threading

Public Class TCPClientController
    Private _TCPClient As TcpClient
    Private _username As String

    Event MessageReceived(message As String)
    Event ConnectedUsers(users As List(Of String))
    Event ServerStopped()
    Private connectResp As ConnectResponse = ConnectResponse.None

    Private ComunicatieThread As Thread

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

    Public Sub stopServer()
        TCPClient = Nothing
    End Sub

    Enum ConnectResponse
        None = -1
        NoUsername = 0
        DuplicateUsername = 1
        CorrectUsername = 2
        ServerUnavailable = 3
    End Enum
    Public Function Connect(IpAdress As String, username As String) As ConnectResponse
        Try
            connectResp = ConnectResponse.None
            If username = "" Or username.Contains(",") Then
                Return ConnectResponse.NoUsername
            Else
                If TCPClient Is Nothing Then
                    TCPClient = New TcpClient(IpAdress, 64553)
                End If
                If Not TCPClient Is Nothing Then
                    'islistening = True
                    ComunicatieThread = New Thread(New ThreadStart(AddressOf Listening))
                    ComunicatieThread.Start()

                    'Luister naar antwoord server, als niet ok => DuplicateUsername
                    Write(username, COM_COMMAND.USERNAME)
                    While connectResp = ConnectResponse.None
                        Thread.Sleep(200)
                    End While
                    If Not connectResp = ConnectResponse.CorrectUsername Then
                        TCPClient = Nothing
                    End If
                    Return connectResp
                End If
            End If
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Return ConnectResponse.ServerUnavailable
        End Try
    End Function
#Region "COMMAND"
    Enum COM_COMMAND
        USERNAME
        NONE_USERNAME
        CORRECT_USERNAME
        DUPLICATE_USERNAME
        DISCONNECTED
        MESSAGE
        CONNECTED
        CONNECTEDUSERS
        STOPSERVER
    End Enum
    Private Function getCommand(message As String) As COM_COMMAND
        Dim IndexSlash As Integer = message.IndexOf("//", 2)
        Dim command As String = message.Substring(0, IndexSlash + 2)
        Return fromTextToComm(command)
    End Function
    Public Function getMessage(message As String) As String
        Dim IndexSlash As Integer = message.IndexOf("//", 2)
        message = message.Substring(IndexSlash + 2)
        Return message
    End Function

    Private Function fromCommToText(commEnum As COM_COMMAND) As String
        If commEnum = COM_COMMAND.DISCONNECTED Then
            Return "//DISC//"
        ElseIf commEnum = COM_COMMAND.USERNAME Then
            Return "//UN//"
        ElseIf commEnum = COM_COMMAND.MESSAGE Then
            Return "//MS//"
        ElseIf commEnum = COM_COMMAND.CONNECTED Then
            Return "//CONNECTED//"
        ElseIf commEnum = COM_COMMAND.STOPSERVER Then
            Return "//STOP//"
        ElseIf commEnum = COM_COMMAND.CORRECT_USERNAME Then
            Return "//CORUS//"
        ElseIf commEnum = COM_COMMAND.DUPLICATE_USERNAME Then
            Return "//DUP//"
        ElseIf commEnum = COM_COMMAND.NONE_USERNAME Then
            Return "//NONUS//"
        Else

            Throw New NotSupportedException()
        End If
    End Function
    Private Function fromTextToComm(commStr As String) As COM_COMMAND
        If commStr = "//DISC//" Then
            Return COM_COMMAND.DISCONNECTED
        ElseIf commStr = "//MS//" Then
            Return COM_COMMAND.MESSAGE
        ElseIf commStr = "//CONNECTED//" Then
            Return COM_COMMAND.CONNECTED
        ElseIf commStr = "//UN//" Then
            Return COM_COMMAND.USERNAME
        ElseIf commStr = "//DUP//" Then
            Return COM_COMMAND.DUPLICATE_USERNAME
        ElseIf commStr = "//USST//" Then
            Return COM_COMMAND.CONNECTEDUSERS
        ElseIf commStr = "//STOP//" Then
            Return COM_COMMAND.STOPSERVER
        ElseIf commStr = "//CORUS//" Then
            Return COM_COMMAND.CORRECT_USERNAME
        ElseIf commStr = "//NONUS//" Then
            Return COM_COMMAND.NONE_USERNAME
        Else

            Throw New NotSupportedException()
        End If
    End Function
    Public Sub Listening()
        Dim streamRdr As StreamReader
        Dim data As String = ""
        Do While True
            Try
                streamRdr = New StreamReader(TCPClientStream)
                data = streamRdr.ReadLine
                HandleMessageWithCommand(data)
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        Loop
    End Sub
#End Region
    Public Sub HandleMessageWithCommand(message As String)
        Dim command As COM_COMMAND = getCommand(message)
        message = getMessage(message)
        If command = COM_COMMAND.DISCONNECTED Then
            DisconnectUser()
            RaiseEvent MessageReceived("<< DISCONNECTED FROM SERVER >>")
        ElseIf command = COM_COMMAND.MESSAGE Then
            RaiseEvent MessageReceived(message)
        ElseIf command = COM_COMMAND.CONNECTED Then
            RaiseEvent MessageReceived("<< CONNECTED TO SERVER >>")
        ElseIf command = COM_COMMAND.CONNECTEDUSERS Then
            RaiseEvent ConnectedUsers(message.Split(",").ToList)
        ElseIf command = COM_COMMAND.STOPSERVER Then
            RaiseEvent ServerStopped()
        ElseIf command = COM_COMMAND.DUPLICATE_USERNAME Then
            connectResp = ConnectResponse.DuplicateUsername
        ElseIf command = COM_COMMAND.CORRECT_USERNAME Then
            connectResp = ConnectResponse.CorrectUsername
        ElseIf command = COM_COMMAND.NONE_USERNAME Then
            connectResp = ConnectResponse.None
        Else

            Throw New NotSupportedException
        End If
    End Sub
    Public Sub Write(Message As String, Command As COM_COMMAND)
        Dim strWrit As StreamWriter
        Try
            strWrit = New StreamWriter(TCPClientStream)
            strWrit.WriteLine(fromCommToText(Command) & Message)
            strWrit.Flush()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        'Public Sub Write(Message As String, Optional isUsername As Boolean = False, Optional IsDisconnect As Boolean = False)
        'Try
        '    If isUsername = True And IsDisconnect = False Then
        '        Message = fromCommToText(COM_COMMAND.USERNAME) & Message
        '    ElseIf isUsername = False And IsDisconnect = False Then
        '        Message = fromCommToText(COM_COMMAND.MESSAGE) & Message
        '    ElseIf isUsername = False And IsDisconnect = True Then
        '        Message = fromCommToText(COM_COMMAND.DISCONNECTED) & Message
        '    End If
        '    Dim strWrit As StreamWriter = New StreamWriter(TCPClientStream)
        '    strWrit.WriteLine(Message)
        '    strWrit.Flush()
        'Catch ex As Exception
        '    MessageBox.Show("Je bent niet meer verbonden")
        'End Try

    End Sub
    Public Sub DisconnectUser()
        Write("", COM_COMMAND.DISCONNECTED)
        TCPClient = Nothing
    End Sub
End Class