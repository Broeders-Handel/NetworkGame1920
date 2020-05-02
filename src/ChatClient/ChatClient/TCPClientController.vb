Imports System.ComponentModel
Imports System.Net.Sockets
Imports System.IO
Imports System.Net

Public Class TCPClientController
    Private _TCPClient As TcpClient
    Private _username As String

    Event MessageReceived(message As String)
    Event ConnectedUsers(users As List(Of String))

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
        TCPClient = New TcpClient
    End Sub
    Public Function Connect(IpAdress As String) As Boolean
        Try
            If Username = "" Then
                Return False
            Else
                TCPClient = New TcpClient(IpAdress, 64553)
                Write(Username, True, False)
                Return True
            End If
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Return False
        End Try
    End Function
#Region "COMMAND"
    Enum COM_COMMAND
        USERNAME
        DISCONNECTED
        MESSAGE
        CONNECTED
        CONNECTEDUSERS
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
        'Do While islistening
        '    Try
        '        streamRdr = New StreamReader(clienController.TCPClientStream)
        '        data = streamRdr.ReadLine
        '        If data Like "server => " & Username & " JOINED" Then
        '            UpdateText(ChatRichTextBox, "<< CONNECTED TO SERVER >>")
        '        End If
        '        UpdateText(ChatRichTextBox, data)
        '    Catch ex As Exception
        '        Console.WriteLine(ex.Message)
        '    End Try
        '    Thread.Sleep(100)
        'Loop
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
            RaiseEvent ConnectedUsers(message.Split(",").ToList)
        ElseIf command = COM_COMMAND.CONNECTED Then
            RaiseEvent MessageReceived("<< CONNECTED TO SERVER >>")
        ElseIf command = COM_COMMAND.CONNECTEDUSERS Then
            RaiseEvent ConnectedUsers(message.Split(",").ToList)
        Else
            Throw New NotSupportedException
        End If
    End Sub
    Public Sub Write(Message As String, Optional isUsername As Boolean = False, Optional IsDisconnect As Boolean = False)
        Try
            If isUsername = True And IsDisconnect = False Then
                Message = fromCommToText(COM_COMMAND.USERNAME) & Message
            ElseIf isUsername = False And IsDisconnect = False Then
                Message = fromCommToText(COM_COMMAND.MESSAGE) & Message
            ElseIf isUsername = False And IsDisconnect = True Then
                Message = fromCommToText(COM_COMMAND.DISCONNECTED) & Message
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