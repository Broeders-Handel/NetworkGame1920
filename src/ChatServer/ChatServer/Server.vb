Imports System.Net.Sockets
Imports System.Net
Imports System.Threading.Thread
Imports System.IO
Imports System.Threading

Public Class Server

    Dim ThreadConnectClient As Thread
    Dim Islistening As Boolean
    Dim TCPListener As TcpListener
    Dim serverStatus As Boolean = False
    Dim StopServer As Boolean = False
    Dim UsersController As New UsersController
    Dim usernameString As String = ""
    Dim username As String
    Dim tcpClientStream As NetworkStream
    Dim isBusy As Boolean = False
    Dim cc As New TcpControllerServer


    Private Sub ClientConnected(clientObject As Object)
        Dim client As TcpClient = CType(clientObject(0), TcpClient)
        Dim streamRdr As StreamReader

        Try
            streamRdr = New StreamReader(client.GetStream)
            Dim username As String = streamRdr.ReadLine
            username = username.Substring(6)

            Dim usr As New User(username, client)
            'voeg client toe aan dictionairy

            If Not UsersController.addUser(usr) Then
                SendToOneClient("", usr, COM_COMMAND.DUPLICATE_USERNAME)
            Else
                SendToOneClient("", usr, COM_COMMAND.CORRECT_USERNAME)
                UpdateText(ChatRichTextBox, username)
                'meld alle gebruikers van nieuwe client
                userConnected(usr)
                'Voegt een User aan de lijst toe
                UpdateClientList(username)
                'luister naar inkomende berichten
                AddHandler usr.MessageRecieved, AddressOf HandleMessageWithCommand
                usr.Listen()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Server_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        StopButton.Enabled = False
        MessageTextBox.ReadOnly = True
        SendButton.Enabled = False
    End Sub
    Private Sub ConnectClient()
        Try
            Do Until StopServer = True
                Dim TCPClient As TcpClient
                TCPClient = TCPListener.AcceptTcpClient()
                Dim ThreadClientConnected As Thread = New Thread(AddressOf ClientConnected)
                Dim parameter = New Object() {TCPClient}
                ThreadClientConnected.Start(parameter)

            Loop
        Catch ex As SocketException
        End Try
    End Sub
    Public Sub SendToOneClient(message As String, usr As User, commando As COM_COMMAND)
        If usr Is Nothing Then
            '.....
        Else
            usr.write(message, commando)
        End If
        'For Each un As String In UsersController.Users.Keys
        '    If un = username Then
        'Next
        'For i As Integer = 0 To UsersController.Users.Count - 1
        '    If UsersController.Users(i).Username = username Then
        '        UsersController.Users(i).write(message)
        '    End If
        'Next
    End Sub
    Public Sub SendToOneClient(message As String, username As String, commando As COM_COMMAND)
        Dim usr As User = UsersController.Users.Item(username)
        SendToOneClient(message, usr, commando)

    End Sub

    Public Sub SendToClients(message As String, comm As COM_COMMAND)

        For Each usr In UsersController.Users.Values
            usr.write(message, comm)
        Next
    End Sub
    Public Sub SendToClients(message As String)
        SendToClients(message, COM_COMMAND.MESSAGE)
    End Sub
    Private Sub MessageTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles MessageTextBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If MessageTextBox.Text.Length > 0 Then
                sendMessageAsServer(MessageTextBox.Text)
                MessageTextBox.Clear()
            End If
        End If
    End Sub
    Private Sub SendButton_Click(sender As Object, e As EventArgs) Handles SendButton.Click
        sendMessageAsServer(MessageTextBox.Text)
    End Sub
    Private Sub userConnected(user As User)

        sendMessageAsServer(user.Username & " JOINED")
        Dim allUsers As String = UsersController.getUsers()
        SendToClients(allUsers, COM_COMMAND.CONNECTEDUSERS)
    End Sub
    Private Sub sendMessageAsServer(message As String)
        SendToClients("server => " & message)

    End Sub
#Region "Buttons"
    Private Sub StartButton_Click(sender As Object, e As EventArgs) Handles StartButton.Click
        Dim Ipadress As IPAddress
        StopServer = False
        serverStatus = True
        TCPListener = New TcpListener(IPAddress.Parse("127.0.0.1"), 64553)
        TCPListener.Start()
        ChatRichTextBox.Text &= "<< SERVER OPEN >>" & Environment.NewLine
        ThreadConnectClient = New Thread(AddressOf ConnectClient)
        isBusy = True
        ThreadConnectClient.Start()
        StopButton.Enabled = True
        StartButton.Enabled = False
        MessageTextBox.ReadOnly = False
        SendButton.Enabled = True
    End Sub

    Private Sub StopButton_Click(sender As Object, e As EventArgs) Handles StopButton.Click
        StopServer = True
        ChatRichTextBox.Text &= "<< SERVER CLOSED >>" & Environment.NewLine
        SendToClients("De server is afgesloten. Kom later terug!")
        StartButton.Enabled = True
        StopButton.Enabled = False
        TCPListener.Stop()
        ThreadConnectClient.Abort()


        For Each usr In UsersController.Users.Values
            UsersController.RemoveUser(usr)

        Next


        MessageTextBox.ReadOnly = True
        SendButton.Enabled = False
        StartButton.Enabled = True
        ClientsListBox.Items.Clear()
    End Sub
