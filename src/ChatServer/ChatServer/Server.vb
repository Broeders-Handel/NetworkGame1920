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
    Dim usr As Users


    Private Sub ClientConnected(clientObject As Object)
        Dim client As TcpClient = CType(clientObject(0), TcpClient)
        Dim streamRdr As StreamReader
        Try
            streamRdr = New StreamReader(client.GetStream)
            Dim username As String = streamRdr.ReadLine
            username = username.Substring(6)
            UpdateText(ChatRichTextBox, username)
            Dim User As New Users(username, client)
            'voeg client toe aan dictionairy
            Do While UsersController.Users.ContainsKey(username)
                MessageBox.Show("Deze username is al in gebruik")
                username = InputBox("Geef een gebruikersnaam op.")
<<<<<<< HEAD
                If username = "" Then
                    MessageBox.Show("Geannuleerd")
                    Exit Sub
                Else
                    client = client
                End If
=======
                client = Nothing
>>>>>>> master
            Loop
            usr = UsersController.addUser(username, client)
            'meld alle gebruikers van nieuwe client
            sendMessageAsServer(username & " JOINED")
            'luister naar inkomende berichten
            AddHandler usr.MessageRecieved, AddressOf HandleMessageWithCommand
            usr.Listen()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
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

    Public Sub SendToOneClient(message As String, username As String, commando As COM_COMMAND)
        Dim usr As Users = UsersController.Users.Item(username)
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
    Public Sub SendToClients(message As String)
        For Each usr In UsersController.Users.Values
            usr.write(message, COM_COMMAND.MESSAGE)
        Next
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
        StartLocalButton.Enabled = False
    End Sub
    Private Sub StartLocalButton_Click(sender As Object, e As EventArgs) Handles StartLocalButton.Click
        TCPListener = New TcpListener(IPAddress.Loopback, 64553)
        TCPListener.Start()
        ChatRichTextBox.Text &= "<< SERVER OPEN >>" & Environment.NewLine
        ThreadConnectClient = New Thread(AddressOf ConnectClient)
        isBusy = True
        ThreadConnectClient.Start()
        StartButton.Enabled = False
    End Sub
    Private Sub StopButton_Click(sender As Object, e As EventArgs) Handles StopButton.Click
        StopServer = True
        ChatRichTextBox.Text &= "<< SERVER CLOSED >>" & Environment.NewLine
        SendToClients("De server is afgesloten. Kom later terug!")
        TCPListener.Stop()
        ThreadConnectClient.Abort()
        usr.stopListen()
        StartLocalButton.Enabled = True
        StartButton.Enabled = True
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

    'update listbox
    Private Sub UpdateClientList(ByVal Item As String)
        If ClientsListBox.InvokeRequired Then
            ClientsListBox.Invoke(New UpdateListBox(AddressOf UpdateClientList), Item)
        Else
            If Item IsNot Nothing Then
                ClientsListBox.Items.Add(Item)
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
        USERNAME
        DISCONNECTED
        MESSAGE
        CONNECTED
        CONNECTEDUSERS
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

    Public Shared Function fromCommToText(commEnum As COM_COMMAND) As String
        If commEnum = COM_COMMAND.DISCONNECTED Then
            Return "//DISC//"
        ElseIf commEnum = COM_COMMAND.USERNAME Then
            Return "//UN//"
        ElseIf commEnum = COM_COMMAND.MESSAGE Then
            Return "//MS//"
        ElseIf commEnum = COM_COMMAND.CONNECTEDUSERS Then
            Return "//USST//"
            'ElseIf commEnum = "//CONNECTED//" Then
            '    Return COM_COMMAND.CONNECTED
        End If
    End Function
    Public Shared Function fromTextToComm(commStr As String) As COM_COMMAND
        If commStr = "//DISC//" Then
            Return COM_COMMAND.DISCONNECTED
        ElseIf commStr = "//MS//" Then
            Return COM_COMMAND.MESSAGE
        ElseIf commStr = "//CONNECTED//" Then
            Return COM_COMMAND.CONNECTED
        ElseIf commStr = "//UN//" Then
            Return COM_COMMAND.USERNAME
        End If
    End Function
    Public Function HandleMessageWithCommand(username As String, message As String) As String
        Dim command As COM_COMMAND = getCommand(message)
        message = getMessage(message)
        If command = COM_COMMAND.DISCONNECTED Then
            HandleDisconnectedClient(username, message)
        ElseIf command = COM_COMMAND.MESSAGE Then
            HandleIncommingMessage(username, message)
            'ElseIf command = COM_COMMAND.CONNECTED Then
            '    Return username & " JOINED"
            'ElseIf command = COM_COMMAND.USERNAME Then
        End If
    End Function
#End Region
End Class