#End Region
#Region "Textbox"

    Private Delegate Sub UpdateTextDelegate(RTB As RichTextBox, txt As String)
    Private Delegate Sub UpdateListBox(ByVal Item As String)
    'Update textbox
    Private Sub UpdateText(RTB As RichTextBox, txt As String)
        If RTB.InvokeRequired Then
            RTB.Invoke(New UpdateTextDelegate(AddressOf UpdateText), New Object() {RTB, txt})

        Else
            If txt IsNot Nothing Then
                RTB.AppendText(txt & Environment.NewLine)
            End If
        End If
    End Sub

    'AddInListbox
    Private Sub UpdateClientList(ByVal Item As String)
        If ClientsListBox.InvokeRequired Then
            ClientsListBox.Invoke(New UpdateListBox(AddressOf UpdateClientList), Item)
        Else
            If Item IsNot Nothing Then
                ClientsListBox.Items.Add(Item)
            End If
        End If
    End Sub

    'RemoveInListbox
    Private Sub RemoveClientListItem(ByVal Item As String)
        If ClientsListBox.InvokeRequired Then
            ClientsListBox.Invoke(New UpdateListBox(AddressOf RemoveClientListItem), Item)
        Else
            If Item IsNot Nothing Then
                ClientsListBox.Items.Remove(Item)
            End If
        End If
    End Sub

#End Region

#Region "HANDLECOMMANDS"
    Private Function HandleDisconnectedClient(username As String, message As String)
        UsersController.RemoveUser(username)
        message = username & " DISCONNECTED"
        UpdateText(ChatRichTextBox, message)
        sendMessageAsServer(message)
    End Function
    Private Function HandleIncommingMessage(username As String, message As String)

        message = username & " : " & message
        UpdateText(ChatRichTextBox, message)
        SendToClients(message)
    End Function
    Private Function HandleStopServer()
        For Each usr In UsersController.Users.Values
            usr.write("", COM_COMMAND.STOPSERVER)
        Next
    End Function
    Private Function CheckPrivateChatroomPossible(user1 As String, user2 As String) As Boolean
        If UsersController.Users(user2).IsBusy = True Or user1 = user2 Then
            Return False
        Else
            Return True
        End If
    End Function
    Private Sub CreatPrivateChatRoom(user1 As String, user2 As String)
        If CheckPrivateChatroomPossible(user1, user2) = True Then
            UsersController.createPrivateChatroom(UsersController.Users(user1), UsersController.Users(user2))
        Else
            UsersController.Users(user1).write("", COM_COMMAND.PRIVATECHATROOMFAILED)
        End If
    End Sub
    Private Function getRoomID(username As String) As Integer
        Dim roomID As Integer = UsersController.Users(username).PrivateChatroomId
        Return roomID
    End Function
    Private Sub HandleIncommingPrivateMessage(username As String, message As String)
        message = username & " : " & message
        Dim roomID As Integer = getRoomID(username)
        Dim chatroom As PrivateChatroom = UsersController.PrivateChatRooms(roomID)
        chatroom.Chat(message, username)

    End Sub

    Private Sub HandleIncomingGameMessage(username As String, message As String)
        Dim roomID As Integer = getRoomID(username)
        Dim chatroom As PrivateChatroom = UsersController.PrivateChatrooms(roomID)
        Dim Rij As Integer
        Dim kolom As Integer
        Rij = message.Substring(0, 1)
        kolom = message.Substring(2, 1)
        chatroom.RecieveCoordinaat(Rij, kolom)
    End Sub


    'Public Sub IncomingMessage(username As String, data As String)
    '    Try
    '        If data Like "//DISC//*" Then
    '            UsersController.RemoveUser(username)
    '            Dim message As String = username & " DISCONNECTED"
    '            UpdateText(ChatRichTextBox, message)
    '            sendMessageAsServer(message)
    '        Else
    '            'pas eigen textbox aan
    '            Dim message As String = username & ": " & data.Substring(6)
    '            UpdateText(ChatRichTextBox, message)
    '            'stuur naar alle andere clients
    '            SendToClients(message)
    '        End If
    '    Catch ex As Exception
    ' Throw New Exception("bericht niet verzonden")
    '    End Try
    'End Sub
#End Region


    '###################### ADD COMMAND TYPE IF NECESSARY ###################### 
#Region "COMMAND"

    Enum COM_COMMAND
        REQUEST_USERNAME  'request username on first connection
        DUPLICATE_USERNAME 'Duplicate username 
        CORRECT_USERNAME  'Username valid and available
        NONE_USERNAME
        DISCONNECTED ' //DISC// 
        MESSAGE
        CONNECTED
        CONNECTEDUSERS
        STOPSERVER
        PRIVATEUSERNAMES
        PRIVATECHATROOMFAILED
        PRIVATEMESSAGES
        GAME
    End Enum
    Public Shared Function getCommand(message As String) As COM_COMMAND
        Dim IndexSlash As Integer = message.IndexOf("//", 2)
        Dim command As String = message.Substring(0, IndexSlash + 2)
        Return fromTextToComm(command)
    End Function
    Public Shared Function getMessage(message As String) As String
        Dim IndexSlash As Integer = message.IndexOf("//", 2)
        message = message.Substring(IndexSlash + 2)
        Return message
    End Function

    Public Shared Function fromCommToText(commEnum As COM_COMMAND) As String 'uitgaande
        If commEnum = COM_COMMAND.DISCONNECTED Then
            Return "//DISC//"
        ElseIf commEnum = COM_COMMAND.MESSAGE Then
            Return "//MS//"
        ElseIf commEnum = COM_COMMAND.CONNECTEDUSERS Then
            Return "//USST//"
        ElseIf commEnum = COM_COMMAND.DUPLICATE_USERNAME Then
            Return "//DUP//"
        ElseIf commEnum = COM_COMMAND.STOPSERVER Then
            Return "//STOP//"
        ElseIf commEnum = COM_COMMAND.CORRECT_USERNAME Then
            Return "//CORUS//"
        ElseIf commEnum = COM_COMMAND.NONE_USERNAME Then
            Return "//NONUS//"
        ElseIf commEnum = COM_COMMAND.PRIVATEUSERNAMES Then
            Return "//PUN//"
        ElseIf commEnum = COM_COMMAND.PRIVATEMESSAGES Then
            Return "//PMS//"
        ElseIf commEnum = COM_COMMAND.PRIVATECHATROOMFAILED Then
            Return "//PCHATF//"
        ElseIf commEnum = COM_COMMAND.GAME Then
            Return "//GAME//"
            'ElseIf commEnum = "//CONNECTED//" Then
            '    Return COM_COMMAND.CONNECTED
        Else
            Throw New NotSupportedException
        End If
    End Function
    Public Shared Function fromTextToComm(commStr As String) As COM_COMMAND 'inkomend
        If commStr = "//DISC//" Then
            Return COM_COMMAND.DISCONNECTED
        ElseIf commStr = "//MS//" Then
            Return COM_COMMAND.MESSAGE
        ElseIf commStr = "//CONNECTED//" Then
            Return COM_COMMAND.CONNECTED
        ElseIf commStr = "//UN//" Then
            Return COM_COMMAND.REQUEST_USERNAME
        ElseIf commStr = "//STOP//" Then
            Return COM_COMMAND.STOPSERVER
        ElseIf commStr = "//PUN//" Then
            Return COM_COMMAND.PRIVATEUSERNAMES
        ElseIf commStr = "//PMS//" Then
            Return COM_COMMAND.PRIVATEMESSAGES
        ElseIf commStr = COM_COMMAND.GAME Then
            Return commStr = "//GAME//"
        Else
            Throw New NotSupportedException
        End If
    End Function
    Public Function HandleMessageWithCommand(username As String, message As String) As String
        Console.WriteLine(username & "  " & message)
        Dim command As COM_COMMAND = getCommand(message)
        message = getMessage(message)
        If command = COM_COMMAND.DISCONNECTED Then
            HandleDisconnectedClient(username, message)
            RemoveClientListItem(username)
        ElseIf command = COM_COMMAND.MESSAGE Then
            HandleIncommingMessage(username, message)
        ElseIf command = COM_COMMAND.PRIVATEUSERNAMES Then
            CreatPrivateChatRoom(username, message)
        ElseIf command = COM_COMMAND.PRIVATEMESSAGES Then
            HandleIncommingPrivateMessage(username, message)
        ElseIf command = COM_COMMAND.STOPSERVER Then
            HandleStopServer()
        ElseIf command = COM_COMMAND.GAME Then
            HandleIncomingGameMessage(username, message)
        Else
            'ElseIf command = COM_COMMAND.USERNAME Then
            'ElseIf command = COM_COMMAND.CONNECTED Then
            '    Return username & " JOINED"
        End If
    End Function
#End Region
End Class
